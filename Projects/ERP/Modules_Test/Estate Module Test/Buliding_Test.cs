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

namespace ERP_Automation_Testing
{
    [TestFixture]
   public class M7_Estate_N2_Buliding_Test
    {
        static Data.Buliding buliding = new Data.Buliding();
        [SetUp]
        public static void Test_Init()
        {
            Automation_Testing.Common.Driver.Manage().Window.Maximize();
            Login_Page.LoginAsAdmin();
            Buliding_page.Goto();
        }
        [Test]
        public static void T1_AddBuliding()
        {
            Buliding_page.Add_Building(buliding);

        }
    }
}
