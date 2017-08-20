using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K2.Utils;
using System.Net;
using System.IO;
using System.Xml;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace ZzzConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string domain = "DENALLIX";
            string username = "Jonno"; 
            string password="K2pass!";
            string formurl = "https://k2.denallix.com/Runtime/Runtime/Form/ERE__Dashboard__Form/";

            var cookie = FedAuthHelper.GetCookie(username, password, domain, formurl);

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--incognito");
            IWebDriver driver = new ChromeDriver(options);
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().GoToUrl(formurl);
            driver.Manage().Cookies.AddCookie(new OpenQA.Selenium.Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Expires));
            var cookies = driver.Manage().Cookies.AllCookies;
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(formurl);
            driver.Close();
            driver.Dispose();

        }

    }

}
