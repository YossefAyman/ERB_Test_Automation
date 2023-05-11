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
    public class HR_M2_P1_PermissionTypes
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
            PermissionType_Page.Goto();
        }

        [Test, Order(1)]
        public static void T1_Add_PermissionType()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.M2HR.Test_Index_PermissionType);
            Data.M2HR.Test_Index_PermissionType = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_HR_M2_P1_PermissionType");
            PermissionType_Page.Add_PermissionType();
            Assert.IsTrue(PermissionType_Page.Search(Data.M2HR.PermissionType_Name) == "Exist", "T1_Add_PermissionType_Test Failed");
        }

        [Test, Order(2)]
        public static void T2_Update_PermissionType()
        {
            PermissionType_Page.Edit_PermissionType(Data.M2HR.PermissionType_Name + "_Edited" , Data.M2HR.PermissionType_Desc + "_Edited");
            Assert.IsTrue(PermissionType_Page.Search(Data.M2HR.PermissionType_Name + "_Edited") == "Exist", "T2_Update_PermissionType_Test Failed");
        }


        [Test, Order(3)]
        public static void T3_Delete_PermissionType()
        {
            PermissionType_Page.Delete_PermissionType(Data.M2HR.PermissionType_Name);
            Assert.IsTrue(PermissionType_Page.Search(Data.M2HR.PermissionType_Name) != "Exist", "T3_Delete_PermissionType_Test Failed");


        }


        [OneTimeTearDown]
        public static void Test_End()
        {
            Common.Driver.Dispose();
            Common.Driver = null;

        }
    }
}