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
    public class SuspensionReason_Page
    {

        static IWebDriver Driver = Automation_Testing.Common.Driver;

        static By Add_Button =                           By.ClassName("btnAddItem");
        static By SuspensionReasonName =                 By.Id("SuspensionReason_SuspensionReasonName");
        static By Save_Button =                          By.ClassName("btn-primary");
        static By Search_TextBox =                       By.ClassName("ng-valid");
        static By Search_Button =                        By.ClassName("btn-light");
        static By EditFirstItem_Button =                 By.ClassName("btnEditItem");
        static By DeleteFirstItem_Button =               By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button =                 By.ClassName("confirm");
        static By NumOfItems_Text =                      By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");

        public static void Goto()
        {
            Pages.SuspensionReasonPage();
        }
        public static void Add_SuspensionReason()
        {
            Driver.FindElement(Add_Button).Click();
            Driver.FindElement(SuspensionReasonName).SendKeys(Data.Estates.SuspensionReason_Name);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }

        public static void Edit_SuspensionReason(string SuspensionReason_Name, string SuspensionReason_NewName)
        {
            Search(SuspensionReason_Name);
            Driver.FindElement(EditFirstItem_Button).Click();
            Driver.FindElement(SuspensionReasonName).Clear();
            Driver.FindElement(SuspensionReasonName).SendKeys(SuspensionReason_NewName);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);

        }
        public static void Delete_SuspensionReason(string SuspensionReason)
        {
            Search(SuspensionReason);
            time.Sleep(1000);
            Driver.FindElement(DeleteFirstItem_Button).Click();
            time.Sleep(1000);
            Driver.FindElement(DeleteConfirm_Button).Click();
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


    }
}