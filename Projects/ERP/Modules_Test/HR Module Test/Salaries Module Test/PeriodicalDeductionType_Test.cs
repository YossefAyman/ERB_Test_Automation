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
    public class HR_M3_P2_PeriodicalDeductionType
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
            PeriodicalDeductionType_Page.Goto();
        }

        [Test, Order(1)]
        public static void T1_Add_PeriodicalDeductionType()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.M3HR.Test_Index_PeriodicalDeductionType);
            Data.M3HR.Test_Index_PeriodicalDeductionType = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_HR_M3_P2_PeriodicalDeductionType");
            PeriodicalDeductionType_Page.Add_PeriodicalDeductionType();
            Assert.IsTrue(Common.Search(Data.M3HR.PeriodicalDeductionType_Name) == Common.SEARCH_Result.EXIST, "T1_Add_PeriodicalDeductionType_Test Failed");
        }

        [Test, Order(2)]
        public static void T2_Update_PeriodicalDeductionType()
        {
            PeriodicalDeductionType_Page.Edit_PeriodicalDeductionType(Data.M3HR.PeriodicalDeductionType_Name + "_Edited", Data.M3HR.PeriodicalDeductionType_Desc + "_Edited");
            Assert.IsTrue(Common.Search(Data.M3HR.PeriodicalDeductionType_Name + "_Edited") == Common.SEARCH_Result.EXIST, "T2_Update_PeriodicalDeductionType_Test Failed");
        }


        [Test, Order(3)]
        public static void T3_Delete_AllowanceType()
        {
            PeriodicalDeductionType_Page.Delete_PeriodicalDeductionType(Data.M3HR.PeriodicalDeductionType_Name);
            Assert.IsTrue(Common.Search(Data.M3HR.PeriodicalDeductionType_Name) != Common.SEARCH_Result.EXIST, "T3_Delete_PeriodicalDeductionType_Test Failed");


        }


        [OneTimeTearDown]
        public static void Test_End()
        {
            Common.Driver.Dispose();
            Common.Driver = null;

        }
    }
}