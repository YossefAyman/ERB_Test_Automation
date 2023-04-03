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


namespace LMS_Automation_Testing
{
    [TestFixture]

    class M2_General_Sittings_N1_Country_Test
    {
        [SetUp]
        public static void Test_Init()
        {
            Automation_Testing.Common.Driver.Manage().Window.Maximize();
            Login_Page.LoginAsAdmin();
            Country_Page.Goto();
        }

        [Test]
        public void T1_AddCountry()
        {
            Country_Page.Add_Country();
            Assert.IsTrue(Country_Page.Search(Data.Place.CountryName) == "Exist", "T1_AddCountry Failed");
        }

        [Test]
        public void T2_EditCountry()
        {
            Country_Page.Edit_Country(Data.Place.CountryName, Data.Place.CountryName + "_edit", Data.Place.Nationality + "_edit");
            Assert.IsTrue(Country_Page.Search(Data.Place.CountryName + "_edit") == "Exist", "T2_EditCountry Failed");
        }

        [Test]
        public void T3_DeleteCountry()
        {
            Country_Page.Delete_Country(Data.Place.CountryName + "_edit");
            Assert.IsTrue(Country_Page.Search(Data.Place.CountryName + "_edit") == "NotExist", "T3_DeleteCountry Failed");
        }

        [Test]
        public void T4_Country_HappyScenario()
        {
            Country_Page.Add_Country();
            Assert.IsTrue(Country_Page.Search(Data.Place.CountryName) == "Exist", "T1_AddCountry Failed");

            Country_Page.Edit_Country(Data.Place.CountryName, Data.Place.CountryName + "_edit", Data.Place.Nationality + "_edit");
            Assert.IsTrue(Country_Page.Search(Data.Place.CountryName + "_edit") == "Exist", "T2_EditCountry Failed");

            Country_Page.Delete_Country(Data.Place.CountryName + "_edit");
            Assert.IsTrue(Country_Page.Search(Data.Place.CountryName + "_edit") == "NotExist", "T3_DeleteCountry Failed");

        }
        
    }
}
