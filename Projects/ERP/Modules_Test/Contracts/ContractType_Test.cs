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
    public class Contracts_P4_ContractType

    {
        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
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
            ContractType_Page.Goto();
        }

        [Test, Order(1)]
        public static void T1_Add_ContractType()
        {
            //TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.Contracts.Test_Index_ContractType);
            //Data.Contracts.Test_Index_ContractType = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_Contracts_P4_ContractType");
            DynamicData PropertyType_insatnce = new DynamicData();            
            PropertyType_insatnce.Name = RandomString(3);
            ContractType_Page.Add_ContractType(PropertyType_insatnce);
            //sAssert.IsTrue(PropertyType_Page.Search(Data.Contracts.PropertyType_Name) == "Exist", "T1_Add_ContractType_Test Failed");
        }

        [Test, Order(2)]
        public static void T2_Update_ContractType()
        {
            ContractType_Page.Edit_ContractType(Data.Contracts.PropertyType_Name, Data.Contracts.PropertyType_Name + "_Edited");
            Assert.IsTrue(PropertyType_Page.Search(Data.Contracts.PropertyType_Name + "_Edited") == "Exist", "T2_Update_ContractType_Test Failed");
        }


        [Test, Order(3)]
        public static void T3_Delete_ContractType()
        {
            ContractType_Page.Delete_ContractType(Data.Contracts.PropertyType_Name);
            time.Sleep(1000);
            Assert.IsTrue(PropertyType_Page.Search(Data.Contracts.PropertyType_Name) != "Exist", "T3_Delete_ContractType_Test Failed");


        }

        [OneTimeTearDown]
        public static void Test_End()
        {
            Common.Driver.Dispose();
            Common.Driver = null;

        }
    }
}