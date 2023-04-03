using Automation_Testing;
using LMS_Automation_Testing;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using time = System.Threading.Thread;

namespace LMS_Automation_Testing
{
    public class Certificate_Page
    {
        static IWebDriver Driver = Automation_Testing.Common.Driver;

        // Selectors
        static By Add_Button = By.ClassName("btnAddItem");
        static By Certificate_TextBox = By.Id("Certificate_CertificateName");
        static By Certificate_Des = By.Id("Certificate_Description");
        
        static By Save_Button = By.CssSelector("#mainModal > div > div > div.modal-body > div.modal-footer > input");
        //static By Search_TextBox = By.ClassName("ng-valid");
        static By Search_TextBox = By.XPath("//*[@placeholder=\"بحث\"]");
        static By Search_Button = By.ClassName("btn-light");
        static By FirstItemEdit_Button = By.ClassName("btnEditItem");
        static By FirstItemDelete_Button = By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button = By.ClassName("confirm");
        static By NumOfItems_Text = By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");

        public static void Goto()
        {
            Pages.CirtificatesLevelPage();
        }
        public static void Add_Certificate_Level()
        {
            time.Sleep(3000);
            
            Driver.FindElement(Add_Button).Click();
            time.Sleep(3000);
            Driver.FindElement(Certificate_TextBox).SendKeys(Data.Certificate.CertificateName);
            Driver.FindElement(Certificate_Des).SendKeys("محلاحظات");
            Driver.FindElement(Save_Button).Click();
            time.Sleep(3000);
        }

        public static void Edit_Certificate_Level(string certificate, string newName)
        {
            Search(certificate);
            time.Sleep(3000);
            Driver.FindElement(FirstItemEdit_Button).Click();
            time.Sleep(3000);
            Driver.FindElement(Certificate_TextBox).Clear();
            Driver.FindElement(Certificate_TextBox).SendKeys(newName);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(3000);

        }


        public static void Delete_Certificate(string certificate)
        {
            Search(certificate);
            time.Sleep(3000);
            Driver.FindElement(FirstItemDelete_Button).Click();
            time.Sleep(3000);
            Driver.FindElement(DeleteConfirm_Button).Click();
            time.Sleep(3000);
        }

        public static Common.SEARCH_Result Search(string item)
        {
            time.Sleep(3000);
            Driver.FindElement(Search_TextBox).Clear();
            Driver.FindElement(Search_TextBox).SendKeys(item);
            Driver.FindElement(Search_Button).Click();
            time.Sleep(1000);

            if (Driver.FindElement(NumOfItems_Text).Text == "1 - 1 من 1")
            {
                return Common.SEARCH_Result.EXIST;
            }
            else if (Driver.FindElement(NumOfItems_Text).GetAttribute("class") == "ng-binding ng-hide")
            {
                return Common.SEARCH_Result.NOT_EXIST;
            }
            else
            {
                return Common.SEARCH_Result.REPEATED;
            }
        }

    }

    }
