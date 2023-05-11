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
    public class Estates_P1_PropertyType
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
            PropertyType_Page.Goto();
        }

        [Test, Order(1)]
        public static void T1_Add_PropertyType()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.Estates.Test_Index_PropertyType);
            Data.Estates.Test_Index_PropertyType = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_Estate_P1_PropertyType");
            PropertyType_Page.AddPropertyType();
            Assert.IsTrue(PropertyType_Page.Search(Data.Estates.PropertyType_Name) == "Exist", "T1_Add_PropertyType_Test Failed");
        }

        [Test, Order(2)]
        public static void T2_Update_PropertyType()
        {
            PropertyType_Page.Edit_PropertyType(Data.Estates.PropertyType_Name + "_Edited", Data.Estates.PropertyType_Desc + "_Edited");
            Assert.IsTrue(PropertyType_Page.Search(Data.Estates.PropertyType_Name + "_Edited") == "Exist", "T2_Update_PropertyType_Test Failed");
        }


        [Test, Order(3)]
        public static void T3_Delete_PropertyType()
        {
            PropertyType_Page.Delete_PropertyType(Data.Estates.PropertyType_Name);
            Assert.IsTrue(PropertyType_Page.Search(Data.Estates.PropertyType_Name) != "Exist", "T3_Delete_PropertyType_Test Failed");
        }


        [OneTimeTearDown]
        public static void Test_End()
        {
            Common.Driver.Dispose();
            Common.Driver = null;

        }
    }
}