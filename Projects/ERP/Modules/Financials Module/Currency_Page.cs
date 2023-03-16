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
    class Currency_Page
    {
        static IWebDriver Driver = Automation_Testing.Common.Driver;

        // Selectors
        static By Add_Button = By.ClassName("btnAddItem");
        static By CurrencyName_TextBox = By.CssSelector("#Currency_CurrencyName");
        static By CurrencyValue_TextBox = By.CssSelector("#Currency_CurrencyValue");
        static By Save_Button = By.CssSelector("#mainModal > div > div > div.modal-body > div.modal-footer > input");
        static By Search_TextBox = By.ClassName("ng-valid");
        static By Search_Button = By.ClassName("btn-light"); 
        static By FirstItemEdit_Button = By.ClassName("btnEditItem");
        static By FirstItemDelete_Button = By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button = By.ClassName("confirm");
        static By NumOfItems_Text = By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");

        public static void Goto()
        {
            Pages.CurrencyPage();
            time.Sleep(2000);

        }
        public static void Add_Currency() 
	    { 
            Driver.FindElement(Add_Button).Click();
            time.Sleep(3000);
            Driver.FindElement(CurrencyName_TextBox).SendKeys(Data.Currency);
            Driver.FindElement(CurrencyValue_TextBox).SendKeys(Data.CurrencyValue);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(3000);
        }

        public static void Edit_Currency(string currency, string newName, string newValue) 
	    {
            Search(currency);
            time.Sleep(1000);
            Driver.FindElement(FirstItemEdit_Button).Click();
            time.Sleep(1000);
            Driver.FindElement(CurrencyName_TextBox).Clear();
            Driver.FindElement(CurrencyName_TextBox).SendKeys(newName);
            Driver.FindElement(CurrencyValue_TextBox).Clear();
            Driver.FindElement(CurrencyValue_TextBox).SendKeys(newValue);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(3000);
        }

        public static void Delete_Currency(string currency) 
	    {
            Search(currency);
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
