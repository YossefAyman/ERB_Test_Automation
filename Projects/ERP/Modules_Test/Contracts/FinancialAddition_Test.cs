using System;
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
    public class Contracts_P5_FinancialAddition

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
            FinancialAddition_Page.Goto();
        }

        [Test, Order(1)]
        public static void T1_Add_FinancialAddition()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.Contracts.Test_Index_FinancialAddition);
            Data.Contracts.Test_Index_FinancialAddition = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_Contracts_P5_FinancialAddition");
            FinancialAddition_Page.Add_FinancialAddition();
            Assert.IsTrue(FinancialAddition_Page.Search(Data.Contracts.FinancialAddition_Name) == "Exist", "T1_Add_FinancialAddition Failed");
        }

        [Test, Order(2)]
        public static void T2_Update_FinancialAddition()
        {
            FinancialAddition_Page.Edit_FinancialAddition(Data.Contracts.FinancialAddition_Name, Data.Contracts.FinancialAddition_Name + "_Edited");
            Assert.IsTrue(FinancialAddition_Page.Search(Data.Contracts.FinancialAddition_Name + "_Edited") == "Exist", "T2_Update_FinancialAddition Failed");
        }


        [Test, Order(3)]
        public static void T3_Delete_FinancialAddition()
        {
            FinancialAddition_Page.Delete_FinancialAddition(Data.Contracts.FinancialAddition_Name);
            time.Sleep(1000);
            Assert.IsTrue(FinancialAddition_Page.Search(Data.Contracts.FinancialAddition_Name) != "Exist", "T3_Delete_FinancialAddition Failed");


        }

        [OneTimeTearDown]
        public static void Test_End()
        {
            Common.Driver.Dispose();
            Common.Driver = null;

        }
    }
}