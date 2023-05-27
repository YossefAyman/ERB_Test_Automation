using Automation_Testing;
using ERP_Automation_Testing;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using time = System.Threading.Thread;

namespace ERP_Automation_Testing
{
    public class PropertyType_Page
    {
        static IWebDriver Driver = Common.Driver;


        // Selectors

        static By Add_Button =                     By.ClassName("btnAddItem");
        static By UnitTypeName =                   By.Id("UnitType_UnitTypeName");
        static By UnitTypeDescription =            By.Id("UnitType_UnitTypeDescription");
        static By Save_Button =                    By.CssSelector("input[class='btn btn-primary actionBtnCantDuplicate actionBtnCantDuplicate']");
        static By Save_ButtonAfterEdit =           By.XPath("//*[@id=\"mainModal\"]/div/div[1]/div[2]/div[2]/input");
        static By Edit_Button =                    By.XPath("//i[@title='تعديل']");
        static By FirstItemDelete_Button =         By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button =           By.ClassName("confirm");
        static By Search_TextBox =                 By.XPath("(//input[@placeholder='بحث'])[1]");
        static By Search_Button =                  By.XPath("//i[@class='fa fa-search']");
        static By NumOfItems_Text =                By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");




        public static void Goto()
        {
            Pages.PropertyTypePage();
            time.Sleep(2000);

        }

        public static void AddPropertyType()
        {
            Driver.FindElement(Add_Button).Click();
            Driver.FindElement(UnitTypeName).SendKeys(Data.Estates.PropertyType_Name);
            Driver.FindElement(UnitTypeDescription).SendKeys(Data.Estates.PropertyType_Desc);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }

        public static void Edit_PropertyType(string PropertyType_Name, string PropertyType_Desc)
        {
            Search(Data.Estates.PropertyType_Name);
            Driver.FindElement(Edit_Button).Click();
            Driver.FindElement(UnitTypeName).Clear();
            Driver.FindElement(UnitTypeName).SendKeys(PropertyType_Name);
            Driver.FindElement(UnitTypeDescription).Clear();
            Driver.FindElement(UnitTypeDescription).SendKeys(PropertyType_Desc);
            Driver.FindElement(Save_ButtonAfterEdit).Click();
            time.Sleep(2000);
        }

        public static void Delete_PropertyType(string PropertyType_Name)
        {
            Search(PropertyType_Name);
            Driver.FindElement(FirstItemDelete_Button).Click();
            time.Sleep(1000);
            Driver.FindElement(DeleteConfirm_Button).Click();
            time.Sleep(2000);
        }
        public static string Search(string item)
        {
            Driver.FindElement(Search_TextBox).Clear();
            Driver.FindElement(Search_TextBox).SendKeys(item);
            Driver.FindElement(Search_Button).Click();
            time.Sleep(2000);

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