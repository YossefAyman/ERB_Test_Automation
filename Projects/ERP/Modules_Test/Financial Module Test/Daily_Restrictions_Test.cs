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
using TestAutomationDbModels;
using TestAutomationDbDataAccess;
//using System.Windows.Forms;

namespace ERP_Automation_Testing
{
    [TestFixture]
    class M1_Profiles_N1_Restructions_Test
    {
       /* [SetUp]
        public static void Test_Init()
        {
            Automation_Testing.Common.Driver.Manage().Window.Maximize();
            Login_Page.LoginAsAdmin();
            Daily_Restrictions.Goto();
        }*/
        [Test]

        public static void Test_N101()
        {
            int valueDebtor, valueCredit; 
            Daily_Restrictions.Verifing_debtor_Creditor_Values( "250" , out  valueDebtor , out  valueCredit );

        }

        [Test]
        public static void Test_N102()
        {
            /* Daily_Restrictions.GettingLastID();*/

            List<TestAutomationDbModels.TestConfig> testConfigs = TestAutomationDbDataAccess.TestConfig.GetList();
            var value = testConfigs.First();
            string Value_OF_Value = value.Value;


            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey( value );

        }

        [TearDown]
        public static void Test_End()
        {
            Common.Driver.Close();


        }
    }

}


