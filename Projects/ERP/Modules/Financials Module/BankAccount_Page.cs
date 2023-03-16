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
    class BankAccount_Page
    {
        static IWebDriver Driver = Automation_Testing.Common.Driver;

        // Selectors
        static By Add_Button = By.ClassName("btnAddItem");
        static By BankList_SelectToggle = By.CssSelector("#FormManager > div > div:nth-child(1) > div > div > a > span.select2-arrow.ui-select-toggle");
        static By BankName_TextBox = By.CssSelector("#FormManager > div > div:nth-child(1) > div > div > div > div > input");
        static By BankAccountCode_TextBox = By.CssSelector("#BankAccount_BankAccountCode");
        static By BankAccountNumber_TextBox = By.CssSelector("#BankAccount_BankAccountNumber");
        static By CheckStart_TextBox = By.CssSelector("#BankAccount_CheckStart");
        static By FirstCheckNumber_TextBox = By.CssSelector("#BankAccount_FirstCheckNumber");
        static By PaymentCardCommission_TextBox = By.CssSelector("#BankAccount_PaymentCardCommission");
        static By Save_Button = By.CssSelector("#mainModal > div > div > div.modal-body > div.modal-footer > input");
       // static By Search_TextBox = By.ClassName("ng-valid");
        static By Search_TextBox = By.XPath("//*[@placeholder=\"بحث\"]");
        static By Search_Button = By.ClassName("btn-light"); 
        static By FirstItemEdit_Button = By.ClassName("btnEditItem");
        static By FirstItemDelete_Button = By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button = By.ClassName("confirm");
        static By NumOfItems_Text = By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");

        public static void  Goto()
        {
            Pages.BankAccountPage();
            time.Sleep(2000);
        }

        public static void Add_BankAccount(Data.BankAccount BankAccount) 
	    {                   
            Driver.FindElement(Add_Button).Click();
            time.Sleep(3000);
            Driver.FindElement(BankList_SelectToggle).Click();
            Driver.FindElement(BankName_TextBox).SendKeys(BankAccount.Bank + Keys.Enter);
            Driver.FindElement(BankAccountCode_TextBox).SendKeys(BankAccount.BankAccountCode);
            Driver.FindElement(BankAccountNumber_TextBox).SendKeys(BankAccount.BankAccountNumber);
            Driver.FindElement(CheckStart_TextBox).SendKeys(BankAccount.CheckStart);
            Driver.FindElement(FirstCheckNumber_TextBox).SendKeys(BankAccount.FirstCheckNumber);
            Driver.FindElement(PaymentCardCommission_TextBox).Clear();
            Driver.FindElement(PaymentCardCommission_TextBox).SendKeys(BankAccount.PaymentCardCommission);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(5000);
        }

        public static void Edit_BankAccount(string bankAccountCode, string newBankAccountCode) 
	    {
            Search(bankAccountCode);
            Driver.FindElement(FirstItemEdit_Button).Click();
            time.Sleep(1000);
            Driver.FindElement(BankAccountCode_TextBox).Clear();
            Driver.FindElement(BankAccountCode_TextBox).SendKeys(newBankAccountCode);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(3000);
        }


        public static void Delete_BankAccount(string bankAccountCode) 
	    {
            Search(bankAccountCode);
            Driver.FindElement(FirstItemDelete_Button).Click();
            time.Sleep(2000);
            Driver.FindElement(DeleteConfirm_Button).Click();
            time.Sleep(3000);      
        }

        public static string Search(string item)
        {
            Driver.FindElement(Search_TextBox).Clear();
            Driver.FindElement(Search_TextBox).SendKeys(item);
            Driver.FindElement(Search_Button).Click();
            time.Sleep(1000);

            if (Driver.FindElement(NumOfItems_Text).Text == "1 - 1 من 1")
            {
                return "Exist";
            }
            else if (Driver.FindElement(NumOfItems_Text).GetAttribute("class") == "ng-binding ng-hide")
            {
                return "NotExist";
            }
            else
            {
                return "Repeated";
            }
        }
    }
}
