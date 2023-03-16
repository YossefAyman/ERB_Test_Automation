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

    public class M3_Financial_N1_Currency_Test
    {

        [SetUp]
        public static void Test_Init()
        {        
            Login_Page.LoginAsAdmin();
            Currency_Page.Goto();
        }

        [Test]

        public static void T1_AddCurrency()
        {
            Currency_Page.Add_Currency();
            Assert.IsTrue(Currency_Page.Search(Data.Currency) == "Exist", "T1_AddCurrency Failed");
        }

        [Test]
        public static void T2_EditCurrency()
        {
            Currency_Page.Edit_Currency(Data.Currency, Data.Currency + "_edit",Data.CurrencyValue + "1");
            Assert.IsTrue(Currency_Page.Search(Data.Currency + "_edit") == "Exist", "T2_EditCurrency Failed");

        }

        [Test]
        public static void T3_DeleteCurrency()
        {
            Currency_Page.Delete_Currency(Data.Currency + "_edit");
            Assert.IsTrue(Currency_Page.Search(Data.Currency + "_edit") != "Exist", "T3_DeleteCurrency Failed");
        }

        [Test]
        public static void T4_CurrencyHappyScenario()
        {
            Currency_Page.Add_Currency();
            if (Data.check(Currency_Page.Search(Data.Currency) == "Exist", "T1_Add_Currency Failed"))
            {
                Currency_Page.Edit_Currency(Data.Currency, Data.Currency + "_edit", Data.CurrencyValue + "1");

                if (Data.check(Currency_Page.Search(Data.Currency + "_edit") == "Exist", "T2_EditCurrency Failed"))
                {
                    Currency_Page.Delete_Currency(Data.Currency + "_edit");

                    Data.check(Currency_Page.Search(Data.Currency + "_edit") == "NotExist", "T3_DeleteCurrency Failed");


                }

            }
           

        }

      
    }
}
