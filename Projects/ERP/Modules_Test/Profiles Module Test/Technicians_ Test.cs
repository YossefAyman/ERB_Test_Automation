using Automation_Testing;
using ERP_Automation_Testing;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace ERP_Automation_Testing
{


    [TestFixture]
    class M1_Profiles_N4_Technicians_Test
    {
        [SetUp]
        public static void Test_Init()
        {
            Automation_Testing.Common.Driver.Manage().Window.Maximize();
            Login_Page.LoginAsAdmin();
            Technicians_page.Goto();
        }

        [Test]
        public void T1_AddTechnicians()
        {
          
             try
            {
                Technicians_page.Add_Technicians(5);
                Assert.IsTrue(Common.Search(Data.Technicians.Name) == Common.SEARCH_Result.EXIST, "T1_Add Technician Failed");
            }
            catch (Exception ex)
            {
                Assert.Warn("Message : \n" + ex.Message + "\nStack Trace : \n" + ex.StackTrace);
                Common.Driver.Close();

            }

         
        }
        [Test]
        public void T2_DeleteTechnicians()
        {
            try
            {
                Technicians_page.Delete_Technicians(Data.Technicians.Name);
                Assert.IsTrue(Technicians_page.Search(Data.Technicians.Name) == "NotExist", "T3_DeleteTechnicians Failed");
            }
            catch (Exception ex)
            {
                Assert.Warn("Message : \n" + ex.Message + "\nStack Trace : \n" + ex.StackTrace);
                Common.Driver.Close();

            }
        }
        [Test]
        public void T3_Edit_Technicians_()
        {
            try
            {
                Technicians_page.Edit_Technicians(Data.Technicians.Name, Data.Technicians.Name + "_edit");
                Assert.IsTrue(Common.Search(Data.Technicians.Name + "_edit") == Common.SEARCH_Result.EXIST, "T2_EditTechniv Failed");
            }
            catch (Exception ex)
            {
                Assert.Warn("Message : \n" + ex.Message + "\nStack Trace : \n" + ex.StackTrace);
                Common.Driver.Close();

            }

        }
        [Test]
        public void T4_Activatemultiselect_()
        {
            try
            {
                Technicians_page.MultiSelect_Technicians();
                Technicians_page.ActivateSelected_Technicians();
                Technicians_page.DisactivateSelected_Technicians();
                Technicians_page.DeleteSelected_Technicians();
                Assert.IsTrue(Technicians_page.Search(Data.Technicians.Name) == "NotExist", "T3_DeleteTechnicians Failed");
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
         //   Common.Driver.Close();

        }

    }


}