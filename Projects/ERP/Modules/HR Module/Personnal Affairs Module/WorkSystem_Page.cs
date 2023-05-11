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
    public class WorkSystem_Page
    {

        static IWebDriver Driver = Common.Driver;


        // Selectors
         
        static By Add_Button =                                                  By.ClassName("btnAddItem");
        static By WorkSystemName =                                              By.Id("WorkSystem_WorkSystemName");
        static By WorkSystemDescription =                                       By.Id("WorkSystem_WorkSystemDescription");
        static By WorkSystem_DailyAllowenceMinutes =                            By.Id("WorkSystem_DailyAllowenceMinutes");
        static By WorkSystem_DailyWorkingHours =                                By.Id("WorkSystem_DailyWorkingHours");
        static By WorkSystem_MonthlyExcusesMinutes =                            By.Id("WorkSystem_MonthlyExcusesMinutes");
        static By WorkSystem_ProbationPeriod =                                  By.Id("WorkSystem_ProbationPeriod");
        static By WorkSystem_WorkerPercentageShareInInsurance =                 By.Id("WorkSystem_WorkerPercentageShareInInsurance");
        static By WorkSystem_CompanyPercentageShareInInsurance =                By.Id("WorkSystem_CompanyPercentageShareInInsurance");
        static By WorkSystem_MaximumVacationsInOneMonth =                       By.Id("WorkSystem_MaximumVacationsInOneMonth");
        static By EmptyWorkSystemPeriod_WorkSystemPeriodFrom =                  By.Id("EmptyWorkSystemPeriod_WorkSystemPeriodFrom");
        static By EmptyWorkSystemVacation_WorkSystemVacationCredit =            By.Id("EmptyWorkSystemVacation_WorkSystemVacationCredit");
        static By EmptyWorkSystemVacation_WorkingMonths =                       By.Id("EmptyWorkSystemVacation_WorkingMonths");
        static By EmptyWorkSystemPermission_WorkSystemPermissionBalance =       By.Id("EmptyWorkSystemPermission_WorkSystemPermissionBalance");
        static By EmptyWorkSystemPermission_ExcuseRepetitionPerMonth =          By.Id("EmptyWorkSystemPermission_ExcuseRepetitionPerMonth");
        static By WorkSystemPeriodName =                                        By.XPath("//input[@ng-model='row.WorkSystemPeriodName']");
        static By UISelect_DDL =                                                By.ClassName("ui-select-container");
        static By UISelectSearch_TextBox =                                      By.ClassName("ui-select-search");
        static By Save_Button =                                                 By.XPath("//input[@value='حفظ']");
        static By Date =                                                        By.XPath("/html/body/div[2]/main/div/div/div[2]/div/div[2]/div[2]/div/div[1]/div[2]/div[1]/form/div[1]/div[13]/date-picker-directive/div/input[1]");
        static By WorkSystemRangeAddButton =                                    By.XPath("//button[@ng-click='addinSection($event)']//i[@class='fa fa-plus']");
        static By VacationAddButton =                                           By.XPath("//button[@ng-click='addinVacationSection($event)']");
        static By PermissionAddButton =                                         By.XPath("//button[@ng-click='addinPermissionSection($event)']//i[@class='fa fa-plus']");
        static By Sunday_CheckBox =                                             By.XPath("//label[@for='WorkSystem_WorkSystemWeekDay_Sunday']");
        static By Monday_CheckBox =                                             By.XPath("//label[@for='WorkSystem_WorkSystemWeekDay_Monday']");
        static By Tuesday_CheckBox =                                            By.XPath("//label[@for='WorkSystem_WorkSystemWeekDay_Tuesday']");
        static By Wednesday_CheckBox =                                          By.XPath("//label[@for='WorkSystem_WorkSystemWeekDay_Wednesday']");
        static By Thursday_CheckBox =                                           By.XPath("//label[@for='WorkSystem_WorkSystemWeekDay_Thursday']");
        static By Search_TextBox =                                              By.XPath("/html/body/div[2]/main/div/div/div[2]/div/div[2]/section/div/div/div[2]/div/div/div[1]/div[1]/div/input");
        static By Search_Button =                                               By.XPath("/html/body/div[2]/main/div/div/div[2]/div/div[2]/section/div/div/div[2]/div/div/div[1]/div[1]/div/span/button");
        static By NumOfItems_Text =                                             By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");
        static By Edit_Button =                                                 By.XPath("//i[@title='تعديل']");
        static By FirstItemDelete_Button =                                      By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button =                                        By.ClassName("confirm");


        public static void Goto()
        {
            Pages.WorkSystemPage();
            time.Sleep(2000);

        }


        public static void Add_WorkSystem()
        {
            Driver.FindElement(Add_Button).Click();
            Driver.FindElement(WorkSystemName).SendKeys(Data.M1HR.WorkSystem_Name);
            Driver.FindElement(WorkSystem_DailyAllowenceMinutes).SendKeys((int.Parse(Data.M1HR.Test_Index_WorkSystem.Value) - 20).ToString());
            Driver.FindElement(WorkSystem_DailyWorkingHours).SendKeys((int.Parse(Data.M1HR.Test_Index_WorkSystem.Value) - 100).ToString());
            Driver.FindElement(WorkSystem_MonthlyExcusesMinutes).SendKeys((int.Parse(Data.M1HR.Test_Index_WorkSystem.Value) - 30).ToString());
            Driver.FindElement(WorkSystem_ProbationPeriod).Clear();
            Driver.FindElement(WorkSystem_ProbationPeriod).SendKeys((int.Parse(Data.M1HR.Test_Index_WorkSystem.Value) - 90).ToString()); 
            Driver.FindElement(WorkSystem_WorkerPercentageShareInInsurance).Clear();
            Driver.FindElement(WorkSystem_WorkerPercentageShareInInsurance).SendKeys((int.Parse(Data.M1HR.Test_Index_WorkSystem.Value) - 10).ToString()); 
            Driver.FindElement(WorkSystem_CompanyPercentageShareInInsurance).Clear();
            Driver.FindElement(WorkSystem_CompanyPercentageShareInInsurance).SendKeys((int.Parse(Data.M1HR.Test_Index_WorkSystem.Value) - 60).ToString());
            Driver.FindElements(UISelect_DDL)[0].Click();
            Driver.FindElement(UISelectSearch_TextBox).SendKeys(Data.M1HR.SalaryType + Keys.Enter);
            Driver.FindElement(Date).SendKeys(Data.RandomDate());
            Driver.FindElement(WorkSystem_MaximumVacationsInOneMonth).Clear();
            Driver.FindElement(WorkSystem_MaximumVacationsInOneMonth).SendKeys((int.Parse(Data.M1HR.Test_Index_WorkSystem.Value) - 100).ToString());
            Driver.FindElement(WorkSystemDescription).SendKeys(Data.M1HR.WorkSystem_Desc);
            Driver.FindElement(WorkSystemRangeAddButton).Click();
            Driver.FindElement(WorkSystemPeriodName).SendKeys(Data.M1HR.WorkSystemPeriodName);
            Driver.FindElement(EmptyWorkSystemPeriod_WorkSystemPeriodFrom).Clear();
            Driver.FindElement(EmptyWorkSystemPeriod_WorkSystemPeriodFrom).SendKeys(Data.M1HR.StartHoursWorkSystem);
            Driver.FindElement(VacationAddButton).Click();
            Driver.FindElements(UISelect_DDL)[1].Click();
            Driver.FindElements(UISelectSearch_TextBox)[1].SendKeys(Data.M1HR.VacationType + Keys.Enter);
            Driver.FindElement(EmptyWorkSystemVacation_WorkSystemVacationCredit).SendKeys((int.Parse(Data.M1HR.Test_Index_WorkSystem.Value) - 90).ToString());
            Driver.FindElement(EmptyWorkSystemVacation_WorkingMonths).SendKeys(Data.M1HR.MonthsOfTheYear);
            Driver.FindElement(PermissionAddButton).Click();
            Driver.FindElements(UISelect_DDL)[2].Click();
            Driver.FindElements(UISelectSearch_TextBox)[2].SendKeys(Data.M1HR.PersmissionType + Keys.Enter);
            Driver.FindElement(EmptyWorkSystemPermission_WorkSystemPermissionBalance).SendKeys((int.Parse(Data.M1HR.Test_Index_WorkSystem.Value) - 10).ToString());
            Driver.FindElement(EmptyWorkSystemPermission_ExcuseRepetitionPerMonth).SendKeys((int.Parse(Data.M1HR.Test_Index_WorkSystem.Value) - 100).ToString());
            Driver.FindElement(Sunday_CheckBox).Click();
            Driver.FindElement(Monday_CheckBox).Click();
            Driver.FindElement(Tuesday_CheckBox).Click();
            Driver.FindElement(Wednesday_CheckBox).Click();
            Driver.FindElement(Thursday_CheckBox).Click();
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }


        public static void Edit_WorkSystem(string WorkSystem)
        {
            Search(Data.M1HR.WorkSystem_Name);
            Driver.FindElement(Edit_Button).Click();
            Driver.FindElement(WorkSystemName).Clear();
            Driver.FindElement(WorkSystemName).SendKeys(WorkSystem);
            Driver.FindElement(WorkSystemDescription).Clear();
            Driver.FindElement(WorkSystemDescription).SendKeys(Data.M1HR.WorkSystem_Desc + "_Edited");
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }

        public static void Delete_WorkSystem(string WorkSystem)
        {
            Search(WorkSystem);
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