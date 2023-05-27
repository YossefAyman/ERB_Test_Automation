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

    class M5_Purchases_N2_PurchaseReturnBill_Test
    {
        [SetUp]
        public static void Test_Init()
        {
            Automation_Testing.Common.Driver.Manage().Window.Maximize();
            Login_Page.LoginAsAdmin();
            PurchaseReturnBill_Page.Goto();
        }

        [Test]   

        public void T1_Add_PurchaseReturnsBill_Test()
        {

            try
            {
                int countValueBeforeAdding = Common.ReadCountText();
                PurchaseReturnBill_Page.Add_PurchasesReturnsBill("000113");
                int countValueAfterAdding = Common.ReadCountText();
                Assert.IsTrue(countValueAfterAdding - countValueBeforeAdding == 1, "T1_Add purchasebillFailed");
            }
            catch (Exception ex)
            {
                Assert.Warn("Message : \n" + ex.Message + "\nStack Trace : \n" + ex.StackTrace);

            }
        }

    }
}
