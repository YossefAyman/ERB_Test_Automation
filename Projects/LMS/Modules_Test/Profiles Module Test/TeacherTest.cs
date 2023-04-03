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
using ERP_Automation_Testing;
//using System.Windows.Forms;

namespace LMS_Automation_Testing
{
    public class M1_Profiles_N3_Teacher_Test
    {
        [SetUp]
        public static void Test_Init()
        {
            Automation_Testing.Common.Driver.Manage().Window.Maximize();
            Login_Page.LoginAsAdmin();
           Teacher_Page.Goto();
        }

        [Test]
        public void T1_AddTeacher()
        {
            Teacher_Page.AddTeacher();
        }
        [Test]
        public void T2_EditTeacher()
        {
            Teacher_Page.edit_Teacher(Data.Teacher.Name, Data.Teacher.Name + "_edit");
        }
        [Test]
        public void T3_DeleteTeacher()
        {
            Teacher_Page.delete_Teacher( Data.Teacher.Name + "_edit");
        }
        [Test]
        public void T4_Teacher_HappyScenario()
        {
            Teacher_Page.add_Teacher();
            Teacher_Page.edit_Teacher( Data.Teacher.Name, Data.Teacher.Name + "_edit");
            Teacher_Page.delete_Teacher( Data.Teacher.Name + "_edit");
        }
        [Test]
        public void T5_Teacher_ShortKeys()
        {
            Teacher_Page.ShortKeys_Scenrio( "Edit Teacher");

        }
    }

}
