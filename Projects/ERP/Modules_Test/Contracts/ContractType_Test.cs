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
using ERP_Automation_Test.Projects.ERP.Modules.Profiles_Module;
using Newtonsoft.Json.Linq;
using Microsoft.Ajax.Utilities;

namespace ERP_Automation_Testing
{
    [TestFixture]
    public class Contracts_ContractType

    {
        [OneTimeSetUp]
        public static void Test_Init()
        {
            if (Common.Driver == null)
            {
                Common.OpenDriver();
            }
            Common.Driver.Manage().Window.Maximize();
            Common.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Login_Page.LoginAsAdmin();
            ContractType_Page.Goto();
        }

        [Test, Order(1)]
        public static void T1_Add_ContractType()
        {
            //TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.Contracts.Test_Index_ContractType);
            //Data.Contracts.Test_Index_ContractType = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_Contracts_P1_ContractType");
            ContractType_Page.Add();
            //Assert.IsTrue(AnnualHolidays_Page.Search(Data.M2HR.AnnualHoliday_Name) == "Exist", "T1_Add_AnnualHoliday_Test Failed");
        }

        //[Test, Order(2)]
        //public static void T2_Update_AnnualHoliday()
        //{
        //    AnnualHolidays_Page.Edit_AnnualHoliday(Data.M2HR.AnnualHoliday_Name + "_Edited", Data.M2HR.AnnualHoliday_Desc + "_Edited");
        //    Assert.IsTrue(AnnualHolidays_Page.Search(Data.M2HR.AnnualHoliday_Name + "_Edited") == "Exist", "T2_Update_AnnualHoliday_Test Failed");
        //}


        //[Test, Order(3)]
        //public static void T3_Delete_AnnualHoliday()
        //{
        //    AnnualHolidays_Page.Delete_AnnualHoliday(Data.M2HR.AnnualHoliday_Name);
        //    Assert.IsTrue(AnnualHolidays_Page.Search(Data.M2HR.AnnualHoliday_Name) != "Exist", "T3_Delete_AnnualHoliday_Test Failed");


        //}

        [OneTimeTearDown]
        public static void Test_End()
        {
            Common.Driver.Dispose();
            Common.Driver = null;

        }
    }
}