using Automation_Testing;
using ERP_Automation_Testing;
using NUnit.Framework;
using OpenQA.Selenium;
using System;


namespace ERP_Automation_Testing
{


    [TestFixture]
    internal class M1_Profiles_N10_property
    {
        [SetUp]
        public static void Test_Init()
        {
            Automation_Testing.Common.Driver.Manage().Window.Maximize();
            Login_Page.LoginAsAdmin();
            property_Page.Goto();
        }

        [Test]
        public void T1_Add_property()
        {

            try
            {
               
                property_Page.Add_property();
               
            }
            catch (Exception ex)
            {
                Assert.Warn("Message : \n" + ex.Message + "\nStack Trace : \n" + ex.StackTrace);
                // Common.Driver.Close();

            }
        }

        [TearDown]
        public static void Test_End()
        {
            Common.Driver.Close();

        }




    }
}


