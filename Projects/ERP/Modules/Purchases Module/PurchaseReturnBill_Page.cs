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
//using System.Windows.Forms;
using Automation_Testing;

namespace ERP_Automation_Testing
{
    class PurchaseReturnBill_Page
    {
        static IWebDriver Driver = Automation_Testing.Common.Driver;

        // Selectors

        static By Add_Button =                                       By.ClassName("btn-success");
        static By PurchaseBillNumber_SelectToggle =                  By.CssSelector("#FormManager > div:nth-child(1) > div:nth-child(2) > div > div > a > span.select2-arrow.ui-select-toggle");
        static By PurchaseBillNumber_TextBox =                       By.CssSelector("#FormManager > div:nth-child(1) > div:nth-child(2) > div > div > div > div > input");
        static By Quantity =                                         By.Id("EmptyPurchasesInvoiceReturnsDetails_Quantity");
        static By QuantityReturns =                                  By.Id("EmptyPurchasesInvoiceReturnsDetails_QuantityReturns");
        static By Save_Button =                                      By.CssSelector("#mainModal > div > div > div.modal-body > div.modal-footer > input");
        static By Search_Button =                                    By.XPath("/html/body/div[2]/main/div/div/div[2]/div/div[2]/section/div/div/div[2]/div/div/div[2]/div[1]/div/span/button");
  



        public static void Goto()
        {
            Pages.PurchaseReturnBill_Page();
            time.Sleep(2000);
        }
        public static void Add_PurchasesReturnsBill(string PurchaseSerialForReturnBill) 
	    {      
            Driver.FindElement(Add_Button).Click();
            Driver.FindElement(PurchaseBillNumber_SelectToggle).Click();
            Driver.FindElement(PurchaseBillNumber_TextBox).SendKeys(PurchaseSerialForReturnBill + Keys.Enter);
            string QuantityCount_string = Driver.FindElement(Quantity).GetAttribute("value");
            Driver.FindElement(QuantityReturns).Clear();
            Driver.FindElement(QuantityReturns).SendKeys((int.Parse(QuantityCount_string) / 2).ToString());
            Common.ScrollDown(12);
            Driver.FindElement(Save_Button).Click();
            new WebDriverWait(Driver, TimeSpan.FromSeconds(20)).Until(Driver => Driver.FindElement(Search_Button).Displayed);
        }

    }
}
