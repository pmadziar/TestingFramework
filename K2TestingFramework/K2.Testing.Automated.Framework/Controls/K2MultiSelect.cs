using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace K2.Testing.Automated.Framework.Controls
{
    public class K2MultiSelect : IMultipleValues
    {
        readonly ISearchContext container;
        readonly string name;
        readonly IWebDriver driver;
        public K2MultiSelect(IK2Form form, ISearchContext container, string name)
        {
            this.driver = form.WebDriver;
            this.container = container;
            this.name = name;
        }
        public void SetValue(string text)
        {
            this.SetValues(new List<string> { text });
        }

        public void SetValues(List<string> values)
        {
            if (values?.Count > 0)
            {
                ISearchContext topWrapper = container.FindElement(By.CssSelector($"div.SourceCode-Forms-Controls-Web-ControlPack-MultiChoice[name='{name}']"));
                ISearchContext sourceWrapper = topWrapper.FindElement(By.CssSelector("div.selectSourceWrapper"));
                foreach(var val in values)
                {
                    var elements = sourceWrapper.FindElements(By.XPath("//div[@data-value]"));
                    IWebElement el = sourceWrapper.FindElements(By.XPath("//div[@data-value]")).Single(x => val.Equals(x.Text, StringComparison.CurrentCultureIgnoreCase));
                    (new Actions(driver)).MoveToElement(el,5,5).Click().DoubleClick().Perform();
                }
            }
        }
    }
}
