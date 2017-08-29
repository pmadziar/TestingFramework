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
    public class ERE_BuyersSuppliers_Item: K2ItemViewBase
    {
        IK2Form form;
        #region Fields
        public void SelectAvailableBuyers(List<string> buyers)
        {
            K2MultiSelect ms = new K2MultiSelect(form, this, "Multi-Select Buyers");
            ms.SetValues(buyers);
        }
        #endregion
        public ERE_BuyersSuppliers_Item(IK2Form form, string name) : base(form, name)
        {
            this.form = form;
        }
    }
}
