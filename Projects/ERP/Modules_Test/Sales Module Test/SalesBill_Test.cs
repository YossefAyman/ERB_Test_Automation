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

    class M6_Sales_N1_SalesBill_Test
    {
        [SetUp]
        public static void Test_Init()
        {
            Automation_Testing.Common.Driver.Manage().Window.Maximize();
            Login_Page.LoginAsAdmin();
            SalesBill_Page.Goto();
        }

        [Test]

        public void T1_Add_SalesBill_Test()
        {
            SalesBill_Page.Add_SalesBill();

        }

        [TearDown]
        public static void Test_End()
        {
            Common.Driver.Close();

        }

    }
}
