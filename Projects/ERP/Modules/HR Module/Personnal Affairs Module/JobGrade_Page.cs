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
    public class JobGrade_Page
    {
        static IWebDriver Driver = Automation_Testing.Common.Driver;


        // Selectors

        static By Add_Button =                  By.ClassName("btnAddItem");
        static By Save_Button =                 By.XPath("//input[@value='حفظ']");
        static By JobGrade_Name =               By.Id("EmploymentDegree_Name");
        static By Search_TextBox =              By.XPath("//input[@placeholder='بحث']");
        static By Search_Button =               By.XPath("//i[@class='fa fa-search']");
        static By NumOfItems_Text =             By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");
        static By Edit_Button =                 By.XPath("//i[@title='تعديل']");
        static By FirstItemDelete_Button =      By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button =        By.ClassName("confirm");


        public static void Goto()
        {
            Pages.JobGradePage();
            time.Sleep(2000);

        }

        public static void Add_JobGrade()
        {
            Driver.FindElement(Add_Button).Click();
            Driver.FindElement(JobGrade_Name).SendKeys(Data.M1HR.JobGradeName);
            Driver.FindElement(Save_Button).Click();
        }

        public static void Edit_JobGrade(string JobGrade)
        {
            Search(Data.M1HR.JobGradeName);
            Driver.FindElement(Edit_Button).Click();
            Driver.FindElement(JobGrade_Name).Clear();
            Driver.FindElement(JobGrade_Name).SendKeys(JobGrade);
            Driver.FindElement(Save_Button).Click();
        }

        public static void Delete_JobGrade(string JobGrade_Name)
        {
            Search(JobGrade_Name);
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