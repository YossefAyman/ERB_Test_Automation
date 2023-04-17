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
    public class Permissions_Page
    {

         static IWebDriver Driver = Common.Driver;


        // Selectors

        static By Add_Button =                                      By.ClassName("btnAddItem");
        static By OfficialVacationName =                            By.Id("Model_OfficialVacationName");
        static By OccasionDescription =                             By.Id("Model_OccasionDescription");
        static By PermissionPeriod =                                By.Id("Model_PermissionPeriod");
        static By Model_Reason =                                    By.Id("Model_Reason");
        static By TimeFrom =                                        By.Id("Model_TimeFrom");
        static By TimeTo =                                          By.Id("Model_TimeTo");
        static By Save_Button =                                     By.XPath("//input[@value='حفظ']");
        static By Permission_Type =                                 By.XPath("/html[1]/body[1]/div[2]/main[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[2]/div[1]/div[1]/div[2]/div[1]/form[1]/div[3]/div[1]/div[1]/div[1]/div[1]");
        static By Permission_Type_Name =                            By.XPath("/html[1]/body[1]/div[2]/main[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[2]/div[1]/div[1]/div[2]/div[1]/form[1]/div[3]/div[1]/div[1]/div[1]/div[1]/input[1]");
        static By Employee_PlaceHolder =                            By.XPath("/html[1]/body[1]/div[2]/main[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[2]/div[1]/div[1]/div[2]/div[1]/form[1]/div[2]/div[2]/div[1]/div[1]/div[1]");
        static By StartDate   =                                     By.XPath("/html[1]/body[1]/div[2]/main[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[2]/div[1]/div[1]/div[2]/div[1]/form[1]/div[4]/div[1]/div[1]/date-picker-directive[1]/div[1]/input[1]");
        static By EmployeeName   =                                  By.XPath("//*[@id=\"FormManager\"]/div[2]/div[2]/div/div/div[1]/input");
        static By AM_Or_PM   =                                      By.XPath("/html[1]/body[1]/div[2]/main[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[2]/div[1]/div[1]/div[2]/div[1]/form[1]/div[5]/div[3]/div[1]/div[1]/div[1]");
        static By AM_Or_PM_Search   =                               By.XPath("/html/body/div[2]/main/div/div/div[2]/div/div[2]/div[2]/div/div[1]/div[2]/div[1]/form/div[5]/div[3]/div/div/div[1]/input");
        static By Search_TextBox =                                  By.ClassName("ng-valid");
        static By Search_Button =                                   By.ClassName("btn-light");
        static By NumOfItems_Text =                                 By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");
        static By Edit_Button =                                     By.XPath("//i[@title='تعديل']");
        static By FirstItemDelete_Button =                          By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button =                            By.ClassName("confirm");
        static By EmoployeeSearchList =                             By.XPath("/html/body/div[2]/main/div/div/div[2]/div/div[2]/section/div/div/div[2]/div/div/div[2]/div[2]/div/div/div[1]");
        static By EmoployeeSearchName =                             By.XPath("/html/body/div[2]/main/div/div/div[2]/div/div[2]/section/div/div/div[2]/div/div/div[2]/div[2]/div/div/div[1]/input");




        public static void Goto()
        {
            Pages.PermissionsPage();
            time.Sleep(2000);

        }

        public static void Add_Permssion()
        {
            Driver.FindElement(Add_Button).Click();
            Driver.FindElement(Employee_PlaceHolder).Click();
            Driver.FindElement(EmployeeName).SendKeys(Data.M1HR.employeeName + Keys.Enter);
            Driver.FindElement(Permission_Type).Click();
            Driver.FindElement(Permission_Type_Name).SendKeys(Data.M2HR.permissionType + Keys.Enter);
            Driver.FindElement(StartDate).SendKeys(Data.RandomDate());
            Driver.FindElement(PermissionPeriod).SendKeys(Data.M2HR.PermissionPeriod);
            Driver.FindElement(TimeFrom).Clear();
            Driver.FindElement(TimeFrom).SendKeys(Data.M2HR.PermissionTimeFrom);
            Driver.FindElement(TimeTo).Clear();
            Driver.FindElement(TimeTo).SendKeys(Data.M2HR.PermissionTimeTo);
            Driver.FindElement(AM_Or_PM).Click();
            Driver.FindElement(AM_Or_PM_Search).SendKeys(Data.M2HR.AmTime + Keys.Enter);
            Driver.FindElement(Model_Reason).SendKeys(Data.M2HR.PermissionReason);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }

        public static void Edit_Permssion(string Permssion_Reason)
        {
            Search(Data.M1HR.employeeName);
            Driver.FindElement(Edit_Button).Click();
            Driver.FindElement(Model_Reason).Clear();
            Driver.FindElement(Model_Reason).SendKeys(Permssion_Reason);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }

        public static void Delete_Permssion(string EmployeeName)
        {
            Search(EmployeeName);
            Driver.FindElement(FirstItemDelete_Button).Click();
            time.Sleep(1000);
            Driver.FindElement(DeleteConfirm_Button).Click();
            time.Sleep(2000);
        }

        public static string Search(string EmployeeName)
        {
            Driver.FindElement(EmoployeeSearchList).Click();
            Driver.FindElement(EmoployeeSearchName).SendKeys(EmployeeName + Keys.Enter);
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