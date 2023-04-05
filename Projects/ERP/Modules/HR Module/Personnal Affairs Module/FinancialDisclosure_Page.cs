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
    public class FinancialDisclosure_Page
    {

        static IWebDriver Driver = Automation_Testing.Common.Driver;


        // Selectors

        static By Add_Button =                               By.ClassName("btnAddItem");
        static By UISelect_DDL =                             By.ClassName("ui-select-container");
        static By UISelectSearch_TextBox =                   By.ClassName("ui-select-search");


        static By FinancialDisclosure_Description =          By.Id("EmployeeFinancialReceivables_Description");
        static By Save_Button =                              By.XPath("//input[@value='حفظ']");
        static By Search_TextBox =                           By.ClassName("ng-valid");
        static By Search_Button =                            By.ClassName("btn-light");
        static By NumOfItems_Text =                          By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");
        static By Edit_Button =                              By.XPath("//i[@title='تعديل']");
        static By FirstItemDelete_Button =                   By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button =                     By.ClassName("confirm");
        static By FinancialDisclosure_Reason =               By.XPath("//div[@class='ng-binding ng-scope']");
        static By Date =                                     By.XPath("/html[1]/body[1]/div[2]/main[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[2]/div[1]/div[1]/div[2]/div[1]/form[1]/div[1]/div[4]/div[1]/date-picker-directive[1]/div[1]/input[1]");
        static By Grid =                                     By.XPath("/html[1]/body[1]/div[2]/main[1]/div[1]/div[1]/div[2]/div[1]/div[2]/section[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[4]/div[1]/div[2]/div[2]/div[1]/div");
     // static By LastElementID =                            By.XPath("/html[1]/body[1]/div[2]/main[1]/div[1]/div[1]/div[2]/div[1]/div[2]/section[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[4]/div[1]/div[2]/div[2]/div[1]/div["+ GetLastColumn() +"]/div[1]/div[1]/div[1]\r\n");



        public static void Goto()
        {
            Pages.FinancialDisclosurePage();
            time.Sleep(2000);


        }

        public static void Add_FinancialDisclosure()
        {
            Driver.FindElement(Add_Button).Click();
            Driver.FindElements(UISelect_DDL)[0].Click();
            Driver.FindElements(UISelectSearch_TextBox)[0].SendKeys(Data.M1HR.employeeName + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[1].Click();
            Driver.FindElement(FinancialDisclosure_Reason).Click();
            Driver.FindElement(FinancialDisclosure_Description).SendKeys(Data.M1HR.FinancialDisclosure_Description);
            Driver.FindElement(Date).SendKeys(Data.DateValue);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }

        public static void Edit_FinancialDisclosure(string FinancialDiscloure_Name)
        {
            Search(GetLastID());
            Driver.FindElement(Edit_Button).Click();
            Driver.FindElement(FinancialDisclosure_Description).Clear();
            Driver.FindElement(FinancialDisclosure_Description).SendKeys(FinancialDiscloure_Name);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }

        public static void Delete_FinancialDisclosure(string FinancialDiscloure)
        {
            Search(FinancialDiscloure);
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
        public static int GetLastColumn()
        {
            var grid = Driver.FindElements(Grid).Count;

            return grid;


        }
        public static string GetLastID()
        {
            By LastElementID = By.XPath("/html[1]/body[1]/div[2]/main[1]/div[1]/div[1]/div[2]/div[1]/div[2]/section[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[4]/div[1]/div[2]/div[2]/div[1]/div[" + GetLastColumn() + "]/div[1]/div[1]/div[1]\r\n");
            var ID = Driver.FindElement(LastElementID);
            string IDText = ID.Text;
            return IDText;

        }
    }
}