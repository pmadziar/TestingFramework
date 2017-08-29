using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K2.Testing.Automated.Framework;
using K2.Testing.Automated.Framework.Controls;
using OpenQA.Selenium;

namespace K2.AtonMartin.RLE.Testing.POM.Views
{
    public class ERE_ReleaseDescription_Item: K2ItemViewBase
    {
        IK2Form form;
        #region Fields
        public string WhatIsTheChange
        {
            set
            {
                if(!string.IsNullOrEmpty(value))
                {
                    //IWebElement row2 = this.LayoutTable.GetRow(2);

                    K2RichText rt = new K2RichText(form, this, 0);
                    rt.SetValue(value);
                }
            }
        }

        public string WhyThisChange
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    //IWebElement row4 = this.LayoutTable.GetRow(4);
                    K2RichText rt = new K2RichText(form, this, 1);
                    rt.SetValue(value);
                }
            }
        }

        public string PartNumber
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    K2TextArea ta = new K2TextArea(form, this, 0);
                    ta.SetValue(value);
                }
            }
        }

        public string Description
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    K2TextArea ta = new K2TextArea(form, this, 1);
                    ta.SetValue(value);
                }
            }
        }

        #endregion

        public ERE_ReleaseDescription_Item(IK2Form form, string name) : base(form, name)
        {
            this.form = form;
        }

    }
}
