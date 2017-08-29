using K2.Testing.Automated.Framework;
using K2.Testing.Automated.Framework.Controls;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2.AtonMartin.RLE.Testing.POM.Views
{
    public class ERE_ReleaseHeaderInformation_Item : K2ItemViewBase
    {
        IK2Form form;

        #region Fields
        public string ReleaseTitle
        {
            set
            {
                if(!string.IsNullOrEmpty(value))
                {
                    K2TextBox tb = new K2TextBox(this, "Text Box Release Title");
                    tb.SetValue(value);
                }
            }
        }

        public string LeadProgramme
        {
            set
            {
                if(!string.IsNullOrEmpty(value))
                {
                    IWebElement row4 = this.LayoutTable.GetRow(4);

                    K2DropDown dd = new K2DropDown(this.form, row4);
                    dd.SetValue(value);
                }
            }
        }

        public string FirstUseProgramme
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    IWebElement row6 = this.LayoutTable.GetRow(6);

                    K2DropDown dd = new K2DropDown(this.form, row6);
                    dd.SetValue(value);
                }
            }
        }

        public string BuildPhase
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    IWebElement row8 = this.LayoutTable.GetRow(8);

                    K2DropDown dd = new K2DropDown(this.form, row8);
                    dd.SetValue(value);
                }
            }
        }

        public string PmtArea
        {
            set
            {
                if(!string.IsNullOrEmpty(value))
                {
                    IWebElement row10 = this.LayoutTable.GetRow(10);
                    K2Picker picker = new K2Picker(row10);
                    picker.SetValue(value);
                }
            }
        }

        public string PmtLeader
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    IWebElement row12 = this.LayoutTable.GetRow(12);
                    K2Picker picker = new K2Picker(row12);
                    picker.SetValue(value);
                }
            }
        }

        public string ProposedCmmDate
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    IWebElement row14 = this.LayoutTable.GetRow(14);
                    K2DatePicker picker = new K2DatePicker(row14);
                    picker.SetValue(value);
                }
            }
        }

        public string ProposedOrd
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    IWebElement row16 = this.LayoutTable.GetRow(16);
                    K2DatePicker picker = new K2DatePicker(row16);
                    picker.SetValue(value);
                }
            }
        }

        public string Urgent
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    IWebElement row18 = this.LayoutTable.GetRow(18);
                    K2RadioButtonList rbl = new K2RadioButtonList(row18);
                    rbl.SetValue(value);
                }
            }
        }

#endregion

public ERE_ReleaseHeaderInformation_Item(IK2Form form, string name) : base(form, name)
        {
            this.form = form;
        }
    }
}
