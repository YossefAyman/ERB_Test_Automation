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
    class InventoryPermission_Page
    {
        static IWebDriver Driver = Automation_Testing.Common.Driver;

        // Selectors
        static By Add_Button = By.ClassName("btnAddItem");
        static By ClientName_SelectToggle = By.CssSelector("#FormManager > div.row > div:nth-child(2) > div > a > span.select2-arrow.ui-select-toggle");
        static By ClientName_TextBox = By.CssSelector("#FormManager > div.row > div:nth-child(2) > div > div > div > input");
        static By StoreName_SelectToggle = By.CssSelector("#FormManager > div.row > div:nth-child(4) > div > a > span.select2-arrow.ui-select-toggle");
        static By StoreName_TextBox = By.CssSelector("#FormManager > div.row > div:nth-child(4) > div > div > div > input");
        static By Date_TextBox = By.XPath("//*[@placeholder=\"DD-MM-YYYY\"]");
        static By AddDetails_TextBox = By.CssSelector("#FormManager > cEnter > input");
        static By ItemInventoryCategory_SelectToggle = By.CssSelector("#FormManager > table > tbody > tr > th:nth-child(1) > cEnter > div > div > a > span.select2-arrow.ui-select-toggle");
        static By ItemInventoryCategory_TextBox = By.CssSelector("#FormManager > table > tbody > tr > th:nth-child(1) > cEnter > div > div > div > div > input");
        static By ItemName_SelectToggle = By.CssSelector("#FormManager > table > tbody > tr > th:nth-child(2) > cEnter > div > div > a > span.select2-arrow.ui-select-toggle");
        static By ItemName_TextBox = By.CssSelector("#FormManager > table > tbody > tr > th:nth-child(2) > cEnter > div > div > div > div > input");
        static By Quantity_TextBox = By.CssSelector("#InventoryPermissionDetails_Quantity");
        static By Save_Button = By.CssSelector("#mainModal > div > div > div.modal-body > div.modal-footer > input");
        static By NumOfItems_Text = By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");
        static By UISelect_DDL = By.ClassName("ui-select-container");
        static By UISelectSearch_TextBox = By.ClassName("ui-select-search");
        static By Date = By.ClassName("dataPickerInputMainClass");
        static By inventorypermissionDescription = By.Id("InventoryPermission_Description");
        static By AddDetails_button = By.ClassName("btn-success");
        static By Quantity_button = By.Id("EmptyInventoryPermissionDetails_Quantity");
        static By save_button = By.ClassName("btn-primary");
        static By edit_button = By.ClassName("btnEditItem");
        static By cancel_button = By.ClassName("btnCancelItem");
        static By confermcancel_button = By.ClassName("confirm");
        public static void Goto()
        {
            Pages.InventoryPermissionPage();
            time.Sleep(2000);

        }
        public static void Add_InventoryPermission()
	    {
            Driver.FindElement(Add_Button).Click();
            Driver.FindElements(UISelect_DDL)[1].Click();
            Driver.FindElements(UISelectSearch_TextBox)[1].SendKeys(Data.inventorypermissionConstants.profileType + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[2].Click();
            Driver.FindElements(UISelectSearch_TextBox)[2].SendKeys(Data.inventorypermissionConstants.customer + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[4].Click();
            Driver.FindElements(UISelectSearch_TextBox)[4].SendKeys(Data.inventorypermissionConstants.store + Keys.Enter);
            Driver.FindElement(Date).Clear();
            Driver.FindElement(Date).SendKeys(Data.inventorypermissionConstants.Date);
            Driver.FindElement(inventorypermissionDescription).SendKeys(Data.inventorypermissionConstants.inventorypermissionDescribtion);
            time.Sleep(2000);
            Driver.FindElement(AddDetails_button).Click();
            time.Sleep(2000);
            Driver.FindElements(UISelect_DDL)[5].Click();
            Driver.FindElements(UISelectSearch_TextBox)[5].SendKeys(Data.inventorypermissionConstants.ItemTypeName + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[6].Click();
            Driver.FindElements(UISelectSearch_TextBox)[6].SendKeys(Data.inventorypermissionConstants.code + Keys.Enter);
            Driver.FindElement(Quantity_button).Clear();
            Driver.FindElement(Quantity_button).SendKeys(Data.inventorypermissionConstants.Quantity + Keys.Enter);
            time.Sleep(3000);
            Driver.FindElement(save_button).Click();
            time.Sleep(3000);




        }

        public static void Edit_InventoryPermission()
        {
            Driver.FindElements(Date)[0].SendKeys(Data.inventorypermissionConstants.Date);
            Driver.FindElements(Date)[1].SendKeys(Data.inventorypermissionConstants.Date);
            Driver.FindElements(UISelect_DDL)[0].Click();
            Driver.FindElements(UISelectSearch_TextBox)[0].SendKeys(Data.inventorypermissionConstants.customer + Keys.Enter);
            Driver.FindElement(edit_button).Click();
            Driver.FindElement(Quantity_button).Clear();
            Driver.FindElement(Quantity_button).SendKeys(Data.inventorypermissionConstants.Quantity1 + Keys.Enter);
            Driver.FindElement(save_button).Click();
            time.Sleep(2000);
            



        }
        public static void cancel_InventoryPermission()
        {
            Driver.FindElements(Date)[0].SendKeys(Data.inventorypermissionConstants.Date);
            Driver.FindElements(Date)[1].SendKeys(Data.inventorypermissionConstants.Date);
            Driver.FindElements(UISelect_DDL)[0].Click();
            Driver.FindElements(UISelectSearch_TextBox)[0].SendKeys(Data.inventorypermissionConstants.customer + Keys.Enter);
            time.Sleep(2000);
            Driver.FindElement(cancel_button).Click();
            time.Sleep(2000);
            Driver.FindElement(confermcancel_button).Click();
            time.Sleep(2000);

        }
        public static Models.InventoryPermission Read()
        {
            Models.InventoryPermission inventoryPermission = new Models.InventoryPermission();
            //return Driver.FindElement(NumOfItems_Text).Text;
            inventoryPermission.DateFrom = Driver.FindElements(Date)[0].Text;
            inventoryPermission.DateTo = Driver.FindElements(Date)[1].Text;
            inventoryPermission.customer =Driver.FindElements(UISelect_DDL)[0].Text;
            Driver.FindElements(UISelectSearch_TextBox)[0].SendKeys(Data.inventorypermissionConstants.customer + Keys.Enter);
            Driver.FindElement(edit_button).Click();
            Driver.FindElement(Quantity_button).Clear();
            Driver.FindElement(Quantity_button).SendKeys(Data.inventorypermissionConstants.Quantity1 + Keys.Enter);
            Driver.FindElement(save_button).Click();
            time.Sleep(2000);

            return inventoryPermission;
        }
        public static bool IsEqual(Models.InventoryPermission inventoryPermissionBeforeEdit, Models.InventoryPermission inventoryPermissionAfterEdit)
        {
            if (inventoryPermissionBeforeEdit.Date != inventoryPermissionAfterEdit.Date)
            {
                return false;
            }

            return true;
            
        }

    }
}
