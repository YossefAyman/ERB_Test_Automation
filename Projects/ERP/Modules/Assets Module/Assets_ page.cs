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
    public class Assets_page

    {
        static IWebDriver Driver = Automation_Testing.Common.Driver;


        /// /////////////////// # Selectors # /////////////////////////////////////////////

        static By Add_Button =                      By.ClassName("btnAddItem");
        static By AddAttachment_Button =            By.CssSelector("#AttachmentFormManager > div:nth-child(3) > div:nth-child(1) > div > div.drop-box.w-100.ng-pristine.ng-untouched.ng-valid.ng-empty > i");
        static By Save_Button =                     By.XPath("//input[@value='حفظ']");
        static By NumOfItems_Text =                 By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");
        static By UISelect_DDL =                    By.ClassName("ui-select-container");
        static By UISelectSearch_TextBox =          By.ClassName("ui-select-search");
        static By ageofassetsinyeras =              By.Id("FixedAssetItem_Years");
        static By originName =                      By.Id("FixedAssetItem_ItemName");
        static By origincode =                      By.Id("FixedAssetItem_ItemCode");
        static By priceofassets =                   By.Id("FixedAssetItem_ItemPrice");
        static By Date =                            By.ClassName("dataPickerInputMainClass");
        static By Search_Button =                   By.XPath("//*[@id=\"fixedAssetsController\"]/div[2]/section/div/div/div[2]/div/div/div[2]/div[1]/div/span/button");
        static By Search_TextBox =                  By.XPath("//*[@id=\"fixedAssetsController\"]/div[2]/section/div/div/div[2]/div/div/div[2]/div[1]/div/input");
        static By FirstItemEdit_Button =            By.XPath("//div[@class='ui-grid-canvas']//div[1]//div[1]//div[6]//div[1]//i[1]");
        static By AssetName_TextBox =               By.Id("FixedAssetItem_ItemName");
        static By AssetPrice_TextBox =              By.Id("FixedAssetItem_ItemPrice");
        static By FirstItemDelete_Button =          By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button =            By.ClassName("confirm");



        public static void Goto()

        {
            Pages.Assets();
            time.Sleep(2000);

        }
        public static void AddAssets()
        {
            Driver.FindElement(Add_Button).Click();
            time.Sleep(1000);
            Driver.FindElements(UISelect_DDL)[2].Click();
            Driver.FindElements(UISelectSearch_TextBox)[2].SendKeys(Data.assets.Brand + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[3].Click();
            Driver.FindElements(UISelectSearch_TextBox)[3].SendKeys(Data.assets.originType + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[4].Click();
            Driver.FindElements(UISelectSearch_TextBox)[4].SendKeys(Data.assets.parentclass + Keys.Enter);
            Driver.FindElement(ageofassetsinyeras).Clear();
            Driver.FindElement(ageofassetsinyeras).SendKeys(Data.assets.ageofassets);
            Driver.FindElement(originName).SendKeys(Data.assets.OriginName);
            Driver.FindElement(origincode).SendKeys(Data.assets.origincode);
            Driver.FindElement(priceofassets).Clear();
            Driver.FindElement(priceofassets).SendKeys(Data.assets.Thepriceofassets);
            Driver.FindElement(Date).Clear();
            Driver.FindElement(Date).SendKeys(Data.assets.Date);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);


        }

        public static void Edit_Asset(string asset_Name ,string newName, string newValue)
        {
            Search(asset_Name);
            Driver.FindElement(FirstItemEdit_Button).Click();
            time.Sleep(1000);
            Driver.FindElement(AssetName_TextBox).Clear();
            Driver.FindElement(AssetName_TextBox).SendKeys(newName);
            Driver.FindElement(AssetPrice_TextBox).Clear();
            Driver.FindElement(AssetPrice_TextBox).SendKeys(newValue);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }



        public static void Delete_Asset(string asset_Name)
        {
            Search(asset_Name);
            Driver.FindElement(FirstItemDelete_Button).Click();
            time.Sleep(1000);
            Driver.FindElement(DeleteConfirm_Button).Click();
            time.Sleep(2000);
        }




        public static string Search(string item)
        {
            Driver.FindElement(Search_TextBox).Clear();
            Driver.FindElement(Search_TextBox).SendKeys(item);
            Driver.FindElement(Search_Button).Click();
            time.Sleep(2000);

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

