using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xamarin_GameStoryEdit.Interface;

namespace Xamarin_GameStoryEdit.Models.TreeData
{
    public class ScreenPlay : BaseTreeItem
    {
        public string Extension { get; set; } = ".fountain";
        public string FileName => Name + Extension;
        public string FullName => Path + @"\" + Name + Extension;
        private IScreenPlay _Editor;
        public IScreenPlay Editor
        {
            get => _Editor;
            set
            {
                _Editor = value;
                _Editor.ScreenPlay = this;
            }
        }

        public string GetText()
        {
            using (StreamReader sr = new StreamReader(FullName))
            {
                string _line;
                StringBuilder line = new StringBuilder();
                while ((_line = sr.ReadLine()) != null)
                {
                    line.AppendLine(_line);
                }
                return line.ToString();
            }
        }
        public void SaveText() => Editor.SaveText();
    }
}
