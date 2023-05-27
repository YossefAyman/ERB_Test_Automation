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
using ERP_Automation_Test.Projects.ERP.Modules.Profiles_Module;
using Newtonsoft.Json.Linq;
using Microsoft.Ajax.Utilities;
using System.Drawing;

namespace ERP_Automation_Testing
{


    [TestFixture]
    internal class Purchase_P3_PurchaseBill
    {
        [OneTimeSetUp]
        public static void Test_Init()
        {
            if (Common.Driver == null)
            {
                Common.OpenDriver();
            }
            Common.Driver.Manage().Window.Maximize();
            Common.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Login_Page.LoginAsAdmin();
            PurchasesBill_Page.Goto();

        }

        [Test, Order(1)]
        public void T1_Add_purchaseBill()
        {

            try
            {
                int countValueBeforeAdding = Common.ReadCountText();
                PurchasesBill_Page.Add_purchaseBill();
                int countValueAfterAdding = Common.ReadCountText();
                Assert.IsTrue(countValueAfterAdding - countValueBeforeAdding == 1, "T1_Add purchasebillFailed");
            }
                catch (Exception ex)
            {
                Assert.Warn("Message : \n" + ex.Message + "\nStack Trace : \n" + ex.StackTrace);

            }
        }

        
        [Test, Order(2)]
        public void T2_Add_purchaseBill_Then_ReturnIt()
        {

            try
            {
                List<string> List = new List<string>(PurchasesBill_Page.Add_purchaseBill());
                PurchaseReturnBill_Page.Goto();
                int countValueBeforeAdding = Common.ReadCountText();
                PurchaseReturnBill_Page.Add_PurchasesReturnsBill(List[1]);
                int countValueAfterAdding = Common.ReadCountText();
                Assert.IsTrue(countValueAfterAdding - countValueBeforeAdding == 1, "T2_Add_purchaseBill_Then_ReturnIt Failed");
            }
                catch (Exception ex)
            {
                Assert.Warn("Message : \n" + ex.Message + "\nStack Trace : \n" + ex.StackTrace);

            }

           
        }




        [OneTimeTearDown]
        public static void Test_End()
        {
            Common.Driver.Dispose();
            Common.Driver = null;

        }



    }
}



