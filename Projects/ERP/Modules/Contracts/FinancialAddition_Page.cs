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
    public class FinancialAddition_Page
    {

         static IWebDriver Driver = Common.Driver;

        protected static By Add_Button =                        By.ClassName("btnAddItem");
        protected static By FinancialAdditionName =             By.Id("FinancialAddition_FinancialAdditionName");
        protected static By Save_Button =                       By.CssSelector("#mainModal > div > div.modal-content.ui-resizable > div.modal-body > div.modal-footer > input");
        protected static By Edit_Button =                       By.XPath("//i[@title='تعديل']");
        protected static By FirstItemDelete_Button =            By.ClassName("btnDeleteItem");
        protected static By DeleteConfirm_Button =              By.ClassName("confirm");
        protected static By StatedAtTheEndOfTheContract =       By.XPath("/html/body/div[2]/main/div/div/div[2]/div/div[2]/div[2]/div/div[1]/div[2]/div[1]/form/div[1]/div[3]/div/div/label");
        protected static By PayableUponRenewal =                By.XPath("/html/body/div[2]/main/div/div/div[2]/div/div[2]/div[2]/div/div[1]/div[2]/div[1]/form/div[1]/div[4]/div/div/label");
        protected static By PayInInstallments =                 By.XPath("/html/body/div[2]/main/div/div/div[2]/div/div[2]/div[2]/div/div[1]/div[2]/div[1]/form/div[1]/div[5]/div/div/label");
        protected static By BeforeTax =                         By.XPath("/html/body/div[2]/main/div/div/div[2]/div/div[2]/div[2]/div/div[1]/div[2]/div[1]/form/div[1]/div[6]/div/div/label");
        protected static By UISelect_DDL =                      By.ClassName("ui-select-container");
        protected static By UISelectSearch_TextBox =            By.ClassName("ui-select-search");
        protected static By Search_TextBox =                    By.XPath("/html/body/div[2]/main/div/div/div[2]/div/div[2]/section/div/div/div[2]/div/div/div[1]/div[1]/div/input");
        protected static By Search_Button =                     By.XPath("//i[@class='fa fa-search']");
        protected static By NumOfItems_Text =                   By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");
        
        
        public static void Goto()
        {
            Pages.Financial_AdditionPage();
            time.Sleep(2000);

        }

        public static void Add_FinancialAddition()
        {
            Driver.FindElement(Add_Button).Click();
            Driver.FindElement(FinancialAdditionName).SendKeys(Data.Contracts.FinancialAddition_Name);
            Driver.FindElements(UISelect_DDL)[0].Click();
            Driver.FindElements(UISelectSearch_TextBox)[0].SendKeys(Data.Contracts.AccountName );
            time.Sleep(2000);
            Driver.FindElements(UISelectSearch_TextBox)[0].SendKeys(Keys.Enter);
            Driver.FindElement(StatedAtTheEndOfTheContract).Click();
            Driver.FindElement(PayableUponRenewal).Click();
            Driver.FindElement(PayInInstallments).Click();
            Driver.FindElement(BeforeTax).Click();
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }
        public static void Edit_FinancialAddition(string FinancialAddition_Name, string FinancialAddition_NewName)
        {
            Search(FinancialAddition_Name);
            Driver.FindElement(Edit_Button).Click();
            Driver.FindElement(FinancialAdditionName).Clear();
            Driver.FindElement(FinancialAdditionName).SendKeys(FinancialAddition_NewName);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }

        public static void Delete_FinancialAddition(string FinancialAddition_Name)
        {
            Search(FinancialAddition_Name);
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