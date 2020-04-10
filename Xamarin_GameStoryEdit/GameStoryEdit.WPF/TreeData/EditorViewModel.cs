using GameStoryEdit.WPF.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xamarin_GameStoryEdit.Interface;
using Xamarin_GameStoryEdit.Models.TreeData;
using Xceed.Wpf.AvalonDock.Layout;

namespace GameStoryEdit.WPF.TreeData
{
    public class EditorViewModel : IScreenPlay
    {
        private ScreenPlay _ScreenPlay;
        public ScreenPlay ScreenPlay
        {
            get => _ScreenPlay;
            set
            {
                _ScreenPlay = value;
                if (_fountainEditor != null)
                {
                    _fountainEditor.Name = _ScreenPlay.Name;
                    if (Directory.Exists(_ScreenPlay.Path))
                    {
                        _ScreenPlay.Extension = new DirectoryInfo(_ScreenPlay.Path).GetFiles().First(file => file.Name.Contains(_ScreenPlay.Name)).Extension;
                        _fountainEditor.textEditor.Text = GetText();
                    }
                    LayoutDocument = new LayoutDocument() { Content = _fountainEditor, ContentId = "FountainEditor", Title = _ScreenPlay.Name };
                }
            }
        }

        private FountainEditor _fountainEditor;
        public FountainEditor FountainEditor
        {
            get => _fountainEditor;
            set
            {
                _fountainEditor = value;
                if (ScreenPlay != null)
                {
                    _fountainEditor.Name = ScreenPlay.Name;
                    if (Directory.Exists(ScreenPlay.Path))
                    {
                        ScreenPlay.Extension = new DirectoryInfo(ScreenPlay.Path).GetFiles().First(file => file.Name.Contains(ScreenPlay.Name)).Extension;
                        _fountainEditor.textEditor.Text = GetText();
                    }
                    LayoutDocument = new LayoutDocument() { Content = _fountainEditor, ContentId = "FountainEditor", Title = ScreenPlay.Name };
                }
            }
        }
        public LayoutDocument LayoutDocument { get; private set; }
        public string GetText()
        {
            using StreamReader sr = new StreamReader(ScreenPlay.FullName);
            string _line;
            StringBuilder line = new StringBuilder();
            while ((_line = sr.ReadLine()) != null)
            {
                line.AppendLine(_line);
            }
            return line.ToString();
        }
        public void SaveText()
        {
            if (!Directory.Exists(ScreenPlay.Path)) Directory.CreateDirectory(ScreenPlay.Path);
            File.WriteAllText(ScreenPlay.FullName, FountainEditor.textEditor.Text);
        }

        public EditorViewModel()
        {
            FountainEditor = new FountainEditor();
        }
    }
}
