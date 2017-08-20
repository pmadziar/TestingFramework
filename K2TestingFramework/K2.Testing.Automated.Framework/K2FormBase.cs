using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K2.Testing.Automated.Framework.Controls;

namespace K2.Testing.Automated.Framework
{
    public abstract class K2FormBase: K2ContainerBase<IK2Form>, IK2Form
    {
        public K2FormBase(IWebDriver driver): base(driver, "body", driver)
        {
            this.Tabs = new List<K2Tab>();
        }

        public List<K2Tab> Tabs { get; private set; }
    }
}
