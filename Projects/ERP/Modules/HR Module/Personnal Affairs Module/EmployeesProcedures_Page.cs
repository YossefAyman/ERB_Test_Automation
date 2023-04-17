using Automation_Testing;
using ERP_Automation_Testing;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestAutomationDbModels;
using time = System.Threading.Thread;

namespace ERP_Automation_Testing
{
    public class EmployeesProcedures_Page
    {

        static IWebDriver Driver = Automation_Testing.Common.Driver;


        // Selectors

        static By Add_Button =                      By.ClassName("btnAddItem");
        static By Save_Button =                     By.XPath("//input[@value='حفظ']");
        static By EmployeeProcedureName =           By.Id("EmployeeProcedure_EmployeeProcedureName");
        static By ProcedureNumber =                 By.Id("EmployeeProcedure_ProcedureNumber");
        static By EmployeeProcedureDescription =    By.Id("EmployeeProcedure_EmployeeProcedureDescription");
        static By EmployeeProcedure_NewNetSalary =  By.Id("EmployeeProcedure_NewNetSalary");
        static By UISelect_DDL =                    By.ClassName("ui-select-container");
        static By UISelectSearch_TextBox =          By.ClassName("ui-select-search");
        static By Procedure_Date =                  By.XPath("/html/body/div[2]/main/div/div/div[2]/div/div[2]/div[2]/div/div[1]/div[2]/div[1]/form/div[1]/div[5]/div/date-picker-directive/div/input[1]");
        static By Procedure_StartDate =             By.XPath("/html/body/div[2]/main/div/div/div[2]/div/div[2]/div[2]/div/div[1]/div[2]/div[1]/form/div[1]/div[6]/div/date-picker-directive/div/input[1]");
        static By Procedure_EndDate =               By.XPath("/html/body/div[2]/main/div/div/div[2]/div/div[2]/div[2]/div/div[1]/div[2]/div[1]/form/div[1]/div[7]/div/date-picker-directive/div/input[1]");
        static By Procedure_ActualDate =            By.XPath("/html/body/div[2]/main/div/div/div[2]/div/div[2]/div[2]/div/div[1]/div[2]/div[1]/form/div[1]/div[8]/div/date-picker-directive/div/input[1]");
        static By Search_TextBox =                  By.XPath("//input[@placeholder='بحث']");
        static By Search_Button =                   By.XPath("//i[@class='fa fa-search']");
        static By NumOfItems_Text =                 By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");
        static By Edit_Button =                     By.XPath("//i[@title='تعديل']");
        static By FirstItemDelete_Button =          By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button =            By.ClassName("confirm");


        public static void Goto()
        {
            Pages.EmployeesProceduresPage();
            time.Sleep(2000);

        }

        public static void Add_EmployeeProcedure()
        {
            Driver.FindElement(Add_Button).Click();
            Driver.FindElement(EmployeeProcedureName).SendKeys(Data.M1HR.EmployeeProcedure_Name);
            Driver.FindElement(ProcedureNumber).SendKeys(Data.M1HR.Test_Index_EmployeesProcedures.Value);
            Driver.FindElement(EmployeeProcedureDescription).SendKeys(Data.M1HR.EmployeeProcedure_Desc);
            Driver.FindElements(UISelect_DDL)[2].Click();
            Driver.FindElements(UISelectSearch_TextBox)[2].SendKeys(Data.M1HR.employeeName + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[3].Click();
            Driver.FindElements(UISelectSearch_TextBox)[3].SendKeys(Data.M1HR.Procedure_Name + Keys.Enter);
            Driver.FindElement(Procedure_Date).SendKeys(Data.RandomDate());
            Driver.FindElement(Procedure_StartDate).SendKeys(Data.RandomDate());
            Driver.FindElement(Procedure_EndDate).SendKeys(Data.RandomDate());
            Driver.FindElement(Procedure_ActualDate).SendKeys(Data.RandomDate());
            //Data.M1HR.StartDateForEmployee = Driver.FindElement(Procedure_StartDate).GetAttribute("value");
            //TestAutomationDbDataAccess.TestConfig.InsertStartDateAndEmployeeName(Data.M1HR.StartDateForEmployee, (int.Parse(Data.M1HR.Test_Index_EmployeesProcedures.Value) * 100).ToString(), Data.M1HR.employeeName);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }
        
        public static void Add_EmployeeProcedure_With_Added_ProcedureType()
        {
            Driver.FindElement(Add_Button).Click();
            Driver.FindElement(EmployeeProcedureName).SendKeys(Data.M1HR.EmployeeProcedure_Name);
            Driver.FindElement(ProcedureNumber).SendKeys(Data.M1HR.Test_Index_EmployeesProcedures.Value);
            Driver.FindElement(EmployeeProcedureDescription).SendKeys(Data.M1HR.EmployeeProcedure_Desc);
            Driver.FindElements(UISelect_DDL)[2].Click();
            Driver.FindElements(UISelectSearch_TextBox)[2].SendKeys(Data.M1HR.employeeName + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[3].Click();
            Driver.FindElements(UISelectSearch_TextBox)[3].SendKeys(Data.M1HR.ProcedureType_Name + Keys.Enter);
            Driver.FindElement(Procedure_Date).SendKeys(Data.RandomDate());
            Driver.FindElement(Procedure_StartDate).SendKeys(Data.RandomDate());
            Driver.FindElement(Procedure_EndDate).SendKeys(Data.RandomDate());
            Driver.FindElement(Procedure_ActualDate).SendKeys(Data.RandomDate());
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }
        
        public static void Add_EmployeeProcedure_ForHiringEmployee()
        {
            Driver.FindElement(Add_Button).Click();
            Driver.FindElement(EmployeeProcedureName).SendKeys(Data.M1HR.EmployeeProcedure_Name);
            Driver.FindElement(ProcedureNumber).SendKeys(Data.M1HR.Test_Index_EmployeesProcedures.Value);
            Driver.FindElement(EmployeeProcedureDescription).SendKeys(Data.M1HR.EmployeeProcedure_Desc);
            Driver.FindElements(UISelect_DDL)[2].Click();
            Driver.FindElements(UISelectSearch_TextBox)[2].SendKeys(Data.M1HR.employeeName + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[3].Click();
            Driver.FindElements(UISelectSearch_TextBox)[3].SendKeys(Data.M1HR.ProcedureForHiringEmployee_Name + Keys.Enter);
            Driver.FindElement(Procedure_Date).SendKeys(Data.RandomDate());
            Driver.FindElement(Procedure_StartDate).SendKeys(Data.RandomDate());
            Driver.FindElement(Procedure_EndDate).SendKeys(Data.RandomDate());
            Driver.FindElement(Procedure_ActualDate).SendKeys(Data.RandomDate());
            Driver.FindElements(UISelect_DDL)[4].Click();
            Driver.FindElements(UISelectSearch_TextBox)[4].SendKeys(Data.M1HR.Job_Name + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[5].Click();
            Driver.FindElements(UISelectSearch_TextBox)[5].SendKeys(Data.M1HR.JobTitle_Name + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[6].Click();
            Driver.FindElements(UISelectSearch_TextBox)[6].SendKeys(Data.M1HR.OrganizationUnit_Name + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[7].Click();
            Driver.FindElements(UISelectSearch_TextBox)[7].SendKeys(Data.M1HR.Qualification_Name + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[8].Click();
            Driver.FindElements(UISelectSearch_TextBox)[8].SendKeys(Data.M1HR.Employee_Status_Name + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[9].Click();
            Driver.FindElements(UISelectSearch_TextBox)[9].SendKeys(Data.M1HR.WorkSystem_Name + Keys.Enter);
            Driver.FindElement(EmployeeProcedure_NewNetSalary).SendKeys((int.Parse(Data.M1HR.Test_Index_EmployeesProcedures.Value) * 100).ToString());
            Data.M1HR.StartDateForEmployee = Driver.FindElement(Procedure_StartDate).GetAttribute("value");
            TestAutomationDbDataAccess.TestConfig.InsertStartDateAndEmployeeName(Data.M1HR.StartDateForEmployee , (int.Parse(Data.M1HR.Test_Index_EmployeesProcedures.Value) * 100).ToString() , Data.M1HR.employeeName);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }

        public static void Edit_EmployeeProcedure(string EmployeeProcedure_Name, string EmployeeProcedure_Desc)
        {
            Search(Data.M1HR.EmployeeProcedure_Name);
            Driver.FindElement(Edit_Button).Click();
            Driver.FindElement(EmployeeProcedureName).Clear();
            Driver.FindElement(EmployeeProcedureName).SendKeys(EmployeeProcedure_Name);
            Driver.FindElement(EmployeeProcedureDescription).Clear();
            Driver.FindElement(EmployeeProcedureDescription).SendKeys(EmployeeProcedure_Desc);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }

        public static void Delete_EmployeeProcedure(string EmployeeProcedure_Name)
        {
            Search(EmployeeProcedure_Name);
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