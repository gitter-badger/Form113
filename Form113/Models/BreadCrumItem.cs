using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Form113.Models
{
    public class BreadCrumItem
    {
        public string Control;
        public string Name;
        public string Action;

        public BreadCrumItem(string name, string action, string control)
        {
            Name = name;
            Action = action;
            Control = control;
        }
    }
}