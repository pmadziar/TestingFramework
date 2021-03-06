﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2.Testing.Automated.Framework
{
    public class K2ItemViewBase: K2ContainerBase<IK2ItemView>, IK2ItemView
    {
        private static string getViewByName(IK2Form form, string name)
        {
            string cssSelector = $"div.innerpanel > div.panel[name='{name}']";
            return cssSelector;
        }


        public K2ItemViewBase(IK2Form form, string name): base(((K2FormBase)form).webDriver, getViewByName(form, name), form)
        {
            this.LayoutTable = new K2LayoutTable(this);
        }

        public K2LayoutTable LayoutTable { get; private set; }

        public bool Collapsed
        {
            get
            {
                //return K2Utils.HasClass(rootWebElement, "collapsed");
                return !this.FindElement(By.CssSelector("div.panel-body")).Displayed;
            }
        }
    }
}
