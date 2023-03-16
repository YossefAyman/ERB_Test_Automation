using Automation_Testing;
using ERP_Automation_Testing;
using NUnit.Framework;
using OpenQA.Selenium;
using System;


namespace ERP_Automation_Testing
{


    [TestFixture]
    internal class M4_Inventories_N4_ItemType_Test
    {
        [SetUp]
        public static void Test_Init()
        {
            Automation_Testing.Common.Driver.Manage().Window.Maximize();
            Login_Page.LoginAsAdmin();
            item_Typepage.Goto();
        }

        [Test]
        public static void T1_AddItemType()
        {

            try
            {
                item_Typepage.Add_itemtype(3);
                Assert.IsTrue(Common.Search(Data.itemTypes.itemTypeName) == Common.SEARCH_Result.EXIST, "T1_Add itemType Failed");
            }
            catch (Exception ex)
            {
                Assert.Warn("Message : \n" + ex.Message + "\nStack Trace : \n" + ex.StackTrace);
                Common.Driver.Close();

            }

        }
        [Test]
        public static void T2_EditItemType()
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
        public static void T3_DeleteItemType()
        {
            try
            {
                item_Typepage.Delete_itemsType(Data.itemTypes.itemTypeName);
                Assert.IsTrue(Common.Search(Data.itemTypes.itemTypeName) == Common.SEARCH_Result.NOT_EXIST, "T3_DeleteitemsType Failed");
            }
            catch (Exception ex)
            {
                Assert.Warn("Message : \n" + ex.Message + "\nStack Trace : \n" + ex.StackTrace);
                Common.Driver.Close();

            }
        }
        public static void  T4_ItemTypeHappyScenario()
            {

            }

      [Test]
        public static void T5_viewitemType()
        {
            try
            {
                item_Typepage.view_itemsType(Data.itemTypes.itemTypeName);
                //Assert.IsTrue(Common.Search(Data.itemTypes.itemTypeName) == Common.SEARCH_Result.NOT_EXIST, "T3_DeleteitemsType Failed");
            }
            catch (Exception ex)
            {
                Assert.Warn("Message : \n" + ex.Message + "\nStack Trace : \n" + ex.StackTrace);
                Common.Driver.Close();

            }
        }



        [TearDown]
        public static void Test_End()
        {
            Common.Driver.Close();

        }

    


    }
}

