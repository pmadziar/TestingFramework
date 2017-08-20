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
    public class K2DropDown : ISingleValue
    {
        IK2Form form;
        ISearchContext container;
        int index = 0;
        public K2DropDown(IK2Form form, ISearchContext container): this(form, container, 0)
        {

        }

        public K2DropDown(IK2Form form, ISearchContext container, int index)
        {
            this.form = form;
            this.container = container;
            this.index = index;
        }
        public void SetValue(string text)
        {
            var inputControlDiv = container.FindElements(By.CssSelector("div.dropdown-box"))[index];
            var inputControlDivId = inputControlDiv.GetAttribute("id");

            var ddButton = inputControlDiv.FindElement(By.CssSelector("div.input-control-buttons > a"));
            ddButton.Click();
            Helpers.WaitUntilDataLoads(2);
            var ulId = $"{inputControlDivId}_droplist";
            var ul = form.FindElement(By.Id(ulId));
            ul.FindElements(By.TagName($"li")).ToList().ForEach(x => System.Diagnostics.Debug.WriteLine($"|{x.Text}|", "Selenium Tests"));
            var li = ul.FindElements(By.TagName($"li")).Single(x => x.Text.Trim().Replace('_', ' ') == text);
            li.FindElement(By.TagName("a")).Click();
        }


    }
}
