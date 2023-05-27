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
    public class SalesInvoiceReturns_Page
    {

         static IWebDriver Driver = Automation_Testing.Common.Driver;
        static IJavaScriptExecutor javaDriverExector = Driver as IJavaScriptExecutor;


        // Selectors

        static By Add_Button =                                           By.ClassName("btn-success");
        static By SalesBill_Serial =                                     By.XPath("/html/body/div[2]/main/div/div/div[2]/div/div[2]/div[2]/div/div[1]/div[2]/div[1]/form/div[1]/div[1]/div/input");
        static By SalesInvoiceReturns_Description =                      By.Id("SalesInvoiceReturns_Description");
        static By EmptySalesInvoiceReturnsDetails_QuantityReturns =      By.Id("EmptySalesInvoiceReturnsDetails_QuantityReturns");
        static By QuantityCount =                                        By.XPath("/html/body/div[2]/main/div/div/div[2]/div/div[2]/div[2]/div/div[1]/div[2]/div[1]/form/table/tbody/tr/th[3]/div/input");
        static By Searchbutton =                                         By.ClassName("btn-primary");
        static By NumOfItems_Text =                                      By.CssSelector("div[class='ui-grid-pager-count'] span[class='ng-binding']");
        static By saveButtun =                                           By.XPath("/html/body/div[2]/main/div/div/div[2]/div/div[2]/div[2]/div/div[1]/div[2]/div[2]/input");
         static By UISelect_DDL =                                        By.ClassName("ui-select-container");
        static By UISelectSearch_TextBox =                               By.ClassName("ui-select-search");
         




        public static void Goto()
        {
            Pages.SalesBillReturnPage();
            time.Sleep(2000);

        }

        public static void ReturnSalesBill(string salesBillSerial)
        {
            Driver.FindElement(Add_Button).Click();
            Driver.FindElement(SalesBill_Serial).SendKeys(salesBillSerial);
            Driver.FindElements(Searchbutton)[0].Click();
            Driver.FindElement(SalesInvoiceReturns_Description).SendKeys("وصف ارجاع فاتوره رقم " + salesBillSerial);
            string QuantityCount_string = Driver.FindElement(QuantityCount).GetAttribute("value");
            Driver.FindElement(EmptySalesInvoiceReturnsDetails_QuantityReturns).Clear();
            Driver.FindElement(EmptySalesInvoiceReturnsDetails_QuantityReturns).SendKeys((int.Parse(QuantityCount_string) / 2).ToString());
            IWebElement Element = Driver.FindElement(saveButtun);
            javaDriverExector.ExecuteScript("arguments[0].scrollIntoView(true);", Element);
            Driver.FindElements(UISelect_DDL)[8].Click();
            Driver.FindElements(UISelectSearch_TextBox)[8].SendKeys(Data.SalesBill.Treasury + Keys.Enter);
            Driver.FindElement(saveButtun).Click();
            time.Sleep(2000);
        }
        
        public static int ReadCountText()
        {
            string countString = Driver.FindElement(NumOfItems_Text).Text;
            string[] countArray = countString.Split(' ');
            int count = 0;
            int.TryParse(countArray[4], out count);
            if (Driver.FindElement(NumOfItems_Text).GetAttribute("class") == "ng-binding ng-hide")
            {
                return 0;
            }
            else
            {
                return count;
            }
        }

    }
}