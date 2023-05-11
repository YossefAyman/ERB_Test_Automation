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
    public class WorkingYear_Page
    {
        static IWebDriver Driver = Common.Driver;


        // Selectors

        static By Add_Button =                            By.ClassName("btnAddItem");
        static By WorkingYearName =                       By.Id("WorkingYear_WorkingYearName");
        static By UISelect_DDL =                          By.ClassName("ui-select-container");
        static By UISelectSearch_TextBox =                By.ClassName("ui-select-search");
        static By Save_Button =                           By.XPath("//input[@value='حفظ']");
        static By Start_Date =                            By.XPath("/html[1]/body[1]/div[2]/main[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[2]/div[1]/div[1]/div[2]/div[1]/form[1]/div[2]/div[1]/date-picker-directive[1]/div[1]/input[1]");
        static By End_Date =                              By.XPath("/html[1]/body[1]/div[2]/main[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[2]/div[1]/div[1]/div[2]/div[1]/form[1]/div[2]/div[2]/date-picker-directive[1]/div[1]/input[1]");
        static By Search_TextBox =                        By.XPath("/html/body/div[2]/main/div/div/div[2]/div/div[2]/section/div/div/div[2]/div/div/div[1]/div[1]/div/input");
        static By Search_Button =                         By.XPath("/html/body/div[2]/main/div/div/div[2]/div/div[2]/section/div/div/div[2]/div/div/div[1]/div[1]/div/span/button");
        static By NumOfItems_Text =                       By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");
        static By Edit_Button =                           By.XPath("//i[@title='تعديل']");
        static By FirstItemDelete_Button =                By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button =                  By.ClassName("confirm");


        public static void Goto()
        {
            Pages.WorkingYearPage();
            time.Sleep(2000);

        }


        public static void Add_WorkingYear()
        {
            Driver.FindElement(Add_Button).Click();
            Driver.FindElement(WorkingYearName).SendKeys(Data.M1HR.WorkingYear_Name);
            Driver.FindElements(UISelect_DDL)[0].Click();
            Driver.FindElement(UISelectSearch_TextBox).SendKeys(Data.M1HR.WorkingYearStatus + Keys.Enter);
            Driver.FindElement(Start_Date).SendKeys(Data.RandomDate());
            Driver.FindElement(End_Date).SendKeys(Data.RandomDate());

            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }


        public static void Edit_WorkingYear(string WorkingYear)
        {
            Search(Data.M1HR.WorkingYear_Name);
            Driver.FindElement(Edit_Button).Click();
            Driver.FindElement(WorkingYearName).Clear();
            Driver.FindElement(WorkingYearName).SendKeys(WorkingYear);
            Driver.FindElement(Start_Date).Clear();
            Driver.FindElement(Start_Date).SendKeys(Data.RandomDate());
            Driver.FindElement(End_Date).Clear();
            Driver.FindElement(End_Date).SendKeys(Data.RandomDate());
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }

        public static void Delete_WorkingYear(string WorkingYear)
        {
            Search(WorkingYear);
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