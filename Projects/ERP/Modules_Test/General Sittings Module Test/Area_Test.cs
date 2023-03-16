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
    class M2_General_Sittings_N2_Test
    {
        [SetUp]
        public static void Test_Init()
        {
            Automation_Testing.Common.Driver.Manage().Window.Maximize();
            Login_Page.LoginAsAdmin();
            Area_Page.Goto();
        }

        [Test]
        public void T1_AddArea()
        {
            Area_Page.Add_Area();
            Assert.IsTrue(Customer_Page.Search(Data.Place.AreaName) == "Exist", "T1_AddArea Failed");

        }

        [Test]
        public void T2_EditArea()
        {
            Area_Page.Edit_Area(Data.Place.AreaName, Data.Place.AreaName + "_edit");
            Assert.IsTrue(Customer_Page.Search(Data.Place.AreaName + "_edit") == "Exist", "T2_EditArea Failed");

        }

        [Test]
        public void T3_DeleteArea()
        {
            Area_Page.Delete_Area(Data.Place.AreaName + "_edit");
            Assert.IsTrue(Customer_Page.Search(Data.Place.AreaName + "_edit") == "NotExist", "T3_DeleteArea Failed");

        }

        [Test]
        public void T4_Area_HappyScenario()
        {
            Area_Page.Add_Area();
            Assert.IsTrue(Customer_Page.Search(Data.Place.AreaName) == "Exist", "T1_AddArea Failed");

            Area_Page.Edit_Area(Data.Place.AreaName, Data.Place.AreaName + "_edit");
            Assert.IsTrue(Customer_Page.Search(Data.Place.AreaName + "_edit") == "Exist", "T2_EditArea Failed");

            Area_Page.Delete_Area(Data.Place.AreaName + "_edit");
            Assert.IsTrue(Customer_Page.Search(Data.Place.AreaName + "_edit") == "NotExist", "T3_DeleteArea Failed");

        }
    }
}
