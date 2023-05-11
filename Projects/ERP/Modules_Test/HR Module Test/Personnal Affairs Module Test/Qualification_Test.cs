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
    public class HR_M1_Q12_Qualifications
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
            Qualifications_Page.Goto();
        }

        [Test, Order(1)]
        public static void T1_Add_Qualification()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.M1HR.Test_Index_Qualification);
            Data.M1HR.Test_Index_Qualification = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_HR_M1_P12_Qualifications");
            Qualifications_Page.Add_Qualification();
            Assert.IsTrue(Skills_Page.Search(Data.M1HR.Qualification_Name) == "Exist", "T1_Add_Qualification_Test Failed");
        }

        [Test, Order(2)]
        public static void T2_Update_Qualification()
        {
            Qualifications_Page.Edit_Qualification(Data.M1HR.Qualification_Name + "_Edited" , Data.M1HR.Qualification_Dec + "_Edited");
            Assert.IsTrue(Skills_Page.Search(Data.M1HR.Qualification_Name + "_Edited") == "Exist", "T2_Update_Qualification_Test Failed");
        }


        [Test, Order(3)]
        public static void T3_Delete_Qualification()
        {
            Qualifications_Page.Delete_Qualification(Data.M1HR.Qualification_Name);
            Assert.IsTrue(Skills_Page.Search(Data.M1HR.Qualification_Name) != "Exist", "T3_Delete_Qualification_Test Failed");
        }


        [OneTimeTearDown]
        public static void Test_End()
        {
            Common.Driver.Dispose();
            Common.Driver = null;

        }
    }
}