using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2.Testing.Automated.Framework.Controls
{
    public class K2RichText : ISingleValue
    {
        ISearchContext container;
        IWebDriver driver;
        int index;
        public K2RichText(IK2Form form, ISearchContext container, int index)
        {
            this.container = container;
            this.index = index;
            this.driver = form.WebDriver;
        }

        public K2RichText(IK2Form form, ISearchContext container): this(form, container, 0)
        {

        }

        public void SetValue(string text)
        {
            ISearchContext wrapper = container.FindElements(By.CssSelector("div.SourceCode-Forms-Controls-Web-ControlPack-HTMLEditor"))[index];
            wrapper.FindElement(By.CssSelector("div.reContentArea")).Click();
            (new Actions(driver)).SendKeys(text).Perform();
        }
    }
}
