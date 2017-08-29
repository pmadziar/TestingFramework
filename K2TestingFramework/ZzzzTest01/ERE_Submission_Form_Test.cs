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
            Helpers.WaitUntilDataLoads(10);
            form.SelectReleaseType("Engine Component Release");
            Helpers.WaitUntilDataLoads(3);
            form.ReleaseHeaderInformation.ReleaseTitle = "This is a test of release title";
            form.ReleaseHeaderInformation.LeadProgramme = "VH118";
            form.ReleaseHeaderInformation.FirstUseProgramme = "VH118";
            form.ReleaseHeaderInformation.BuildPhase = "X1";
            form.ReleaseHeaderInformation.PmtArea = "After Sales";
            form.ReleaseHeaderInformation.PmtLeader = "Chris Geier";
            form.ReleaseHeaderInformation.Urgent = "Yes";
            form.ReleaseHeaderInformation.ProposedCmmDate = "10/09/2017";
            form.ReleaseHeaderInformation.ProposedOrd = "12/09/2017";
        }
    }
}
