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
    public class Estates_P7_BanReason
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
            BanReason_Page.Goto();
        }

        [Test, Order(1)]
        public static void T1_Add_BanReason()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.Estates.Test_Index_BanReason);
            Data.Estates.Test_Index_BanReason = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_Estate_P7_BanReason");
            BanReason_Page.Add_BanReason();
            Assert.IsTrue(PropertyType_Page.Search(Data.Estates.BanReason_Name) == "Exist", "T1_Add_BanReason_Test Failed");
        }

        [Test, Order(2)]
        public static void T2_Update_BanReason()
        {
            BanReason_Page.Edit_BanReason(Data.Estates.BanReason_Name, Data.Estates.BanReason_Name + "_Edited");
            Assert.IsTrue(PropertyType_Page.Search(Data.Estates.BanReason_Name + "_Edited") == "Exist", "T2_Update_BanReason_Test Failed");
        }


        [Test, Order(3)]
        public static void T3_Delete_BanReason()
        {
            BanReason_Page.Delete_BanReason(Data.Estates.BanReason_Name);
            time.Sleep(1000);
            Assert.IsTrue(PropertyType_Page.Search(Data.Estates.BanReason_Name) != "Exist", "T3_Delete_BanReason_Test Failed");
        }


        [OneTimeTearDown]
        public static void Test_End()
        {
            Common.Driver.Dispose();
            Common.Driver = null;

        }
    }
}