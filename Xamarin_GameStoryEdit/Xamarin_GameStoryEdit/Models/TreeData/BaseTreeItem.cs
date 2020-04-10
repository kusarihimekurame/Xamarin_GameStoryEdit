﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Xamarin_GameStoryEdit.Models.TreeData
{
    public class BaseTreeItem
    {
        public virtual string Name { get; set; }
        public virtual string Path { get; set; }
        public virtual ChildrenCollection Children { get; } = new ChildrenCollection();
    }
}
