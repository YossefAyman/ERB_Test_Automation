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
    class SalesBill_Page
    {
        static IWebDriver Driver = Automation_Testing.Common.Driver;
        static IJavaScriptExecutor javaDriverExector = Driver as IJavaScriptExecutor;


        // Selectors
        
        static By Add_Button =                          By.ClassName("btn-success");
        static By ClientName_SelectToggle =             By.XPath("//a[@placeholder='العميل']//b");
        static By ClientName_TextBox =                  By.CssSelector("#FormManager > fieldset:nth-child(1) > div > div:nth-child(1) > div > div > div > div > input");
        static By StoreName_SelectToggle =              By.XPath("//a[@placeholder='مخزن']//b");
        static By StoreName_TextBox =                   By.CssSelector("#FormManager > fieldset:nth-child(1) > div > div:nth-child(3) > div > div > div > div > input");
        static By Item_Type_SelectToggle =              By.XPath("//a[@placeholder='نوع الصنف']//b");
        static By Item_Type_TextBox =                   By.CssSelector("#FormManager > fieldset:nth-child(2) > div.row.mb-5 > div:nth-child(1) > div > div > div > input");
        static By Item_SelectToggle =                   By.CssSelector("#FormManager > fieldset:nth-child(2) > div.row.mb-5 > div:nth-child(2) > div > div.selectize-input.items.not-full.ng-valid.ng-pristine.has-options > input[type=text]");
        static By Item_SelectName =                     By.XPath("//div[contains(text(),'اسم العنصر_101')]");
        static By Item_Quantity =                       By.Id("EmptySalesInvoiceDetails_Quantity");
        static By Tax_CheckButton =                     By.CssSelector("div.wrapper:nth-child(2) main.main-content div.page-content div.container-fluid div.ng-scope:nth-child(3) section.section-md.ng-scope:nth-child(2) div.container:nth-child(1) div.main-box div.main-box-content form.isVisible.ng-valid.ng-valid-min.ng-valid-required.ng-dirty.ng-valid-parse.ng-valid-max:nth-child(2) fieldset.groupBoxSection:nth-child(2) div.row.sm-gutters:nth-child(4) div.col-md-12:nth-child(7) div.searchArea.check-radio-item.inline > label:nth-child(2)");
        static By Total_Amount_OF_Bill =                By.Id("tbTotalForSales");
        static By Save_Button =                         By.XPath("//body/div[@class='wrapper']/main[@role='main']/div[@id='testId1']/div[@class='container-fluid']/div[@class='ng-scope']/section[@id='salesInvoiceController']/div[@class='container']/div[@class='main-box']/div[@class='main-box-content']/div[@id='frm']/input[1]");



        public static void Goto()
        {
            Pages.SalessBillPage();
            time.Sleep(2000);

        }
        public static int Add_SalesBill() 
	    {
        
            Driver.FindElement(Add_Button).Click();
            time.Sleep(2000);
		
            Driver.FindElement(ClientName_SelectToggle).Click();
            Driver.FindElement(ClientName_TextBox).SendKeys("تيست" + Keys.Enter);
		
            Driver.FindElement(StoreName_SelectToggle).Click();
            Driver.FindElement(StoreName_TextBox).SendKeys("مخزن_101" + Keys.Enter);

            Driver.FindElement(Item_Type_SelectToggle).Click();
            Driver.FindElement(Item_Type_TextBox).SendKeys("اغذيه" + Keys.Enter);

            Driver.FindElement(Item_SelectToggle).Click();
            Driver.FindElement(Item_SelectName).Click();
            Driver.FindElement(Item_Quantity).Clear();
            Driver.FindElement(Item_Quantity).SendKeys("5");

            time.Sleep(3000);


            IWebElement Element = Driver.FindElement(Item_Quantity);
            javaDriverExector.ExecuteScript("arguments[0].scrollIntoView();", Element);



            Driver.FindElement(Tax_CheckButton).Click();

            time.Sleep(2000);

            IWebElement Element2 = Driver.FindElement(Save_Button);
            javaDriverExector.ExecuteScript("arguments[0].scrollIntoView();", Element2);

            time.Sleep(2000);

            
            string total_Amount_OfTheBill = Driver.FindElement(Total_Amount_OF_Bill).GetAttribute("value");
            Driver.FindElement(Save_Button).Click();
            time.Sleep(3000);

            return int.Parse(total_Amount_OfTheBill);

        }




    }
}
