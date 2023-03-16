using Automation_Testing;
using ERP_Automation_Testing;
using NUnit.Framework;
using OpenQA.Selenium;
using System;


namespace ERP_Automation_Testing
{


    [TestFixture]
    internal class M5_Inventories_N5_Addingpermission_Test
    {
        [SetUp]
        public static void Test_Init()
        {
            Automation_Testing.Common.Driver.Manage().Window.Maximize();
            Login_Page.LoginAsAdmin();
            Addingpermission_page.Goto();
        }

        [Test]
        public static void T1_Addpermission()
        {

            try
            {


                int countValueBeforeAdding = Common.ReadCountText();//0
                Addingpermission_page.Add_AddingPermission();
                int countValueAfterAdding = Common.ReadCountText();//1


                Assert.IsTrue(countValueAfterAdding - countValueBeforeAdding == 1, "T1_Add permission Failed");

               
            }
            catch (Exception ex)
            {
                Assert.Warn("Message : \n" + ex.Message + "\nStack Trace : \n" + ex.StackTrace);
                Common.Driver.Close();

            }
            
        }

        [Test]

        public static void T2_EditAddingpermission()
        {
            try
            {
                Addingpermission_page.edit_Addingpermission();
                Assert.IsTrue(Common.Search(Data.item.ItemName + "_edit") == Common.SEARCH_Result.EXIST, "T2_Edititem Failed");
            }
            catch (Exception ex)
            {
                Assert.Warn("Message : \n" + ex.Message + "\nStack Trace : \n" + ex.StackTrace);
                Common.Driver.Close();

            }
        }

       
  
        [Test]
        public static void T3_cancelAddingpermission()
        {
            try
            {
                Addingpermission_page.cancel_Addingpermission();
               // Assert.IsTrue(Common.Search(Data.itemTypes.itemTypeName) == Common.SEARCH_Result.NOT_EXIST, "T3_DeleteitemsType Failed");
            }
            catch (Exception ex)
            {
                Assert.Warn("Message : \n" + ex.Message + "\nStack Trace : \n" + ex.StackTrace);
                Common.Driver.Close();

            }
        }

        [Test]
        public static void t5_viewaddingpermission()
        {
            try
            {
                Addingpermission_page.viewAddingpermission();
                Assert.IsTrue(Common.Search(Data.itemTypes.itemTypeName) == Common.SEARCH_Result.NOT_EXIST, "T3_DeleteitemsType Failed");
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

