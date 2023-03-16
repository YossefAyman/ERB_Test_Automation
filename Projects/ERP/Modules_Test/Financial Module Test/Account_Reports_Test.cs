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
    public class M3_Financial_N6_AccountReport
    {
        [SetUp]
        public static void Test_Init()
        {
           
            Login_Page.LoginAsAdmin();
            Account_Reports_Page.Goto();
        }

        [Test]
        public static void Test_Customer_Balance_From_Report()
        {
            Account_Reports_Page.CheckCustomerBalanceFromReports(out int maden_Amount_For_BeforelastTransaction, out int da2en_Amount_For_lastTransaction);
        }
    }
}