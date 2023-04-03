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
//using System.Windows.Forms;

namespace ERP_Automation_Testing
{
    [TestFixture]
    class Test_Test
    {

        [Test]

        public static void hamadaTest()
        {

            Automation_Testing.Common.Driver.Manage().Window.Maximize();
            Login_Page.LoginAsAdmin();

            Assets_page.Goto();
            //item_page.Goto();
        }
    }
}