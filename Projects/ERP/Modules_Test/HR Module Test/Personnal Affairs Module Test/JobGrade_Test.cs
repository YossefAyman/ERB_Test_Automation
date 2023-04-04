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
    public class HR_M1_P2_JobGrade
    {
        [SetUp]
        public static void Test_Init()
        {
            Automation_Testing.Common.Driver.Manage().Window.Maximize();
            Login_Page.LoginAsAdmin();
            JobGrade_Page.Goto();
        }
        [Test]
        public static void T1_Add_JobGrade()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.M1HR_JobGrade.Test_Index_JobGrade);
            Data.M1HR_JobGrade.Test_Index_JobGrade = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_HR_M1_P2_JobGrade");
            JobGrade_Page.Add_JobGrade();
            Assert.IsTrue(JobGrade_Page.Search(Data.M1HR_JobGrade.JobGradeName) == "Exist", "T1_Add_JobGrade_Test Failed");
        }

        [Test]
        public static void T2_Update_JobGrade()
        {
            JobGrade_Page.Edit_JobGrade(Data.M1HR_JobGrade.JobGradeName + "_Edited");
            Assert.IsTrue(JobGrade_Page.Search(Data.M1HR_JobGrade.JobGradeName + "_Edited") == "Exist", "T2_Update_JobGrade_Test Failed");
        }


        [Test]
        public static void T3_Delete_DesignationType()
        {
            JobGrade_Page.Delete_JobGrade(Data.M1HR_JobGrade.JobGradeName);
            Assert.IsTrue(JobGrade_Page.Search(Data.M1HR_JobGrade.JobGradeName) != "Exist", "T3_Delete_JobGrade_Test Failed");


        }


        [TearDown]
        public static void Test_End()
        {
            Common.Driver.Close();

        }
    }
}