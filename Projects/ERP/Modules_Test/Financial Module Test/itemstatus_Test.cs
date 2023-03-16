using Automation_Testing;
using ERP_Automation_Testing;
using NUnit.Framework;
using OpenQA.Selenium;
using System;


namespace ERP_Automation_Testing
{


    [TestFixture]
    internal class M1_Profiles_N8_item_status
    {
        [SetUp]
        public static void Test_Init()
        {
            Automation_Testing.Common.Driver.Manage().Window.Maximize();
            Login_Page.LoginAsAdmin();
            itemstatus_page.Goto();
        }

        [Test]
        public void T1_Add_itemstatus()
        {

            try
            {
                itemstatus_page.Add_itemstatus();
                Assert.IsTrue(Common.Search(Data.itemstatusName.itemstatusname) == Common.SEARCH_Result.EXIST, "T1_Add item Failed");
            }
            catch (Exception ex)
            {
                Assert.Warn("Message : \n" + ex.Message + "\nStack Trace : \n" + ex.StackTrace);
                // Common.Driver.Close();

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
                Assert.IsTrue(Common.Search(Data.item.ItemName) == Common.SEARCH_Result.NOT_EXIST, "T3_Deleteitems Failed");
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