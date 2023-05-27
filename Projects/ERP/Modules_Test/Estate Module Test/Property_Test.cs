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
    public class Estates_P2_Property
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
            Property_Page.Goto();
        }

        [Test, Order(1)]
        public static void T1_Add_Property()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.Estates.Test_Index_Property);
            Data.Estates.Test_Index_Property = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_Estate_P2_Property");
            Property_Page.Add_Property();
            Assert.IsTrue(PropertyType_Page.Search(Data.Estates.Property_Name) == "Exist", "T1_Add_Property_Test Failed");
        }

        [Test, Order(2)]
        public static void T2_Update_Property()
        {
            Property_Page.Edit_Property(Data.Estates.Property_Name + "_Edited");
            Assert.IsTrue(PropertyType_Page.Search(Data.Estates.Property_Name + "_Edited") == "Exist", "T2_Update_Property_Test Failed");
        }


        [Test, Order(3)]
        public static void T3_Delete_Property()
        {
            Property_Page.Delete_Property(Data.Estates.Property_Name);
            time.Sleep(1000);
            Assert.IsTrue(PropertyType_Page.Search(Data.Estates.Property_Name) != "Exist", "T3_Delete_Property_Test Failed");
        }

        [Test, Order(4)]
        public static void T4_Add_PropertyType_Then_Add_Property()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.Estates.Test_Index_PropertyType);
            Data.Estates.Test_Index_PropertyType = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_Estate_P1_PropertyType");
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.Estates.Test_Index_Property);
            Data.Estates.Test_Index_Property = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_Estate_P2_Property");
            PropertyType_Page.Goto();
            PropertyType_Page.AddPropertyType();
            Property_Page.Goto();
            Property_Page.Add_Property_With_Added_NewPropertyType();
            Assert.IsTrue(PropertyType_Page.Search(Data.Estates.Property_Name) == "Exist", "T1_Add_Property_Test Failed");
        }

        [Test, Order(5)]
        public static void T5_Add_PropertyType_Then_Add_Property_Then_Check_That_Property_Is_Added_Correctly_To_The_Owner_Report()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.Estates.Test_Index_PropertyType);
            Data.Estates.Test_Index_PropertyType = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_Estate_P1_PropertyType");
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.Estates.Test_Index_Property);
            Data.Estates.Test_Index_Property = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_Estate_P2_Property");
            PropertyType_Page.Goto();
            PropertyType_Page.AddPropertyType();
            Property_Page.Goto();
            Property_Page.Add_Property_With_Added_NewPropertyType();
            Owner_PropertyReport_Report.Goto();
            Assert.IsTrue(Owner_PropertyReport_Report.Check_That_Property_Is_Added_Correctly_To_The_Owner(), "T5_Add_PropertyType_Then_Add_Property_Then_Check_That_Property_Is_Added_Correctly_To_The_Owner_Report Failed");
        }
        [Test, Order(6)]
        public static void T6_Add_PropertyType_Then_Add_Property_Then_Add_RentContract_For_This_Property()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.Estates.Test_Index_PropertyType);
            Data.Estates.Test_Index_PropertyType = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_Estate_P1_PropertyType");
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.Estates.Test_Index_Property);
            Data.Estates.Test_Index_Property = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_Estate_P2_Property");
            PropertyType_Page.Goto();
            PropertyType_Page.AddPropertyType();
            Property_Page.Goto();
            Property_Page.Add_Property_With_Added_NewPropertyType();
            RentContract_Page.Goto();
            RentContract_Page.Add_RentContract();
        }

        [Test, Order(7)]
        public static void T7_Add_PropertyType_Then_Add_Property_Then_Add_RentContract_Then_Check_That_Property_Is_Added_Correctly_To_Leased_Properties_Report()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.Estates.Test_Index_PropertyType);
            Data.Estates.Test_Index_PropertyType = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_Estate_P1_PropertyType");
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.Estates.Test_Index_Property);
            Data.Estates.Test_Index_Property = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_Estate_P2_Property");
            PropertyType_Page.Goto();
            PropertyType_Page.AddPropertyType();
            Property_Page.Goto();
            Property_Page.Add_Property_With_Added_NewPropertyType();
            RentContract_Page.Goto();
            RentContract_Page.Add_RentContract();
            LeasedProperties_Report.Goto();
            Assert.IsTrue(LeasedProperties_Report.Check_That_Property_Is_Added_Correctly_To_Leased_Properties(), "T7_Add_PropertyType_Then_Add_Property_Then_Add_RentContract_Then_Check_That_Property_Is_Added_Correctly_To_Leased_Properties_Report Failed");
        }

        [OneTimeTearDown]
        public static void Test_End()
        {
            Common.Driver.Dispose();
            Common.Driver = null;

        }
    }
}