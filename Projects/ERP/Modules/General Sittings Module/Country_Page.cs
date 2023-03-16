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
    class Country_Page
    {
        static IWebDriver Driver = Automation_Testing.Common.Driver;

        // Selectors
        static By Add_Button = By.ClassName("btnAddItem");
        static By CountryName_TextBox = By.CssSelector("#Country_CountryName");
        static By Nationality_TextBox = By.CssSelector("#Country_Nationality");
        static By Save_Button = By.CssSelector("#mainModal > div > div > div.modal-body > div.modal-footer > input");
        static By Search_TextBox = By.ClassName("ng-valid");
        static By Search_Button = By.ClassName("btn-light"); 
        static By FirstCountryEdit_Button = By.ClassName("btnEditItem");
        static By FirstCountryDelete_Button = By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button = By.ClassName("confirm");
        static By NumOfItems_Text = By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");

        
        public static void Goto()
        {
            Pages.CountriesPage();   
        }

        public static void Add_Country() 
        {       
            Driver.FindElement(Add_Button).Click();
            time.Sleep(1000);
            Driver.FindElement(CountryName_TextBox).SendKeys(Data.Place.CountryName);
            Driver.FindElement(Nationality_TextBox).SendKeys(Data.Place.Nationality);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(3000);        
        }

           
        public static void Edit_Country(string country_name, string new_name, string new_nationality)
        {
            Search(country_name);
            time.Sleep(3000);

            Driver.FindElement(FirstCountryEdit_Button).Click();
            time.Sleep(3000);

            Driver.FindElement(CountryName_TextBox).Clear();
            Driver.FindElement(CountryName_TextBox).SendKeys(new_name);
            Driver.FindElement(Nationality_TextBox).Clear();
            Driver.FindElement(Nationality_TextBox).SendKeys(new_nationality);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(3000);
        }

                
        public static void Delete_Country(string country_name)
        {
            Search(country_name);
            time.Sleep(3000);
            Driver.FindElement(FirstCountryDelete_Button).Click();
            time.Sleep(3000);
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
