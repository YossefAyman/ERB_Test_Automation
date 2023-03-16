using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using time = System.Threading.Thread;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;




namespace ERP_Automation_Testing
{
    public class Account_Reports_Page
    {
        static IWebDriver Driver = Automation_Testing.Common.Driver;
        

        // Selectors
        static By account_Report_Icon =              By.CssSelector("body > div:nth-child(2) > main:nth-child(2) > div:nth-child(2) > div:nth-child(1) > div:nth-child(3) > div:nth-child(2) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(2) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(15) > a:nth-child(1) > div:nth-child(1)");
        static By ClientName_SelectToggle =          By.XPath("//a[@placeholder='الحساب']//b");
        static By ClientName_TextBox =               By.XPath("/html[1]/body[1]/div[2]/main[1]/div[1]/div[1]/div[2]/div[1]/div[2]/section[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[3]/div[2]/div[1]/div[1]/div[1]/div[1]/input[1]");
        static By SelectFirstSearchResult =          By.CssSelector("#accountBalanceController > div:nth-child(2) > section > div > div > div.main-box-content > div > div > div:nth-child(6) > div:nth-child(2) > div > div > div > ul");
        static By searchButton =                     By.XPath("//button[@class='btn btn-secondary']");
        static By rowElmenetXpath =                  By.XPath("//table[@class='table table-striped table-bordered table-responsive-md']//tbody//tr");
       /* static By before_lastTransaction =           
        static By lastTransaction*/




        public static void Goto()
        {
            Pages.AccountReportPage();
            time.Sleep(2000);

        }
       
        ////////////////////////# Check Customer Balance When Customer Make a Sales Bill #/////////////////////////////
        
        public static void CheckCustomerBalanceFromReports(out int maden_Amount_For_BeforelastTransaction_int , out int da2en_Amount_For_lastTransaction_int)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Driver.FindElement(account_Report_Icon).Click();
            Driver.FindElement(ClientName_SelectToggle).Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Driver.FindElement(ClientName_TextBox).SendKeys("تيست عميل" + Keys.Enter);
            time.Sleep(1000);
            Driver.FindElement(SelectFirstSearchResult).Click();
            Driver.FindElement(searchButton).Click();
            time.Sleep(1000);
            List<IWebElement> rowElements = Driver.FindElements(rowElmenetXpath).ToList();

            int rowSize01 = rowElements.Count() - 1;
            string maden_Amount = Driver.FindElement(By.XPath("//table[@class='table table-striped table-bordered table-responsive-md']//tbody//tr[" + rowSize01 + "]//td[10]")).Text;
            maden_Amount_For_BeforelastTransaction_int = int.Parse(maden_Amount);

            int rowSize02 = rowElements.Count()-2;
            string da2en_Amount =  Driver.FindElement(By.XPath("//table[@class='table table-striped table-bordered table-responsive-md']//tbody//tr[" + rowSize02 + "]//td[9]")).Text;
            da2en_Amount_For_lastTransaction_int = int.Parse(da2en_Amount);

        }


    }
}