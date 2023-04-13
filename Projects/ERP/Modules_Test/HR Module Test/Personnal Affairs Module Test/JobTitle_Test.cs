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
    public class HR_M1_Q10_JobTitle
    {
        [OneTimeSetUp]
        public static void Test_Init()
        {
            if (Common.Driver == null)
            {
                Common.OpenDriver();
            }
            Common.Driver.Manage().Window.Maximize();
            Login_Page.LoginAsAdmin();
            JobTitle_Page.Goto();
        }

        [Test, Order(1)]
        public static void T1_Add_JobTitle()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.M1HR.Test_Index_JobTitle);
            Data.M1HR.Test_Index_JobTitle = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_HR_M1_P10_JobTitle");
            JobTitle_Page.Add_JobTitle();
            Assert.IsTrue(JobTitle_Page.Search(Data.M1HR.JobTitle_Name) == "Exist", "T1_Add_JobGrade_Test Failed");
        }

        [Test, Order(2)]
        public static void T2_Update_JobTitle()
        {
            JobTitle_Page.Edit_JobTitle(Data.M1HR.JobTitle_Name + "_Edited" , Data.M1HR.JobTitle_Dec + "_Edited");
            Assert.IsTrue(JobTitle_Page.Search(Data.M1HR.JobTitle_Name + "_Edited") == "Exist", "T2_Update_JobTitle_Test Failed");
        }


        [Test, Order(3)]
        public static void T3_Delete_JobTitle()
        {
            JobTitle_Page.Delete_JobTitle(Data.M1HR.JobTitle_Name);
            Assert.IsTrue(JobTitle_Page.Search(Data.M1HR.JobTitle_Name) != "Exist", "T3_Delete_JobTitle_Test Failed");


        }


        [OneTimeTearDown]
        public static void Test_End()
        {
            Common.Driver.Dispose();
            Common.Driver = null;

        }
    }
}