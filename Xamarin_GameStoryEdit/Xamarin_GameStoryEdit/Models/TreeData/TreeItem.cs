using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin_GameStoryEdit.ViewModels.TreeData;

namespace Xamarin_GameStoryEdit.Models.TreeData
{
    public static class TreeItem
    {
        public static Solution Solution = new Solution();
        public static SolutionViewModel GetSolutionTree() => new SolutionViewModel(Solution);
    }
}
