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
            string NoOfItemsBefore = " ", NoOfItemsAfter = " ";
            
            // BUG "عدم ظهور فواتير المشتريات الا بعد الضغط على زرار البحث"
            Assert.True(PurchaseReturnBill_Page.Search("") != "NotExist", "No Items Appear in the list before adding new purchase returns bill");

            NoOfItemsBefore = PurchaseReturnBill_Page.Number_Of_Items();
            Data.PurchaseReturnBill NewPurchaseReturnBill = new Data.PurchaseReturnBill();

            PurchaseReturnBill_Page.Add_PurchasesReturnsBill(NewPurchaseReturnBill);

            Assert.True(PurchaseReturnBill_Page.Search("") != "NotExist", "No Items Appear in the list after adding new purchase returns bill");
                
            NoOfItemsAfter = PurchaseReturnBill_Page.Number_Of_Items();
              
            Assert.True(NoOfItemsBefore != NoOfItemsAfter, "T1_Add_PurchaseReturnsBill_Test Failed");
            
           

        }

    }
}
