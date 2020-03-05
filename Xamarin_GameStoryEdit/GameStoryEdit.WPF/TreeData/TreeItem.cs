using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoryEdit.WPF.TreeData
{
    public static class TreeItem
    {
        public static Solution Solution = new Solution();
        public static SolutionViewModel GetSolutionTree() => new SolutionViewModel(Solution);
    }
}
