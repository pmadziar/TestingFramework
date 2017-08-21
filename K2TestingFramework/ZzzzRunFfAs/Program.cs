using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using K2.Testing.Automated.Framework.Utils;

namespace ZzzzRunFfAs
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = @"DENALLIX\Johnny";


            string domain = "DENALLIX";
            string password = "K2pass!";
            string formurl = "https://k2.denallix.com/Runtime/Runtime/Form/ERE__Dashboard__Form/";

            var cookie = FedAuthHelper.GetCookie(username, password, domain, formurl);

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--incognito");
            options.AddArguments("--start-maximized");

            IWebDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(formurl);
            driver.Manage().Cookies.AddCookie(new OpenQA.Selenium.Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Expires));

            driver.Navigate().GoToUrl(formurl);

        }
    }
}
