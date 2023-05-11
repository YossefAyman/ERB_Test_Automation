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
    public class HR_M3_P1_AllowanceType
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
            AllowanceType_Page.Goto();
        }

        [Test, Order(1)]
        public static void T1_Add_AllowanceType()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.M3HR.Test_Index_AllowanceType);
            Data.M3HR.Test_Index_AllowanceType = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_HR_M3_P1_AllowanceType");
            AllowanceType_Page.Add_AllowanceType();
            Assert.IsTrue(Common.Search(Data.M3HR.AllowanceType_Name) == Common.SEARCH_Result.EXIST, "T1_Add_AllowanceType_Test Failed");
        }

        [Test, Order(2)]
        public static void T2_Update_AllowanceType()
        {
            AllowanceType_Page.Edit_AllowanceType(Data.M3HR.AllowanceType_Name + "_Edited", Data.M3HR.AllowanceType_Desc + "_Edited");
            Assert.IsTrue(Common.Search(Data.M3HR.AllowanceType_Name + "_Edited") == Common.SEARCH_Result.EXIST, "T2_Update_AllowanceType_Test Failed");
        }


        [Test, Order(3)]
        public static void T3_Delete_AllowanceType()
        {
            AllowanceType_Page.Delete_AllowanceType(Data.M3HR.AllowanceType_Name);
            Assert.IsTrue(Common.Search(Data.M3HR.AllowanceType_Name) != Common.SEARCH_Result.EXIST, "T3_Delete_AllowanceType_Test Failed");


        }


        [OneTimeTearDown]
        public static void Test_End()
        {
            Common.Driver.Dispose();
            Common.Driver = null;

        }
    }
}