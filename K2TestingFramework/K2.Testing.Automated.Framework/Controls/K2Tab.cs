﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2.Testing.Automated.Framework.Controls
{
    public class K2Tab : IClickable
    {
        public readonly string Name;
        private IK2Form form;

        private string cssSelector
        {
            get
            {
                //return $"//div[@class='tab-box']/ul[@class='tab-box-tabs']/li/a[@class='tab']/spancontains(text(), '{name}')]";
                //return $"//div[@class='tab-box']/ul[@class='tab-box-tabs']/li/a[@class='tab']//span[.='{name}']";
                return $"div.tab-box > ul.tab-box-tabs > li > a.tab span.tab-text";
                //return $"a:contains('{name}')";
            }
        }

        public K2Tab(IK2Form form, string name)
        {
            this.form = form;
            this.Name = name;
        }
        public void Click()
        {
            //object xxx = form.FindElements(By.XPath(xpathSelector));
            var tabs = form.WebDriver.FindElements(By.CssSelector(cssSelector));
            var tab = tabs.Single(x => x.Text.Equals(Name));
            var a = tab.GetParent().GetParent();
            a.Click();
        }

        public void DoubleClick()
        {
            throw new NotImplementedException();
        }
    }
}
