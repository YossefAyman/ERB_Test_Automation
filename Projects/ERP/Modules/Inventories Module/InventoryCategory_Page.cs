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
    class InventoryCategory_Page
    {
        static IWebDriver Driver = Automation_Testing.Common.Driver;

        // Selectors
        static By Add_Button = By.ClassName("btnAddItem");
        static By InventoryCategoryName_TextBox = By.CssSelector("#InventoryCategory_CategoryName");
        static By ParentTypeList_SelectToggle = By.CssSelector("#FormManager > div.row > div.form-group.col-md-4 > div > a > span.select2-arrow.ui-select-toggle");
        static By ParentType_TextBox = By.CssSelector("#FormManager > div.row > div.form-group.col-md-4 > div > div > div > input");
        static By Save_Button = By.CssSelector("#mainModal > div > div > div.modal-body > div.modal-footer > input");
        static By Search_TextBox = By.XPath("//*[@placeholder=\"Search...\"]");
        static By SelectFirstItem = By.CssSelector("#inventoryCategoryController > div > section > div > div > div.main-box-content > div > div > div > div > div > multiselect-searchtree > div > div.tree-view > ul > tree-item:nth-child(1) > li > div");
        static By FirstItemEdit_Button = By.CssSelector("#inventoryCategoryController > div > section > div > div > div.main-box-content > div > div > div > div > div > div > button.btnEditItem.btn.btn-info.category-buttons");
        static By FirstItemDelete_Button = By.CssSelector("#inventoryCategoryController > div > section > div > div > div.main-box-content > div > div > div > div > div > div > button.btnDeleteItem.btn.btn-danger.category-buttons");
        static By DeleteConfirm_Button = By.ClassName("confirm");
        static By NumOfItems_Text = By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");

        public static void Goto()
        {
            Pages.InventoryCategoriesPage();
        }

        public static void Add_InventoryCategory(string inventoryCategory, string parentType) 
	    {             
            Driver.FindElement(Add_Button).Click();
            time.Sleep(3000);
            Driver.FindElement(InventoryCategoryName_TextBox).SendKeys(inventoryCategory);
		
            if (parentType != "") {
                Driver.FindElement(ParentTypeList_SelectToggle).Click();
                Driver.FindElement(ParentType_TextBox).SendKeys(parentType + Keys.Enter);
            }
            Driver.FindElement(Save_Button).Click();
            time.Sleep(3000);
        }

        public static void Edit_InventoryCategory(string inventoryCategory, string newName) 
	    {
            Driver.FindElement(Search_TextBox).Clear();
            Driver.FindElement(Search_TextBox).SendKeys(inventoryCategory);
            Driver.FindElement(SelectFirstItem).Click();
            Driver.FindElement(FirstItemEdit_Button).Click();
            time.Sleep(1000);
            Driver.FindElement(InventoryCategoryName_TextBox).Clear();
            Driver.FindElement(InventoryCategoryName_TextBox).SendKeys(newName);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(3000);
        }

        public static void Delete_InventoryCategory(string inventoryCategory) 
	    {
            Driver.FindElement(Search_TextBox).Clear();
            Driver.FindElement(Search_TextBox).SendKeys(inventoryCategory);
            Driver.FindElement(SelectFirstItem).Click();
            Driver.FindElement(FirstItemDelete_Button).Click();
            time.Sleep(2000);
            Driver.FindElement(DeleteConfirm_Button).Click();

        }

       
    }
}
