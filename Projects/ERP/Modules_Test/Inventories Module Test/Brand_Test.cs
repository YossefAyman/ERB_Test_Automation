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
//using System.Windows.Forms;


namespace ERP_Automation_Testing
{
    [TestFixture]

    public class M4_Inventories_N1_Brand_Test
    {
        [SetUp]
        public static void TestInit()
        {
            Automation_Testing.Common.Driver.Manage().Window.Maximize();
            Login_Page.LoginAsAdmin();
            Brand_Page.Goto();
            
        }

        [Test]

        public static void T1_AddBrand()
        {
            Brand_Page.Add_Brand();
            Assert.IsTrue(Brand_Page.Search(Data.Brand) == "Exist", "T1_Add_Brand Failed");
        }

        [Test]
        public static void T2_EditBrand()
        {
            Brand_Page.Edit_Brand(Data.Brand, Data.Brand + "_edit");
            Assert.IsTrue(Brand_Page.Search(Data.Brand + "_edit") == "Exist", "T2_Edit_Brand Failed");

        }

        [Test]
        public static void T3_DeleteBrand()
        {
            Brand_Page.Delete_Brand(Data.Brand + "_edit");
            Assert.IsTrue(Brand_Page.Search(Data.Brand + "_edit") != "Exist", "T3_Delete_Brand Failed");
        }

        [Test]
        public static void T4_BrandHappyScenario()
        {
            Brand_Page.Add_Brand();
            Assert.IsTrue(Brand_Page.Search(Data.Brand) == "Exist", "T1_Add_Brand Failed");

            Brand_Page.Edit_Brand(Data.Brand, Data.Brand + "_edit");
            Assert.IsTrue(Brand_Page.Search(Data.Brand + "_edit") == "Exist", "T2_Edit_Brand Failed");

            Brand_Page.Delete_Brand(Data.Brand + "_edit");
            Assert.IsTrue(Brand_Page.Search(Data.Brand + "_edit") == "NotExist", "T3_Delete_Brand Failed");

        }
        [TearDown]
        public static void Test_End()
        {
            Common.Driver.Close();
        }
    }
}
