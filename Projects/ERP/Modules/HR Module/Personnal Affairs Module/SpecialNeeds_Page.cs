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
    public class SpecialNeeds_Page
    {

        static IWebDriver Driver = Common.Driver;


        // Selectors

        static By Add_Button =                              By.ClassName("btnAddItem");
        static By UISelect_DDL =                            By.ClassName("ui-select-container");
        static By UISelectSearch_TextBox =                  By.ClassName("ui-select-search");   
        static By SpecialNeeds_CertificateNumber =          By.Id("SpecialNeeds_CertificateNumber");
        static By SpecialNeeds_Description =                By.Id("SpecialNeeds_Description");
        static By Date  =                                   By.XPath("/html/body/div[2]/main/div/div/div[2]/div/div[2]/div[2]/div/div[1]/div[2]/div[1]/form/div[1]/div[6]/div/date-picker-directive/div/input[1]");
        static By SpecialNeeds_IsActive =                   By.Id("SpecialNeeds_IsActive");
        static By Save_Button =                             By.XPath("//input[@value='حفظ']");
        static By Search_TextBox =                          By.ClassName("ng-valid");
        static By Search_Button =                           By.ClassName("btn-light");
        static By NumOfItems_Text =                         By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");
        static By Edit_Button =                             By.XPath("//i[@title='تعديل']");
        static By FirstItemDelete_Button =                  By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button =                    By.ClassName("confirm");
       


        public static void Goto()
        {
            Pages.SpecialNeedsPage();
            time.Sleep(2000);


        }

        public static void Add_SpecialNeed()
        {
            Driver.FindElement(Add_Button).Click();
            Driver.FindElements(UISelect_DDL)[0].Click();
            Driver.FindElements(UISelectSearch_TextBox)[0].SendKeys(Data.M1HR.employeeName + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[1].Click();
            Driver.FindElements(UISelectSearch_TextBox)[1].SendKeys(Data.M1HR.typeOfDisability + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[2].Click();
            Driver.FindElements(UISelectSearch_TextBox)[2].SendKeys(Data.M1HR.degreeOfDisability + Keys.Enter);
            Driver.FindElement(SpecialNeeds_CertificateNumber).Clear();
            Driver.FindElement(SpecialNeeds_CertificateNumber).SendKeys(Data.M1HR.SpecialNeedCertifNum);
            Driver.FindElement(SpecialNeeds_Description).SendKeys(Data.M1HR.SpecialNeedDec);
            Driver.FindElement(Date).SendKeys(Data.RandomDate());
            Driver.FindElement(SpecialNeeds_IsActive).Click();
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }

        public static void Edit_SpecialNeede(string SpecialNeed_Dec)
        {
            Search(Data.M1HR.SpecialNeedCertifNum);
            Driver.FindElement(Edit_Button).Click();
            Driver.FindElement(SpecialNeeds_Description).Clear();
            Driver.FindElement(SpecialNeeds_Description).SendKeys(SpecialNeed_Dec); 
            Driver.FindElement(Date).Clear();
            Driver.FindElement(Date).SendKeys(Data.RandomDate());

            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }

        public static void Delete_SpecialNeed(string SpecialNeedCertifNum)
        {
            Search(SpecialNeedCertifNum);
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