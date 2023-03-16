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

    public class M3_Financial_N2_Tax_Test
    {
        [SetUp]
        public static void Test_Init()
        {
            Login_Page.LoginAsAdmin();
            Tax_Page.Goto();
        }

        [Test]

        public static void T1_AddTax()
        {
            Tax_Page.Add_Tax();
            Assert.IsTrue(Tax_Page.Search(Data.Tax) == "Exist", "T1_Add_Tax Failed");
        }

        [Test]
        public static void T2_EditTax()
        {
            Tax_Page.Edit_Tax(Data.Tax, Data.Tax + "_edit", (Data.TaxValue + 3).ToString());
            Assert.IsTrue(Tax_Page.Search(Data.Tax + "_edit") == "Exist", "T2_Edit_Tax Failed");

        }

        [Test]
        public static void T3_DeleteTax()
        {
            Tax_Page.Delete_Tax(Data.Tax + "_edit");
            Assert.IsTrue(Tax_Page.Search(Data.Tax + "_edit") != "Exist", "T3_Delete_Tax Failed");
        }

        [Test]
        public static void T4_TaxHappyScenario()
        {
            Tax_Page.Add_Tax();
            if (Data.check(Tax_Page.Search(Data.Tax) == "Exist", "T1_Add_Tax Failed"))
            {
                Tax_Page.Edit_Tax(Data.Tax, Data.Tax + "_edit", (Data.TaxValue + 3).ToString());

                if (Data.check(Tax_Page.Search(Data.Tax + "_edit") == "Exist", "T2_EditTax Failed"))
                {
                    Tax_Page.Delete_Tax(Data.Tax + "_edit");

                    Data.check(Tax_Page.Search(Data.Tax + "_edit") == "NotExist", "T3_DeleteTax Failed");


                }

            }
           
        }


    }
}
