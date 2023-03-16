using Automation_Testing;
using ERP_Automation_Testing;
using NUnit.Framework;
using OpenQA.Selenium;
using System;


namespace ERP_Automation_Testing
{


    [TestFixture]
    internal class M1_Profiles_N9_receiptvoucher
    {
        [SetUp]
        public static void Test_Init()
        {
            Automation_Testing.Common.Driver.Manage().Window.Maximize();
            Login_Page.LoginAsAdmin();
            receiptvoucher_Page.Goto();
        }

        [Test]
        public void T1_Add_receiptvoucher()
        {

            try
            {
                int countValueBeforeAdding = Common.ReadCountText();
                receiptvoucher_Page.Add_Receiptvoucher();
                int countValueAfterAdding = Common.ReadCountText();
                Assert.IsTrue(countValueAfterAdding - countValueBeforeAdding == 1, "T1_Add receipvoucher Failed"); 
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



