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
    public class Errand_Page
    {

        static IWebDriver Driver = Common.Driver;


        // Selectors

        static By Add_Button =                                  By.ClassName("btnAddItem");
        static By MissionName =                                 By.Id("Model_MissionName");
        static By Model_MissionPeriod =                         By.Id("Model_MissionPeriod");
        static By Save_Button =                                 By.XPath("//input[@value='حفظ']");
        static By EmployeeName_List =                           By.XPath("//*[@id=\"FormManager\"]/div[2]/div[2]/div/div/div[1]");
        static By EmployeeName_Input =                          By.XPath("//*[@id=\"FormManager\"]/div[2]/div[2]/div/div/div[1]/input");
        static By Dates =                                       By.ClassName("dataPickerInputMainClass");
        static By Search_Button =                               By.ClassName("btn-light");
        static By NumOfItems_Text =                             By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");
        static By Edit_Button =                                 By.XPath("//i[@title='تعديل']");
        static By EmployeeSearchList =                          By.XPath("/html[1]/body[1]/div[2]/main[1]/div[1]/div[1]/div[2]/div[1]/div[2]/section[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[2]/div[4]/div[1]/div[1]/div[1]");
        static By EmployeeNameSearch =                          By.XPath("/html/body/div[2]/main/div/div/div[2]/div/div[2]/section/div/div/div[2]/div/div/div[2]/div[4]/div/div/div[1]/input");
        static By ApproveVacationButton =                       By.XPath("//i[@class='fas fa-file-signature fa-fw actoionsButtonColored actoionsButtonColoredFixed']");
        static By FirstItemDelete_Button =                      By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button =                        By.ClassName("confirm");




        public static void Goto()
        {
            Pages.ErrandsPage();
            time.Sleep(2000);

        }

        public static void Add_Errand()
        {
            Driver.FindElement(Add_Button).Click();
            Driver.FindElement(EmployeeName_List).Click();
            Driver.FindElement(EmployeeName_Input).SendKeys(Data.M1HR.employeeName + Keys.Enter);
            Driver.FindElement(MissionName).SendKeys(Data.M2HR.Errand_Name);
            Driver.FindElements(Dates)[2].Clear();
            Driver.FindElements(Dates)[2].SendKeys(Data.M2HR.VacationRequestDate);
            Driver.FindElements(Dates)[3].Clear();
            Driver.FindElements(Dates)[3].SendKeys(Data.M2HR.VacationStartDate);
            Driver.FindElements(Dates)[4].Clear();
            Driver.FindElements(Dates)[4].SendKeys(Data.M2HR.VacationEndDate);
            Driver.FindElement(Model_MissionPeriod).SendKeys(Data.M2HR.PermissionPeriod);

            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }


        public static void Approve_Errand(string EmployeeName)
        {
            Search(EmployeeName);
            Driver.FindElement(ApproveVacationButton).Click();
            time.Sleep(1000);
            Driver.FindElement(DeleteConfirm_Button).Click();
            time.Sleep(2000);
        }


        public static void Edit_Errand(string Errand_Name)
        {
            Search(Data.M1HR.employeeName);
            Driver.FindElement(Edit_Button).Click();
            Driver.FindElement(MissionName).Clear();
            Driver.FindElement(MissionName).SendKeys(Errand_Name);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }

        public static void Delete_Errand(string AnnualHoliday_Name)
        {
            Search(AnnualHoliday_Name);
            Driver.FindElement(FirstItemDelete_Button).Click();
            time.Sleep(1000);
            Driver.FindElement(DeleteConfirm_Button).Click();
            time.Sleep(2000);
        }

        public static string Search(string EmployeeName)
        {
            Driver.FindElement(EmployeeSearchList).Click();
            Driver.FindElement(EmployeeNameSearch).SendKeys(EmployeeName + Keys.Enter);
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