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
using Microsoft.Ajax.Utilities;
//using System.Windows.Forms;

namespace ERP_Automation_Testing
{
    class Addingpermission_page: CommonSelectors
    {
        static IWebDriver Driver = Automation_Testing.Common.Driver;
        static IJavaScriptExecutor javaDriverExector = Driver as IJavaScriptExecutor;


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

        

        public static void Goto()
        {
            Pages.AddingPermissionPage();
            time.Sleep(2000);

        }

        public static void Add_AddingPermission()
	    {     
            Driver.FindElement(Add_Button).Click();
            time.Sleep(2000);
            Driver.FindElements(UISelect_DDL)[1].Click();
          
            Driver.FindElements(UISelectSearch_TextBox)[1].SendKeys(Data.AddingPermission.profileType + Keys.Enter);
           
            Driver.FindElements(UISelect_DDL)[2].Click();
           
            Driver.FindElements(UISelectSearch_TextBox)[2].SendKeys(Data.AddingPermission.Supplier + Keys.Enter);
            
            Driver.FindElements(UISelect_DDL)[4].Click();
            
            Driver.FindElements(UISelectSearch_TextBox)[4].SendKeys(Data.AddingPermission.Store + Keys.Enter);
            
            Driver.FindElement(Date).Clear();
           
            Driver.FindElement(Date).SendKeys(Data.AddingPermission.Date);
            
            Driver.FindElement(inventorypermissionDescribtion_TextBox).SendKeys(Data.AddingPermission.inventorypermissionDescribtion);

            //  Driver.FindElement(radio_button).Click();

            IWebElement Element = Driver.FindElement(AddDetails_button);
            javaDriverExector.ExecuteScript("arguments[0].scrollIntoView();", Element);

            time.Sleep(2000);
            Driver.FindElement(AddDetails_button).Click();
           
            Driver.FindElements(UISelect_DDL)[5].Click();
           
            Driver.FindElements(UISelectSearch_TextBox)[5].SendKeys(Data.AddingPermission.ItemTypeName + Keys.Enter);
          
            Driver.FindElements(UISelect_DDL)[6].Click();
            
            Driver.FindElements(UISelectSearch_TextBox)[6].SendKeys(Data.AddingPermission.code + Keys.Enter);
            
            Driver.FindElement(Quantity_button).Clear();
            
            Driver.FindElement(Quantity_button).SendKeys(Data.AddingPermission.Quantity);
            
            Driver.FindElement(price).SendKeys(Data.AddingPermission.Price);
           
            // Driver.FindElement(price_button).SendKeys(Data.AddingPermission.Price);
           
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);



  
        }
        public static void edit_Addingpermission()
        {

            Driver.FindElements(UISelect_DDL)[1].Click();
            Driver.FindElements(UISelectSearch_TextBox)[1].SendKeys(Data.AddingPermission.Store + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[2].Click();
            Driver.FindElements(UISelectSearch_TextBox)[2].SendKeys(Data.AddingPermission.code + Keys.Enter);
            time.Sleep(2000);
            Driver.FindElement(edit_button).Click();
            time.Sleep(2000);
            Driver.FindElement(Quantity_button).Clear();
            time.Sleep(2000);
            Driver.FindElement(Quantity_button).SendKeys(Data.AddingPermission.Quantity);
            time.Sleep(2000);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);


        }
        public static void cancel_Addingpermission()
        {
            
            Driver.FindElements(UISelect_DDL)[1].Click();
            Driver.FindElements(UISelectSearch_TextBox)[1].SendKeys(Data.AddingPermission.Store + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[2].Click();
            Driver.FindElements(UISelectSearch_TextBox)[2].SendKeys(Data.AddingPermission.code + Keys.Enter);
            time.Sleep(2000);
            Driver.FindElement(cancel_button).Click();
            time.Sleep(2000);
            Driver.FindElement(confermcancel_button).Click();
            time.Sleep(2000);

        }
        public static void viewAddingpermission()
        {
            Driver.FindElements(UISelect_DDL)[1].Click();
            Driver.FindElements(UISelectSearch_TextBox)[1].SendKeys(Data.AddingPermission.Store + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[2].Click();
            Driver.FindElements(UISelectSearch_TextBox)[2].SendKeys(Data.AddingPermission.code + Keys.Enter);
            time.Sleep(2000);
            Driver.FindElement(viewbutton).Click();
            time.Sleep(3000);

        }
        public static string Number_Of_Items()
        {
            return Driver.FindElement(NumOfItems_Text).Text;
        }
    
    }
}
