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
    public class HR_M1_P1_DesignationType_Page
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
            DesignationType_Page.Goto();
        }

        [Test, Order(1)]
        public static void T1_Add_DesignationType()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.M1HR.Test_Index_Add_DesignationType);
            Data.M1HR.Test_Index_Add_DesignationType = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_HR_M1_P1_Add_DesignationType");
            DesignationType_Page.Add_DesignationType();
            Assert.IsTrue(DesignationType_Page.Search(Data.M1HR.DesignationType_Name) == "Exist", "T1_Add_DesignationType_Test Failed");
        }

        [Test, Order(2)]
        public static void T2_Update_DesignationType()
        {
            DesignationType_Page.Edit_DesignationType(Data.M1HR.DesignationType_Name + "_Edited");
            Assert.IsTrue(DesignationType_Page.Search(Data.M1HR.DesignationType_Name + "_Edited") == "Exist", "T2_Update_DesignationType_Test Failed");
        }


        [Test, Order(3)]
        public static void T3_Delete_DesignationType()
        {
            DesignationType_Page.Delete_DesignationType(Data.M1HR.DesignationType_Name);
            Assert.IsTrue(DesignationType_Page.Search(Data.M1HR.DesignationType_Name) != "Exist", "T3_Delete_DesignationType_Test Failed");


        }

        [Test, Order(4)]
        public static void T4_DesignationTypeHappyScenario()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.M1HR.Test_Index_Add_DesignationType);
            Data.M1HR.Test_Index_Add_DesignationType = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_HR_M1_P1_Add_DesignationType");
            DesignationType_Page.Add_DesignationType();
            if (Data.check(DesignationType_Page.Search(Data.M1HR.DesignationType_Name) == "Exist", "T1_Add_DesignationType_Test Failed"))
            {
                DesignationType_Page.Edit_DesignationType(Data.M1HR.DesignationType_Name + "_Edited");

                if (Data.check(DesignationType_Page.Search(Data.M1HR.DesignationType_Name) == "Exist", "T2_Update_DesignationType_Test Failed"))
                {
                    DesignationType_Page.Delete_DesignationType(Data.M1HR.DesignationType_Name);

                    Data.check(DesignationType_Page.Search(Data.M1HR.DesignationType_Name) != "Exist", "T3_Delete_DesignationType_Test Failed");


                }

            }

        }


        [OneTimeTearDown]
            public static void Test_End()
            {
            Common.Driver.Dispose();
            Common.Driver = null;

        }
    }
}