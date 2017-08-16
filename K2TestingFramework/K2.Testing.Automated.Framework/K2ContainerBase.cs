using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2.Testing.Automated.Framework
{
    public abstract class K2ContainerBase<T> where T: IK2Container
    {
        internal IWebDriver webDriver;
        internal ISearchContext parent;
        internal string cssLocator;

        protected K2ContainerBase(IWebDriver driver, string cssLocator, ISearchContext parent)
        {
            this.webDriver = driver;
            this.cssLocator = cssLocator;
            this.parent = parent;
        }

        public IWebElement FindElement(By by)
        {
            return parent.FindElement(By.CssSelector(cssLocator)).FindElement(by);
        }
        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return parent.FindElement(By.CssSelector(cssLocator)).FindElements(by);
        }

        public IWebDriver WebDriver
        {
            get
            {
                return webDriver;
            }
        }

        public ISearchContext Parent
        {
            get
            {
                return parent;
            }
        }
        public bool Hidden
        {
            get
            {
                return !Parent.FindElement(By.CssSelector(cssLocator)).Displayed;
            }
        }
        public bool Enabled
        {
            get
            {
                return Parent.FindElement(By.CssSelector(cssLocator)).Enabled;
            }
        }
    }
}
