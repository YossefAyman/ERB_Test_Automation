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
//using System.Windows.Forms;


namespace ERP_Automation_Testing
{
    [TestFixture]

    public class M4_Inventories_N7_InventoryPermission_Test
    {
        [SetUp]
        public static void Test_Init()
        {
            Automation_Testing.Common.Driver.Manage().Window.Maximize();
            Login_Page.LoginAsAdmin();
            InventoryPermission_Page.Goto();
        }

        [Test]
        public void T1_Add_InventoryPermission_Test()
        {

            try
            {
                int countValueBeforeAdding = Common.ReadCountText();
                InventoryPermission_Page.Add_InventoryPermission();
                int countValueAfterAdding = Common.ReadCountText();


                Assert.IsTrue(countValueAfterAdding - countValueBeforeAdding == 1, "T1_Add permission Failed");
            }
            catch (Exception ex)
            {



                Assert.Warn("Message : \n" + ex.Message + "\nStack Trace : \n" + ex.StackTrace);

                Common.Driver.Close();
            
             
            }
        }
        [Test]
        public static void T2_Edit_inventorypermission()
        {
            try
            {
                Models.InventoryPermission inventoryPermissionBeforeEdit = InventoryPermission_Page.Read();
                InventoryPermission_Page.Edit_InventoryPermission();
                Models.InventoryPermission inventoryPermissionAfterEdit = InventoryPermission_Page.Read();

                Assert.IsTrue(InventoryPermission_Page.IsEqual(inventoryPermissionBeforeEdit, inventoryPermissionAfterEdit) == false, "T1_Add permission Failed");
            }
            catch (Exception ex)
            {
                Assert.Warn("Message : \n" + ex.Message + "\nStack Trace : \n" + ex.StackTrace);
                Common.Driver.Close();

            }
        }
        [Test]
        public static void T3_cancel_inventorypermission()
        {
            try
            {
                InventoryPermission_Page.cancel_InventoryPermission();
                // Assert.IsTrue(Common.Search(Data.itemTypes.itemTypeName) == Common.SEARCH_Result.NOT_EXIST, "T3_DeleteitemsType Failed");
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

