using System;
using System.Collections.Generic;
using System.Text;
using Xamarin_GameStoryEdit.Models.TreeData;

namespace Xamarin_GameStoryEdit.Interface
{
    public interface IScreenPlay
    {
        ScreenPlay ScreenPlay { get; set; }
        void SaveText();
    }
}
