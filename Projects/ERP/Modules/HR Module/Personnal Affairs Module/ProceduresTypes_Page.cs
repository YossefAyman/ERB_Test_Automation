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
    public class ProceduresTypes_Page
    {

        static IWebDriver Driver = Automation_Testing.Common.Driver;


        // Selectors

        static By Add_Button =                                          By.ClassName("btnAddItem");
        static By Save_Button =                                         By.XPath("//input[@value='حفظ']");
        static By ProcedureTypeName =                                   By.Id("ProcedureType_ProcedureTypeName");
        static By ProcedureTypeDescription =                            By.Id("ProcedureType_ProcedureTypeDescription");
        static By UISelect_DDL =                                        By.ClassName("ui-select-container");
        static By UISelectSearch_TextBox =                              By.ClassName("ui-select-search");
        static By SelectLastElementInList =                             By.XPath("//li[4]//div[1]//div[1]");
        static By Search_TextBox =                                      By.XPath("//input[@placeholder='بحث']");
        static By Search_Button =                                       By.XPath("//i[@class='fa fa-search']");
        static By NumOfItems_Text =                                     By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");
        static By Edit_Button =                                         By.XPath("//i[@title='تعديل']");
        static By FirstItemDelete_Button =                              By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button =                                By.ClassName("confirm");


        public static void Goto()
        {
            Pages.ProceduresTypesPage();
            time.Sleep(2000);

        }

        public static void Add_ProcedureType()
        {
            Driver.FindElement(Add_Button).Click();
            Driver.FindElement(ProcedureTypeName).SendKeys(Data.M1HR.ProcedureType_Name);
            Driver.FindElement(ProcedureTypeDescription).SendKeys(Data.M1HR.ProcedureType_Desc);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(1000);
        }

        public static void Add_ProcedureType_With_Added_Job_JobTittle_OrganizationUnit_Qualification_WorkSystem()
        {
            Driver.FindElement(Add_Button).Click();
            Driver.FindElement(ProcedureTypeName).SendKeys(Data.M1HR.ProcedureType_Name);
            Driver.FindElement(ProcedureTypeDescription).SendKeys(Data.M1HR.ProcedureType_Desc);
            Driver.FindElements(UISelect_DDL)[0].Click();
            Driver.FindElement(SelectLastElementInList).Click();
            Driver.FindElements(UISelect_DDL)[1].Click();
            Driver.FindElements(UISelectSearch_TextBox)[1].SendKeys(Data.M1HR.Job_Name + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[2].Click();
            Driver.FindElement(SelectLastElementInList).Click();
            Driver.FindElements(UISelect_DDL)[3].Click();
            Driver.FindElements(UISelectSearch_TextBox)[3].SendKeys(Data.M1HR.JobTitle_Name + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[4].Click();
            Driver.FindElement(SelectLastElementInList).Click();
            Driver.FindElements(UISelect_DDL)[5].Click();
            Driver.FindElements(UISelectSearch_TextBox)[5].SendKeys(Data.M1HR.OrganizationUnit_Name + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[6].Click();
            Driver.FindElement(SelectLastElementInList).Click();
            Driver.FindElements(UISelect_DDL)[7].Click();
            Driver.FindElements(UISelectSearch_TextBox)[7].SendKeys(Data.M1HR.Qualification_Name + Keys.Enter); 
            Driver.FindElements(UISelect_DDL)[10].Click();
            Driver.FindElement(SelectLastElementInList).Click();
            Driver.FindElements(UISelect_DDL)[11].Click();
            Driver.FindElements(UISelectSearch_TextBox)[11].SendKeys(Data.M1HR.WorkSystem_Name + Keys.Enter);

            Driver.FindElement(Save_Button).Click();
            time.Sleep(1000);
        }


        public static void Edit_ProcedureType(string ProcedureType , string ProcedureType_Desc)
        {
            Search(Data.M1HR.ProcedureType_Name);
            Driver.FindElement(Edit_Button).Click();
            Driver.FindElement(ProcedureTypeName).Clear();
            Driver.FindElement(ProcedureTypeName).SendKeys(ProcedureType); 
            Driver.FindElement(ProcedureTypeDescription).Clear();
            Driver.FindElement(ProcedureTypeDescription).SendKeys(ProcedureType_Desc);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(1000);
        }

        public static void Delete_ProcedureType(string ProcedureType)
        {
            Search(ProcedureType);
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