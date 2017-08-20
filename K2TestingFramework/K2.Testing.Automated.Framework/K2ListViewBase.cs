using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K2.Testing.Automated.Framework.Utils;

namespace K2.Testing.Automated.Framework
{
    public class K2ListViewBase : K2ContainerBase<IK2ListView>, IK2ListView
    {
        private static string getViewByName(IK2Form form, string name)
        {
            string cssSelector = $"div.innerpanel > div.grid[name='{name}']";
            return cssSelector;
        }

        public K2ListViewBase(IK2Form form, string name) : base(((K2FormBase)form).webDriver, getViewByName(form, name), form)
        {
        }

        public bool Collapsed
        {
            get
            {
                return !this.FindElement(By.CssSelector("div.grid-body")).Displayed;
            }
        }

        protected IWebElement getToolBarButtonByName(string name)
        {
            Helpers.WaitUntilDataLoads(3);
            return this.FindElements(By.CssSelector("div.grid-toolbars a.toolbar-button")).Single(x => x.Text.Trim().Equals(name));
        }

        protected IWebElement getRowAddNew()
        {
            Helpers.WaitUntilDataLoads();
            return this.FindElement(By.CssSelector("div.grid-body > div.grid-body-content table.grid-content-table > tbody > tr.edit-template-row"));
        }
    }

}
