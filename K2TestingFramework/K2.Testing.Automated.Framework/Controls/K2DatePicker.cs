using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K2.Testing.Automated.Framework;
using OpenQA.Selenium;

namespace K2.Testing.Automated.Framework.Controls
{
    public class K2DatePicker : ISingleValue
    {
        ISearchContext container;
        int index = 0;
        public K2DatePicker(ISearchContext container): this(container, 0)
        {

        }

        public K2DatePicker(ISearchContext container, int index)
        {
            this.container = container;
            this.index = index;
        }

        public void SetValue(string text)
        {
            //container.FindElements(By.CssSelector("div.datepicker"))[index].FindElement(By.CssSelector("input.input-control[type='text'] + div.input-control-watermark")).Click();
            container.FindElements(By.CssSelector("div.datepicker"))[index].FindElement(By.CssSelector("input.input-control[type='text']")).GetParent().Click();
            container.FindElements(By.CssSelector("div.datepicker "))[index].FindElement(By.CssSelector("input.input-control[type='text']")).SendKeys($"{text}\t");
        }
    }
}
