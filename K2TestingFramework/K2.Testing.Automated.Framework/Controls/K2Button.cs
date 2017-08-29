using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2.Testing.Automated.Framework.Controls
{
    public class K2Button : IClickable
    {
        ISearchContext container;
        string name;

        public K2Button(ISearchContext container, string name)
        {
            this.container = container;
            this.name = name;
        }
        public void Click()
        {
            container.FindElement(By.CssSelector($"a[name='{name}']")).Click();
        }

        public void DoubleClick()
        {
            throw new NotImplementedException();
        }
    }
}
