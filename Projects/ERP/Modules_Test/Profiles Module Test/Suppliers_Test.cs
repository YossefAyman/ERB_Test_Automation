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
using Aspose.Pdf.Operators;
//using System.Windows.Forms;

namespace ERP_Automation_Testing
{
    [TestFixture]
    class M1_Profiles_N1_Suppliers_Test
    {
        [SetUp]
        public static void Test_Init()
        {
            Automation_Testing.Common.Driver.Manage().Window.Maximize();
            Login_Page.LoginAsAdmin();
            Supplier_Page.Goto();
        }

        [Test]
        public void T1_AddSupplier()
        {

            try
            {
                int countValueBeforeAdding = Common.ReadCountText();
                Supplier_Page.Add_Supplier();
                int countValueAfterAdding = Common.ReadCountText();
                Assert.AreNotEqual(countValueAfterAdding , countValueBeforeAdding , "T1_Add supplier faild");
                

            }
            catch (Exception ex)
            {
                Assert.Warn("Message : \n" + ex.Message + "\nStack Trace : \n" + ex.StackTrace);
                Common.Driver.Close();

            }
        }
        [Test]
        public void T2_EditSupplier()
        {
            Supplier_Page.Edit_Supplier(Data.Supplier.Name, Data.Supplier.Name + "edit");

            Assert.IsTrue(Customer_Page.Search(Data.Supplier.Name + "_edit") == "Exist", "T2_EditSupplier Failed");
        }

        [Test]
        public void T3_DeleteSupplier()
        {
            Supplier_Page.Delete_Supplier(Data.Supplier.Name + "_edit");
            Assert.IsTrue(Customer_Page.Search(Data.Supplier.Name) == "NotExist", "T3_DeleteSupplier Failed");

        }

        [Test]
        public void T4_Supplier_HappyScenario()
        {
            Supplier_Page.Add_Supplier();
            Assert.IsTrue(Customer_Page.Search(Data.Supplier.Name) == "Exist", "Add_Supplier_With_Full_Data Failed");

            Supplier_Page.Edit_Supplier(Data.Supplier.Name, Data.Supplier.Name + "_edit");
            Assert.IsTrue(Customer_Page.Search(Data.Supplier.Name + "_edit") == "Exist", "T2_EditSupplier Failed");

            Supplier_Page.Delete_Supplier(Data.Supplier.Name + "_edit");
            Assert.IsTrue(Customer_Page.Search(Data.Supplier.Name) == "NotExist", "T3_DeleteSupplier Failed");

        }
        [TearDown]

        public static void Test_End()

        {
            Common.Driver.Close();
        }




    }
}














