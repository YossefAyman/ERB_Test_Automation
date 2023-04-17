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
    public class AnnualHolidays_Page
    {

         static IWebDriver Driver = Common.Driver;


        // Selectors

        static By Add_Button =                                      By.ClassName("btnAddItem");
        static By OfficialVacationName =                            By.Id("Model_OfficialVacationName");
        static By OccasionDescription =                             By.Id("Model_OccasionDescription");
        static By Save_Button =                                     By.XPath("//input[@value='حفظ']");
        static By StartDate   =                                     By.XPath("/html[1]/body[1]/div[2]/main[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[2]/div[1]/div[1]/div[2]/div[1]/form[1]/div[1]/div[2]/div[1]/date-picker-directive[1]/div[1]/input[1]");
        static By EndDate   =                                       By.XPath("/html/body/div[2]/main/div/div/div[2]/div/div[2]/div[2]/div/div[1]/div[2]/div[1]/form/div[1]/div[3]/div/date-picker-directive/div/input[1]");
        static By Search_TextBox =                                  By.ClassName("ng-valid");
        static By Search_Button =                                   By.ClassName("btn-light");
        static By NumOfItems_Text =                                 By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");
        static By Edit_Button =                                     By.XPath("//i[@title='تعديل']");
        static By FirstItemDelete_Button =                          By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button =                            By.ClassName("confirm");




        public static void Goto()
        {
            Pages.AnnualHolidaysPage();
            time.Sleep(2000);

        }

        public static void Add_AnnualHoliday()
        {
            Driver.FindElement(Add_Button).Click();
            Driver.FindElement(OfficialVacationName).SendKeys(Data.M2HR.AnnualHoliday_Name);
            Driver.FindElement(StartDate).SendKeys(Data.RandomDate());
            Driver.FindElement(EndDate).SendKeys(Data.RandomDate());
            Driver.FindElement(OccasionDescription).SendKeys(Data.M2HR.AnnualHoliday_Desc);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }

        public static void Edit_AnnualHoliday(string AnnualHoliday_Name, string AnnualHoliday_Desc)
        {
            Search(Data.M2HR.AnnualHoliday_Name);
            Driver.FindElement(Edit_Button).Click();
            Driver.FindElement(OfficialVacationName).Clear();
            Driver.FindElement(OfficialVacationName).SendKeys(AnnualHoliday_Name);
            Driver.FindElement(OccasionDescription).Clear();
            Driver.FindElement(OccasionDescription).SendKeys(AnnualHoliday_Desc);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }

        public static void Delete_AnnualHoliday(string AnnualHoliday_Name)
        {
            Search(AnnualHoliday_Name);
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