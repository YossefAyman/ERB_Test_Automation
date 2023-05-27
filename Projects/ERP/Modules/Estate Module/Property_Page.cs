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
namespace ERP_Automation_Testing
{
    class Property_Page
    {
        static IWebDriver Driver = Automation_Testing.Common.Driver;
        static IJavaScriptExecutor javaDriverExector = Driver as IJavaScriptExecutor;


        static By Add_Button =                  By.ClassName("btnAddItem");
        static By BanReasonName_Textbox =       By.Id("BanReason_BanReasonName");
        static By Save_Button =                 By.ClassName("btnSaveItem");
        static By Search_TextBox =              By.ClassName("ng-valid");
        static By Search_Button =               By.ClassName("btn-light");
        static By Edit_Button =                 By.XPath("//i[@title='تعديل']");
        static By DeleteFirstItem_Button =      By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button =        By.ClassName("confirm");
        static By NumOfItems_Text =             By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");
        static By Country_List =                By.XPath("//*[@id=\"FormManager\"]/div[5]/div[1]/div[1]/div/div/div[1]");
        static By Country_List1 =               By.XPath("//*[@id=\"FormManager\"]/div[5]/div[1]/div[1]/div/div/div[1]/input");
        static By Erea_List =                   By.XPath("//*[@id=\"FormManager\"]/div[5]/div[1]/div[2]/div/div/div[1]");
        static By Erea_List1 =                  By.XPath("//*[@id=\"FormManager\"]/div[5]/div[1]/div[2]/div/div/div[1]/input");
        static By City_List =                   By.XPath("//*[@id=\"FormManager\"]/div[5]/div[1]/div[3]/div/div/div[1]");
        static By City_List1 =                  By.XPath("//*[@id=\"FormManager\"]/div[5]/div[1]/div[3]/div/div/div[1]/input");
        static By District_List =               By.XPath("//*[@id=\"FormManager\"]/div[5]/div[1]/div[4]/div/div/div[1]");
        static By District_List1 =              By.XPath("//*[@id=\"FormManager\"]/div[5]/div[1]/div[4]/div/div/div[1]/input");
        static By UISelect_DDL =                By.ClassName("ui-select-container");
        static By UISelectSearch_TextBox =      By.ClassName("ui-select-search");
        static By name_textbox =                By.Id("Unit_UnitName");
        static By properetyspace_textbox =      By.Id("Unit_UnitSpace");
        static By Date =                        By.ClassName("dataPickerInputMainClass");
        static By Rentvalue_Textbox =           By.Id("Unit_RentValue");
        static By AnnualRent_Textbox =          By.Id("Unit_AnnualRent");
        static By Describtion_Textbox =         By.Id("Unit_UnitDescription");
        static By address_Textbox =             By.Id("Unit_UnitAddress");
        static By save_button =                 By.ClassName("btn-primary");
        static By FirstItemDelete_Button =      By.ClassName("btnDeleteItem");
        static By Owner_NameList_input =        By.XPath("/html/body/div[2]/main/div/div/div[2]/section/div[1]/div/div[2]/div/div/form/fieldset[3]/div[1]/div/div/div/div[1]/input");
        static By Owner_NameList =              By.XPath("/html/body/div[2]/main/div/div/div[2]/section/div[1]/div/div[2]/div/div/form/fieldset[3]/div[1]/div/div/div/div[1]");



        public static void Goto()
        {
            Pages.PropertyPage();
            time.Sleep(2000);
        }
        public static void Add_Property()
        {
            Driver.FindElements(UISelect_DDL)[0].Click();
            Driver.FindElements(UISelectSearch_TextBox)[0].SendKeys(Data.Estates.PropertyTypeName + Keys.Enter);
            Driver.FindElement(Add_Button).Click();
            time.Sleep(2000);
            Driver.FindElement(name_textbox).SendKeys(Data.Estates.Property_Name);
            Driver.FindElement(properetyspace_textbox).SendKeys(Data.Estates.propertyspace);
            Driver.FindElement(Date).Clear();
            Driver.FindElement(Date).SendKeys(Data.RandomDate());
            /*Driver.FindElements(UISelect_DDL)[1].Click();
            Driver.FindElements(UISelectSearch_TextBox)[1].SendKeys(Data.Estates.propertypurbose + Keys.Enter);
            Driver.FindElement(Rentvalue_Textbox).SendKeys(Data.Estates.Rentvalue);
            Driver.FindElement(AnnualRent_Textbox).SendKeys(Data.Estates.AnnualRent);
            Driver.FindElement(Describtion_Textbox).SendKeys(Data.Estates.Describtion);*/
            IWebElement Element = Driver.FindElements(UISelect_DDL)[3];
            javaDriverExector.ExecuteScript("arguments[0].scrollIntoView(true);", Element);
            Driver.FindElements(UISelect_DDL)[4].Click();
            Driver.FindElements(UISelectSearch_TextBox)[4].SendKeys(Data.Estates.PropertyTypeName + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[5].Click();
            Driver.FindElements(UISelectSearch_TextBox)[5].SendKeys(Data.Estates.Area + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[6].Click();
            Driver.FindElements(UISelectSearch_TextBox)[6].SendKeys(Data.Estates.city + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[7].Click();
            Driver.FindElements(UISelectSearch_TextBox)[7].SendKeys(Data.Estates.District + Keys.Enter);
            Driver.FindElement(address_Textbox).SendKeys(Data.Estates.address);
            Driver.FindElement(Owner_NameList).Click();
            Driver.FindElement(Owner_NameList_input).SendKeys(Data.Estates.owner + Keys.Enter);
            IWebElement Element2 = Driver.FindElement(save_button);
            javaDriverExector.ExecuteScript("arguments[0].scrollIntoView(true);", Element2);
            Driver.FindElement(save_button).Click();
            time.Sleep(2000);
        }
        
        public static void Add_Property_With_Added_NewPropertyType()
        {
            Driver.FindElements(UISelect_DDL)[0].Click();
            Driver.FindElements(UISelectSearch_TextBox)[0].SendKeys(Data.Estates.PropertyType_Name + Keys.Enter);
            Driver.FindElement(Add_Button).Click();
            time.Sleep(2000);
            Driver.FindElement(name_textbox).SendKeys(Data.Estates.Property_Name);
            Driver.FindElement(properetyspace_textbox).SendKeys(Data.Estates.propertyspace);
            Driver.FindElement(Date).Clear();
            Driver.FindElement(Date).SendKeys(Data.RandomDate());
            /*Driver.FindElements(UISelect_DDL)[1].Click();
            Driver.FindElements(UISelectSearch_TextBox)[1].SendKeys(Data.Estates.propertypurbose + Keys.Enter);
            Driver.FindElement(Rentvalue_Textbox).SendKeys(Data.Estates.Rentvalue);
            Driver.FindElement(AnnualRent_Textbox).SendKeys(Data.Estates.AnnualRent);
            Driver.FindElement(Describtion_Textbox).SendKeys(Data.Estates.Describtion);*/
            IWebElement Element = Driver.FindElements(UISelect_DDL)[3];
            javaDriverExector.ExecuteScript("arguments[0].scrollIntoView(true);", Element);
            Driver.FindElements(UISelect_DDL)[4].Click();
            Driver.FindElements(UISelectSearch_TextBox)[4].SendKeys(Data.Estates.PropertyTypeName + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[5].Click();
            Driver.FindElements(UISelectSearch_TextBox)[5].SendKeys(Data.Estates.Area + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[6].Click();
            Driver.FindElements(UISelectSearch_TextBox)[6].SendKeys(Data.Estates.city + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[7].Click();
            Driver.FindElements(UISelectSearch_TextBox)[7].SendKeys(Data.Estates.District + Keys.Enter);
            Driver.FindElement(address_Textbox).SendKeys(Data.Estates.address);
            Driver.FindElement(Owner_NameList).Click();
            Driver.FindElement(Owner_NameList_input).SendKeys(Data.Estates.owner + Keys.Enter);
            IWebElement Element2 = Driver.FindElement(save_button);
            javaDriverExector.ExecuteScript("arguments[0].scrollIntoView(true);", Element2);
            Driver.FindElement(save_button).Click();
            time.Sleep(2000);
        }

        public static void Edit_Property(string Property_Name)
        {
            PropertyType_Page.Search(Data.Estates.Property_Name);
            Driver.FindElement(Edit_Button).Click();
            Driver.FindElement(name_textbox).Clear();
            Driver.FindElement(name_textbox).SendKeys(Property_Name);
            Driver.FindElement(save_button).Click();
            time.Sleep(2000);
        }

        public static void Delete_Property(string Property_Name)
        {
            PropertyType_Page.Search(Property_Name);
            Driver.FindElement(FirstItemDelete_Button).Click();
            time.Sleep(1000);
            Driver.FindElement(DeleteConfirm_Button).Click();
            time.Sleep(2000);
        }
    }
}