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

namespace ERP_Automation_Testing
{
    class property_Page
    {
        static IWebDriver Driver = Automation_Testing.Common.Driver;

        static By Add_Button = By.ClassName("btnAddItem");
        static By BanReasonName_Textbox = By.Id("BanReason_BanReasonName");
        static By Save_Button = By.ClassName("btnSaveItem");
        static By Search_TextBox = By.ClassName("ng-valid");
        static By Search_Button = By.ClassName("btn-light");
        static By EditFirstItem_Button = By.ClassName("btnEditItem");
        static By DeleteFirstItem_Button = By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button = By.ClassName("confirm");
        static By NumOfItems_Text = By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");
        static By UISelect_DDL = By.ClassName("ui-select-container");
        static By UISelectSearch_TextBox = By.ClassName("ui-select-search");
        static By name_textbox = By.Id("Unit_UnitName");
        static By properetyspace_textbox = By.Id("Unit_UnitSpace");
        static By Date = By.ClassName("dataPickerInputMainClass");
        static By Rentvalue_Textbox = By.Id("Unit_RentValue");
        static By AnnualRent_Textbox = By.Id("Unit_AnnualRent");
        static By Describtion_Textbox = By.Id("Unit_UnitDescription");
        static By address_Textbox = By.Id("Unit_UnitAddress");
        static By save_button = By.ClassName("btn-primary");

        public static void Goto()
        {
            Pages.property();

        }
        public static void Add_property()
        {
           //river.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Driver.FindElements(UISelect_DDL)[0].Click();
            Driver.FindElements(UISelectSearch_TextBox)[0].SendKeys(Data.Estates.propertyType + Keys.Enter);
            time.Sleep(2000);
            Driver.FindElement(Add_Button).Click();
            time.Sleep(2000);
            Driver.FindElement(name_textbox).SendKeys(Data.Estates.Name);
            time.Sleep(2000);
            Driver.FindElements(UISelect_DDL)[0].Click();
            time.Sleep(2000);
            Driver.FindElements(UISelectSearch_TextBox)[0].SendKeys(Data.Estates.owner + Keys.Enter);
            time.Sleep(2000);
            Driver.FindElement(properetyspace_textbox).SendKeys(Data.Estates.propertyspace);
            time.Sleep(2000);

            Driver.FindElement(Date).Clear();
            time.Sleep(2000);
            Driver.FindElement(Date).SendKeys(Data.Estates.operationstartDate);
            time.Sleep(2000);
            Driver.FindElements(UISelect_DDL)[1].Click();
            time.Sleep(2000);
            Driver.FindElements(UISelectSearch_TextBox)[1].SendKeys(Data.Estates.propertypurbose + Keys.Enter);
            time.Sleep(2000);
            Driver.FindElement(Rentvalue_Textbox).SendKeys(Data.Estates.Rentvalue);
            time.Sleep(2000);

            Driver.FindElement(AnnualRent_Textbox).SendKeys(Data.Estates.AnnualRent);
            time.Sleep(2000);
            Driver.FindElement(Describtion_Textbox).SendKeys(Data.Estates.Describtion);
            time.Sleep(2000);

            Driver.FindElements(UISelect_DDL)[5].Click();
            time.Sleep(2000);
            Driver.FindElements(UISelectSearch_TextBox)[5].SendKeys(Data.Estates.country + Keys.Enter);
            time.Sleep(2000);
            Driver.FindElements(UISelect_DDL)[6].Click();
            time.Sleep(2000);
            Driver.FindElements(UISelectSearch_TextBox)[6].SendKeys(Data.Estates.Area + Keys.Enter);
            time.Sleep(2000);
            Driver.FindElements(UISelect_DDL)[7].Click();
            time.Sleep(2000);
            Driver.FindElements(UISelectSearch_TextBox)[7].SendKeys(Data.Estates.city + Keys.Enter);
            time.Sleep(2000);
            Driver.FindElements(UISelect_DDL)[8].Click();
            time.Sleep(2000);
            Driver.FindElements(UISelectSearch_TextBox)[8].SendKeys(Data.Estates.District + Keys.Enter);
            time.Sleep(2000);
            Driver.FindElement(address_Textbox).SendKeys(Data.Estates.address);
            time.Sleep(2000);
            Driver.FindElement(save_button).Click();
            time.Sleep(2000);














































        }
    }
}