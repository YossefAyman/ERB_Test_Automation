using Automation_Testing;
using ERP_Automation_Testing;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using time = System.Threading.Thread;

namespace ERP_Automation_Testing
{
    public class LeavingReason_Page
    {

        static IWebDriver Driver = Common.Driver;


        // Selectors

        static By Add_Button =              By.ClassName("btnAddItem");
        static By LeavingReason_Name =      By.Id("LeavingReason_Name");
        static By Save_Button =             By.XPath("//input[@value='حفظ']");
        static By Search_TextBox =          By.XPath("//*[@id=\"leavingReasonController\"]/div[2]/section/div/div/div[2]/div/div/div[1]/div[1]/div/input");
        static By Search_Button =           By.XPath("//*[@id=\"leavingReasonController\"]/div[2]/section/div/div/div[2]/div/div/div[1]/div[1]/div/span/button");
        static By NumOfItems_Text =         By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");
        static By Edit_Button =             By.XPath("//i[@title='تعديل']");
        static By FirstItemDelete_Button =  By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button =    By.ClassName("confirm");




        public static void Goto()
        {
            Pages.TheLeavingReasonPage();
            time.Sleep(2000);

        }

        public static void Add_LeavingReason()
        {
            Driver.FindElement(Add_Button).Click();
            Driver.FindElement(LeavingReason_Name).SendKeys(Data.M1HR.LeavingReason_Name);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }

        public static void Edit_LeavingReason(string LeavingReason)
        {
            Search(Data.M1HR.LeavingReason_Name);
            Driver.FindElement(Edit_Button).Click();
            Driver.FindElement(LeavingReason_Name).Clear();
            Driver.FindElement(LeavingReason_Name).SendKeys(LeavingReason);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }

        public static void Delete_LeavingReason(string LeavingReason)
        {
            Search(LeavingReason);
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