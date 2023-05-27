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
using Automation_Testing;

namespace ERP_Automation_Testing
{
    public class Owner_PropertyReport_Report
    {
        static IWebDriver Driver = Common.Driver;
        static IJavaScriptExecutor javaDriverExector = Driver as IJavaScriptExecutor;


        // Selectors

        static By Owner_PropertyReport =             By.ClassName("col-md-2");
        static By UISelect_DDL =                     By.ClassName("ui-select-container");
        static By UISelectSearch_TextBox =           By.ClassName("ui-select-search");
        static By advancedSearchButton =             By.ClassName("advancedSearchWraperButton");
        static By Search_Button =                    By.XPath("//*[@id=\"unitController\"]/div[2]/section/div/div/div[2]/div/div/div[4]/div/span/button[1]");
        static By NumOfItems_Text =                  By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");
        static By NumOfPages_Text =                  By.XPath("//*[@id=\"grid\"]/div[2]/div[1]/div[1]/span");
        static By NumOfCurrentPage_Text =            By.XPath("//*[@id=\"grid\"]/div[2]/div[1]/div[1]/input");
        static By NextButton =                       By.XPath("//*[@id=\"grid\"]/div[2]/div[1]/div[1]/button[3]");


        public static void Goto()
        {
            Pages.PropertyReportsPage();
            Driver.FindElements(Owner_PropertyReport)[9].Click();
            time.Sleep(2000);

        }

        private static List<string> GetListOfAllNamesInGrid()
        {
            IWebElement Element = Driver.FindElement(NumOfItems_Text);
            javaDriverExector.ExecuteScript("arguments[0].scrollIntoView(true);", Element);
            string countString = Driver.FindElement(NumOfItems_Text).Text;
            string[] countArray = countString.Split(' ');
            int count = 0;
            int.TryParse(countArray[2], out count);
            List<string> ListOfNames = new List<string>();
            var NumOfPage = Driver.FindElement(NumOfPages_Text).Text;
            string[] NumOfPages_Text_List =  NumOfPage.Split(' ');
            int NumOfPages = int.Parse(NumOfPages_Text_List[1]);
            int NumOfCurrentPage = int.Parse(Driver.FindElement(NumOfCurrentPage_Text).GetAttribute("value"));
            
             for (int i = 1; i <= count; i++)
                {
                    string name = Driver.FindElement(By.XPath("/html/body/div[2]/main/div/div/div[2]/div/div[2]/section/div/div/div[2]/div/div/div[6]/div[1]/div[2]/div[2]/div/div[" + i + "]/div/div[1]/div/a[1]/span")).Text;
                    ListOfNames.Add(name);
                }
            
             while (NumOfCurrentPage < NumOfPages)
                {
                Driver.FindElement(NextButton).Click();
                for (int x = 1; x <= count; x++)
                {
                    string name = Driver.FindElement(By.XPath("/html/body/div[2]/main/div/div/div[2]/div/div[2]/section/div/div/div[2]/div/div/div[6]/div[1]/div[2]/div[2]/div/div[" + x + "]/div/div[1]/div/a[1]/span")).Text;
                    ListOfNames.Add(name);
                }
                NumOfCurrentPage++;
            }
            return ListOfNames;
        }

        public static bool Check_That_Property_Is_Added_Correctly_To_The_Owner()
        {
            Driver.FindElement(advancedSearchButton).Click();
            Driver.FindElements(UISelect_DDL)[0].Click();
            Driver.FindElements(UISelectSearch_TextBox)[0].SendKeys(Data.Estates.PropertyTypeName + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[2].Click();
            Driver.FindElements(UISelectSearch_TextBox)[2].SendKeys(Data.Estates.owner + Keys.Enter);
            IWebElement Element = Driver.FindElements(UISelectSearch_TextBox)[5];
            javaDriverExector.ExecuteScript("arguments[0].scrollIntoView(true);", Element);
            Driver.FindElement(Search_Button).Click();
            time.Sleep(2000);
            return GetListOfAllNamesInGrid().Contains(Data.Estates.Name);
        }
    }
}