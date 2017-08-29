using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K2.Testing.Automated.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using K2.Testing.Automated.Framework.Utils;

namespace K2.Testing.Automated.Framework.Controls
{
    public class K2TextBox: ISingleValue
    {
        ISearchContext container;
        string name;

        public K2TextBox(ISearchContext container, string name)
        {
            this.container = container;
            this.name = name;
        }

        public void SetValue(string text)
        {
            container.FindElement(By.CssSelector($"input[name='{name}']")).SendKeys(text);
        }
    }
}
