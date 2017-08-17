using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using K2.AtonMartin.RLE.Testing.POM;
using K2.AtonMartin.RLE.Testing.POM.Forms;

namespace ZzzzTest01
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new InternetExplorerDriver();
            driver.Manage().Window.Maximize();

            //driver.Navigate().GoToUrl("https://k2.denallix.com/Runtime/Runtime/Form/ERE__Dashboard__Form/");
            //System.Threading.Thread.Sleep(4000);

            //ERE_Dashboard_Form form = new ERE_Dashboard_Form(driver);

            //System.Console.WriteLine(form.Header.Hidden);
            //System.Console.WriteLine(form.Header.Collapsed);

            //System.Console.WriteLine(form.Buttons.Hidden);
            //System.Console.WriteLine(form.Buttons.Collapsed);

            //System.Console.WriteLine(form.SearchFilter.Hidden);
            //System.Console.WriteLine(form.SearchFilter.Collapsed);

            //System.Console.WriteLine(form.WorklistAll.Hidden);
            //System.Console.WriteLine(form.WorklistAll.Collapsed);

            //System.Console.WriteLine(form.WorklistUser.Hidden);
            //System.Console.WriteLine(form.WorklistUser.Collapsed);

            //System.Console.WriteLine(form.SearchFilter.LayoutTable.GetCell(5, 1).Text);

            driver.Navigate().GoToUrl("https://k2.denallix.com/Runtime/Runtime/Form/ERE__Administration__Form/");
            //System.Threading.Thread.Sleep(4000);

            ERE_Administration_Form administrationForm = new ERE_Administration_Form(driver);
            System.Threading.Thread.Sleep(4000);
            administrationForm.UserManagement.Click();
            System.Threading.Thread.Sleep(4000);
            administrationForm.GroupMemberList.AddButton.Click();
            driver.Close();
            driver.Dispose();
        }
    }
}
