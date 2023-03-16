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
    class Bank_Page
    {
        static IWebDriver Driver = Automation_Testing.Common.Driver;

        // Selectors
        static By Add_Button = By.ClassName("btnAddItem");
        static By BankName_TextBox = By.Id("Bank_BankName");
        static By Save_Button = By.CssSelector("#mainModal > div > div > div.modal-body > div.modal-footer > input");
        static By Search_TextBox = By.ClassName("ng-valid");
        static By Search_Button = By.ClassName("btn-light"); 
        static By EditFirstItem_Button = By.ClassName("btnEditItem");
        static By DeleteFirstItem_Button = By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button = By.ClassName("confirm");
        static By NumOfItems_Text = By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");

        public static void Goto()
        {
            Pages.BankPage();
            time.Sleep(2000);

        }
        public static void Add_Bank()
        {
            Driver.FindElement(Add_Button).Click();
            //Data.Wait.Until(ExpectedConditions.ElementIsVisible(BankName_TextBox));
            Driver.FindElement(BankName_TextBox).SendKeys(Data.Bank);
            Driver.FindElement(Save_Button).Click();           
            time.Sleep(3000);
        }

        public static void Edit_Bank(string bank, string newName)
        {            
            Search(bank);
            time.Sleep(1000);
            Driver.FindElement(EditFirstItem_Button).Click();
            Driver.FindElement(BankName_TextBox).Clear();
            Driver.FindElement(BankName_TextBox).SendKeys(newName);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(3000);

        }

        public static void Delete_Bank(string bank)
        {
            Search(bank);
            time.Sleep(1000); 
            Driver.FindElement(DeleteFirstItem_Button).Click();
            time.Sleep(1000); 
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
