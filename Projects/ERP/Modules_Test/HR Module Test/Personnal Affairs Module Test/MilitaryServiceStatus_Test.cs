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
    public class HR_M1_P4_MilitaryServiceStatus_Page
    {
        [OneTimeSetUp]
        public static void Test_Init()
        {
            if (Common.Driver == null)
            {
                Common.OpenDriver();
            }
            Automation_Testing.Common.Driver.Manage().Window.Maximize();
            Common.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Login_Page.LoginAsAdmin();
            MilitaryServiceStatus_Page.Goto();
        }

        [Test, Order(1)]
        public static void T1_Add_MilitaryServiceStatus()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.M1HR.Test_Index_MilitaryServiceStatus);
            Data.M1HR.Test_Index_MilitaryServiceStatus = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_HR_M1_P4_MilitaryServiceStatus");
            MilitaryServiceStatus_Page.Add_MilitaryServiceStatus();
            Assert.IsTrue(MilitaryServiceStatus_Page.Search() == "Exist", "T1_Add_MilitaryServiceStatus_Test Failed");
        }

        [Test, Order(2)]
        public static void T2_Update_MilitaryServiceStatus()
        {
            MilitaryServiceStatus_Page.Edit_MilitaryServiceStatus();
           // Assert.IsTrue(MilitaryServiceStatus_Page.Search() == "Exist", "T2_Add_MilitaryServiceStatus_Test Failed");
        }


        [Test, Order(3)]
        public static void T3_Delete_MilitaryServiceStatus()
        {
            MilitaryServiceStatus_Page.Delete_MilitaryServiceStatus();
           // Assert.IsTrue(MilitaryServiceStatus_Page.Search() != "Exist", "T3_Add_MilitaryServiceStatus_Test Failed");


        }


        [OneTimeTearDown]
        public static void Test_End()
        {
            Common.Driver.Dispose();
            Common.Driver = null;

        }

    }
}