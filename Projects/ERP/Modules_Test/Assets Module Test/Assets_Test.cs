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

namespace ERP_Automation_Testing
{
    [TestFixture]
    public class M9_Assets_N1_Assets_AED
    {
        [SetUp]
        public static void Test_Init()
        {
            Automation_Testing.Common.Driver.Manage().Window.Maximize();
            Login_Page.LoginAsAdmin();
            Assets_page.Goto();
        }

        [Test]
        public static void T1_Addassets_Assert()
        {

            try
            {
                //int countValueBeforeAdding = Common.ReadCountText();//0
                Assets__page.AddAssets();
                //int countValueAfterAdding = Common.ReadCountText();//1
                //Assert.IsTrue(countValueAfterAdding - countValueBeforeAdding == 1, "T1_Add permission Failed");



            }
            catch (Exception ex)
            {
                Assert.Warn("Message : \n" + ex.Message + "\nStack Trace : \n" + ex.StackTrace);
                Common.Driver.Close();

            }





        }

        [Test]

        public static void T1_Add_Asset_Test()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.assets.Test_Index_Add_Asset);
            Data.assets.Test_Index_Add_Asset = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_Add_Asset");
            Assets_page.AddAssets();
            Assert.IsTrue(Assets_page.Search(Data.assets.OriginName) == "Exist", "T1_Add_Asset_Test Failed");
        }

        [Test]
        public static void T2_Update_Asset_Test()
        {
            Assets_page.Edit_Asset(Data.assets.OriginName , Data.assets.OriginName +"_Edit" , (int.Parse(Data.assets.Thepriceofassets) + 100).ToString());
            Assert.IsTrue(Assets_page.Search(Data.assets.OriginName + "_Edit") == "Exist", "T2_Update_Asset_Test Failed");
        }


        [Test]  
        public static void T3_Delete_Asset_Test()
        {
            Assets_page.Delete_Asset(Data.assets.OriginName);
            Assert.IsTrue(Assets_page.Search(Data.assets.OriginName) != "Exist", "T3_Delete_Asset_Test Failed");


        }

        [Test]
        public static void T4_AssetHappyScenario()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.assets.Test_Index_Add_Asset);
            Data.assets.Test_Index_Add_Asset = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_Add_Asset");
            Assets_page.AddAssets();
            if (Data.check(Assets_page.Search(Data.assets.OriginName) == "Exist", "T1_Add_Asset_Test Failed"))
            {
                Assets_page.Edit_Asset(Data.assets.OriginName, Data.assets.OriginName + "_Edit", (int.Parse(Data.assets.Thepriceofassets) + 100).ToString());

                if (Data.check(Assets_page.Search(Data.assets.OriginName + "_Edit") == "Exist", "T2_Update_Asset_Test Failed"))
                {
                    Assets_page.Delete_Asset(Data.assets.OriginName);

                    Data.check(Assets_page.Search(Data.assets.OriginName) == "NotExist", "T3_Delete_Asset_Test Failed");


                }
                
            }

        }


        [TearDown]
        public static void Test_End()
        {
            Common.Driver.Close();

        }

    }
}
