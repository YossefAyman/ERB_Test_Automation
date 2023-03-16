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

    public class Daily_Restrictions
    {
        static IWebDriver Driver = Automation_Testing.Common.Driver;

        // Selectors
        static By SupplierName_SelectToggle = By.CssSelector("#FormManager > div.row > div:nth-child(2) > div > a > span.select2-arrow.ui-select-toggle");
        static By SupplierName_TextBox = By.CssSelector("#FormManager > div.row > div:nth-child(2) > div > div > div > input");
        static By StoreName_SelectToggle = By.CssSelector("#FormManager > div:nth-child(3) > div:nth-child(4) > div > a > span.select2-arrow.ui-select-toggle");
        static By StoreName_TextBox = By.CssSelector("#FormManager > div:nth-child(3) > div:nth-child(4) > div > div > div > input");
        static By Date_TextBox = By.XPath("//*[@placeholder=\"DD-MM-YYYY\"]");

        static By ItemInventoryCategory_SelectToggle = By.CssSelector("#FormManager > table > tbody > tr > th:nth-child(1) > center > div > div > a > span.select2-arrow.ui-select-toggle");
        static By ItemInventoryCategory_TextBox = By.CssSelector("#FormManager > table > tbody > tr > th:nth-child(1) > center > div > div > div > div > input");
        static By ItemName_SelectToggle = By.CssSelector("#FormManager > table > tbody > tr > th:nth-child(2) > center > div > div > a > span.select2-arrow.ui-select-toggle");
        static By ItemName_TextBox = By.CssSelector("#FormManager > table > tbody > tr > th:nth-child(2) > center > div > div > div > div > input");
        static By Quantity_TextBox = By.CssSelector("#InventoryPermissionDetails_Quantity");
        static By Price_TextBox = By.CssSelector("#InventoryPermissionDetails_Price");
        static By UISelect_DDL = By.ClassName("ui-select-container");
        static By UISelectSearch_TextBox = By.ClassName("ui-select-search");
        static By inventorypermissionDescribtion_TextBox = By.Id("AddingPermission_Description");
        static By AddDetails_button = By.ClassName("btn-success");
        static By Quantity_button = By.Id("EmptyInventoryPermissionDetails_Quantity");
        static By price_button = By.Id("EmptyInventoryPermissionDetails_Price");
        static By radio_button = By.Name("IsFirstInventoryPermission");
        static By edit_button = By.ClassName("btnEditItem");
        static By cancel_button = By.ClassName("btnCancelItem");
        static By confermcancel_button = By.ClassName("confirm");
        static By viewbutton = By.ClassName("contents ng-scope");
        static By Date = By.ClassName("dataPickerInputMainClass");
        static By price = By.Id("EmptyInventoryPermissionDetails_Price");

        static By searchID = By.XPath("//input[@placeholder='بحث']");
        static By searchButton = By.XPath("//i[@class='fa fa-search']");
        static By restriction_ID = By.CssSelector("div[class='ui-grid-canvas'] div:nth-child(1) div:nth-child(1) div:nth-child(3) div:nth-child(1) a:nth-child(1) span:nth-child(1)");
        static By debtorValue = By.CssSelector("#Transaction_TotalDebitAmount");
        static By creditValue = By.Id("Transaction_TotalCreditAmount");
        static By dateMn = By.XPath("/html[1]/body[1]/div[2]/main[1]/div[1]/div[1]/div[2]/div[1]/div[2]/section[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/date-picker-directive[1]/div[1]/input[1]");
        static By dateEla = By.XPath("/html[1]/body[1]/div[2]/main[1]/div[1]/div[1]/div[2]/div[1]/div[2]/section[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[2]/div[2]/div[1]/date-picker-directive[1]/div[1]/input[1]");
        static By registrationID = By.Id("Transaction_TransactionCode");
       

        public static void Goto()
        {
                Pages.DailyRestrictionspage();
                time.Sleep(3000);

        }

        public static void Verifing_debtor_Creditor_Values(string ID, out int debtorVaueInt , out int creditValueInt)
        {
            
            Driver.FindElement(searchID).SendKeys(ID);
            Driver.FindElement(searchButton).Click();
            Driver.FindElement(restriction_ID).Click();
            time.Sleep(3000);
            string valueDebtor = Driver.FindElement(debtorValue).GetAttribute("value");
            debtorVaueInt = int.Parse(valueDebtor);
            string valueCredit = Driver.FindElement(creditValue).GetAttribute("value");
            creditValueInt = int.Parse(valueCredit);


        }
        public static string GettingLastID()
        {
           
            Driver.FindElement(dateMn).SendKeys(Data.AddingPermission.Date);
            Driver.FindElement(dateEla).SendKeys(Data.AddingPermission.Date);
            Driver.FindElement(searchButton).Click();
            time.Sleep(1000);
            Driver.FindElement(restriction_ID).Click();
            time.Sleep(1000);
            string lastregistrationID = Driver.FindElement(registrationID).GetAttribute("value");
            return (int.Parse(lastregistrationID)+1).ToString();
        }

    }
    }
