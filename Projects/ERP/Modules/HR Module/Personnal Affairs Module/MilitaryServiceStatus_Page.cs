using Automation_Testing;
using ERP_Automation_Testing;
using LMS_Automation_Testing;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Automation_Testing.Common;
using time = System.Threading.Thread;

namespace ERP_Automation_Testing
{
    public class MilitaryServiceStatus_Page
    {
        static IWebDriver Driver = Automation_Testing.Common.Driver;


        // Selectors

        static By Add_Button =                  By.ClassName("btnAddItem");
        static By Save_Button =                 By.XPath("//input[@value='حفظ']");
        static By UISelect_DDL =                By.ClassName("ui-select-container");
        static By UISelectSearch_TextBox =      By.XPath("//*[@id=\"FormManager\"]/div[1]/div[1]/div/div/div/div/input");
        static By UISelectSearch_TextBox2 =     By.XPath("//*[@id=\"FormManager\"]/div[1]/div[2]/div/div/div/div/input");
        static By Date =                        By.XPath("/html[1]/body[1]/div[2]/main[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[2]/div[1]/div[1]/div[2]/div[1]/form[1]/div[1]/div[3]/div[1]/date-picker-directive[1]/div[1]/input[1]");
        static By Date2 =                       By.XPath("/html[1]/body[1]/div[2]/main[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[2]/div[1]/div[1]/div[2]/div[1]/form[1]/div[1]/div[4]/div[1]/date-picker-directive[1]/div[1]/input[1]");
        static By Date3 =                       By.XPath("/html[1]/body[1]/div[2]/main[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[2]/div[1]/div[1]/div[2]/div[1]/form[1]/div[1]/div[5]/div[1]/date-picker-directive[1]/div[1]/input[1]");
        static By Date4 =                       By.XPath("/html[1]/body[1]/div[2]/main[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[2]/div[1]/div[1]/div[2]/div[1]/form[1]/div[1]/div[6]/div[1]/date-picker-directive[1]/div[1]/input[1]");
        static By Date5 =                       By.XPath("/html[1]/body[1]/div[2]/main[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[2]/div[1]/div[1]/div[2]/div[1]/form[1]/div[1]/div[7]/div[1]/date-picker-directive[1]/div[1]/input[1]");
        static By ActiveCheckButton =           By.Id("EmployeeMilitaryStatus_IsActive");
        static By CustomerSearchExitDropDownList =  By.XPath("//section//div[@class='row']//div[1]//div[1]//div[1]//a[1]//abbr[1]");
        static By MilitarySevicesExitDropDownList = By.XPath("//body/div[2]/main[1]/div[1]/div[1]/div[2]/div[1]/div[2]/section[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/a[1]/abbr[1]");
        static By CustomerSearchDropDownList =      By.XPath("//body[1]/div[2]/main[1]/div[1]/div[1]/div[2]/div[1]/div[2]/section[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/a[1]/span[3]/b[1]");
        static By Search_Button =                   By.XPath("//i[@class='fa fa-search']");
        static By CustomerSearch =                  By.XPath("/html[1]/body[1]/div[2]/main[1]/div[1]/div[1]/div[2]/div[1]/div[2]/section[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]");
        static By NumOfItems_Text =                 By.CssSelector("div[class='ui-grid-pager-count'] span[class='ng-binding']");
        static By Edit_Button =                     By.XPath("//i[@title='تعديل']");
        static By FirstItemDelete_Button =          By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button  =           By.ClassName("confirm");



        public static void Goto()
        {
            Pages.MilitaryServiceStatusPage();
            time.Sleep(2000);


        }

        public static void Add_MilitaryServiceStatus()
        {
            Driver.FindElement(Add_Button).Click();
            time.Sleep(2000);
            Driver.FindElements(UISelect_DDL)[2].Click();
            Driver.FindElement(UISelectSearch_TextBox).SendKeys(Data.M1HR.employeeName + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[3].Click();
            Driver.FindElement(UISelectSearch_TextBox2).SendKeys(Data.M1HR.militarySevices + Keys.Enter);
            Driver.FindElement(Date).SendKeys(Data.RandomDate());
            Driver.FindElement(Date2).SendKeys(Data.RandomDate());
            Driver.FindElement(Date3).SendKeys(Data.RandomDate());
            Driver.FindElement(Date4).SendKeys(Data.RandomDate());
            Driver.FindElement(Date5).SendKeys(Data.RandomDate());
            Driver.FindElement(ActiveCheckButton).Click();
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }


        public static void Edit_MilitaryServiceStatus()
        {
       //     Search();
            Driver.FindElement(Edit_Button).Click();
            Driver.FindElement(Date).Clear();
            Driver.FindElement(Date).SendKeys(Data.RandomDate());
            Driver.FindElement(Date2).Clear();
            Driver.FindElement(Date2).SendKeys(Data.RandomDate());
            Driver.FindElement(Date3).Clear();
            Driver.FindElement(Date3).SendKeys(Data.RandomDate());
            Driver.FindElement(Date4).Clear();
            Driver.FindElement(Date4).SendKeys(Data.RandomDate());
            Driver.FindElement(Date5).Clear();
            Driver.FindElement(Date5).SendKeys(Data.RandomDate());
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);

        }

        public static void Delete_MilitaryServiceStatus()
        {
            if (Search() == "Exist")
            {
                Driver.FindElement(FirstItemDelete_Button).Click();
                time.Sleep(1000);
                Driver.FindElement(DeleteConfirm_Button).Click();
                time.Sleep(2000);
            }
            else
            {
            }
        }


        public static string Search()
        {
            if (Driver.FindElement(CustomerSearchExitDropDownList).Displayed)
            {

                Driver.FindElement(CustomerSearchExitDropDownList).Click();
            }
            if (Driver.FindElement(MilitarySevicesExitDropDownList).Displayed) {
                Driver.FindElement(MilitarySevicesExitDropDownList).Click();
            }

            Driver.FindElement(CustomerSearchDropDownList).Click();
            Driver.FindElement(CustomerSearch).SendKeys(Data.M1HR.employeeName + Keys.Enter);
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