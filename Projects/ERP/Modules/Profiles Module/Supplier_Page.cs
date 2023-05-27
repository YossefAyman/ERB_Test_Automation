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
    class Supplier_Page
    {
        static IWebDriver Driver = Automation_Testing.Common.Driver;

        // Selectors
        static By Add_Button = By.ClassName("btnAddItem");
        static By SupplierName_TextBox = By.Id("Profile_ProfileName");
        static By SupplierEmail_TextBox = By.Id("Profile_Email");
        static By SupplierPhone_TextBox = By.Id("Supplier_Phone");
        static By SupplierMobile_TextBox = By.Id("Supplier_Mobile");
        static By SupplierAddress_TextBox = By.Id("Supplier_Address");
        static By CountryName_SelectToggle = By.CssSelector("#FormManager > div:nth-child(3) > div:nth-child(1) > div > div > div.selectize-input > input");
        static By AreaName_SelectToggle = By.CssSelector("#FormManager > div:nth-child(3) > div:nth-child(2) > div > div > a > span.select2-arrow.ui-select-toggle");
        static By CityName_SelectToggle = By.CssSelector("#FormManager > div:nth-child(3) > div:nth-child(3) > div > div > a > span.select2-arrow.ui-select-toggle");
        static By DistrictName_SelectToggle = By.CssSelector("#FormManager > div:nth-child(3) > div:nth-child(4) > div > div > a > span.select2-arrow.ui-select-toggle");
        static By AddAttachment_Button = By.CssSelector("#AttachmentFormManager > div:nth-child(3) > div:nth-child(1) > div:nth-child(1) > div > div.drop-box.w-100.ng-pristine.ng-untouched.ng-valid.ng-binding.ng-empty");
        static By Save_Button = By.CssSelector("#mainModal > div > div > div.modal-body > div.modal-footer > input");
        // static By Search_TextBox = By.ClassName("ng-valid");
        static By Search_TextBox = By.XPath("//*[@placeholder=\"بحث\"]");
        static By Search_Button = By.ClassName("btn-light");
        static By CountryName_TextBox = By.CssSelector("#FormManager > div:nth-child(3) > div:nth-child(1) > div > div > div > div > input");
        static By AreaName_TextBox = By.CssSelector("#FormManager > div:nth-child(3) > div:nth-child(2) > div > div > div > div > input");
        static By CityName_TextBox = By.CssSelector("#FormManager > div:nth-child(3) > div:nth-child(3) > div > div > div > div > input");
        static By DistrictName_TextBox = By.CssSelector("#FormManager > div:nth-child(3) > div:nth-child(4) > div > div > div > div > input");
        static By FirstItemEdit_Button = By.ClassName("btnEditItem");
        static By FirstItemDelete_Button = By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button = By.ClassName("confirm");
        static By NumOfItems_Text = By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");
        static By NationalID = By.Id("Supplier_NationalId");
        static By address = By.Id("Profile_Address");
        static By Describtion = By.Id("Profile_Description");
        static By updateuserinfo = By.CssSelector("#FormManager > div:nth-child(1) > div.col.px-0 > div.row.sm-gutters.w-100.updateUser.ng-isolate-scope > div > div:nth-child(2) > button:nth-child(1");
        static By UISelect_DDL = By.ClassName("ui-select-container");
        static By UISelectSearch_TextBox = By.ClassName("ui-select-search");
        static By userName = By.Id("UserViewModel_User_Username");
        static By password = By.Id("UserViewModel_User_Password");
        static By confirmpassword = By.Id("UserViewModel_User_ConfirmPassword");
        static By checkbox = By.ClassName("check-radio-item");
        static By showusserpassword = By.ClassName("custom-control-label");
        public static void Goto()
        {
            Pages.SupplierPage();
            time.Sleep(2000);
        }

        public static void Add_Supplier()
        {

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5000);
            Driver.FindElement(Add_Button).Click();

            Driver.FindElement(SupplierName_TextBox).SendKeys(Data.Supplier.Name);

            Driver.FindElement(SupplierEmail_TextBox).SendKeys(Data.Supplier.Email);

            Driver.FindElement(address).SendKeys(Data.Supplier.Address);

            Driver.FindElement(SupplierPhone_TextBox).SendKeys(Data.Supplier.Phone);


            Driver.FindElement(SupplierMobile_TextBox).SendKeys(Data.Supplier.Mobile);

            Driver.FindElement(SupplierAddress_TextBox).SendKeys(Data.Supplier.Address);

            Driver.FindElement(Describtion).SendKeys(Data.Supplier.Describtion);


            Driver.FindElement(updateuserinfo).Click();
            time.Sleep(2000);
            Driver.FindElement(userName).SendKeys(Data.Supplier.Name);
            time.Sleep(2000);
            Driver.FindElement(password).SendKeys(Data.Supplier.password);
            time.Sleep(2000);
            Driver.FindElement(confirmpassword).SendKeys(Data.Supplier.password);
            time.Sleep(2000);
            Driver.FindElement(showusserpassword).Click();
            time.Sleep(2000);



            Driver.FindElement(NationalID).SendKeys(Data.Supplier.NationalID);


            Driver.FindElements(UISelect_DDL)[3].Click();// country
            time.Sleep(2000);
            Driver.FindElements(UISelectSearch_TextBox)[3].SendKeys(Data.Supplier.Country + Keys.Enter);
            time.Sleep(2000);
            Driver.FindElements(UISelect_DDL)[4].Click();//Area
            time.Sleep(2000);
            Driver.FindElements(UISelectSearch_TextBox)[4].SendKeys(Data.Supplier.Area + Keys.Enter);
            time.Sleep(2000);
            Driver.FindElements(UISelect_DDL)[5].Click();//city
            time.Sleep(2000);
            Driver.FindElements(UISelectSearch_TextBox)[5].SendKeys(Data.Supplier.City + Keys.Enter);
            time.Sleep(2000);
            Driver.FindElements(UISelect_DDL)[6].Click();//District
            time.Sleep(2000);
            Driver.FindElements(UISelectSearch_TextBox)[6].SendKeys(Data.Supplier.District + Keys.Enter);
            time.Sleep(2000);


            Driver.FindElement(AddAttachment_Button).Click();




            Driver.FindElement(AddAttachment_Button).Click();

            Data.Add_Attachment();

            Driver.FindElement(Save_Button).Click();
            Driver.Navigate().Refresh();
            time.Sleep(2000);

        }

        //#############################################################################################   
        public static void Edit_Supplier(string SupplierName, string newName)
        {
            Search(SupplierName);
            Driver.FindElement(FirstItemEdit_Button).Click();
            time.Sleep(1000);
            Driver.FindElement(SupplierName_TextBox).Clear();
            Driver.FindElement(SupplierName_TextBox).SendKeys(newName);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }

        //##############################################################################################        
        public static void Delete_Supplier(string supplierName)
        {
            Search(supplierName);
            Driver.FindElement(FirstItemDelete_Button).Click();
            time.Sleep(2000);
            Driver.FindElement(DeleteConfirm_Button).Click();
            time.Sleep(1000);

        }

        public static string Search(string item)
        {
            Driver.FindElement(Search_TextBox).Clear();
            Driver.FindElement(Search_TextBox).SendKeys(item);
            Driver.FindElement(Search_Button).Click();
            time.Sleep(1000);

            if (Driver.FindElement(NumOfItems_Text).Text == "1 - 1 من 1")
            {
                return "Exist";
            }
            else if (Driver.FindElement(NumOfItems_Text).GetAttribute("class") == "ng-binding ng-hide")
            {
                return "NotExist";
            }
            else
            {
                return "Repeated";
            }

      
            
                    


            }


            
        }
        }
    
