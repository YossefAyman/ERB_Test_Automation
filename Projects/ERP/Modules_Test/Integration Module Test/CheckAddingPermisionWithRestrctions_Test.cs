﻿using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using time = System.Threading.Thread;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Automation_Testing;
using Aspose.Pdf.Operators;

namespace ERP_Automation_Testing
{
    [TestFixture]
    class M8_IntegrationTests
    {
        [SetUp]
        public static void Test_Init()
        {
            Automation_Testing.Common.Driver.Manage().Window.Maximize();
            Login_Page.LoginAsAdmin();
        }
        [Test]
        ///////# Check When customer Add Permistion , A Restriction is added in Restrictions page with same amount #/////
        public static void T1_CheckAddingPermisionWithREstrictions()
        {
           
            Daily_Restrictions.Goto();
            string dailyRestrictionsID = Daily_Restrictions.GettingLastID();

            Addingpermission_page.Goto();

            int countValueBeforeAdding = Common.ReadCountText();//0
            Addingpermission_page.Add_AddingPermission();
            int countValueAfterAdding = Common.ReadCountText();//1

            Assert.IsTrue(countValueAfterAdding - countValueBeforeAdding == 1, "T1_Add permission Failed");

            Daily_Restrictions.Goto();
            int valueDebtor, valueCredit;

            Daily_Restrictions.Verifing_debtor_Creditor_Values(dailyRestrictionsID, out valueDebtor, out valueCredit);
            int totalAmout = int.Parse(Data.AddingPermission.Price) * int.Parse(Data.AddingPermission.Quantity);
            Assert.AreEqual(totalAmout, valueDebtor);

        }



        [TearDown]
        public static void Test_End()
        {
            Common.Driver.Close();

        }
    }
}