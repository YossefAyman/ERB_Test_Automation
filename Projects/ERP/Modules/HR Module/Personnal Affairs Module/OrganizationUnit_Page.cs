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
    public class OrganizationUnit_Page
    {
        static IWebDriver Driver = Common.Driver;


        // Selectors

        static By Add_Button =                      By.ClassName("btnAddItem");
        static By OrganizationUnitName =            By.Id("OrganizationUnit_OrganizationUnitName");
        static By UISelect_DDL =                    By.ClassName("ui-select-container");
        static By UISelectSearch_TextBox =          By.ClassName("ui-select-search"); 
        static By Save_Button =                     By.XPath("//input[@value='حفظ']");
        static By Search_TextBox =                  By.XPath("/html/body/div[2]/main/div/div/div[2]/div/div[2]/section/div/div/div[2]/div/div/div[1]/div[1]/div/input");
        static By Search_Button =                   By.XPath("/html/body/div[2]/main/div/div/div[2]/div/div[2]/section/div/div/div[2]/div/div/div[1]/div[1]/div/span/button");
        static By NumOfItems_Text =                 By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");
        static By Edit_Button =                     By.XPath("//i[@title='تعديل']");
        static By FirstItemDelete_Button =          By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button =            By.ClassName("confirm");



        public static void Goto()
        {
            Pages.OrganizationUnitPage();
            time.Sleep(2000);

        }

        public static void Add_OrganizationUnit()
        {
            Driver.FindElement(Add_Button).Click();
            Driver.FindElement(OrganizationUnitName).SendKeys(Data.M1HR.OrganizationUnit_Name);
            Driver.FindElements(UISelect_DDL)[0].Click();
            Driver.FindElement(UISelectSearch_TextBox).SendKeys(Data.M1HR.OrganizationUnit + Keys.Enter); 
            Driver.FindElements(UISelect_DDL)[1].Click();
            Driver.FindElements(UISelectSearch_TextBox)[1].SendKeys(Data.M1HR.employeeName + Keys.Enter);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(3000);
        }

    }
}