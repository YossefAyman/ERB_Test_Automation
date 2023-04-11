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
    public class HR_M1_Q17_WorkSystem
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
            WorkSystem_Page.Goto();
        }

        [Test, Order(1)]
        public static void T1_Add_WorkSystem()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.M1HR.Test_Index_WorkSystem);
            Data.M1HR.Test_Index_WorkSystem = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_HR_M1_P17_WorkSystem");
            WorkSystem_Page.Add_WorkSystem();
            Assert.IsTrue(WorkSystem_Page.Search(Data.M1HR.WorkSystem_Name) == "Exist", "T1_Add_WorkSystem_Test Failed");
        }

        [Test, Order(2)]
        public static void T2_Update_WorkSystem()
        {
            WorkSystem_Page.Edit_WorkSystem(Data.M1HR.WorkSystem_Name + "_Edited");
            Assert.IsTrue(WorkSystem_Page.Search(Data.M1HR.WorkSystem_Name + "_Edited") == "Exist", "T2_Update_WorkSystem_Test Failed");
        }


        [Test, Order(3)]
        public static void T3_Delete_WorkSystem()
        {
            WorkSystem_Page.Delete_WorkSystem(Data.M1HR.WorkSystem_Name);
            Assert.IsTrue(WorkSystem_Page.Search(Data.M1HR.WorkSystem_Name) != "Exist", "T3_Delete_WorkSystem_Test Failed");


        }


        [OneTimeTearDown]
        public static void Test_End()
        {
            Common.Driver.Dispose();
            Common.Driver = null;

        }
    }
}