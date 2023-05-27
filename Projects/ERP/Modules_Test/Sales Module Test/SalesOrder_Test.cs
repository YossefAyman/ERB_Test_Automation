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
    public class Sales_P4_SalesOrder
    {
        [OneTimeSetUp]
        public static void Test_Init()
        {
            if (Common.Driver == null)
            {
                Common.OpenDriver();
            }
            Common.Driver.Manage().Window.Maximize();
            /* Common.Driver.Manage().Window.Size = new Size(1280, 402); */
            Common.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            Login_Page.LoginAsAdmin();
            SalesOrder_Page.Goto();

        }

        [Test, Order(1)]
        public static void T1_Add_SalesOrder()
        {
            SalesOrder_Page.Add_SalesOrder();
            Assert.IsTrue(SalesOrder_Page.Search() == "Exist", "T1_Add_SalesOrder Failed");
        }

        [Test, Order(2)]
        public static void T2_Update_SalesOrder()
        {
            SalesOrder_Page.Edit_SalesOrder();
            Assert.IsTrue(SalesOrder_Page.Search() == "Exist", "T2_Update_SalesOrder Failed");
        }


        [Test, Order(3)]
        public static void T3_Delete_SalesOrder()
        {
            SalesOrder_Page.Delete_SalesOrder();
            Assert.IsTrue(SalesOrder_Page.Search() != "Exist", "T3_Delete_SalesOrder Failed");
        }


        [OneTimeTearDown]
        public static void Test_End()
        {
            Common.Driver.Dispose();
            Common.Driver = null;

        }
    }
}