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


namespace ERP_Automation_Testing
{
    class PurchaseReturnBill_Page
    {
        static IWebDriver Driver = Automation_Testing.Common.Driver;

        // Selectors

        //static By Add_Button = By.ClassName("btnAddItem");
        static By Add_Button = By.ClassName("btn-success");
        static By PurchaseBillNumber_SelectToggle = By.CssSelector("#FormManager > div:nth-child(1) > div:nth-child(2) > div > div > a > span.select2-arrow.ui-select-toggle");
        static By PurchaseBillNumber_TextBox = By.CssSelector("#FormManager > div:nth-child(1) > div:nth-child(2) > div > div > div > div > input");
        static By StoreName_SelectToggle = By.CssSelector("#FormManager > div:nth-child(1) > div:nth-child(4) > div > div > a > span.select2-arrow.ui-select-toggle");
        static By StoreName_TextBox = By.CssSelector("#FormManager > div:nth-child(1) > div:nth-child(4) > div > div > div > div > input");
        static By Date_TextBox = By.XPath("//*[@placeholder=\"DD-MM-YYYY\"]");
        static By Quantity_TextBox = By.CssSelector("#PurchasesInvoiceDetails_QuantityReturns");
        static By Discount_TextBox = By.CssSelector("#PurchasesInvoiceDetails_Discount");
        static By AddAttachement_Button = By.CssSelector("#AttachmentFormManager > div:nth-child(3) > div:nth-child(1) > div > div.drop-box.ng-pristine.ng-untouched.ng-valid.ng-empty > i");
        static By Save_Button = By.CssSelector("#mainModal > div > div > div.modal-body > div.modal-footer > input");
        static By NumOfItems_Text = By.ClassName("ng-binding");
        static By Search_TextBox = By.XPath("//*[@placeholder=\"بحث\"]");
        static By Search_Button = By.ClassName("btn-light"); 

        public static void Goto()
        {
            Pages.PurchaseReturnBill_Page();
            time.Sleep(2000);
        }
        public static void Add_PurchasesReturnsBill(Data.PurchaseReturnBill PurchaseReturnBill) 
	    {      
            Driver.FindElement(Add_Button).Click();
            time.Sleep(3000);
            Driver.FindElement(PurchaseBillNumber_SelectToggle).Click();
            Driver.FindElement(PurchaseBillNumber_TextBox).SendKeys(Keys.Enter);
            //Driver.FindElement(StoreName_SelectToggle).Click();
            //Driver.FindElement(StoreName_TextBox).SendKeys(PurchaseReturnBill.Store + Keys.Enter);
            Driver.FindElement(Date_TextBox).Clear();
            Driver.FindElement(Date_TextBox).SendKeys(PurchaseReturnBill.Date);
            Driver.FindElement(Quantity_TextBox).Clear();
            Driver.FindElement(Quantity_TextBox).SendKeys(PurchaseReturnBill.Quantity);
		
            Driver.FindElement(Discount_TextBox).Clear();
            Driver.FindElement(Discount_TextBox).SendKeys(PurchaseReturnBill.Discount);
		
            Driver.FindElement(AddAttachement_Button).Click();
            time.Sleep(2000);
            Data.Add_Attachment();
            time.Sleep(3000);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(3000);
        }

        public static string Number_Of_Items()
        {
            return Driver.FindElement(NumOfItems_Text).Text;
        }

        public static string Search(string item)
        {
            Driver.FindElement(Search_TextBox).Clear();
            Driver.FindElement(Search_TextBox).SendKeys(item);
            Driver.FindElement(Search_Button).Click();
            time.Sleep(1000);

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
