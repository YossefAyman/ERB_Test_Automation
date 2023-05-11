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
    public class HR_M2_P8_Permissions
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
            Permissions_Page.Goto();
        }

        [Test, Order(1)]
        public static void T1_Add_Permission()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.M2HR.Test_Index_Permission);
            Data.M2HR.Test_Index_Permission = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_HR_M2_P8_Permission");
            Permissions_Page.Add_Permssion();
            Assert.IsTrue(Permissions_Page.Search(Data.M1HR.employeeName) == "Exist", "T1_Add_Permission_Test Failed");
        }

        [Test, Order(2)]
        public static void T2_Update_Permission()
        {
            Permissions_Page.Edit_Permssion(Data.M2HR.PermissionReason + "_Edited");
            Assert.IsTrue(Permissions_Page.Search(Data.M1HR.employeeName ) == "Exist", "T2_Update_Permission_Test Failed");
        }


        [Test, Order(3)]
        public static void T3_Delete_Permission()
        {
            Permissions_Page.Delete_Permssion(Data.M1HR.employeeName);
            Assert.IsTrue(Permissions_Page.Search(Data.M1HR.employeeName) != "Exist", "T3_Delete_Permission_Test Failed");


        }  

        [OneTimeTearDown]
        public static void Test_End()
        {
            Common.Driver.Dispose();
            Common.Driver = null;

        }
    }
}