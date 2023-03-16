using Automation_Testing;
using ERP_Automation_Test.Projects.ERP.Modules.Profiles_Module;
using ERP_Automation_Testing;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
namespace ERP_Automation_Test.Projects.ERP.Modules_Test
{


    [Testfixture]
    internal class M7_assets_N7_AddingAssets_Test
    {

        [SetUp]

        public static void Test_Init()
        {
            Automation_Testing.Common.Driver.Manage().Window.Maximize();
            Login_Page.LoginAsAdmin();
            Assets__page.Goto();




        }

        [Test]
        public static void T1_Addassets()
        {

            try
            {
                int countValueBeforeAdding = Common.ReadCountText();//0
                Assets__page.AddAssets();
                int countValueAfterAdding = Common.ReadCountText();//1
                Assert.IsTrue(countValueAfterAdding - countValueBeforeAdding == 1, "T1_Add permission Failed");



            }
            catch (Exception ex)
            {
                Assert.Warn("Message : \n" + ex.Message + "\nStack Trace : \n" + ex.StackTrace);
                Common.Driver.Close();

            }





        }

    }



}






























































            

            


    


    

