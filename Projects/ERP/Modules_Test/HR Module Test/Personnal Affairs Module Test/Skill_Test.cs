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
    public class HR_M1_Q11_Skills
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
            Skills_Page.Goto();
        }

        [Test, Order(1)]
        public static void T1_Add_Skill()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.M1HR.Test_Index_Skills);
            Data.M1HR.Test_Index_Skills = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_HR_M1_P11_Skills");
            Skills_Page.Add_Skill();
        //  Assert.IsTrue(Skills_Page.Search(Data.M1HR.Skills_Name) == "Exist", "T1_Add_Skill_Test Failed");
        }

        [Test, Order(2)]
        public static void T2_Update_Skill()
        {
            Skills_Page.Edit_Skill(Data.M1HR.Skills_Name + "_Edited");
        //  Assert.IsTrue(Skills_Page.Search(Data.M1HR.Skills_Name + "_Edited") == "Exist", "T2_Update_Skill_Test Failed");
        }


        [Test, Order(3)]
        public static void T3_Delete_Skill()
        {
            Skills_Page.Delete_Skill(Data.M1HR.Skills_Name);
       //   Assert.IsTrue(Skills_Page.Search(Data.M1HR.Skills_Name) != "Exist", "T3_Delete_Skill_Test Failed");


        }


        [OneTimeTearDown]
        public static void Test_End()
        {
            Common.Driver.Dispose();
            Common.Driver = null;

        }
    }
}