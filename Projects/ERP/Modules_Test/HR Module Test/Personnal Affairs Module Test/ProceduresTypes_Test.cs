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
    public class HR_M1_Q18_ProceduresTypes
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
            ProceduresTypes_Page.Goto();
        }

        [Test, Order(1)]
        public static void T1_Add_ProcedureType()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.M1HR.Test_Index_ProceduresTypes);
            Data.M1HR.Test_Index_ProceduresTypes = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_HR_M1_P18_ProceduresTypes");
            ProceduresTypes_Page.Add_ProcedureType();
            Assert.IsTrue(ProceduresTypes_Page.Search(Data.M1HR.ProcedureType_Name) == "Exist", "T1_Add_ProcedureType_Test Failed");
        }

        [Test, Order(2)]
        public static void T2_Update_ProcedureType()
        {
            ProceduresTypes_Page.Edit_ProcedureType(Data.M1HR.ProcedureType_Name + "_Edited" , Data.M1HR.ProcedureType_Desc + "_Edited");
            Assert.IsTrue(JobGrade_Page.Search(Data.M1HR.ProcedureType_Name + "_Edited") == "Exist", "T2_Update_ProcedureType_Test Failed");
        }


        [Test, Order(3)]
        public static void T3_Delete_ProcedureType()
        {
            ProceduresTypes_Page.Delete_ProcedureType(Data.M1HR.ProcedureType_Name);
            Assert.IsTrue(ProceduresTypes_Page.Search(Data.M1HR.ProcedureType_Name) != "Exist", "T3_Delete_ProcedureType_Test Failed");


        }

        [Test, Order(4)]
        public static void T4_Add_ProcedureType_With_Added_Job_JobTittle_OrganizationUnit_Qualification_WorkSystem()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.M1HR.Test_Index_ProceduresTypes);
            Data.M1HR.Test_Index_ProceduresTypes = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_HR_M1_P18_ProceduresTypes");
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.M1HR.Test_Index_Job);
            Data.M1HR.Test_Index_Job = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_HR_M1_P13_Job");
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.M1HR.Test_Index_JobTitle);
            Data.M1HR.Test_Index_JobTitle = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_HR_M1_P10_JobTitle");
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.M1HR.Test_Index_OrganizationUnit);
            Data.M1HR.Test_Index_OrganizationUnit = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_HR_M1_P14_OrganizationUnit");
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.M1HR.Test_Index_Qualification);
            Data.M1HR.Test_Index_Qualification = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_HR_M1_P12_Qualifications");
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.M1HR.Test_Index_WorkSystem);
            Data.M1HR.Test_Index_WorkSystem = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_HR_M1_P17_WorkSystem");
            Job_Page.GotoJobPage();
            Job_Page.Add_Job();
            JobTitle_Page.Goto();
            JobTitle_Page.Add_JobTitle();
            OrganizationUnit_Page.Goto();
            OrganizationUnit_Page.Add_OrganizationUnit();
            Qualifications_Page.Goto();
            Qualifications_Page.Add_Qualification();
            WorkSystem_Page.Goto();
            WorkSystem_Page.Add_WorkSystem();
            ProceduresTypes_Page.Goto();
            ProceduresTypes_Page.Add_ProcedureType_With_Added_Job_JobTittle_OrganizationUnit_Qualification_WorkSystem();
            Assert.IsTrue(ProceduresTypes_Page.Search(Data.M1HR.ProcedureType_Name) == "Exist", "T4_Add_ProcedureType_With_Added_Job_JobTittle_OrganizationUnit_Qualification_WorkSystem_Test Failed");
        }




        [OneTimeTearDown]
        public static void Test_End()
        {
            Common.Driver.Dispose();
            Common.Driver = null;

        }
    }
}