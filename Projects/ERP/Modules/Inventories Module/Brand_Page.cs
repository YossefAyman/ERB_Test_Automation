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
    class Brand_Page
    {
        static IWebDriver Driver = Automation_Testing.Common.Driver;
        // Selectors
        static By Add_Button = By.ClassName("btnAddItem");
        static By BrandName_TextBox = By.CssSelector("#Brand_BrandName");
        static By Save_Button = By.CssSelector("#mainModal > div > div > div.modal-body > div.modal-footer > input");
        static By Search_TextBox = By.ClassName("ng-valid");
        static By Search_Button = By.ClassName("btn-light"); 
        static By FisrtItemEdit_Button = By.ClassName("btnEditItem");
        static By FirstItemDelete_Button = By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button = By.ClassName("confirm");
        static By NumOfItems_Text = By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");

        public static void Goto()
        {
            Pages.BrandPage();
        }
        public static void Add_Brand() 
        {       
            Driver.FindElement(Add_Button).Click();
            time.Sleep(2000);
            Driver.FindElement(BrandName_TextBox).SendKeys(Data.Brand);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(3000);
        }

        public static void Edit_Brand(string brand, string newName) 
        {      
            Search(brand);
            time.Sleep(1000);
            Driver.FindElement(FisrtItemEdit_Button).Click();
            time.Sleep(1000);
            Driver.FindElement(BrandName_TextBox).Clear();
            Driver.FindElement(BrandName_TextBox).SendKeys(newName);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }

        public static void Delete_Brand(string brand) 
        {      
            Search(brand);
            time.Sleep(1000);
            Driver.FindElement(FirstItemDelete_Button).Click();
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
            
            if( Driver.FindElement(NumOfItems_Text).Text == "1 - 1 من 1" )
            {
                return "Exist";
            }
            else if ( Driver.FindElement(NumOfItems_Text).GetAttribute("class") == "ng-binding ng-hide")
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
