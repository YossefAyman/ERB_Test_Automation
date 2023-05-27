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

        protected static By Add_Button =                        By.ClassName("btnAddItem");
        protected static By ContractTypeName =                  By.Id("ContractType_ContractTypeName");
        protected static By ContractTypeDescription =           By.Id("ContractType_ContractTypeDescription");
        protected static By Save_Button =                       By.CssSelector("#mainModal > div > div.modal-content.ui-resizable > div.modal-body > div.modal-footer > input");
        static By Edit_Button =                                 By.XPath("//i[@title='تعديل']");
        static By FirstItemDelete_Button =                      By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button =                        By.ClassName("confirm");
        static By Search_TextBox =                              By.XPath("(//input[@placeholder='بحث'])[1]");

        public static void Goto()
        {
            Pages.ContractTypePage();
            time.Sleep(2000);

        }

        public static void Add_ContractType(DynamicData PropertyType_insatnce)
        {
            Driver.FindElement(Add_Button).Click();
            PropertyType_insatnce.Name = PropertyType_insatnce.Name + "_اسم";
            Driver.FindElement(ContractTypeName).SendKeys(PropertyType_insatnce.Name);
            PropertyType_insatnce.Name = PropertyType_insatnce.Name + "_وصف";
            Driver.FindElement(ContractTypeDescription).SendKeys(PropertyType_insatnce.Name);
            Driver.FindElement(Save_Button).Click();
            
            time.Sleep(2000);
        }
        public static void Edit_ContractType(string PropertyType_Name, string PropertyType_NewName)
        {
            PropertyType_Page.Search(PropertyType_Name);
            Driver.FindElement(Edit_Button).Click();
            Driver.FindElement(ContractTypeName).Clear();
            Driver.FindElement(ContractTypeName).SendKeys(PropertyType_NewName);
            Driver.FindElement(ContractTypeDescription).Clear();
            Driver.FindElement(ContractTypeDescription).SendKeys(PropertyType_NewName);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }

        public static void Delete_ContractType(string PropertyType_Name)
        {
            PropertyType_Page.Search(PropertyType_Name);
            Driver.FindElement(FirstItemDelete_Button).Click();
            time.Sleep(1000);
            Driver.FindElement(DeleteConfirm_Button).Click();
            time.Sleep(2000);
        }
    }
}