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
    class M6_Sales_N1_SalesBill_Test
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
            SalesBill_Page.Goto();

        }


        [Test, Order(1)]

        public void T1_Add_SalesBill_Test()
        {
            SalesBill_Page.Add_SalesBill();

        }


        [Test, Order(2)]
        /////////////# Check When customer make a sales bill with the Report of Customer Report #/////////////
        public static void T2_CheckSalesBill_With_AccountsReports()
        {
            List<string> List = new List<string>(SalesBill_Page.Add_SalesBill());
            int totalAmountOfTheSalesBill = int.Parse(List[0]);
            Account_Reports_Page.Goto();
            Account_Reports_Page.CheckCustomerBalanceFromReports(out int maden_Amount_For_BeforelastTransaction, out int da2en_Amount_For_lastTransaction);
            Assert.IsTrue(totalAmountOfTheSalesBill == maden_Amount_For_BeforelastTransaction && totalAmountOfTheSalesBill == da2en_Amount_For_lastTransaction, "T2_CheckSalesBill_With_AccountsReports Failed");
        }


        [Test, Order(3)]
        /////////////# Check When customer make a sales bill with the Report of Customer Report #/////////////
        public static void T3_AddSalesBillThenReturnIt()
        {

            List<string> List = new List<string>(SalesBill_Page.Add_SalesBill());
            SalesInvoiceReturns_Page.Goto();
            int countValueBeforeAdding = SalesInvoiceReturns_Page.ReadCountText();
            SalesInvoiceReturns_Page.ReturnSalesBill(List[1]);
            int countValueAfterAdding = SalesInvoiceReturns_Page.ReadCountText();

            Assert.IsTrue(countValueAfterAdding - countValueBeforeAdding == 1, "T3_AddSalesBillThenReturnIt Failed");




        }






        [OneTimeTearDown]
        public static void Test_End()
        {
            Common.Driver.Dispose();
            Common.Driver = null;

        }

    }
}