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

    public class M4_Inventories_N2_Store_Test
    {
        [SetUp]
        public static void TestInit()
        {
            Automation_Testing.Common.Driver.Manage().Window.Maximize();
            Login_Page.LoginAsAdmin();
            Store_Page.Goto();
        }

        [Test]

        public static void T1_AddStore()
        {
            Store_Page.Add_Store();
            Assert.IsTrue(Store_Page.Search(Data.Store) == "Exist", "T1_Add_Brand Failed");
        }

        [Test]
        public static void T2_EditStore()
        {
            Store_Page.Edit_Store(Data.Store, Data.Store + "_edit");
            Assert.IsTrue(Store_Page.Search(Data.Store + "_edit") == "Exist", "T2_Edit_Store Failed");

        }

        [Test]
        public static void T3_DeleteStore()
        {
            Store_Page.Delete_Store(Data.Store + "_edit");
            Assert.IsTrue(Store_Page.Search(Data.Store + "_edit") != "Exist", "T3_Delete_Store Failed");
        }

        [Test]
        public static void T4_StoreHappyScenario()
        {
            Store_Page.Add_Store();
            Assert.IsTrue(Store_Page.Search(Data.Store) == "Exist", "T1_Add_Brand Failed");

            Store_Page.Edit_Store(Data.Store, Data.Store + "_edit");
            Assert.IsTrue(Store_Page.Search(Data.Store + "_edit") == "Exist", "T2_Edit_Store Failed");

            Store_Page.Delete_Store(Data.Store + "_edit");
            Assert.IsTrue(Store_Page.Search(Data.Store + "_edit") != "Exist", "T3_Delete_Store Failed");

        }

    }
}
