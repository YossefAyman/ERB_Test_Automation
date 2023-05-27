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
using static ERP_Automation_Testing.Data;

namespace ERP_Automation_Testing
{
    public class DeliveryPrice_Page
    {

        static IWebDriver Driver = Automation_Testing.Common.Driver;

        static By Add_Button =                              By.ClassName("btnAddItem");
        static By DeliveryPrice =                           By.Id("DeliveryPrice_Price");
        static By Save_Button =                             By.ClassName("btn-primary");
        static By Search_TextBox =                          By.ClassName("ng-valid");
        static By Search_Button =                           By.ClassName("btn-light");
        static By EditFirstItem_Button =                    By.ClassName("btnEditItem");
        static By DeleteFirstItem_Button =                  By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button =                    By.ClassName("confirm");
        static By NumOfItems_Text =                         By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");
          static By UISelect_DDL =                          By.ClassName("ui-select-container");
        static By UISelectSearch_TextBox =                  By.ClassName("ui-select-search");

        public static void Goto()
        {
            Pages.DeliveryPricePage();
        }
        public static void Add_DliveryPrice()
        {
            Driver.FindElement(Add_Button).Click();
            Driver.FindElement(DeliveryPrice).SendKeys(Data.Sales.Quantity);
            Driver.FindElements(UISelect_DDL)[1].Click();
            Driver.FindElements(UISelectSearch_TextBox)[1].SendKeys(Data.Sales.District + Keys.Enter);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }

        public static void Edit_DliveryPrice()
        {
            Search();
            Driver.FindElement(EditFirstItem_Button).Click();
            Driver.FindElement(DeliveryPrice).Clear();
            Driver.FindElement(DeliveryPrice).SendKeys(Data.Sales.Price);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);

        }
        public static void Delete_DliveryPrice()
        {
            Search();
            time.Sleep(1000);
            Driver.FindElement(DeleteFirstItem_Button).Click();
            time.Sleep(1000);
            Driver.FindElement(DeleteConfirm_Button).Click();
            time.Sleep(2000);
        }
        public static string Search()
        {
            Driver.FindElements(UISelect_DDL)[0].Click();
            Driver.FindElements(UISelectSearch_TextBox)[0].SendKeys(Data.Sales.District + Keys.Enter);
            time.Sleep(1000);
             if (Driver.FindElement(NumOfItems_Text).GetAttribute("class") == "ng-binding ng-hide")
            {
                return "NotExist";
            }
            else
            {
                return "Exist";
            }
        }
    }
}