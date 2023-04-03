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

namespace LMS_Automation_Testing
{
    [TestFixture]
    class M1_Profiles_N2_Student_Test
    {
            [SetUp]
            public static void Test_Init()
            {
                Automation_Testing.Common.Driver.Manage().Window.Maximize();
                Login_Page.LoginAsAdmin();
                Student_Page.Goto();
            }

            [Test]
            public void T1_AddStudent_With_Full_Data()
            {

            Student_Page.Add_Student_With_Full_Data();

                Assert.IsTrue(Student_Page.Search(Data.Student.Name) == "Exist", "Add_Student_With_Full_Data Failed");
            }

            [Test]
            public void T2_EditStudent()
            {
            Student_Page.Edit_Student(Data.Student.Name, Data.Student.Name + "_edit");

                Assert.IsTrue(Student_Page.Search(Data.Student.Name + "_edit") == "Exist", "Edit Check Failed");
            }

            [Test]
            public void T3_DeleteStudent()
            {
            Student_Page.Delete_Student(Data.Student.Name);

                Assert.IsTrue(Student_Page.Search(Data.Student.Name) == "NotExist", "Delete Check Failed");
            }

            [Test]
            public void T4_Student_HappyScenario()
            {
            Student_Page.Add_Student_With_Full_Data();
                Assert.IsTrue(Student_Page.Search(Data.Student.Name) == "Exist", "Add_Student_With_Full_Data Failed");

            Student_Page.Edit_Student(Data.Student.Name, Data.Student.Name + "_edit");
                Assert.IsTrue(Student_Page.Search(Data.Student.Name + "_edit") == "Exist", "Edit Check Failed");

            Student_Page.Delete_Student(Data.Student.Name + "_edit");
                Assert.IsTrue(Student_Page.Search(Data.Student.Name + "_edit") == "NotExist", "Delete Check Failed");
            }

            [Test]
            public void T5_Add_Two_Student_With_Same_Full_Data_Times()
            {
            Student_Page.Add_Student_With_Full_Data();
            Student_Page.Add_Student_With_Full_Data();
                Assert.IsTrue(Student_Page.Search(Data.Student.Name) != "Repeated", "Repeat Check Failed");
            }
            [Test]

            public void T6_Add_Student_With_Required_Data_Only()
            {
            Student_Page.Add_Student_With_Required_Data_Only();

                Assert.IsTrue(Student_Page.Search(Data.Student.Name) == "Exist", "Add_Student_With_Required_Data_Only Failed");
            }

            [Test]
            public void T7_Add_Two_Student_With_Same_Required_Data()
            {
            Student_Page.Add_Student_With_Required_Data_Only();
            Student_Page.Add_Student_With_Required_Data_Only();
                Assert.IsTrue(Student_Page.Search(Data.Student.Name) != "Repeated", "T7_Add_Two_Student_With_Same_Required_Data Failed");

            }
     }
  
}
