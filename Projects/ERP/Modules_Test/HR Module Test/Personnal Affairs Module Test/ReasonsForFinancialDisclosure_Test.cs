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
    public class HR_M1_P9_ReasonsForFinancialDisclosure
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
            ReasonsForFinancialDisclosure_Page.Goto();
        }

        [Test, Order(1)]
        public static void T1_Add_ReasonForFinancialDisclosure()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.M1HR.Test_Index_ReasonsForFinancialDisclosure);
            Data.M1HR.Test_Index_ReasonsForFinancialDisclosure = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_HR_M1_P9_ReasonsForFinancialDisclosure");
            ReasonsForFinancialDisclosure_Page.Add_ReasonForFinancialDisclosure();
            Assert.IsTrue(ReasonsForFinancialDisclosure_Page.Search(Data.M1HR.ReasonForFinancialDisclosure) == "Exist", "T1_Add_ReasonForFinancialDisclosure_Test Failed");
        }


        [Test, Order(2)]
        public static void T2_Update_ReasonForFinancialDisclosure()
        {
            ReasonsForFinancialDisclosure_Page.Edit_ReasonForFinancialDisclosure(Data.M1HR.ReasonForFinancialDisclosure+ "_Edited");
            Assert.IsTrue(ReasonsForFinancialDisclosure_Page.Search(Data.M1HR.ReasonForFinancialDisclosure + "_Edited") == "Exist", "T2_Update_ReasonForFinancialDisclosure_Test Failed");
        }


        [Test, Order(3)]
        public static void T3_Delete_ReasonForFinancialDisclosure()
        {
            ReasonsForFinancialDisclosure_Page.Delete_ReasonForFinancialDisclosure(Data.M1HR.ReasonForFinancialDisclosure);
            Assert.IsTrue(ReasonsForFinancialDisclosure_Page.Search(Data.M1HR.ReasonForFinancialDisclosure) != "Exist", "T3_Delete_ReasonForFinancialDisclosure_Test Failed");


        }


        [OneTimeTearDown]
        public static void Test_End()
        {
            Common.Driver.Dispose();
            Common.Driver = null;


        }
    }
}