using K2.AtonMartin.RLE.Testing.POM.Views;
using K2.Testing.Automated.Framework;
using K2.Testing.Automated.Framework.Controls;
using K2.Testing.Automated.Framework.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2.AtonMartin.RLE.Testing.POM.Forms
{

    public class ERE_Submission_Form : K2FormBase
    {
        #region Views/Panels
        public readonly ERE_ReleaseHeaderInformation_Item ReleaseHeaderInformation;
        public readonly ERE_ReleaseDescription_Item ReleaseDescription;
        public readonly ERE_BuyersSuppliers_Item BuyersAndSuppliers;
        #endregion

        #region Tabs
        public readonly K2Tab Release;
        public readonly K2Tab Auditing;
        public readonly K2Tab CostSummary;
        public readonly K2Tab CostPart;
        public readonly K2Tab CostTooling;
        public readonly K2Tab CostSheetC;
        #endregion

        public ERE_Submission_Form(IWebDriver driver) : base(driver)
        {
            #region Initialize Tabs
            this.Release = new K2Tab(this, "Release");
            this.Tabs.Add(Release);

            this.Auditing = new K2Tab(this, "Auditing");
            this.Tabs.Add(Auditing);

            this.CostSummary = new K2Tab(this, "Cost Summary");
            this.Tabs.Add(CostSummary);

            this.CostPart = new K2Tab(this, "Cost - Part");
            this.Tabs.Add(CostPart);

            this.CostTooling = new K2Tab(this, "Cost - Tooling");
            this.Tabs.Add(CostTooling);

            this.CostSheetC = new K2Tab(this, "Cost - Sheet C");
            this.Tabs.Add(CostSheetC);


            #endregion

            #region Initialize Views/Panels
            this.ReleaseHeaderInformation = new ERE_ReleaseHeaderInformation_Item(this, "ERE_Submission_Form Area Item1");
            this.ReleaseDescription = new ERE_ReleaseDescription_Item(this, "ERE_Submission_Form Area Item2");
            this.BuyersAndSuppliers = new ERE_BuyersSuppliers_Item(this, "ERE_Submission_Form Area Item3");
            #endregion
        }

        public void SelectReleaseType(string releasetype)
        {
            if (!string.IsNullOrEmpty(releasetype))
            {
                IWebElement iframe = WebDriver.FindElement(By.CssSelector("iframe.runtime-popup"));
                this.WebDriver.SwitchTo().Frame(iframe);
                this.WebDriver.FindElement(By.CssSelector($"label[title='{releasetype}']")).FindElement(By.CssSelector($"span.input-control-img")).Click();
                Helpers.WaitUntilDataLoads();
                var button = new K2Button(this.WebDriver, "Button Create New Release change");
                button.Click();
                this.WebDriver.SwitchTo().DefaultContent();
            }
        }
    }
}
