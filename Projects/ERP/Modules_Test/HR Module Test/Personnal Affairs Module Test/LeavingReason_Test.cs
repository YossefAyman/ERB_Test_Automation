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

namespace ERP_Automation_Testing
{
    [TestFixture]
    public class HR_M1_P5_LeavingReason
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
            LeavingReason_Page.Goto();
        }

        [Test, Order(1)]
        public static void T1_Add_LeavingReason()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.M1HR.Test_Index_LeavingReason);
            Data.M1HR.Test_Index_LeavingReason = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_HR_M1_P5_LeavingReason");
            LeavingReason_Page.Add_LeavingReason();
            Assert.IsTrue(LeavingReason_Page.Search(Data.M1HR.LeavingReason_Name) == "Exist", "T1_Add_LeavingReason_Test Failed");
        }

        [Test, Order(2)]
        public static void T2_Update_LeavingReason()
        {
            LeavingReason_Page.Edit_LeavingReason(Data.M1HR.LeavingReason_Name + "_Edited");
            Assert.IsTrue(LeavingReason_Page.Search(Data.M1HR.LeavingReason_Name + "_Edited") == "Exist", "T2_Update_JobGrade_Test Failed");
        }


        [Test, Order(3)]
        public static void T3_Delete_LeavingReason()
        {
            LeavingReason_Page.Delete_LeavingReason(Data.M1HR.LeavingReason_Name);
            Assert.IsTrue(LeavingReason_Page.Search(Data.M1HR.LeavingReason_Name) != "Exist", "T3_Delete_JobGrade_Test Failed");


        }


        [OneTimeTearDown]
        public static void Test_End()
        {
            Common.Driver.Dispose();
            Common.Driver = null; 

        }
    }
}