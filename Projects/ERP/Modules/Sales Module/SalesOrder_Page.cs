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
    public class SalesOrder_Page
    {


        static IWebDriver Driver = Automation_Testing.Common.Driver;

        static By Add_Button =                              By.XPath("/html/body/div[2]/main/div/div/div[2]/div/div[2]/section/div/div/div[2]/div/div/div[3]/div[2]/div/button[3]");
        static By DeliveryPrice =                           By.Id("DeliveryPrice_Price");
        static By Save_Button =                             By.XPath("//*[@id=\"frm\"]/input");
        static By Add_Detalis_Button =                      By.ClassName("btn-success");
        static By Search_TextBox =                          By.ClassName("ng-valid");
        static By Search_Button =                           By.ClassName("btn-light");
        static By EditFirstItem_Button =                    By.ClassName("btnEditItem");
        static By DeleteFirstItem_Button =                  By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button =                    By.ClassName("confirm");
        static By NumOfItems_Text =                         By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");
        static By UISelect_DDL =                            By.ClassName("ui-select-container");
        static By UISelectSearch_TextBox =                  By.ClassName("ui-select-search");
        static By Item_Name =                               By.XPath("//*[@id=\"FormManager\"]/fieldset[2]/div[2]/table/tbody/tr/th[2]/center/div/div/div[1]/input");
        static By DateFrom =                                By.XPath("/html[1]/body[1]/div[2]/main[1]/div[1]/div[1]/div[2]/div[1]/div[2]/section[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/date-picker-directive[1]/div[1]/input[1]");
        static By Item_Count =                              By.XPath("/html[1]/body[1]/div[2]/main[1]/div[1]/div[1]/div[2]/section[1]/div[1]/div[1]/div[2]/div[1]/form[1]/fieldset[2]/div[2]/table[1]/tbody[1]/tr[1]/th[3]/div[1]/input[1]");
        public static void Goto()
        {
            Pages.SalesOrderPage();
        }
        public static void Add_SalesOrder()
        {
            Driver.FindElement(Add_Button).Click();
            Driver.FindElements(UISelect_DDL)[0].Click();
            Driver.FindElements(UISelectSearch_TextBox)[0].SendKeys(Data.Sales.Clinet_Name + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[1].Click();
            Driver.FindElements(UISelectSearch_TextBox)[1].SendKeys(Data.Sales.PayMethod + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[2].Click();
            Driver.FindElements(UISelectSearch_TextBox)[2].SendKeys(Data.Sales.Store + Keys.Enter);
            Driver.FindElement(Add_Detalis_Button).Click();
            Driver.FindElement(Item_Name).SendKeys(Data.Sales.Item_Name + Keys.Enter);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(5000);
        }

        public static void Edit_SalesOrder()
        {
            Search();
            Driver.FindElement(EditFirstItem_Button).Click();
            Driver.FindElement(Item_Count).Clear();
            Driver.FindElement(Item_Count).SendKeys(Data.Sales.Quantity);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(5000);

        }
        public static void Delete_SalesOrder()
        {
            Search();
            time.Sleep(1000);
            Driver.FindElement(DeleteFirstItem_Button).Click();
            time.Sleep(1000);
            Driver.FindElement(DeleteConfirm_Button).Click();
            time.Sleep(5000);
        }
        public static string Search()
            {
            time.Sleep(1000);
            Driver.FindElement(DateFrom).Clear();
            Driver.FindElement(DateFrom).SendKeys(Data.DateValue);
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