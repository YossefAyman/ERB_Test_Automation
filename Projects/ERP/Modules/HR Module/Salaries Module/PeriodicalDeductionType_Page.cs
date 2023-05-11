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
    public class PeriodicalDeductionType_Page
    {

         static IWebDriver Driver = Common.Driver;


        // Selectors

        static By Add_Button =                                       By.ClassName("btnAddItem");
        static By PeriodicalDeductionTypeName =                      By.Id("PeriodicalDeductionType_PeriodicalDeductionTypeName");
        static By PeriodicalDeductionTypeDescription =               By.Id("PeriodicalDeductionType_PeriodicalDeductionTypeDescription");
        static By Save_Button =                                      By.XPath("//input[@value='حفظ']");
        static By Edit_Button =                                      By.XPath("//i[@title='تعديل']");
        static By FirstItemDelete_Button =                           By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button =                             By.ClassName("confirm");




        public static void Goto()
        {
            Pages.PeriodicalDeductionTypePage();
            time.Sleep(2000);

        }

        public static void Add_PeriodicalDeductionType()
        {
            Driver.FindElement(Add_Button).Click();
            Driver.FindElement(PeriodicalDeductionTypeName).SendKeys(Data.M3HR.PeriodicalDeductionType_Name);
            Driver.FindElement(PeriodicalDeductionTypeDescription).SendKeys(Data.M3HR.PeriodicalDeductionType_Desc);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }

        public static void Edit_PeriodicalDeductionType(string PeriodicalDeductionType_Name, string PeriodicalDeductionType_Desc)
        {
            Common.Search(Data.M3HR.PeriodicalDeductionType_Name);
            Driver.FindElement(Edit_Button).Click();
            Driver.FindElement(PeriodicalDeductionTypeName).Clear();
            Driver.FindElement(PeriodicalDeductionTypeName).SendKeys(PeriodicalDeductionType_Name);
            Driver.FindElement(PeriodicalDeductionTypeDescription).Clear();
            Driver.FindElement(PeriodicalDeductionTypeDescription).SendKeys(PeriodicalDeductionType_Desc);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }

        public static void Delete_PeriodicalDeductionType(string PeriodicalDeductionType_Name)
        {
            Common.Search(PeriodicalDeductionType_Name);
            Driver.FindElement(FirstItemDelete_Button).Click();
            time.Sleep(1000);
            Driver.FindElement(DeleteConfirm_Button).Click();
            time.Sleep(2000);
        }

    }
}