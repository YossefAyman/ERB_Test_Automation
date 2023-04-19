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
    public class HR_M2_P2_LeaveType
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
            VacationType_Page.Goto();
        }

        [Test, Order(1)]
        public static void T1_Add_LeaveTypeType()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.M2HR.Test_Index_LeaveType);
            Data.M2HR.Test_Index_LeaveType = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_HR_M2_P2_LeaveType");
            VacationType_Page.Add_LeaveType();
            Assert.IsTrue(VacationType_Page.Search(Data.M2HR.LeaveType_Name) == "Exist", "T1_Add_LeaveType_Test Failed");
        }

        [Test, Order(2)]
        public static void T2_Update_LeaveType()
        {
            VacationType_Page.Edit_LeaveType(Data.M2HR.LeaveType_Name + "_Edited");
            Assert.IsTrue(PermissionType_Page.Search(Data.M2HR.LeaveType_Name + "_Edited") == "Exist", "T2_Update_LeaveTypee_Test Failed");
        }


        [Test, Order(3)]
        public static void T3_Delete_LeaveType()
        {
            VacationType_Page.Delete_LeaveType(Data.M2HR.LeaveType_Name);
            Assert.IsTrue(VacationType_Page.Search(Data.M2HR.LeaveType_Name) != "Exist", "T3_Delete_LeaveType_Test Failed");


        }

        [Test, Order(4)]
        public static void T4_Add_Paid_LeaveType()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.M2HR.Test_Index_LeaveType);
            Data.M2HR.Test_Index_LeaveType = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_HR_M2_P2_LeaveType");
            VacationType_Page.Add_Paid_LeaveType();
            Assert.IsTrue(VacationType_Page.Search(Data.M2HR.LeaveType_Name) == "Exist", "T4_Add_LeaveType_Test Failed");
        }

        
        [Test, Order(5)]
        public static void T5_Add_Migration_LeaveType()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.M2HR.Test_Index_LeaveType);
            Data.M2HR.Test_Index_LeaveType = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_HR_M2_P2_LeaveType");
            VacationType_Page.Add_Migration_LeaveType();
            Assert.IsTrue(VacationType_Page.Search(Data.M2HR.LeaveType_Name) == "Exist", "T5_Add_LeaveType_Test Failed");
        }
         
        [Test, Order(6)]
        public static void T6_Add_NeedToApproved_LeaveType()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.M2HR.Test_Index_LeaveType);
            Data.M2HR.Test_Index_LeaveType = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_HR_M2_P2_LeaveType");
            VacationType_Page.Add_NeedToApproved_LeaveType();
            Assert.IsTrue(VacationType_Page.Search(Data.M2HR.LeaveType_Name) == "Exist", "T6_Add_LeaveType_Test Failed");
        }


        [OneTimeTearDown]
        public static void Test_End()
        {
            Common.Driver.Dispose();
            Common.Driver = null;

        }
    }
}