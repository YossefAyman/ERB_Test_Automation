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
    public class HR_M1_P8_SpecialNeeds
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
            SpecialNeeds_Page.Goto();
        }

        [Test, Order(1)]
        public static void T1_Add_SpecialNeed()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.M1HR.Test_Index_SpecialNeeds);
            Data.M1HR.Test_Index_SpecialNeeds = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_HR_M1_P8_SpecialNeeds");
            SpecialNeeds_Page.Add_SpecialNeed();
            Assert.IsTrue(SpecialNeeds_Page.Search(Data.M1HR.SpecialNeedCertifNum) == "Exist", "T1_Add_SpecialNeed_Test Failed");
        }


        [Test, Order(2)]
        public static void T2_Update_EmploymentType()
        {
            SpecialNeeds_Page.Edit_SpecialNeede(Data.M1HR.SpecialNeedDec + "_Edited");
            Assert.IsTrue(SpecialNeeds_Page.Search(Data.M1HR.SpecialNeedCertifNum) == "Exist", "T2_Edit_SpecialNeed_Test Failed");
        }


        [Test, Order(3)]
        public static void T3_Delete_EmploymentType()
        {
            SpecialNeeds_Page.Delete_SpecialNeed(Data.M1HR.SpecialNeedCertifNum);
            Assert.IsTrue(SpecialNeeds_Page.Search(Data.M1HR.SpecialNeedCertifNum) != "Exist", "T3_Delete_SpecialNeed_Test Failed");


        }


        [OneTimeTearDown]
        public static void Test_End()
        {
            Common.Driver.Dispose();
            Common.Driver = null;


        }
    }
}