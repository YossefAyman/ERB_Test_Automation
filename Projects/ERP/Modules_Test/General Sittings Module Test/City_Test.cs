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
    class M2_General_Sittings_N3_City_Test
    {
        [SetUp]
        public static void Test_Init()
        {
            Automation_Testing.Common.Driver.Manage().Window.Maximize();
            Login_Page.LoginAsAdmin();
            City_Page.Goto();
        }

        [Test]
        public void T1_AddCity()
        {
            City_Page.Add_City();
            Assert.IsTrue(Customer_Page.Search(Data.Place.CityName) == "Exist", "T1_AddCity Failed"); ; ;
        }

        [Test]
        public void T2_EditCity()
        {
            City_Page.Edit_City(Data.Place.CityName, Data.Place.CityName + "_edit");
            Assert.IsTrue(Customer_Page.Search(Data.Place.CityName + "_edit") == "Exist", "T2_EditCity Failed");
        }

        [Test]
        public void T3_DeleteCity()
        {
            City_Page.Delete_City(Data.Place.CityName + "_edit");
            Assert.IsTrue(Customer_Page.Search(Data.Place.CityName + "_edit") == "NotExist", "T3_DeleteCity Failed");
        }

        [Test]
        public void T4_City_HappyScenario()
        {
            City_Page.Add_City();
            Assert.IsTrue(Customer_Page.Search(Data.Place.CityName) == "Exist", "T1_AddCity Failed");

            City_Page.Edit_City(Data.Place.CityName, Data.Place.CityName + "_edit");
            Assert.IsTrue(Customer_Page.Search(Data.Place.CityName + "_edit") == "Exist", "T2_EditCity Failed");

            City_Page.Delete_City(Data.Place.CityName + "_edit");
            Assert.IsTrue(Customer_Page.Search(Data.Place.CityName + "_edit") == "NotExist", "T3_DeleteCity Failed");

        }
        
    }
}
