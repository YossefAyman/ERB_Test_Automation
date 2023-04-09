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
    public class HR_M1_P3_FinancialDisclosure_Page
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
            FinancialDisclosure_Page.Goto();
        }

        [Test, Order(1)]
        public static void T1_Add_FinancialDisclosure()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.M1HR.Test_Index_FinancialDisclosure);
            Data.M1HR.Test_Index_FinancialDisclosure = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_HR_M1_P3_FinancialDisclosure");
            FinancialDisclosure_Page.Add_FinancialDisclosure();
            Assert.IsTrue(FinancialDisclosure_Page.Search(FinancialDisclosure_Page.GetLastID()) == "Exist", "T1_FinancialDisclosure_Test Failed");
        }


        [Test, Order(2)]
        public static void T2_Update_FinancialDisclosure()
        {
            FinancialDisclosure_Page.Edit_FinancialDisclosure(Data.M1HR.FinancialDisclosure_Description + "_Edited");
            Assert.IsTrue(FinancialDisclosure_Page.Search(FinancialDisclosure_Page.GetLastID()) == "Exist", "T2_Update_FinancialDisclosure_Test Failed");
        }


        [Test, Order(3)]
        public static void T3_Delete_FinancialDisclosure()
        {
            var DeleteItem = FinancialDisclosure_Page.GetLastID();
            FinancialDisclosure_Page.Delete_FinancialDisclosure(DeleteItem);
            Assert.IsTrue(FinancialDisclosure_Page.Search(DeleteItem) != "Exist", "T3_Delete_FinancialDisclosure_Test Failed");


        }  

/*      [Test, Order(3)]
        public static void T3_Test()
        {
           var ss = FinancialDisclosure_Page.GetLastID();
        }*/



        [OneTimeTearDown]
        public static void Test_End()
        {
            Common.Driver.Dispose();
            Common.Driver = null;

        }
    }
}