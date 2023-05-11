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
    public class ContractType_Page
    {
        static IWebDriver Driver = Common.Driver;

        protected static By Add_Button = By.ClassName("btnAddItem");
        protected static By ContractTypeName = By.Id("ContractType_ContractTypeName");
        protected static By ContractTypeDescription = By.Id("ContractType_ContractTypeDescription");
        protected static By Save_Button = By.CssSelector("#mainModal > div > div.modal-content.ui-resizable > div.modal-body > div.modal-footer > input");
       

        public static void Goto()
        {
            Pages.ContractTypePage();
            time.Sleep(2000);

        }

        public static void Add()
        {
            Driver.FindElement(Add_Button).Click();
            Driver.FindElement(ContractTypeName).SendKeys("Yosof");
            Driver.FindElement(ContractTypeDescription).SendKeys("Ayman");
            //Driver.FindElement(ContractTypeName).SendKeys(Data.Contracts.Name);
            //Driver.FindElement(ContractTypeDescription).SendKeys(Data.Contracts.Describtion);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }


    }
}