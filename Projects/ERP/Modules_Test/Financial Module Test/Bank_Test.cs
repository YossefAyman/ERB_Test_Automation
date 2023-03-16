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
//using System.Windows.Forms;

namespace ERP_Automation_Testing
{
    [TestFixture]

    public class M3_Financial_N4_Bank_Test
    {
        [SetUp]
        public static void Test_Init()
        {
            Data.TestPassed = false;
            Login_Page.LoginAsAdmin();
            Bank_Page.Goto();
        }

        [Test]

        public static void T1_AddBank()
        {           
            Bank_Page.Add_Bank();
            if(Data.check(Bank_Page.Search(Data.Bank) == "Exist", "T1_Add_Bank Failed"))
            {
                Data.TestPassed = true;
            }
        }

        [Test]
        public static void T2_EditBank()
        {
            Bank_Page.Edit_Bank(Data.Bank, Data.Bank + "_edit");
            if(Data.check(Bank_Page.Search(Data.Bank + "_edit") == "Exist", "T2_EditBank Failed"))
            {
                Data.TestPassed = true;
            }

        }

        [Test]
        public static void T3_DeleteBank()
        {
            Bank_Page.Delete_Bank(Data.Bank + "_edit");
            if(Data.check(Bank_Page.Search(Data.Bank + "_edit") != "Exist", "T3_DeleteBank Failed"))
            {
                Data.TestPassed = true;
            }
        }

        [Test]
        public static void T4_Bank_HappyScenario()
        {
            /* Data.TestPassed = false;
             * add             
             * if(check(search()== exist,"add failed"))
             * {
             *  edit
             *  if(check(search()== exist,"edit failed"))
             *  {
             *   delete 
             *   if(check(search()== Notexist,"delete failed"))
             *     {
             *      Data.TestPassed = true;
             *     }
             *   
             *  }
             *             
             */
            Bank_Page.Add_Bank();
            if (Data.check(Bank_Page.Search(Data.Bank) == "Exist", "T1_Add_Bank Failed"))
            {
                Bank_Page.Edit_Bank(Data.Bank, Data.Bank + "_edit");

                if (Data.check(Bank_Page.Search(Data.Bank + "_edit") == "Exist", "T2_EditBank Failed"))
                {
                    Bank_Page.Delete_Bank(Data.Bank + "_edit");

                    if(Data.check(Bank_Page.Search(Data.Bank + "_edit") == "NotExist", "T3_DeleteBank Failed"))
                    {
                        Data.TestPassed = true;
                    }
                                  
                }               

            }

          
            //Bank_Page.Add_Bank();
            //Assert.IsTrue(Bank_Page.Search(Data.Bank) == "Exist", "T1_Add_Bank Failed");

            //Bank_Page.Edit_Bank(Data.Bank, Data.Bank + "_edit");
            //Assert.IsTrue(Bank_Page.Search(Data.Bank + "_edit") == "Exist", "T2_EditBank Failed");

            //Bank_Page.Delete_Bank(Data.Bank + "_edit");
            //Assert.IsTrue(Bank_Page.Search(Data.Bank + "_edit") == "NotExist", "T3_DeleteBank Failed");
        }

        
    }
}