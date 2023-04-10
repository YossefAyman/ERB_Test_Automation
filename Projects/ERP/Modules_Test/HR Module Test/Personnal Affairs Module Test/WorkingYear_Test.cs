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
    public class HR_M1_Q16_WorkingYear
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
            WorkingYear_Page.Goto();
        }

        [Test, Order(1)]
        public static void T1_Add_WorkingYear()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.M1HR.Test_Index_WorkingYear);
            Data.M1HR.Test_Index_WorkingYear = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_HR_M1_P16_WorkingYear");
            WorkingYear_Page.Add_WorkingYear();
            Assert.IsTrue(WorkingYear_Page.Search(Data.M1HR.WorkingYear_Name) == "Exist", "T1_Add_WorkingYear_Test Failed");
        }

        [Test, Order(2)]
        public static void T2_Update_WorkingYear()
        {
            WorkingYear_Page.Edit_WorkingYear(Data.M1HR.WorkingYear_Name + "_Edited");
            Assert.IsTrue(WorkingYear_Page.Search(Data.M1HR.WorkingYear_Name + "_Edited") == "Exist", "T2_Update_WorkingYear_Test Failed");
        }




        [OneTimeTearDown]
        public static void Test_End()
        {
            Common.Driver.Dispose();
            Common.Driver = null;

        }
    }
}