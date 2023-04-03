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
using Automation_Testing;
//using System.Windows.Forms;


namespace LMS_Automation_Testing
{
    class City_Page
    {
        static IWebDriver Driver = Automation_Testing.Common.Driver;

        // Selectors
        static By CountryList_SelectToggle = By.CssSelector("#cityController > div > section > div > div > div.main-box-content > div > div > div.row.sm-gutters.ng-isolate-scope > div:nth-child(1) > div > div > a > span.select2-arrow.ui-select-toggle");
        static By CountryName_TextBox = By.CssSelector("#cityController > div > section > div > div > div.main-box-content > div > div > div.row.sm-gutters.ng-isolate-scope > div:nth-child(1) > div > div > div > div > input");
        static By AreaList_SelectToggle = By.CssSelector("#cityController > div > section > div > div > div.main-box-content > div > div > div.row.sm-gutters.ng-isolate-scope > div:nth-child(2) > div > div > a > span.select2-arrow.ui-select-toggle");
        static By AreaName_TextBox = By.CssSelector("#cityController > div > section > div > div > div.main-box-content > div > div > div.row.sm-gutters.ng-isolate-scope > div:nth-child(2) > div > div > div > div > input");
        static By Add_Button = By.ClassName("btnAddItem");
        static By CityName_TextBox = By.CssSelector("#City_CityName");
        static By Save_Button = By.CssSelector("#mainModal > div > div > div.modal-body > div.modal-footer > input");
        static By Search_TextBox = By.XPath("//*[@placeholder=\"بحث\"]");
        static By Search_Button = By.ClassName("btn-light"); 
        static By FirstItemEdit_Button = By.ClassName("btnEditItem");
        static By FirstItemDelete_Button = By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button = By.ClassName("confirm");
        static By NumOfItems_Text = By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");

        public static void Goto()
        {
            Pages.CityPage();
        }
        public static void Add_City() 
	    {    
            //###### First , a country must be selected from the list before adding an area ##########
            Driver.FindElement(CountryList_SelectToggle).Click();
            Driver.FindElement(CountryName_TextBox).SendKeys(Data.Place.CountryName + "\n");
            //###### Second , an Area must be selected from the list before adding a City ##########
            Driver.FindElement(AreaList_SelectToggle).Click();
            Driver.FindElement(AreaName_TextBox).SendKeys(Data.Place.AreaName + "\n");

            Driver.FindElement(Add_Button).Click();
            time.Sleep(1000);
            Driver.FindElement(CityName_TextBox).SendKeys(Data.Place.CityName);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(3000);
        }

        public static void Edit_City(string city, string newName) 
	    {       
            Driver.FindElement(FirstItemEdit_Button).Click();
            time.Sleep(3000);
            Driver.FindElement(CityName_TextBox).Clear();
            Driver.FindElement(CityName_TextBox).SendKeys(newName);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(3000);
        }

        public static void Delete_City(string city) 
	    {
            Driver.FindElement(FirstItemDelete_Button).Click();
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
