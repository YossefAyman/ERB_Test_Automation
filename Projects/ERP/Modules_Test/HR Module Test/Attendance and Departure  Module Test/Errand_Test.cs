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
    public class HR_M2_Q10_Errands
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
            Errand_Page.Goto();
        }

        [Test, Order(1)]
        public static void T1_Add_Errand()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.M2HR.Test_Index_Errand);
            Data.M2HR.Test_Index_Errand = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_HR_M2_P10_Errand");
            Errand_Page.Add_Errand();
            Assert.IsTrue(Errand_Page.Search(Data.M1HR.employeeName) == "Exist", "T1_Add_Errand_Test Failed");
        }
        
        [Test, Order(4)]
        public static void T4_Add_And_Approve_Errand()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.M2HR.Test_Index_Errand);
            Data.M2HR.Test_Index_Errand = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_HR_M2_P10_Errand");
            Errand_Page.Add_Errand();
            Errand_Page.Approve_Errand(Data.M1HR.employeeName);
            Assert.IsTrue(Errand_Page.Search(Data.M1HR.employeeName) == "Exist", "T4_Add_And_Approve_Errand_Test Failed");
        }

        [Test, Order(2)]
        public static void T2_Update_Errand()
        {
            Errand_Page.Edit_Errand(Data.M2HR.Errand_Name + "_Edited");
            Assert.IsTrue(Errand_Page.Search(Data.M1HR.employeeName) == "Exist", "T2_Update_Errand_Test Failed");
        }


        [Test, Order(3)]
        public static void T3_Delete_Permission()
        {
            Errand_Page.Delete_Errand(Data.M1HR.employeeName);
            Assert.IsTrue(Errand_Page.Search(Data.M1HR.employeeName) != "Exist", "T3_Delete_Errand_Test Failed");


        }

        [OneTimeTearDown]
        public static void Test_End()
        {
            Common.Driver.Dispose();
            Common.Driver = null;

        }
    }
}