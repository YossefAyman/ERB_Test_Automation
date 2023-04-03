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
    class M3_Educational_Institution_N1_EducationalLevel_Test
    {
        [SetUp]
        public static void Test_Init()
        {
            Automation_Testing.Common.Driver.Manage().Window.Maximize();
            Login_Page.LoginAsAdmin();
            Educational_Level_Page.Goto();
        }

        [Test]
        public void T1_AddEducationalLevel()
        {
            Educational_Level_Page.Add_Educational_Level();
            Assert.IsTrue(Educational_Level_Page.Search(Data.EducationalLevel.EducationalLevelName) == Common.SEARCH_Result.EXIST, "T1_AddEducationalLevel Failed");

        }

        [Test]
        public void T2_EditEducationalLevel()
        {
            Educational_Level_Page.Edit_Educational_Level(Data.EducationalLevel.EducationalLevelName, Data.EducationalLevel.EducationalLevelName + "_edit");
            Assert.IsTrue(Educational_Level_Page.Search(Data.EducationalLevel.EducationalLevelName + "_edit") == Common.SEARCH_Result.EXIST, "T2_EditEducationalLevel Failed");

        }

        [Test]
        public void T3_DeleteEducationalLevel()
        {
            Educational_Level_Page.Delete_Educational_Level(Data.EducationalLevel.EducationalLevelName + "_edit");
            Assert.IsTrue(Educational_Level_Page.Search(Data.EducationalLevel.EducationalLevelName + "_edit") == Common.SEARCH_Result.NOT_EXIST, "T3_DeleteEducationalLevel Failed");

        }

        [Test]
        public void T4_EducationalLevel_HappyScenario()
        {
            Educational_Level_Page.Add_Educational_Level();
            Assert.IsTrue(Educational_Level_Page.Search(Data.EducationalLevel.EducationalLevelName) == Common.SEARCH_Result.EXIST, "T1_AddEducationalLevel Failed");

            Educational_Level_Page.Edit_Educational_Level(Data.EducationalLevel.EducationalLevelName, Data.EducationalLevel.EducationalLevelName + "_edit");
            Assert.IsTrue(Educational_Level_Page.Search(Data.EducationalLevel.EducationalLevelName + "_edit") == Common.SEARCH_Result.NOT_EXIST, "T2_EditEducationalLevel Failed");

            Educational_Level_Page.Delete_Educational_Level(Data.EducationalLevel.EducationalLevelName + "_edit");
            Assert.IsTrue(Educational_Level_Page.Search(Data.EducationalLevel.EducationalLevelName + "_edit") == Common.SEARCH_Result.NOT_EXIST, "T3_DeleteEducationalLevel Failed");

        }
    }
}
