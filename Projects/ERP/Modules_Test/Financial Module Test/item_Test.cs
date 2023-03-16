using Automation_Testing;
using ERP_Automation_Testing;
using NUnit.Framework;
using OpenQA.Selenium;
using System;


namespace ERP_Automation_Testing
{


    [TestFixture]
    internal class M1_Profiles_N5_item_Test
    {
        [SetUp]
        public static void Test_Init()
        {
            Automation_Testing.Common.Driver.Manage().Window.Maximize();
            Login_Page.LoginAsAdmin();
            item_page.Goto();
        }

        [Test]
        public void T1_Add_item()
        {

            try
            {
                TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.item.Test_Index_Item_Page);
                Data.assets.Test_Index_Add_Asset = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_Item_Page");
                item_page.Add_item();
                Assert.IsTrue(Common.Search(Data.item.ItemName) == Common.SEARCH_Result.EXIST, "T1_Add item Failed");
            }
            catch (Exception ex)
            {
                Assert.Warn("Message : \n" + ex.Message + "\nStack Trace : \n" + ex.StackTrace);
            }


        }
        [Test]
        public void T2_Edit_items_()
        {
            try
            {
                item_page.Edit_items(Data.item.ItemName, Data.item.ItemName + "_edit");
                Assert.IsTrue(Common.Search(Data.item.ItemName + "_edit") == Common.SEARCH_Result.EXIST, "T2_Edititem Failed");
            }
            catch (Exception ex)
            {
                Assert.Warn("Message : \n" + ex.Message + "\nStack Trace : \n" + ex.StackTrace);
                Common.Driver.Close();

            }
        }
        [Test]
        public void T3_Deleteitems()
        {
            try
            {
                item_page.Delete_items(Data.item.ItemName);
                Assert.IsTrue(Common.Search(Data.item.ItemName ) == Common.SEARCH_Result.NOT_EXIST, "T3_Deleteitems Failed");
            }
            catch (Exception ex)
            {
                Assert.Warn("Message : \n" + ex.Message + "\nStack Trace : \n" + ex.StackTrace);
                Common.Driver.Close();

            }
        }

        [Test]
        public static void T4_ItemHappyScenario()
        {
            TestAutomationDbDataAccess.TestConfig.UpdateValueForSpacificKey(Data.assets.Test_Index_Add_Asset);
            Data.assets.Test_Index_Add_Asset = TestAutomationDbDataAccess.TestConfig.Get("Test_Index_Add_Asset");
            item_page.Add_item();
            if (Data.check(Common.Search(Data.item.ItemName) == Common.SEARCH_Result.EXIST, "T1_Add_Item_Test Failed"))
            {
                item_page.Edit_items(Data.item.ItemName, Data.item.ItemName + "_Edit");

                if (Data.check(Common.Search(Data.item.ItemName + "_Edit") == Common.SEARCH_Result.EXIST, "T2_Update_Item_Test Failed"))
                {
                    item_page.Delete_items(Data.item.ItemName);

                    Data.check(Common.Search(Data.item.ItemName) == Common.SEARCH_Result.NOT_EXIST, "T3_Delete_Item_Test Failed");


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