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
    public class RentContract_Page
    {

        static IWebDriver Driver = Common.Driver;
        static IJavaScriptExecutor javaDriverExector = Driver as IJavaScriptExecutor;


        // Selectors

        static By Add_Button =                      By.ClassName("btnAddItem");
        static By Start_Date =                      By.XPath("/html[1]/body[1]/div[2]/main[1]/div[1]/div[1]/div[2]/section[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/fieldset[1]/div[1]/div[3]/div[1]/date-picker-directive[1]/div[1]/input[1]");
        static By StartWork_Date =                  By.XPath("/html[1]/body[1]/div[2]/main[1]/div[1]/div[1]/div[2]/section[1]/div[1]/div[1]/div[2]/div[1]/div[1]/form[1]/fieldset[1]/div[1]/div[2]/div[1]/date-picker-directive[1]/div[1]/input[1]");
        static By End_Date =                        By.XPath("/html[1]/body[1]/div[2]/main[1]/div[1]/div[1]/div[2]/section[1]/div[1]/div[1]/div[2]/div[1]/div[1]/form[1]/fieldset[1]/div[1]/div[3]/div[1]/date-picker-directive[1]/div[1]/input[1]");
        static By UISelect_DDL =                    By.ClassName("ui-select-container");
        static By UISelectSearch_TextBox =          By.ClassName("ui-select-search");
        static By NumberOfpremium =                 By.Id("Contract_NumberOfpremium");
        static By Add_Property_Button =             By.XPath("/html/body/div[2]/main/div/div/div[2]/section/div[1]/div/div[2]/div/div[2]/div[1]/fieldset[2]/div/div/div/button/span");
        static By Save_Button =                     By.ClassName("btn-primary");
        static By Property_Price =                  By.XPath("/html/body/div[2]/main/div/div/div[2]/section/div[1]/div/div[2]/div/div[2]/div[1]/fieldset[2]/div/table/tbody/tr/th[4]/div/input");
        static By Contract_Num =                    By.Id("Contract_Code");
        




        public static void Goto()
        {
            Pages.RentContractPage();
            time.Sleep(2000);

        }

        public static void Add_RentContract()
        {
            Driver.FindElement(Add_Button).Click();
            Driver.FindElement(StartWork_Date).Clear();
            Driver.FindElement(StartWork_Date).SendKeys(Data.Contracts.Contract_Date);
            Driver.FindElement(End_Date).Clear();
            Driver.FindElement(End_Date).SendKeys(Data.Contracts.Ending_Date);
            IWebElement Element = Driver.FindElement(NumberOfpremium);
            javaDriverExector.ExecuteScript("arguments[0].scrollIntoView(true);", Element);
            Driver.FindElement(Start_Date).Clear();
            Driver.FindElement(Start_Date).SendKeys(Data.Contracts.Contract_Date);
            Driver.FindElements(UISelect_DDL)[1].Click();
            time.Sleep(1000);
            Driver.FindElements(UISelectSearch_TextBox)[1].SendKeys(Data.Contracts.Customer);
            time.Sleep(2000);
            Driver.FindElements(UISelectSearch_TextBox)[1].SendKeys(Keys.Enter);
            if (Driver.FindElement(Contract_Num).Enabled)
            {
                Driver.FindElement(Contract_Num).SendKeys(Data.Estates.Test_Index_Property.Value);
            }
            Driver.FindElements(UISelect_DDL)[5].Click();
            Driver.FindElements(UISelectSearch_TextBox)[5].SendKeys(Data.Contracts.Collector + Keys.Enter);
            Driver.FindElement(NumberOfpremium).SendKeys(Data.Contracts.NumberOfpremium);
            IWebElement Element2 = Driver.FindElement(NumberOfpremium);
            javaDriverExector.ExecuteScript("arguments[0].scrollIntoView(true);", Element2);
            Driver.FindElement(Add_Property_Button).Click();
            Driver.FindElements(UISelect_DDL)[8].Click();
            Driver.FindElements(UISelectSearch_TextBox)[8].SendKeys(Data.Estates.Property_Name);
            time.Sleep(2000);
            Driver.FindElements(UISelectSearch_TextBox)[8].SendKeys(Keys.Enter);
            Driver.FindElement(Property_Price).Clear();
            Driver.FindElement(Property_Price).SendKeys(Data.Estates.Rentvalue);
            IWebElement Element3 = Driver.FindElement(Save_Button);
            javaDriverExector.ExecuteScript("arguments[0].scrollIntoView(true);", Element3);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }


    }
}