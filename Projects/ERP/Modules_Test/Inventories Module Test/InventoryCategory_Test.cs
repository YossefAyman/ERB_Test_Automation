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
//using System.Windows.Forms;


namespace ERP_Automation_Testing
{
    [TestFixture]

    public class M4_Inventories_N3_InventoryCategory_Test
    {
        [SetUp]
        public static void TestInit()
        {
            Automation_Testing.Common.Driver.Manage().Window.Maximize();
            Login_Page.LoginAsAdmin();
            InventoryCategory_Page.Goto();
        }

        [Test]

        public static void T1_AddInventoryCategory()
        {
            InventoryCategory_Page.Add_InventoryCategory(Data.InventoryCategory,"");
            //Assert.IsTrue(InventoryCategory_Page.Search(Data.InventoryCategory) == "Exist", "T1_Add_InventoryCategory Failed");
        }

        [Test]
        public static void T2_EditInventoryCategory()
        {
            InventoryCategory_Page.Edit_InventoryCategory(Data.InventoryCategory, Data.InventoryCategory + "_edit");
           // Assert.IsTrue(InventoryCategory_Page.Search(Data.InventoryCategory + "_edit") == "Exist", "T2_Edit_InventoryCategory Failed");

        }

        [Test]
        public static void T3_DeleteInventoryCategory()
        {
            InventoryCategory_Page.Delete_InventoryCategory(Data.InventoryCategory + "_edit");
            //Assert.IsTrue(InventoryCategory_Page.Search(Data.InventoryCategory + "_edit") != "Exist", "T3_Delete_InventoryCategory Failed");
        }

        [Test]
        public static void T4_InventoryCategoryHappyScenario()
        {
            InventoryCategory_Page.Add_InventoryCategory(Data.InventoryCategory, "");
            //Assert.IsTrue(InventoryCategory_Page.Search(Data.InventoryCategory) == "Exist", "T1_Add_InventoryCategory Failed");

            InventoryCategory_Page.Edit_InventoryCategory(Data.InventoryCategory, Data.InventoryCategory + "_edit");
           // Assert.IsTrue(InventoryCategory_Page.Search(Data.InventoryCategory + "_edit") == "Exist", "T2_Edit_InventoryCategory Failed");

            InventoryCategory_Page.Delete_InventoryCategory(Data.InventoryCategory + "_edit");
            //Assert.IsTrue(InventoryCategory_Page.Search(Data.InventoryCategory + "_edit") == "NotExist", "T3_Delete_InventoryCategory Failed");

        }

    }
}
