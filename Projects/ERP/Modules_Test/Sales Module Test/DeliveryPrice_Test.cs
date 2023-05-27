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
    public class Sales_P3_DeliveryPrice
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
            Common.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Login_Page.LoginAsAdmin();
            DeliveryPrice_Page.Goto();

        }

        [Test, Order(1)]
        public static void T1_Add_DeliveryPrice()
        {
            DeliveryPrice_Page.Add_DliveryPrice();
            Assert.IsTrue(DeliveryPrice_Page.Search() == "Exist", "T1_Add_DeliveryPrice Failed");
        }

        [Test, Order(2)]
        public static void T2_Update_DeliveryPrice()
        {
            DeliveryPrice_Page.Edit_DliveryPrice();
            Assert.IsTrue(DeliveryPrice_Page.Search() == "Exist", "T2_Update_DeliveryPrice Failed");
        }


        [Test, Order(3)]
        public static void T3_Delete_DeliveryPrice()
        {
            DeliveryPrice_Page.Delete_DliveryPrice();
        }


        [OneTimeTearDown]
        public static void Test_End()
        {
            Common.Driver.Dispose();
            Common.Driver = null;

        }
    }
}