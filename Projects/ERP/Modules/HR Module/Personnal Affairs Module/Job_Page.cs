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
    public class Job_Page
    {

        static IWebDriver Driver = Common.Driver;


        // Selectors

        static By Add_Button =                                  By.ClassName("btnAddItem");
        static By JobName =                                     By.Id("Job_JobName");
        static By Job_Description =                             By.Id("Job_Description");
        static By UISelect_DDL =                                By.ClassName("ui-select-container");
        static By UISelectSearch_TextBox =                      By.ClassName("ui-select-search");
        static By AddQualification =                            By.XPath("//*[@id=\"FormManager\"]/div/div[5]/div/button");
        static By Qualification =                               By.XPath("//a[@placeholder='المهارة']//b");
        static By Qualification_Level =                         By.XPath("//a[@placeholder='تقدير المهارة']//b");
        static By QualificationDesc =                           By.Id("EmptyJobDescription_Description");

        static By Save_Button =                                 By.XPath("//input[@value='حفظ']");
        static By Search_TextBox =                              By.XPath("/html/body/div[2]/main/div/div/div[2]/div/div[2]/section/div/div/div[2]/div/div/div[1]/div[1]/div/input");
        static By Search_Button =                               By.XPath("/html/body/div[2]/main/div/div/div[2]/div/div[2]/section/div/div/div[2]/div/div/div[1]/div[1]/div/span/button");
        static By NumOfItems_Text =                             By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");
        static By Edit_Button =                                 By.XPath("//i[@title='تعديل']");
        static By FirstItemDelete_Button =                      By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button =                        By.ClassName("confirm");




        public static void GotoJobPage()
        {
            Pages.JobPage();
            time.Sleep(2000);

        }
       
        public static void Add_Job()
        {
            Driver.FindElement(Add_Button).Click();
            Driver.FindElement(JobName).SendKeys(Data.M1HR.Job_Name);
            Driver.FindElement(Job_Description).SendKeys(Data.M1HR.Job_Desc);
            Driver.FindElements(UISelect_DDL)[0].Click();
            Driver.FindElement(UISelectSearch_TextBox).SendKeys(Data.M1HR.OrganizationUnit + Keys.Enter);
            Driver.FindElement(AddQualification).Click();
            Driver.FindElement(Qualification).Click();
            Driver.FindElements(UISelectSearch_TextBox)[1].SendKeys(Data.M1HR.Skill + Keys.Enter);
            Driver.FindElement(Qualification_Level).Click();
            Driver.FindElements(UISelectSearch_TextBox)[2].SendKeys(Data.M1HR.SkillLevel + Keys.Enter);
            Driver.FindElement(QualificationDesc).SendKeys(Data.M1HR.Skills_Dec + Keys.Enter);

            Driver.FindElement(Save_Button).Click();
            time.Sleep(3000);
        }

        public static void Add_Job_With_Added_OrganizationUnit_And_Skill()
        {
            Driver.FindElement(Add_Button).Click();
            Driver.FindElement(JobName).SendKeys(Data.M1HR.Job_Name);
            Driver.FindElement(Job_Description).SendKeys(Data.M1HR.Job_Desc);
            Driver.FindElements(UISelect_DDL)[0].Click();
            Driver.FindElement(UISelectSearch_TextBox).SendKeys(Data.M1HR.OrganizationUnit_Name + Keys.Enter);
            Driver.FindElement(AddQualification).Click();
            Driver.FindElement(Qualification).Click();
            Driver.FindElements(UISelectSearch_TextBox)[1].SendKeys(Data.M1HR.Skills_Name + Keys.Enter);
            Driver.FindElement(Qualification_Level).Click();
            Driver.FindElements(UISelectSearch_TextBox)[2].SendKeys(Data.M1HR.SkillLevel + Keys.Enter);
            Driver.FindElement(QualificationDesc).SendKeys(Data.M1HR.Skills_Dec + Keys.Enter);

            Driver.FindElement(Save_Button).Click();
            time.Sleep(3000);
        }


        /*   public static void Add_OrganizationUnit()
           {
               Driver.FindElement(Add_Button).Click();
               Driver.FindElement(JobName).SendKeys(Data.M1HR.Skills_Name);
               Driver.FindElement(SkillDescription).SendKeys(Data.M1HR.Skills_Dec);
               Driver.FindElement(Save_Button).Click();
               time.Sleep(3000);
           } */

        public static void Edit_Job(string Job)
           {
               Search(Data.M1HR.Job_Name);
               Driver.FindElement(Edit_Button).Click();
               Driver.FindElement(JobName).Clear();
               Driver.FindElement(JobName).SendKeys(Job);
               Driver.FindElement(Job_Description).Clear();
               Driver.FindElement(Job_Description).SendKeys(Data.M1HR.Job_Desc + "_Edited");
               Driver.FindElement(Save_Button).Click();
               time.Sleep(3000);
           }

        public static void Delete_Job(string Job)
        {
            Search(Job);
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