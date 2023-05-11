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
    public class HR_M1_P7_EmploymentType_N2
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
            EmploymentType_N2_Page.Goto();
        }

        [Test, Order(1)]
        public static void T1_Add_EmploymentType()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.M1HR.Test_Index_N2_Employment_Type);
            Data.M1HR.Test_Index_N2_Employment_Type = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_HR_M1_P7_N2_EmploymentType");
            EmploymentType_N2_Page.Add_EmploymentType();
            Assert.IsTrue(EmploymentType_N2_Page.Search(Data.M1HR.N2_Employment_Type_Name) == "Exist", "T1_Add_EmploymentType_Test Failed");
        }


        [Test, Order(2)]
        public static void T2_Update_EmploymentType()
        {
            EmploymentType_N2_Page.Edit_EmploymentType(Data.M1HR.N2_Employment_Type_Name + "_Edited");
            Assert.IsTrue(EmploymentType_N2_Page.Search(Data.M1HR.N2_Employment_Type_Name + "_Edited") == "Exist", "T2_Update_EmploymentType_Test Failed");
        }


        [Test, Order(3)]
        public static void T3_Delete_EmploymentType()
        {
            EmploymentType_N2_Page.Delete_EmploymentType(Data.M1HR.N2_Employment_Type_Name);
            Assert.IsTrue(EmploymentType_N2_Page.Search(Data.M1HR.N2_Employment_Type_Name) != "Exist", "T3_Delete_EmploymentType_Test Failed");


        }


        [OneTimeTearDown]
        public static void Test_End()
        {
            Common.Driver.Dispose();
            Common.Driver = null;


        }
    }
}