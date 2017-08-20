using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K2.Testing.Automated.Framework;
using OpenQA.Selenium;

namespace K2.Testing.Automated.Framework.Controls
{
    public class K2Picker : ISingleValue
    {
        ISearchContext container;
        int index = 0;
        public K2Picker(ISearchContext container): this(container, 0)
        {

        }

        public K2Picker(ISearchContext container, int index)
        {
            this.container = container;
            this.index = index;
        }

        public void SetValue(string text)
        {
            container.FindElements(By.CssSelector("div.picker-input"))[index].FindElement(By.CssSelector("div.input-control[role='textbox'] + div.input-control-watermark")).Click();
            container.FindElements(By.CssSelector("div.picker-input"))[index].FindElement(By.CssSelector("div.input-control[role='textbox']")).SendKeys($"{text}\n");
        }
    }
}
