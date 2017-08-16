using K2.Testing.Automated.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace K2.AtonMartin.RLE.Testing.POM
{
    public class ERE_Dashboard_Form: K2FormBase
    {
        // Buttons: ERE_Dashboard_Form Area Item2
        // Filter/Search: ERE_Dashboard_Form Area Item3
        // Eng release process: ERE_Dashboard_Form Area Item
        // Eng/release ALL: ERE_Dashboard_Form Area Item5

        public readonly ERE_Header_Item Header;
        public readonly ERE_FilterSearchHeader_Item Buttons;
        public readonly ERE_FilterSearch_Item SearchFilter;
        public readonly ERE_EngineeringReleaseProcess_List WorklistUser;

        public readonly ERE_EngineeringReleaseProcessAllReleases_List WorklistAll;

        public ERE_Dashboard_Form(IWebDriver driver): base(driver)
        {
            this.Header = new ERE_Header_Item(this, "ERE_Dashboard_Form Area Item1");
            this.Buttons = new ERE_FilterSearchHeader_Item(this, "ERE_Dashboard_Form Area Item2");
            this.SearchFilter = new ERE_FilterSearch_Item(this, "ERE_Dashboard_Form Area Item3");
            this.WorklistUser = new ERE_EngineeringReleaseProcess_List(this, "ERE_Dashboard_Form Area Item");
            this.WorklistAll = new ERE_EngineeringReleaseProcessAllReleases_List(this, "ERE_Dashboard_Form Area Item5");
        }
    }
}
