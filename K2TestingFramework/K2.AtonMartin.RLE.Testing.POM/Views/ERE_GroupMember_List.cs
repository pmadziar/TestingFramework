﻿using K2.Testing.Automated.Framework;
using K2.Testing.Automated.Framework.Controls;
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
        IK2Form form;
        public void AddNew(string group, string userName )
        {
            this.getToolBarButtonByName("Add").Click();
            var addNewRow = getRowAddNew();
            var groupDd = new K2DropDown(form , addNewRow);
            var userNamePicker = new K2Picker(addNewRow);
            groupDd.SetValue(group);
            userNamePicker.SetValue(userName);
            System.Threading.Thread.Sleep(1500);

            this.getToolBarButtonByName("Save").Click();
        }

        public ERE_GroupMember_List(IK2Form form, string name): base(form, name)
        {
            this.form = form;
        }
    }
}
