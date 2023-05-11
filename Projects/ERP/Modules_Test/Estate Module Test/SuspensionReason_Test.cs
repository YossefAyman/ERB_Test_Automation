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
    public class Estates_P3_SuspensionReason
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
            SuspensionReason_Page.Goto();
        }

        [Test, Order(1)]
        public static void T1_Add_SuspensionReason()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.Estates.Test_Index_SuspensionReason);
            Data.Estates.Test_Index_SuspensionReason = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_Estate_P3_SuspensionReason");
            SuspensionReason_Page.Add_SuspensionReason();
            Assert.IsTrue(PropertyType_Page.Search(Data.Estates.SuspensionReason_Name) == "Exist", "T1_Add_SuspensionReason_Test Failed");
        }

        [Test, Order(2)]
        public static void T2_Update_SuspensionReason()
        {
            SuspensionReason_Page.Edit_SuspensionReason(Data.Estates.SuspensionReason_Name, Data.Estates.SuspensionReason_Name + "_Edited");
            Assert.IsTrue(PropertyType_Page.Search(Data.Estates.SuspensionReason_Name + "_Edited") == "Exist", "T2_Update_SuspensionReason_Test Failed");
        }


        [Test, Order(3)]
        public static void T3_Delete_SuspensionReason()
        {
            SuspensionReason_Page.Delete_SuspensionReason(Data.Estates.SuspensionReason_Name);
            time.Sleep(1000);
            Assert.IsTrue(PropertyType_Page.Search(Data.Estates.SuspensionReason_Name) != "Exist", "T3_Delete_SuspensionReason_Test Failed");
        }


        [OneTimeTearDown]
        public static void Test_End()
        {
            Common.Driver.Dispose();
            Common.Driver = null;

        }
    }
}