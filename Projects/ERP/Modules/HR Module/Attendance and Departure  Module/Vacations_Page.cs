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
    public class Vacations_Page
    {

          static IWebDriver Driver = Common.Driver;


        // Selectors

        static By Add_Button =                                       By.ClassName("btnAddItem");
        static By EmployeeCheckList =                                By.CssSelector("input[placeholder=' الموظف']");
        static By vacationCheckList =                                By.CssSelector("input[placeholder='نوع الإجازة']");
        static By Dates =                                            By.ClassName("dataPickerInputMainClass");
        static By VacationTypeCheckList =                            By.XPath("/html[1]/body[1]/div[3]/main[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[2]/div[1]/div[1]/div[2]/div[1]/form[1]/div[3]/div[1]/div[1]/div[1]/div[1]");
        static By VacationType =                                     By.XPath("/html[1]/body[1]/div[3]/main[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[2]/div[1]/div[1]/div[2]/div[1]/form[1]/div[3]/div[1]/div[1]/div[1]/div[1]/input[1]");
        static By Save_Button =                                      By.XPath("//input[@value='حفظ']");
        static By Model_Duration =                                   By.Id("Model_Duration");
        static By Search_TextBox =                                   By.XPath("//*[@id=\"vacationController\"]/div[2]/section/div/div/div[2]/div/div/div[2]/div[2]/div/div/div[1]/input");
        static By Search_Button =                                    By.ClassName("btn-light");
        static By NumOfItems_Text =                                  By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");
        static By Edit_Button =                                      By.XPath("//i[@title='تعديل']");
        static By ApproveVacationButton =                            By.XPath("//i[@class='fas fa-file-signature fa-fw actoionsButtonColored actoionsButtonColoredFixed']");
        static By HamburgerMenuButton =                              By.XPath("//*[@id=\"1681821054196-grid-menu\"]/i");
        static By HideDateOfRequestVacation =                        By.CssSelector("#menuitem-3 > button");
        static By FirstItemDelete_Button =                           By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button =                             By.ClassName("confirm");




        public static void Goto()
        {
            Pages.VacationsPage();
            time.Sleep(2000);

        }

        public static void Add_Vacation()
        {
            Driver.FindElement(Add_Button).Click();
            Driver.FindElement(EmployeeCheckList).Click();
            Driver.FindElement(EmployeeCheckList).SendKeys(Data.M1HR.employeeName + Keys.Enter);
            Driver.FindElements(Dates)[2].SendKeys(Data.M2HR.VacationRequestDate);
            Driver.FindElements(Dates)[3].SendKeys(Data.M2HR.DateOfStartWorkAfterVacation);
            Driver.FindElements(Dates)[4].SendKeys(Data.M2HR.VacationStartDate);
            Driver.FindElements(Dates)[5].SendKeys(Data.M2HR.VacationEndDate);
            Driver.FindElement(vacationCheckList).Click();
            Driver.FindElement(vacationCheckList).SendKeys(Data.M1HR.VacationType + Keys.Enter);
            Driver.FindElement(Model_Duration).Clear();
            Driver.FindElement(Model_Duration).SendKeys(Data.M2HR.PermissionPeriod);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }

        /* public static void Edit_Vacation(string PermissionType_Name , string PermissionType_Desc)
         {
             Search(Data.M2HR.PermissionType_Name);
             Driver.FindElement(Edit_Button).Click();
             Driver.FindElement(EmployeePermissionTypeName).Clear();
             Driver.FindElement(EmployeePermissionTypeName).SendKeys(PermissionType_Name);
             Driver.FindElement(EmployeePermissionTypeDescription).Clear();
             Driver.FindElement(EmployeePermissionTypeDescription).SendKeys(PermissionType_Desc);
             Driver.FindElement(Save_Button).Click();
             time.Sleep(3000);
         }*/

        public static void Approve_Vacation(string Vacation)
        {
            Search(Vacation);
            if (Driver.FindElement(ApproveVacationButton).Displayed)
            {
                Driver.FindElement(ApproveVacationButton).Click();
                time.Sleep(1000);
                Driver.FindElement(DeleteConfirm_Button).Click();
             }
            else
            {
                Driver.FindElement(HamburgerMenuButton).Click();
                Driver.FindElement(HideDateOfRequestVacation).Click();
            }

            time.Sleep(2000);
        }

        public static void Delete_Vacation(string Vacation)
        {
            Search(Vacation);
            Driver.FindElement(FirstItemDelete_Button).Click();
            time.Sleep(1000);
            Driver.FindElement(DeleteConfirm_Button).Click();
            time.Sleep(2000);
        }

        public static string Search(string EmployeeName)
        {
            Driver.FindElement(Search_TextBox).Click();
            Driver.FindElement(Search_TextBox).SendKeys(EmployeeName + Keys.Enter);
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