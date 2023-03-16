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
    class PurchasesBill_Page
    {
        static IWebDriver Driver = Automation_Testing.Common.Driver;

        // Selectors
        //static By Add_Button = By.ClassName("btnAddItem");
        static By Add_Button = By.ClassName("btn-success");

        static By SupplierName_SelectToggle = By.CssSelector("#FormManager > div:nth-child(1) > div:nth-child(1) > div > div > a > span.select2-arrow.ui-select-toggle");
        static By SupplierName_TextBox = By.CssSelector("#FormManager > div:nth-child(1) > div:nth-child(1) > div > div > div > div > input");
        static By StoreName_SelectToggle = By.CssSelector("#FormManager > div:nth-child(1) > div:nth-child(3) > div > div > a > span.select2-arrow.ui-select-toggle");
        static By StoreName_TextBox = By.CssSelector("#FormManager > div:nth-child(1) > div:nth-child(3) > div > div > div > div > input");
        static By Date_TextBox = By.XPath("//*[@placeholder=\"DD-MM-YYYY\"]");
        static By PaymentMethod_SelectToggle = By.CssSelector("#FormManager > div:nth-child(1) > div:nth-child(6) > div > div > a > span.select2-arrow.ui-select-toggle");
        static By PaymentMethod_TextBox = By.CssSelector("#FormManager > div:nth-child(1) > div:nth-child(6) > div > div > div > div > input");
        static By Treasury_SelectToggle = By.CssSelector("#Treasury > div > div > a > span.select2-arrow.ui-select-toggle");
        static By Treasury_TextBox = By.CssSelector("#Treasury > div > div > div > div > input");
        static By BankTransferNumber_TextBox = By.CssSelector("#PurchasesInvoice_TransferNumber");
        static By BankAccountCode_SelectToggle = By.CssSelector("#BankAccount > div > div > a > span.select2-arrow.ui-select-toggle");
        static By bankAccountCode_TextBox = By.CssSelector("#BankAccount > div > div > div > div > input");
        static By ChequeNumber_TextBox = By.CssSelector("#PurchasesInvoice_ChequeNumber");
        static By CardPaymentReceiptNumber_TextBox = By.CssSelector("#PurchasesInvoice_CardPaymentReceiptNumber");
        static By AddDetails_Button = By.CssSelector("#FormManager > center > div > input");
        static By ItemType_SelectToggle = By.CssSelector("#FormManager > table > tbody > tr > th:nth-child(1) > center > div > div > a > span.select2-arrow.ui-select-toggle");
        static By ItemType_TextBox = By.CssSelector("#FormManager > table > tbody > tr > th:nth-child(1) > center > div > div > div > div > input");
        static By ItemName_SelectToggle = By.CssSelector("#FormManager > table > tbody > tr > th:nth-child(2) > center > div > div > a > span.select2-arrow.ui-select-toggle");
        static By ItemName_TextBox = By.CssSelector("#FormManager > table > tbody > tr > th:nth-child(2) > center > div > div > div > div > input");
        static By Quantity_TextBox = By.CssSelector("#PurchasesInvoiceDetails_Quantity");
        static By Price_TextBox = By.CssSelector("#PurchasesInvoiceDetails_Price");
        static By Discount_TextBox = By.CssSelector("#PurchasesInvoiceDetails_Discount");
        static By Tax_SelectToggle = By.CssSelector("#FormManager > table > tbody > tr > th:nth-child(7) > center > div > div > a > span.select2-arrow.ui-select-toggle");
        static By Tax_TextBox = By.CssSelector("#FormManager > table > tbody > tr > th:nth-child(7) > center > div > div > div > div > input");
        static By AddAttachement_Button = By.CssSelector("#AttachmentFormManager > div:nth-child(3) > div:nth-child(1) > div > div.drop-box.ng-pristine.ng-untouched.ng-valid.ng-empty > i");
        static By Save_Button = By.CssSelector("#mainModal > div > div > div.modal-body > div.modal-footer > input");
        //static By NumOfItems_Text = By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");
        static By NumOfItems_Text = By.ClassName("ui-grid-pager-count");
        static By Search_TextBox = By.XPath("//*[@placeholder=\"بحث\"]");
        static By Search_Button = By.ClassName("btn-light");
        static By UISelect_DDL = By.ClassName("ui-select-container");
        static By UISelectSearch_TextBox = By.ClassName("ui-select-search");
        static By Date = By.ClassName("dataPickerInputMainClass");
        static By Adddetails = By.ClassName("btn-success");
        static By NameCode = By.ClassName("selectize-control");
        static By NameCodeInput = By.CssSelector("#FormManager > fieldset:nth-child(2) > div.d-none.d-xl-block > table > tbody > tr > th:nth-child(2) > center > div > div > div.selectize-input.items.not-full.ng-valid.ng-pristine.has-options > input[type=text]");
        static By itemcode = By.Id("EmptyPurchasesInvoiceDetails_PurchasesInvoiceDetailsName");
        static By quantity = By.Id("EmptyPurchasesInvoiceDetails_Quantity");
        static By price = By.Id("EmptyPurchasesInvoiceDetails_Price");
        static By IsPurchaseInInstallmentsRadioBtn = By.CssSelector("#FormManager > fieldset:nth-child(3) > div > div:nth-child(1) > div > div > label");


        static By savebutton = By.CssSelector("#frm > input");
        
        public static void Goto()
        {
            Pages.PurchasesBillPage();

            time.Sleep(2000);




        }

        public static void Add_purchaseBill()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Driver.FindElement(Add_Button).Click();
           // time.Sleep(2000);
            Driver.FindElements(UISelect_DDL)[0].Click();
          //  time.Sleep(2000);
            Driver.FindElements(UISelectSearch_TextBox)[0].SendKeys(Data.purchase1.supplierName+Keys.Enter);
          //  time.Sleep(2000);
            Driver.FindElements(UISelect_DDL)[1].Click();
            Driver.FindElements(UISelectSearch_TextBox)[1].SendKeys(Data.purchase1.storeName + Keys.Enter);
            Driver.FindElement(Date).Clear();
            Driver.FindElement(Date).SendKeys(Data.purchase1.Date + Keys.Enter);
          //  time.Sleep(2000);
            Driver.FindElement(Adddetails).Click();
            //time.Sleep(2000);
            Driver.FindElements(UISelect_DDL)[2].Click();
            Driver.FindElements(UISelectSearch_TextBox)[2].SendKeys(Data.purchase1.ItemType + Keys.Enter);
          //  time.Sleep(2000);
            Driver.FindElements(NameCode)[1].Click();
            //time.Sleep(2000);
            Driver.FindElement(NameCodeInput).SendKeys(Data.purchase1.codeName + Keys.Enter);
            //time.Sleep(2000);
            Driver.FindElement(itemcode).SendKeys(Data.purchase1.itemcode + Keys.Enter);
            //time.Sleep(2000);
            Driver.FindElement(quantity).SendKeys(Data.purchase1.quantity + Keys.Enter);
            //time.Sleep(2000);
            Driver.FindElement(price).Clear();
            Driver.FindElement(price).SendKeys(Data.purchase1.price + Keys.Enter);
            Automation_Testing.Common.ScrollDown(12);

            Driver.FindElement(IsPurchaseInInstallmentsRadioBtn).Click();


            time.Sleep(2000);

            Driver.FindElement(savebutton).Click();
            time.Sleep(2000);

           // time.Sleep(2000);
        

           






        }

    }
}