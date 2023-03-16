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
namespace ERP_Automation_Testing
{

    [TestFixture]
   public class M7_Estate_N1_BanReason_Test
    {
        static Data.BanReason banReason = new Data.BanReason();
        [SetUp]
        public static void Test_Init()
        {
            Automation_Testing.Common.Driver.Manage().Window.Maximize();
            Login_Page.LoginAsAdmin();
           BanReason_Page.Goto();
        }
        [Test]

        public static void T1_AddBanReason()
        {
           
            BanReason_Page.Add_BanReason(banReason);
        }
        [Test]
        public static void T2_EditBanReason()
        {
            BanReason_Page.Edit_BanReason(banReason.Banresaon_name, banReason.Banresaon_name+"_edit");
        }
        [Test]
        public static void T3_DeleteBanReason()
        {
            BanReason_Page.Delete_BanReason(banReason.Banresaon_name+ "_edit");
        }
        [Test]
        public static void T4_BanReason_HappyScenario()
        {
            /*
             * add             
             * if(check(search()== exist,"add failed"))
             * {
             *  edit
             *  if(check(search()== exist,"edit failed"))
             *  {
             *   delete
             *   check(search()== Notexist,"delete failed")
             *   
             *  }
             *             
             */
           

            BanReason_Page.Add_BanReason(banReason);
            if (Data.check(BanReason_Page.Search(banReason.Banresaon_name) == "Exist", "T1_Add_BanReason Failed"))
            {
                BanReason_Page.Edit_BanReason(banReason.Banresaon_name, banReason.Banresaon_name + "_edit");

                if (Data.check(BanReason_Page.Search(banReason.Banresaon_name + "_edit") == "Exist", "T2_EditBanReason Failed"))
                {
                    BanReason_Page.Delete_BanReason(banReason.Banresaon_name + "_edit");

                    Data.check(BanReason_Page.Search(banReason.Banresaon_name + "_edit") == "NotExist", "T3_DeleteBanReason Failed");


                }

            }

            //BanReason_Page.Add_BanReason();
            //Assert.IsTrue(BanReason_Page.Search(Data.BanReason) == "Exist", "T1_Add_BanReason Failed");

            //BanReason_Page.Edit_BanReason(Data.BanReason, Data.BanReason + "_edit");
            //Assert.IsTrue(BanReason_Page.Search(Data.BanReason + "_edit") == "Exist", "T2_EditBanReason Failed");

            //BanReason_Page.Delete_BanReason(Data.BanReason + "_edit");
            //Assert.IsTrue(BanReason_Page.Search(Data.BanReason + "_edit") == "NotExist", "T3_DeleteBanReason Failed");
        }


    }
}
