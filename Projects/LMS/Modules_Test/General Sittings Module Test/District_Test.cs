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
    class M2_General_Sittings_N4_District_Test
    {
        [SetUp]
        public static void Test_Init()
        {
            Automation_Testing.Common.Driver.Manage().Window.Maximize();
            Login_Page.LoginAsAdmin();
            District_Page.Goto();
        }

        [Test]
        public void T1_AddDistrict()
        {
            District_Page.Add_District();
            Assert.IsTrue(District_Page.Search(Data.Place.DistrictName) == "Exist", "T1_AddDistrict Failed");
        }

        [Test]
        public void T2_EditDistrict()
        {
            District_Page.Edit_District(Data.Place.DistrictName, Data.Place.DistrictName + "_edit");
            Assert.IsTrue(District_Page.Search(Data.Place.DistrictName + "_edit") == "Exist", "T2_EditDistrict Failed");
        }

        [Test]
        public void T3_DeleteDistrict()
        {
            District_Page.Delete_District(Data.Place.DistrictName + "_edit");
            Assert.IsTrue(District_Page.Search(Data.Place.DistrictName + "_edit") == "NotExist", "T3_DeleteDistrict Failed");
        }

        [Test]
        public void T4_District_HappyScenario()
        {
            District_Page.Add_District();
            Assert.IsTrue(District_Page.Search(Data.Place.DistrictName) == "Exist", "T1_AddDistrict Failed");

            District_Page.Edit_District(Data.Place.DistrictName, Data.Place.DistrictName + "_edit");
            Assert.IsTrue(District_Page.Search(Data.Place.DistrictName + "_edit") == "Exist", "T2_EditDistrict Failed");

            District_Page.Delete_District(Data.Place.DistrictName + "_edit");
            Assert.IsTrue(District_Page.Search(Data.Place.DistrictName + "_edit") == "NotExist", "T3_DeleteDistrict Failed");

        }

    }
}
