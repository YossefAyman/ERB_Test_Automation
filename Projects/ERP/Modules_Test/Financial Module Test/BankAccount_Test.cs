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

    public class M3_Financial_N5_BankAccount_Test
    {
        static Data.BankAccount BankAccount = new Data.BankAccount();

        [SetUp]
        public static void Test_Init()
        {
            Login_Page.LoginAsAdmin();
            BankAccount_Page.Goto();
        }

        [Test]

        public static void T1_AddBankAccount()
        {
            BankAccount_Page.Add_BankAccount(BankAccount);
            Assert.IsTrue(BankAccount_Page.Search(BankAccount.BankAccountCode) == "Exist", "T1_Add_BankAccount Failed");
        }

        [Test]
        public static  void T2_EditBankAccount()
        {
            BankAccount_Page.Edit_BankAccount(BankAccount.BankAccountCode, BankAccount.BankAccountCode + "_edit");
            Assert.IsTrue(BankAccount_Page.Search(BankAccount.BankAccountCode + "_edit") == "Exist", "T2_EditBankAccount Failed");

        }

        [Test]
        public static void T3_DeleteBankAccount()
        {
            BankAccount_Page.Delete_BankAccount(BankAccount.BankAccountCode + "_edit");
            Assert.IsTrue(BankAccount_Page.Search(BankAccount.BankAccountCode + "_edit") != "Exist", "T3_DeleteBankAccount Failed");
        }

        [Test]
        public static void T4_BankAccount_HappyScenario()
        {

            BankAccount_Page.Add_BankAccount(BankAccount);
            if (Data.check(BankAccount_Page.Search(BankAccount.BankAccountCode) == "Exist", "T1_Add_BankAccount Failed"))
            {
                BankAccount_Page.Edit_BankAccount(BankAccount.BankAccountCode, BankAccount.BankAccountCode + "_edit");

                if (Data.check(BankAccount_Page.Search(BankAccount.BankAccountCode + "_edit") == "Exist", "T2_EditBankAccount Failed"))
                {
                    BankAccount_Page.Delete_BankAccount(BankAccount.BankAccountCode + "_edit");

                    Data.check(BankAccount_Page.Search(BankAccount.BankAccountCode + "_edit") == "NotExist", "T3_DeleteBankAccount Failed");


                }

            }
          

        }

       
    }
}
