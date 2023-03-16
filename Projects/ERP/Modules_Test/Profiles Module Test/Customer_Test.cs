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
    class M1_Profiles_N2_Customer_Test
    {
            [SetUp]
            public static void Test_Init()
            {
                Automation_Testing.Common.Driver.Manage().Window.Maximize();
                Login_Page.LoginAsAdmin();
                Customer_Page.Goto();
            }

            [Test]
            public void T1_AddCustomer_With_Full_Data()
            {

                Customer_Page.Add_Customer_With_Full_Data();

                Assert.IsTrue(Customer_Page.Search(Data.Customer.Name) == "Exist", "Add_Customer_With_Full_Data Failed");

            }

            [Test]
            public void T2_EditCustomer()
            {
                Customer_Page.Edit_Customer(Data.Customer.Name, Data.Customer.Name + "_edit");

                Assert.IsTrue(Customer_Page.Search(Data.Customer.Name + "_edit") == "Exist", "Edit Check Failed");
            }

            [Test]
            public void T3_DeleteCustomer()
            {
                Customer_Page.Delete_Customer(Data.Customer.Name);

                Assert.IsTrue(Customer_Page.Search(Data.Customer.Name) == "NotExist", "Delete Check Failed");
            }

            [Test]
            public void T4_Customer_HappyScenario()
            {
                Customer_Page.Add_Customer_With_Full_Data();
                Assert.IsTrue(Customer_Page.Search(Data.Customer.Name) == "Exist", "Add_Customer_With_Full_Data Failed");

                Customer_Page.Edit_Customer(Data.Customer.Name, Data.Customer.Name + "_edit");
                Assert.IsTrue(Customer_Page.Search(Data.Customer.Name + "_edit") == "Exist", "Edit Check Failed");

                Customer_Page.Delete_Customer(Data.Customer.Name + "_edit");
                Assert.IsTrue(Customer_Page.Search(Data.Customer.Name + "_edit") == "NotExist", "Delete Check Failed");
            }

            [Test]
            public void T5_Add_Two_Customer_With_Same_Full_Data_Times()
            {
                Customer_Page.Add_Customer_With_Full_Data();
                Customer_Page.Add_Customer_With_Full_Data();
                Assert.IsTrue(Customer_Page.Search(Data.Customer.Name) != "Repeated", "Repeat Check Failed");
            }
            [Test]

            public void T6_Add_Customer_With_Required_Data_Only()
            {
                Customer_Page.Add_Customer_With_Required_Data_Only();

                Assert.IsTrue(Customer_Page.Search(Data.Customer.Name) == "Exist", "Add_Customer_With_Required_Data_Only Failed");
            }

            [Test]
            public void T7_Add_Two_Customer_With_Same_Required_Data()
            {
                Customer_Page.Add_Customer_With_Required_Data_Only();
                Customer_Page.Add_Customer_With_Required_Data_Only();
                Assert.IsTrue(Customer_Page.Search(Data.Customer.Name) != "Repeated", "T7_Add_Two_Customer_With_Same_Required_Data Failed");

            }
     }
  
}
