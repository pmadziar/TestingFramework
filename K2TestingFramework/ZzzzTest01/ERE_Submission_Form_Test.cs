using K2.AtonMartin.RLE.Testing.POM.Forms;
using K2.Testing.Automated.Framework.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZzzzTest01
{
    public static class ERE_Submission_Form_Test
    {
        public static void test(IWebDriver driver)
        {
            string formUrl = "https://k2.denallix.com/Runtime/Runtime/Form/ERE__Submission__Form/";

            driver.Navigate().GoToUrl(formUrl);

            Helpers.WaitUntilDataLoads();

            ERE_Submission_Form form = new ERE_Submission_Form(driver);
            Helpers.WaitUntilDataLoads(6);
            form.SelectReleaseType("Production Part Release - Post PR");
            Helpers.WaitUntilDataLoads(3);
            form.ReleaseHeaderInformation.ReleaseTitle = "This is a test of release title 02";
            form.ReleaseHeaderInformation.LeadProgramme = "VH118";
            form.ReleaseHeaderInformation.FirstUseProgramme = "VH118";
            form.ReleaseHeaderInformation.BuildPhase = "X1";
            form.ReleaseHeaderInformation.PmtArea = "After Sales";
            form.ReleaseHeaderInformation.PmtLeader = "Chris Geier";
            form.ReleaseHeaderInformation.Urgent = "Yes";
            form.ReleaseHeaderInformation.ProposedCmmDate = "14/09/2017";
            form.ReleaseHeaderInformation.ProposedOrd = "15/09/2017";
            form.ReleaseDescription.WhatIsTheChange = "This is the change";
            form.ReleaseDescription.WhyThisChange = "Because this change is good";
            form.ReleaseDescription.PartNumber = "12233";
            form.ReleaseDescription.Description= "This is a description";
            //form.BuyersAndSuppliers.SelectAvailableBuyers(new List<string>() { "Chris Geier", "Bob Maggio" });
        }
    }
}
