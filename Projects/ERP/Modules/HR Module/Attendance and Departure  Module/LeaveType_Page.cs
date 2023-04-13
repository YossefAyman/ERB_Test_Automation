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
    public class LeaveType_Page
    {

        static IWebDriver Driver = Common.Driver;


        // Selectors

        static By Add_Button =                           By.ClassName("btnAddItem");
        static By VacationTypeName =                     By.Id("Model_VacationTypeName");
        static By Save_Button =                          By.XPath("//input[@ng-click='addUpdate()']");
        static By Paid_CheckBox =                        By.XPath("//*[@id=\"FormManager\"]/div[2]/div/div/div/label");
        static By Migration_CheckBox =                   By.XPath("//*[@id=\"FormManager\"]/div[3]/div[1]/div/div/label");
        static By Approved_CheckBox =                    By.XPath("//*[@id=\"FormManager\"]/div[3]/div[2]/div/div/label");
        static By Search_TextBox =                       By.ClassName("ng-valid");
        static By Search_Button =                        By.ClassName("btn-light");
        static By NumOfItems_Text =                      By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");
        static By Edit_Button =                          By.XPath("//i[@title='تعديل']");
        static By FirstItemDelete_Button =               By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button =                 By.ClassName("confirm");




        public static void Goto()
        {
            Pages.LeaveTypePage();
            time.Sleep(2000);

        }

        public static void Add_LeaveType()
        {
            Driver.FindElement(Add_Button).Click();
            Driver.FindElement(VacationTypeName).SendKeys(Data.M2HR.LeaveType_Name);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }

        public static void Add_Paid_LeaveType()
        {
            Driver.FindElement(Add_Button).Click();
            Driver.FindElement(VacationTypeName).SendKeys(Data.M2HR.LeaveType_Name);
            Driver.FindElement(Paid_CheckBox).Click();
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }
        public static void Add_Migration_LeaveType()
        {
            Driver.FindElement(Add_Button).Click();
            Driver.FindElement(VacationTypeName).SendKeys(Data.M2HR.LeaveType_Name);
            Driver.FindElement(Migration_CheckBox).Click();
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }
        public static void Add_NeedToApproved_LeaveType()
        {
            Driver.FindElement(Add_Button).Click();
            Driver.FindElement(VacationTypeName).SendKeys(Data.M2HR.LeaveType_Name);
            Driver.FindElement(Approved_CheckBox).Click();
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }

        public static void Edit_LeaveType(string LeaveType_Name)
        {
            Search(Data.M2HR.LeaveType_Name);
            Driver.FindElement(Edit_Button).Click();
            Driver.FindElement(VacationTypeName).Clear();
            Driver.FindElement(VacationTypeName).SendKeys(LeaveType_Name);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }

        public static void Delete_LeaveType(string LeaveType_Name)
        {
            Search(LeaveType_Name);
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