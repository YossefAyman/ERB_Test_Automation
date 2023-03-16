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
    class itemstatus_page
    {
        static IWebDriver Driver = Automation_Testing.Common.Driver;

        // Selectors
        static By Add_Button = By.ClassName("btnAddItem");

        static By save_button = By.ClassName("btn-primary");
        static By edit_button = By.ClassName("btnEditItem");
        static By cancel_button = By.ClassName("btnCancelItem");
        static By confermcancel_button = By.ClassName("confirm");
        static By ItemstatusName_Text_box = By.Id("ItemStatus_ItemStatusName");
        static By UISelect_DDL = By.ClassName("ui-select-container");
        static By UISelectSearch_TextBox = By.ClassName("ui-select-search");
        public static void Goto()
        {
            Pages.itemstatuspage();
            time.Sleep(2000);

        }
        public static void Add_itemstatus()
        {

            Driver.FindElement(Add_Button).Click();
            Driver.FindElement(ItemstatusName_Text_box).SendKeys(Data.itemstatusName.itemstatusname);
            time.Sleep(3000);
            Driver.FindElements(UISelect_DDL)[1].Click();
            Driver.FindElements(UISelectSearch_TextBox)[1].SendKeys(Data.itemstatusName.ItemTypeName + Keys.Enter);
            Driver.FindElement(save_button).Click();
            time.Sleep(3000);





        }
    }
}