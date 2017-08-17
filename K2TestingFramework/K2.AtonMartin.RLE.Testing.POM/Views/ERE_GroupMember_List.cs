using K2.Testing.Automated.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2.AtonMartin.RLE.Testing.POM.Views
{
    public class ERE_GroupMember_List: K2ListViewBase
    {
        public ERE_GroupMember_List(IK2Form form, string name): base(form, name)
        {

        }

        public IWebElement AddButton
        {
            get
            {
                return this.getToolBarButtonByName("Add");
            }
        }
    }
}
