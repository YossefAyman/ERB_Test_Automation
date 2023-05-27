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
using ERP_Automation_Testing;

namespace ERP_Automation_Test.Projects.ERP.Modules.Profiles_Module
{
    public class Assets__page

    {
        static IWebDriver Driver = Automation_Testing.Common.Driver;



        static By Add_Button = By.ClassName("btnAddItem");
        static By AssetsName_textbox= By.Id("FixedAssetItem_ItemName");
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
        static By Save_Button = By.ClassName("actionBtnCantDuplicate");
        //static By Search_TextBox = By.ClassName("ng-valid");
        static By Search_TextBox = By.XPath("//*[@placeholder=\"بحث\"]");
        static By Search_Button = By.ClassName("btn-light");
        static By firstItemEdit_Button = By.ClassName("btnEditItem");
        static By firstItemDelete_Button = By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button = By.ClassName("confirm");
        static By NumOfItems_Text = By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");
        static By UISelect_DDL = By.ClassName("ui-select-container");
        static By UISelectSearch_TextBox = By.ClassName("ui-select-search");
        static By ageofassetsinyeras = By.Id("FixedAssetItem_FixedAssetLife");
        static By originName = By.Id("FixedAssetItem_ItemName");
        static By origincode = By.Id("FixedAssetItem_ItemCode");
        static By priceofassets = By.Id("FixedAssetItem_ItemPrice");
        static By Date = By.XPath("/html/body/div[2]/main/div/div/div[2]/div/div[2]/div[2]/div/div[1]/div[2]/div[1]/form/div[2]/div[5]/div/date-picker-directive/div/input[1]");


        public static void Goto()

        {

            Pages.Assets();
            time.Sleep(2000);

        }
        public static void AddAssets()

        {

            Driver.FindElement(Add_Button).Click();
            time.Sleep(2000);
            Driver.FindElements(UISelect_DDL)[2].Click();
            Driver.FindElements(UISelectSearch_TextBox)[2].SendKeys(Data.assets.Brand + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[3].Click();
            Driver.FindElements(UISelectSearch_TextBox)[3].SendKeys(Data.assets.originType + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[4].Click();
            Driver.FindElements(UISelectSearch_TextBox)[4].SendKeys(Data.assets.parentclass + Keys.Enter);
            time.Sleep(2000);
            Driver.FindElement(ageofassetsinyeras).Clear();
            Driver.FindElement(ageofassetsinyeras).SendKeys(Data.assets.ageofassets);
            Driver.FindElement(originName).SendKeys(Data.assets.OriginName);
            
            Driver.FindElement(origincode).SendKeys(Data.assets.origincode);
            Driver.FindElement(priceofassets).Clear();
            Driver.FindElement(priceofassets).SendKeys(Data.assets.Thepriceofassets);
            time.Sleep(2000);
            Driver.FindElement(Date).Clear();
            time.Sleep(2000);
            Driver.FindElement(Date).SendKeys(Data.assets.Date);

            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
            






















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
        public static void Edit_Assets(string AssetsName, string newName)
        {
            Search(AssetsName);
            time.Sleep(1000);
            Driver.FindElement(firstItemEdit_Button).Click();
            time.Sleep(1000);
            Driver.FindElement(AssetsName_textbox).Clear();
            Driver.FindElement(AssetsName_textbox).SendKeys(newName);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }

        public static void Delete_Assets(string AssetsName)
        {
            Search(AssetsName);
            time.Sleep(1000);
            Driver.FindElement(firstItemDelete_Button).Click();
            time.Sleep(2000);
            Driver.FindElement(DeleteConfirm_Button).Click();
            time.Sleep(3000);

        }
    }
    }

