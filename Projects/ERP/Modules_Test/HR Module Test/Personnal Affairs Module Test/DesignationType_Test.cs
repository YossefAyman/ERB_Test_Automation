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
        [SetUp]
        public static void Test_Init()
        {
            Automation_Testing.Common.Driver.Manage().Window.Maximize();
            Login_Page.LoginAsAdmin();
            DesignationType_Page.Goto();
        }

        [Test]
        public static void T1_Add_DesignationType()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.M1HR_DesignationType.Test_Index_Add_DesignationType);
            Data.M1HR_DesignationType.Test_Index_Add_DesignationType = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_HR_M1_P1_Add_DesignationType");
            DesignationType_Page.Add_DesignationType();
            Assert.IsTrue(DesignationType_Page.Search(Data.M1HR_DesignationType.DesignationType_Name) == "Exist", "T1_Add_DesignationType_Test Failed");
        }

        [Test]
        public static void T2_Update_DesignationType()
        {
            DesignationType_Page.Edit_DesignationType(Data.M1HR_DesignationType.DesignationType_Name + "_Edited");
            Assert.IsTrue(DesignationType_Page.Search(Data.M1HR_DesignationType.DesignationType_Name + "_Edited") == "Exist", "T2_Update_DesignationType_Test Failed");
        }


        [Test]
        public static void T3_Delete_DesignationType()
        {
            DesignationType_Page.Delete_DesignationType(Data.M1HR_DesignationType.DesignationType_Name);
            Assert.IsTrue(DesignationType_Page.Search(Data.M1HR_DesignationType.DesignationType_Name) != "Exist", "T3_Delete_DesignationType_Test Failed");


        }

        [Test]
        public static void T4_DesignationTypeHappyScenario()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.M1HR_DesignationType.Test_Index_Add_DesignationType);
            Data.M1HR_DesignationType.Test_Index_Add_DesignationType = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_HR_M1_P1_Add_DesignationType");
            DesignationType_Page.Add_DesignationType();
            if (Data.check(DesignationType_Page.Search(Data.M1HR_DesignationType.DesignationType_Name) == "Exist", "T1_Add_DesignationType_Test Failed"))
            {
                DesignationType_Page.Edit_DesignationType(Data.M1HR_DesignationType.DesignationType_Name + "_Edited");

                if (Data.check(DesignationType_Page.Search(Data.M1HR_DesignationType.DesignationType_Name + "_Edited") == "Exist", "T2_Update_DesignationType_Test Failed"))
                {
                    DesignationType_Page.Delete_DesignationType(Data.M1HR_DesignationType.DesignationType_Name);

                    Data.check(DesignationType_Page.Search(Data.M1HR_DesignationType.DesignationType_Name) != "Exist", "T3_Delete_DesignationType_Test Failed");


                }

            }

        }


        [TearDown]
        public static void Test_End()
        {
            Common.Driver.Close();

        }
    }
}