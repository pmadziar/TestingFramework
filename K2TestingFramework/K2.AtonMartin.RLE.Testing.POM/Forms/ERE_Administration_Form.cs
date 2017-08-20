using K2.AtonMartin.RLE.Testing.POM.Views;
using K2.Testing.Automated.Framework;
using K2.Testing.Automated.Framework.Controls;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2.AtonMartin.RLE.Testing.POM.Forms
{
    public class ERE_Administration_Form: K2FormBase
    {
        public K2Tab ReferenceDataTab { get; private set; }
        public K2Tab UserManagement { get; private set; }

        public ERE_GroupMember_List GroupMemberList { get; private set; }


        public ERE_Administration_Form(IWebDriver driver): base(driver)
        {
            ReferenceDataTab = new K2Tab(this, "Reference Data");
            this.Tabs.Add(ReferenceDataTab);
            UserManagement = new K2Tab(this, "User Management");
            this.Tabs.Add(UserManagement);
            GroupMemberList = new ERE_GroupMember_List(this, "ERE_Administration_Form Area Item11");
        }
    }
}
