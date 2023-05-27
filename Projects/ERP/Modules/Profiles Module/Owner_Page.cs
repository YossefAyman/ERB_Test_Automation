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
    class Owner_Page
    {
        static IWebDriver Driver = Automation_Testing.Common.Driver;

        static By Add_Button = By.ClassName("btnAddItem");
        static By OwnerName_TextBox = By.Id("Profile_ProfileName");
        static By OwnerEmail_TextBox = By.Id("Profile_Email");
        static By OwnerNumber_TextBox = By.Id("Owner_OwnerNumber");
        static By OwnerMobile_TextBox = By.Id("Owner_Mobile");

        internal static void AddTeacher()
        {
            throw new NotImplementedException();
        }

        internal static void Addteacher()
        {
            throw new NotImplementedException();
        }

        static By OwnerAddress_TextBox = By.Id("Owner_Address");

        internal static void delete_Teacher(string v)
        {
            throw new NotImplementedException();
        }

        static By CountryList_SelectToggle = By.CssSelector("#FormManager > div:nth-child(3) > div:nth-child(1) > div > div > a > span.select2-arrow.ui-select-toggle");
        static By CountryList_TextBox = By.CssSelector("#FormManager > div:nth-child(3) > div:nth-child(1) > div > div > div > div > input");
        static By AreaList_SelectToggle = By.CssSelector("#FormManager > div:nth-child(3) > div:nth-child(2) > div > div > a > span.select2-arrow.ui-select-toggle");
        static By AreaList_TextBox = By.CssSelector("#FormManager > div:nth-child(3) > div:nth-child(2) > div > div > div > div > input");
        static By CityList_SelectToggle = By.CssSelector("#FormManager > div:nth-child(3) > div:nth-child(3) > div > div > a > span.select2-arrow.ui-select-toggle");
        static By CityList_TextBox = By.CssSelector("#FormManager > div:nth-child(3) > div:nth-child(3) > div > div > div > div > input");
        static By District_SelectBox = By.CssSelector("#FormManager > div:nth-child(3) > div:nth-child(4) > div > div > a > span.select2-arrow.ui-select-toggle");
        static By District_TextBox = By.CssSelector("#FormManager > div:nth-child(3) > div:nth-child(4) > div > div > div > div > input");
        static By Nationality_SelectToggle = By.CssSelector("#FormManager > div:nth-child(4) > div > div > div > a > span.select2-arrow.ui-select-toggle > b");
        static By Nationality_TextBox = By.CssSelector("#FormManager > div:nth-child(4) > div > div > div > div > div > input");
        static By AddAttachment_Button = By.CssSelector("#AttachmentFormManager > div:nth-child(3) > div:nth-child(1) > div > div.drop-box.w-100.ng-pristine.ng-untouched.ng-valid.ng-empty > i");
        static By Save_Button = By.ClassName("btnSaveItem");
        static By Search_TextBox = By.ClassName("ng-valid");
        static By Search_Button = By.ClassName("btn-light");
        static By firstItemEdit_Button = By.ClassName("btnEditItem");
        static By firstItemDelete_Button = By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button = By.ClassName("confirm");
        public static void add_owner()
        {
            time.Sleep(3000);
            Driver.FindElement(Add_Button).Click();
            time.Sleep(1000);
            Driver.FindElement(OwnerName_TextBox).SendKeys(Data.Owner.Name);
            Driver.FindElement(OwnerEmail_TextBox).SendKeys(Data.Owner.Email);
            Driver.FindElement(OwnerMobile_TextBox).SendKeys(Data.Owner.Mobile);
            Driver.FindElement(OwnerAddress_TextBox).SendKeys(Data.Owner.Address);
            Driver.FindElement(CountryList_SelectToggle).Click();
            Driver.FindElement(CountryList_TextBox).SendKeys(Data.Owner.Country + Keys.Enter);
            Driver.FindElement(AreaList_SelectToggle).Click();
            Driver.FindElement(AreaList_TextBox).SendKeys(Data.Owner.Area + Keys.Enter);
            Driver.FindElement(CityList_SelectToggle).Click();
            Driver.FindElement(CityList_TextBox).SendKeys(Data.Owner.City + Keys.Enter);
            Driver.FindElement(District_SelectBox).Click();
            Driver.FindElement(District_TextBox).SendKeys(Data.Owner.District + Keys.Enter);
            Driver.FindElement(Nationality_SelectToggle).Click();
            Driver.FindElement(Nationality_TextBox).SendKeys(Data.Owner.Nationality + Keys.Enter);
            Driver.FindElement(AddAttachment_Button).Click();
            time.Sleep(2000);

            time.Sleep(1000);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(3);
        }
        public static void Goto()
        {
            Pages.OwnersPage();
        }
        public static void edit_Teacher(string OwnerName, string newName)
        {

            time.Sleep(3000);
            Driver.FindElement(Search_TextBox).SendKeys(OwnerName);
            Driver.FindElement(Search_Button).Click();
            time.Sleep(1000);
            Driver.FindElement(firstItemEdit_Button).Click();
            time.Sleep(1000);
            Driver.FindElement(OwnerName_TextBox).Clear();
            Driver.FindElement(OwnerName_TextBox).SendKeys(newName);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }
        public static void delete_owner(string OwnerName)
        {

            time.Sleep(3000);
            Driver.FindElement(By.ClassName("ng-valid")).Clear();
            Driver.FindElement(By.ClassName("ng-valid")).SendKeys(OwnerName);
            Driver.FindElement(Search_Button).Click();
            time.Sleep(1000);
            Driver.FindElement(firstItemDelete_Button).Click();
            time.Sleep(2000);
            Driver.FindElement(DeleteConfirm_Button).Click();
            time.Sleep(1000);
        }
        public static void ShortKeys_Scenrio(string newName)
        {
            time.Sleep(3000);
            //Data.Shortcut("");
            time.Sleep(1000);
            Driver.FindElement(OwnerName_TextBox).SendKeys(Data.Owner.Name);
            Driver.FindElement(OwnerEmail_TextBox).SendKeys(Data.Owner.Email);
            Driver.FindElement(OwnerMobile_TextBox).SendKeys(Data.Owner.Mobile);
            Driver.FindElement(OwnerAddress_TextBox).SendKeys(Data.Owner.Address);
            Driver.FindElement(CountryList_SelectToggle).Click();
            Driver.FindElement(CountryList_TextBox).SendKeys(Data.Owner.Country + Keys.Enter);
            Driver.FindElement(AreaList_SelectToggle).Click();
            Driver.FindElement(AreaList_TextBox).SendKeys(Data.Owner.Area + Keys.Enter);
            Driver.FindElement(CityList_SelectToggle).Click();
            Driver.FindElement(CityList_TextBox).SendKeys(Data.Owner.City + Keys.Enter);
            Driver.FindElement(District_SelectBox).Click();
            Driver.FindElement(District_TextBox).SendKeys(Data.Owner.District + Keys.Enter);
            Driver.FindElement(Nationality_SelectToggle).Click();
            Driver.FindElement(Nationality_TextBox).SendKeys(Data.Owner.Nationality + Keys.Enter);
            Driver.FindElement(AddAttachment_Button).Click();
            time.Sleep(2000);
            Data.Add_Attachment();
            time.Sleep(1000);
            Data.Shortcut(Keys.LeftControl + "s");
            time.Sleep(3000);
            Driver.FindElement(Search_TextBox).SendKeys(Data.Owner.Name);
            Driver.FindElement(Search_Button).Click();
            time.Sleep(1000);
            Data.Shortcut(Keys.LeftControl + "A");
            time.Sleep(1000);
            Data.Shortcut(Keys.LeftControl + Keys.Shift + "D");
            time.Sleep(2000);
            Data.Shortcut(Keys.LeftControl + "A");
            time.Sleep(1000);
            Data.Shortcut(Keys.LeftControl + Keys.Shift + "C");
            time.Sleep(2000);
            Data.Shortcut(Keys.LeftControl + "A");
            time.Sleep(1000);
            Data.Shortcut(Keys.LeftControl + "E");
            time.Sleep(1000);
            Driver.FindElement(OwnerName_TextBox).Clear();
            Driver.FindElement(OwnerName_TextBox).SendKeys(newName);
            Data.Shortcut(Keys.LeftControl + "S");
            time.Sleep(3000);
            Driver.FindElement(Search_TextBox).Clear();
            Driver.FindElement(Search_TextBox).SendKeys(newName);
            Driver.FindElement(Search_Button).Click();
            time.Sleep(1000);
            Data.Shortcut(Keys.LeftControl + "A");
            time.Sleep(1000);
            Data.Shortcut(Keys.LeftControl + Keys.Delete);
            time.Sleep(2000);
            Driver.FindElement(DeleteConfirm_Button).Click();
            time.Sleep(2000);
            Driver.FindElement(Search_TextBox).Clear();
            Data.Shortcut(Keys.LeftControl + "F");
            time.Sleep(1000);

           


        }
    }


}
