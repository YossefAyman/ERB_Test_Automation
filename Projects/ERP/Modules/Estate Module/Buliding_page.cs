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
    class Buliding_page
    {
        static IWebDriver Driver = Automation_Testing.Common.Driver;
        static By Add_Button = By.ClassName("btnAddItem");
        static By Buliding_Textbox = By.Id("Unit_UnitName");
        static By UnitAddress_Textbox = By.Id("Unit_UnitAddress");
        static By Descripiton_Textbox = By.Id("Unit_UnitDescription");
        static By purpose_SelectToggle = By.CssSelector("#FormManager > div:nth-child(2) > div:nth-child(5) > div > div > a > span.select2-arrow.ui-select-toggle > b");
        static By purpose_Textbox = By.CssSelector("#FormManager > div:nth-child(2) > div:nth-child(5) > div > div > div > div > input");
        static By Unitamount_Text = By.Id("Unit_Amount");
        static By RentValue_Textbox = By.Id("Unit_RentValue");
        static By Owner_SelectToggle = By.CssSelector("#FormManager > div:nth-child(3) > div:nth-child(2) > div > div > a > span.select2-arrow.ui-select-toggle > b");
        static By Owner_Textbox = By.CssSelector("#FormManager > div:nth-child(3) > div:nth-child(2) > div > div > div > div > input");
        static By Distract_SelectToggle = By.CssSelector("#FormManager > div.row.sm-gutters.ng-isolate-scope > div:nth-child(4) > div > div > a > span.select2-arrow.ui-select-toggle > b");
        static By Distract_Textbox = By.CssSelector("#FormManager > div.row.sm-gutters.ng-isolate-scope > div:nth-child(4) > div > div > div > div > input");
        static By UnitSpace_Textbox = By.Id("Unit_UnitSpace");
        static By AddAttachment_Button = By.CssSelector("#AttachmentFormManager > div:nth-child(3) > div:nth-child(1) > div > div.drop-box.w-100.ng-pristine.ng-untouched.ng-valid.ng-empty");
        static By Save_Button = By.ClassName("btnSaveItem");
        static By Search_TextBox = By.XPath("//*[@placeholder=\"بحث\"]");
        static By Search_Button = By.ClassName("btn-light");
        static By EditFirstItem_Button = By.ClassName("btnEditItem");
        static By DeleteFirstItem_Button = By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button = By.ClassName("confirm");
        static By NumOfItems_Text = By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");
    
        public static void Goto()
        {
            Pages.BuildingPage();
        }
        public static void Add_Building(Data.Buliding Buliding)
        {
           
            Driver.FindElement(Add_Button).Click();
            time.Sleep(1000);
            Driver.FindElement(Buliding_Textbox).SendKeys(Buliding.Buliding_name);
            Driver.FindElement(UnitAddress_Textbox).SendKeys(Buliding.Address);
            Driver.FindElement(Descripiton_Textbox).SendKeys(Buliding.Describtion);
            Driver.FindElement(purpose_SelectToggle).Click();
            Driver.FindElement(purpose_Textbox).SendKeys(Buliding.Property_Purpose+"\n");
            Driver.FindElement(Unitamount_Text).SendKeys(Buliding.Amount);
            Driver.FindElement(RentValue_Textbox).SendKeys(Buliding.Rent_Value);
            Driver.FindElement(UnitSpace_Textbox).SendKeys(Buliding.Property_Space);
            Driver.FindElement(Owner_SelectToggle).Click();
            Driver.FindElement(Owner_Textbox).SendKeys(Buliding.Owner + "\n");
            Driver.FindElement(Distract_SelectToggle).Click();
            Driver.FindElement(Distract_Textbox).SendKeys(Buliding.Distract+"\n");
            Driver.FindElement(AddAttachment_Button).Click();
            time.Sleep(2000);
            Data.Add_Attachment();
            time.Sleep(2000);
            // Driver.FindElement(Save_Button).Click();
            Driver.FindElement(By.TagName("html")).SendKeys(Keys.LeftControl + "S");
            time.Sleep(3000);

        }

    }
}
