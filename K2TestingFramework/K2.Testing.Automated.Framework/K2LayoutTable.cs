using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2.Testing.Automated.Framework
{
    public class K2LayoutTable: K2ContainerBase<IK2LayoutTable>, IK2LayoutTable
    {
        private static string getCssSelector(IK2Container container)
        {
            string ret = string.Empty;
            if(container is IK2ItemView)
            {
                ret = "div.panel-body-wrapper > div > table";
            }
            else
            {
                throw new NotImplementedException("The Layout Table is not implemented for this type of container");
            }
            return ret;
        }
        public K2LayoutTable(IK2Container container) : base(container.WebDriver, getCssSelector(container), container)
        {
        }

        public IWebElement GetRow(int rowNo)
        {
            return this.FindElement(By.CssSelector($"tbody > tr:nth-child({rowNo})"));
        }

        public IWebElement GetCell(int rowNo, int colNo)
        {
            return this.FindElement(By.CssSelector($"tbody > tr:nth-child({rowNo}) > td:nth-child({colNo})"));
        }

    }
}
