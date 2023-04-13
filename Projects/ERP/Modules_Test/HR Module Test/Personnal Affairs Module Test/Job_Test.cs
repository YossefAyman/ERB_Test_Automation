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
    public class HR_M1_Q13_Job
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
            Job_Page.GotoJobPage();
        }

        [Test, Order(1)]
        public static void T1_Add_Job()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.M1HR.Test_Index_Job);
            Data.M1HR.Test_Index_Job = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_HR_M1_P13_Job");
            Job_Page.Add_Job();
            Assert.IsTrue(Job_Page.Search(Data.M1HR.Job_Name) == "Exist", "T1_Add_Job_Test Failed");
        }

        [Test, Order(2)]
        public static void T2_Update_JobGrade()
        {
            Job_Page.Edit_Job(Data.M1HR.Job_Name + "_Edited" , Data.M1HR.Job_Desc + "_Edited");
            Assert.IsTrue(Job_Page.Search(Data.M1HR.Job_Name + "_Edited") == "Exist", "T2_Update_Job_Test Failed");
        }


        [Test, Order(3)]
        public static void T3_Delete_JobGrade()
        {
            Job_Page.Delete_Job(Data.M1HR.Job_Name);
            Assert.IsTrue(JobGrade_Page.Search(Data.M1HR.Job_Name) != "Exist", "T3_Delete_Job_Test Failed");


        }
        [Test , Order(4)]
        public static void T1_Add_Job_With_Adding_Skill()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.M1HR.Test_Index_Skills);
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.M1HR.Test_Index_Job);
            Data.M1HR.Test_Index_Skills = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_HR_M1_P11_Skills");
            Data.M1HR.Test_Index_Job = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_HR_M1_P13_Job");
            OrganizationUnit_Page.Goto();
            OrganizationUnit_Page.Add_OrganizationUnit();
            Skills_Page.Goto();
            Skills_Page.Add_Skill();
            Job_Page.GotoJobPage();
            Job_Page.Add_Job_With_Added_OrganizationUnit_And_Skill();
            Assert.IsTrue(Job_Page.Search(Data.M1HR.Job_Name) == "Exist", "T1_Add_Job_Test Failed");
        }


        [OneTimeTearDown]
        public static void Test_End()
        {
            Common.Driver.Dispose();
            Common.Driver = null;

        }
    }
}