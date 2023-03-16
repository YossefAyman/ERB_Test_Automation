#define CHECK

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
    class Area_Page
    {
        static IWebDriver Driver = Automation_Testing.Common.Driver;

        // Selectors
        static By GeneralSittings_SideMenuItem = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(10) > a");
        static By Areas_SideMenuSubItem = By.CssSelector("body > div > aside > div > ul > li:nth-child(10) > ul > li:nth-child(2) > a");
        static By CountryList_SelectToggle = By.CssSelector("#areaController > div > section > div > div > div.main-box-content > div > div > div.row.sm-gutters.ng-isolate-scope > div:nth-child(1) > div > div > a");
        static By CountryName_TextBox = By.CssSelector("#areaController > div > section > div > div > div.main-box-content > div > div > div.row.sm-gutters.ng-isolate-scope > div:nth-child(1) > div > div > div > div > input");
        static By Add_Button = By.ClassName("btnAddItem");
        static By AreaName_TextBox = By.CssSelector("#Area_AreaName");
        static By Save_Button = By.CssSelector("#mainModal > div > div > div.modal-body > div.modal-footer > input");
        //static By Search_TextBox = By.ClassName("ng-valid");
        static By Search_TextBox = By.XPath("//*[@placeholder=\"بحث\"]");
        static By Search_Button = By.ClassName("btn-light");
        static By FirstItemEdit_Button = By.ClassName("btnEditItem");
        static By FirstItemDelete_Button = By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button = By.ClassName("confirm");
        static By NumOfItems_Text = By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");

        public static void Goto()
        {
            Pages.AreaPage();
        }
        public static void Add_Area() 
	    {          
            time.Sleep(1000);
            //###### First , a country must be selected from the list before adding an area ##########
            Driver.FindElement(CountryList_SelectToggle).Click();
            Driver.FindElement(CountryName_TextBox).SendKeys(Data.Place.CountryName + Keys.Enter);
            time.Sleep(3000);
            //########################################################################################
            Driver.FindElement(Add_Button).Click();
            time.Sleep(1000);
            Driver.FindElement(AreaName_TextBox).SendKeys(Data.Place.AreaName);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(3000);
        }

        public static void Edit_Area(string area, string newName) 
	    {
            Search(area);
            time.Sleep(3000);
            Driver.FindElement(FirstItemEdit_Button).Click();
            time.Sleep(3000);
            Driver.FindElement(AreaName_TextBox).Clear();
            Driver.FindElement(AreaName_TextBox).SendKeys(newName);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(3000);

        }

       
        public static void Delete_Area(string area) 
        {
            Search(area);
            time.Sleep(1000);
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
