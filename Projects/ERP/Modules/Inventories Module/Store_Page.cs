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
    class Store_Page
    {
        static IWebDriver Driver = Automation_Testing.Common.Driver;

        // Selectors
        static By Add_Button = By.ClassName("btnAddItem");
        static By StoreName_TextBox = By.CssSelector("#Store_StoreName");
        static By Save_Button = By.CssSelector("#mainModal > div > div > div.modal-body > div.modal-footer > input");
        static By Search_TextBox = By.XPath("//*[@id=\"storeController\"]/div/section/div/div/div[2]/div/div/div[1]/div[1]/div/input");
        static By Search_Button = By.XPath("//*[@id=\"storeController\"]/div/section/div/div/div[2]/div/div/div[1]/div[1]/div/span/button");
        static By FirstItemEdit_Button = By.ClassName("btnEditItem");
        static By FirstItemDelete_Button = By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button = By.ClassName("confirm");
        static By NumOfItems_Text = By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");
        static By storeaddress = By.Id("Store_StoreAddress");

        public static void Goto()
        {
            Pages.StoresPage();
        }
        public static void Add_Store() 
	    {      
            Driver.FindElement(Add_Button).Click();
            time.Sleep(3000);
            Driver.FindElement(StoreName_TextBox).SendKeys(Data.Store);
            Driver.FindElement(storeaddress).SendKeys(Data.address);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(3000);
        }

        public static void Edit_Store(string store, string newName) 
	    {
            Driver.FindElement(FirstItemEdit_Button).Click();
            time.Sleep(1000);
            Driver.FindElement(StoreName_TextBox).Clear();
            Driver.FindElement(StoreName_TextBox).SendKeys(newName);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }

        public static void Delete_Store(string store) 
	    {       
            Driver.FindElement(FirstItemDelete_Button).Click();
            time.Sleep(2000);
            Driver.FindElement(DeleteConfirm_Button).Click();
            time.Sleep(2000);
      
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
