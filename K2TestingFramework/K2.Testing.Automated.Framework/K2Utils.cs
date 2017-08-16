using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2.Testing.Automated.Framework
{
    internal static class K2Utils
    {
        public static bool HasClass(IWebElement webElement, string className)
        {
            bool ret = false;
            string attrv = webElement.GetAttribute("class");
            if (!string.IsNullOrEmpty(attrv))
            {
                ret = attrv.Split(' ').Any(x => x.Equals(className, StringComparison.CurrentCultureIgnoreCase));
            }
            return ret;
        }

        public static IWebElement GetParent(this IWebElement e)
        {
            return e.FindElement(By.XPath(".."));
        }
    }
}
