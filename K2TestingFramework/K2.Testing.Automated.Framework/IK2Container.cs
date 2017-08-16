using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2.Testing.Automated.Framework
{
    public interface IK2Container: ISearchContext
    {
        IWebDriver WebDriver { get; }
        ISearchContext Parent { get; }
        bool Enabled { get; }
        bool Hidden { get; }
    }
}
