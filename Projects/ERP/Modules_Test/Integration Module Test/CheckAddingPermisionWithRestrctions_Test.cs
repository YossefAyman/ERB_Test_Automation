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

namespace ERP_Automation_Testing
{
    [TestFixture]
    class M8_IntegrationTests_N1_CheckAddingPermisionWithREstrictions
    {
        [SetUp]
        public static void Test_Init()
        {
            Automation_Testing.Common.Driver.Manage().Window.Maximize();
            Login_Page.LoginAsAdmin();
        }
        [Test]
        ///////# Check When customer Add Permistion , A Restriction is added in Restrictions page with same amount #/////
        public static void T1_CheckAddingPermisionWithREstrictions()
        {
           
            Daily_Restrictions.Goto();
            string dailyRestrictionsID = Daily_Restrictions.GettingLastID();

            Addingpermission_page.Goto();

            int countValueBeforeAdding = Common.ReadCountText();//0
            Addingpermission_page.Add_AddingPermission();
            int countValueAfterAdding = Common.ReadCountText();//1

            Assert.IsTrue(countValueAfterAdding - countValueBeforeAdding == 1, "T1_Add permission Failed");

            Daily_Restrictions.Goto();
            int valueDebtor, valueCredit;

            Daily_Restrictions.Verifing_debtor_Creditor_Values(dailyRestrictionsID, out valueDebtor, out valueCredit);
            int totalAmout = int.Parse(Data.AddingPermission.Price) * int.Parse(Data.AddingPermission.Quantity);
            Assert.AreEqual(totalAmout, valueDebtor);

           


        }


        [Test]
        /////////////# Check When customer make a sales bill with the Report of Customer Report #/////////////
        public static void T2_CheckSalesBill_With_AccountsReports()
        {
            SalesBill_Page.Goto();
            int totalAmountOfTheSalesBill = SalesBill_Page.Add_SalesBill();
            Account_Reports_Page.Goto();
            Account_Reports_Page.CheckCustomerBalanceFromReports(out int maden_Amount_For_BeforelastTransaction , out int da2en_Amount_For_lastTransaction);
            Assert.IsTrue(totalAmountOfTheSalesBill == maden_Amount_For_BeforelastTransaction && totalAmountOfTheSalesBill == da2en_Amount_For_lastTransaction, "T2_CheckSalesBill_With_AccountsReports Failed");
        }

        [TearDown]
        public static void Test_End()
        {
            Common.Driver.Close();

        }
    }
}