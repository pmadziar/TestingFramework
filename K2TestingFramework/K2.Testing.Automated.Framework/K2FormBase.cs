using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2.Testing.Automated.Framework
{
    public abstract class K2FormBase: K2ContainerBase<IK2Form>, IK2Form
    {
        public K2FormBase(IWebDriver driver): base(driver, "body", driver)
        {
        }
    }
}
