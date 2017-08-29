using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K2.Testing.Automated.Framework;
using OpenQA.Selenium;

namespace K2.Testing.Automated.Framework.Controls
{
    public class K2RadioButtonList : ISingleValue
    {
        ISearchContext container;
        int index;
        public K2RadioButtonList(ISearchContext container, int index)
        {
            this.container = container;
            this.index = index;
        }

        public K2RadioButtonList(ISearchContext container): this(container, 0)
        {
        }
        public void SetValue(string text)
        {
            ISearchContext div = container.FindElements(By.CssSelector("div.multi-select-outer-panel"))[index];
            div.FindElement(By.CssSelector($"label.radio[title='{text}'] > span.input-control-img")).Click();
        }
    }
}
