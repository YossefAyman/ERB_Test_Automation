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
    public class AllowanceType_Page
    {

        
        static IWebDriver Driver = Common.Driver;


        // Selectors

        static By Add_Button =                                       By.ClassName("btnAddItem");
        static By AllowanceTypeName =                                By.Id("Model_AllowanceTypeName");
        static By AllowanceTypeAmount =                              By.Id("Model_AllowanceTypeAmount");
        static By MinAmount =                                        By.Id("Model_MinAmount");
        static By MaxAmount =                                        By.Id("Model_MaxAmount");
        static By MAllowanceTypeDescription =                        By.Id("Model_AllowanceTypeDescription");
        static By Save_Button =                                      By.XPath("//input[@value='حفظ']");
        static By Edit_Button =                                      By.XPath("//i[@title='تعديل']");
        static By FirstItemDelete_Button =                           By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button =                             By.ClassName("confirm");




        public static void Goto()
        {
            Pages.AllowanceTypePage();
            time.Sleep(2000);

        }

        public static void Add_AllowanceType()
        {
            Driver.FindElement(Add_Button).Click();
            Driver.FindElement(AllowanceTypeName).SendKeys(Data.M3HR.AllowanceType_Name);
            Driver.FindElement(AllowanceTypeAmount).SendKeys((int.Parse(Data.M3HR.Test_Index_AllowanceType.Value) * 10).ToString());
            Driver.FindElement(MinAmount).SendKeys((int.Parse(Data.M3HR.Test_Index_AllowanceType.Value) * 10).ToString());
            Driver.FindElement(MaxAmount).SendKeys((int.Parse(Data.M3HR.Test_Index_AllowanceType.Value) * 10).ToString());
            Driver.FindElement(MAllowanceTypeDescription).SendKeys(Data.M3HR.AllowanceType_Desc);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }

        public static void Edit_AllowanceType(string AllowanceType_Name, string AllowanceType_Desc)
        {
            Common.Search(Data.M3HR.AllowanceType_Name);
            Driver.FindElement(Edit_Button).Click();
            Driver.FindElement(AllowanceTypeName).Clear();
            Driver.FindElement(AllowanceTypeName).SendKeys(AllowanceType_Name);
            Driver.FindElement(MAllowanceTypeDescription).Clear();
            Driver.FindElement(MAllowanceTypeDescription).SendKeys(AllowanceType_Desc);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }

        public static void Delete_AllowanceType(string AllowanceType_Name)
        {
            Common.Search(AllowanceType_Name);
            Driver.FindElement(FirstItemDelete_Button).Click();
            time.Sleep(1000);
            Driver.FindElement(DeleteConfirm_Button).Click();
            time.Sleep(2000);
        }
    }
}