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
    public class Customer_Page
    {
        static IWebDriver Driver = Automation_Testing.Common.Driver;
         
        // Selectors
        static By Add_Button = By.ClassName("btnAddItem");
        static By CustomerName_TextBox = By.Id("Profile_ProfileName");
        static By CustomerEmail_TextBox = By.Id("Profile_Email");
        static By CustomerNumber_TextBox = By.Id("Customer_CustomerNumber");
        static By IDType_SelectToggle = By.CssSelector("#FormManager > div:nth-child(2) > div:nth-child(2) > div > div > a > span.select2-arrow.ui-select-toggle");
        static By IDType_TextBox = By.CssSelector("#FormManager > div:nth-child(2) > div:nth-child(2) > div > div > div > div > input");
        static By CustomerID_TextBox = By.CssSelector("#Customer_IdentityNumber");
        static By CustomerPhone_TextBox = By.Id("Customer_Phone");
        static By CustomerMobile_TextBox = By.Id("Customer_Mobile");
        static By CustomerAddress_TextBox = By.Id("Customer_Address");
        static By CountryList_SelectToggle = By.CssSelector("#FormManager > div:nth-child(3) > div:nth-child(1) > div > div > a > span.select2-arrow.ui-select-toggle");
        static By CountryList_TextBox = By.CssSelector("#FormManager > div:nth-child(3) > div:nth-child(1) > div > div > div > div > input");
        static By AreaList_SelectToggle = By.CssSelector("#FormManager > div:nth-child(3) > div:nth-child(2) > div > div > a > span.select2-arrow.ui-select-toggle");
        static By AreaList_TextBox = By.CssSelector("#FormManager > div:nth-child(3) > div:nth-child(2) > div > div > div > div > input");
        static By CityList_SelectToggle = By.CssSelector("#FormManager > div:nth-child(3) > div:nth-child(3) > div > div > a > span.select2-arrow.ui-select-toggle");
        static By CityList_TextBox = By.CssSelector("#FormManager > div:nth-child(3) > div:nth-child(3) > div > div > div > div > input");
        static By District_SelectBox = By.CssSelector("#FormManager > div:nth-child(3) > div:nth-child(4) > div > div > a > span.select2-arrow.ui-select-toggle");
        static By District_TextBox = By.CssSelector("#FormManager > div:nth-child(3) > div:nth-child(4) > div > div > div > div > input");
        static By Nationality_SelectToggle = By.CssSelector("#FormManager > div:nth-child(4) > div:nth-child(1) > div > div > a > span.select2-arrow.ui-select-toggle");
        static By Nationality_TextBox = By.CssSelector("#FormManager > div:nth-child(4) > div:nth-child(1) > div > div > div > div > input");
        static By AddAttachment_Button = By.CssSelector("#AttachmentFormManager > div:nth-child(3) > div:nth-child(1) > div > div.drop-box.w-100.ng-pristine.ng-untouched.ng-valid.ng-empty > i");
        static By Save_Button = By.CssSelector("#mainModal > div > div > div.modal-body > div.modal-footer > input");
        //static By Search_TextBox = By.ClassName("ng-valid");
        static By Search_TextBox = By.XPath("//*[@placeholder=\"بحث\"]");
        static By Search_Button = By.ClassName("btn-light"); 
        static By firstItemEdit_Button = By.ClassName("btnEditItem");
        static By firstItemDelete_Button = By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button = By.ClassName("confirm");
        static By NumOfItems_Text = By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");

        public static void Add_Customer_With_Full_Data()
        {
            Driver.FindElement(Add_Button).Click();
            time.Sleep(3000);
            Driver.FindElement(CustomerName_TextBox).SendKeys(Data.Customer.Name);
            Driver.FindElement(CustomerEmail_TextBox).SendKeys(Data.Customer.Email);
            Driver.FindElement(CustomerNumber_TextBox).SendKeys(Data.Customer.Number);
            Driver.FindElement(IDType_SelectToggle).Click();
            Driver.FindElement(IDType_TextBox).SendKeys(Data.Customer.ID_Type + Keys.Enter);
            Driver.FindElement(CustomerID_TextBox).SendKeys(Data.Customer.ID_Number);
            Driver.FindElement(CustomerPhone_TextBox).SendKeys(Data.Customer.Phone);
            Driver.FindElement(CustomerMobile_TextBox).SendKeys(Data.Customer.Mobile);
            Driver.FindElement(CustomerAddress_TextBox).SendKeys(Data.Customer.Address);
            Driver.FindElement(CountryList_SelectToggle).Click();
            Driver.FindElement(CountryList_TextBox).SendKeys(Data.Customer.Country + Keys.Enter);
            Driver.FindElement(AreaList_SelectToggle).Click();
            Driver.FindElement(AreaList_TextBox).SendKeys(Data.Customer.Area + Keys.Enter);
            Driver.FindElement(CityList_SelectToggle).Click();
            Driver.FindElement(CityList_TextBox).SendKeys(Data.Customer.City + Keys.Enter);
            Driver.FindElement(District_SelectBox).Click();
            Driver.FindElement(District_TextBox).SendKeys(Data.Customer.District + Keys.Enter);
            Driver.FindElement(Nationality_SelectToggle).Click();
            Driver.FindElement(Nationality_TextBox).SendKeys(Data.Customer.Nationality + Keys.Enter);
            Driver.FindElement(AddAttachment_Button).Click();
            time.Sleep(2000);
            /* upload the Attachment when the dialog pop up */
            Data.Add_Attachment();

            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);

        }
        public static void Add_Customer_With_Required_Data_Only()
        {
            Driver.FindElement(Add_Button).Click();
            time.Sleep(3000);
            Driver.FindElement(CustomerName_TextBox).SendKeys(Data.Customer.Name);
            Driver.FindElement(CustomerMobile_TextBox).SendKeys(Data.Customer.Mobile);
            Driver.FindElement(CustomerAddress_TextBox).SendKeys(Data.Customer.Address);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(3000);

        }
        //#############################################################################################   
        public static void Edit_Customer(string CustomerName, string newName)
        {
            Search(CustomerName);
            time.Sleep(1000);
            Driver.FindElement(firstItemEdit_Button).Click();
            time.Sleep(1000);
            Driver.FindElement(CustomerName_TextBox).Clear();
            Driver.FindElement(CustomerName_TextBox).SendKeys(newName);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }

        //##############################################################################################        
        public static void Delete_Customer(string customerName)
        {       
            Search(customerName);
            time.Sleep(1000);
            Driver.FindElement(firstItemDelete_Button).Click();
            time.Sleep(2000);
            Driver.FindElement(DeleteConfirm_Button).Click();
            time.Sleep(3000);

        }

        public static string Search(string item)
        {
            Driver.FindElement(Search_TextBox).Clear();
            Driver.FindElement(Search_TextBox).SendKeys(item);
            Driver.FindElement(Search_Button).Click();
            time.Sleep(1000);
            
            if( Driver.FindElement(NumOfItems_Text).Text == "1 - 1 من 1" )
            {
                return "Exist";
            }
            else if ( Driver.FindElement(NumOfItems_Text).GetAttribute("class") == "ng-binding ng-hide")
            {
                return "NotExist";
            }
            else
            {
                return "Repeated";
            }
        }
        public static void Goto()
        {
            Pages.CustomersPage();
        }
    }
}
