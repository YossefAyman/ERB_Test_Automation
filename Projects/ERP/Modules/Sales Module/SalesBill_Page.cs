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

        static By Add_Button =                           By.ClassName("btn-success");
        static By ClientName_SelectToggle =              By.XPath("//a[@placeholder='العميل']//b");
        static By ClientName_TextBox =                   By.CssSelector("#FormManager > fieldset:nth-child(1) > div > div:nth-child(1) > div > div > div > div > input");
        static By StoreName_SelectToggle =               By.XPath("//a[@placeholder='مخزن']//b");
        static By StoreName_TextBox =                    By.CssSelector("#FormManager > fieldset:nth-child(1) > div > div:nth-child(3) > div > div > div > div > input");
        static By Item_Type_SelectToggle =               By.XPath("//a[@placeholder='نوع الصنف']//b");
        static By Item_Type_TextBox =                    By.CssSelector("#FormManager > fieldset:nth-child(2) > div.row.mb-5 > div:nth-child(1) > div > div > div > input");
        static By Item_SelectToggle =                    By.CssSelector("#FormManager > fieldset:nth-child(2) > div.row.mb-5 > div:nth-child(2) > div > div.selectize-input.items.not-full.ng-valid.ng-pristine.has-options > input[type=text]");
        static By Item_SelectName =                      By.XPath("//div[contains(text(),'اسم العنصر_101')]");
        static By Item_Quantity =                        By.Id("EmptySalesInvoiceDetails_Quantity");
        static By Tax_CheckButton =                      By.CssSelector("div.wrapper:nth-child(2) main.main-content div.page-content div.container-fluid div.ng-scope:nth-child(3) section.section-md.ng-scope:nth-child(2) div.container:nth-child(1) div.main-box div.main-box-content form.isVisible.ng-valid.ng-valid-min.ng-valid-required.ng-dirty.ng-valid-parse.ng-valid-max:nth-child(2) fieldset.groupBoxSection:nth-child(2) div.row.sm-gutters:nth-child(4) div.col-md-12:nth-child(7) div.searchArea.check-radio-item.inline > label:nth-child(2)");
        static By Total_Amount_OF_Bill =                 By.Id("tbTotalForSales");
        static By Save_Button =                          By.XPath("//body/div[@class='wrapper']/main[@role='main']/div[@id='testId1']/div[@class='container-fluid']/div[@class='ng-scope']/section[@id='salesInvoiceController']/div[@class='container']/div[@class='main-box']/div[@class='main-box-content']/div[@id='frm']/input[1]");
        static By NumOfItems_Text =                      By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");
        static By NumOfPages_Text =                      By.XPath("//*[@id=\"grid\"]/div[2]/div[1]/div[1]/span");
        static By NumOfCurrentPage_Text =                By.XPath("//*[@id=\"grid\"]/div[2]/div[1]/div[1]/input");
        static By NextButton =                           By.XPath("//*[@id=\"grid\"]/div[2]/div[1]/div[1]/button[3]");
        static By BackButton =                           By.XPath("/html/body/div[2]/main/div/div/div[2]/section/div[1]/div/div[2]/div/button");


        public static void Goto()
        {
            Pages.SalessBillPage();
            time.Sleep(2000);

        }
        public static List<string> Add_SalesBill()
        {

            Driver.FindElement(Add_Button).Click();
            time.Sleep(2000);
            Driver.FindElement(ClientName_SelectToggle).Click();
            Driver.FindElement(ClientName_TextBox).SendKeys(Data.Sales.Clinet_Name + Keys.Enter);
            Driver.FindElement(StoreName_SelectToggle).Click();
            Driver.FindElement(StoreName_TextBox).SendKeys(Data.Sales.Store + Keys.Enter);
            Driver.FindElement(Item_Type_SelectToggle).Click();
            Driver.FindElement(Item_Type_TextBox).SendKeys("اغذية" + Keys.Enter);
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
            Driver.FindElement(BackButton).Click();
            time.Sleep(3000);
            List<string> ListOftotal_Amount_Serial = new List<string>();
            ListOftotal_Amount_Serial.Add(total_Amount_OfTheBill);
            ListOftotal_Amount_Serial.Add(GetInvoiceSeries());
            return ListOftotal_Amount_Serial;

        }

        public static string GetInvoiceSeries()
        {

                IWebElement Element = Driver.FindElement(NumOfItems_Text);
                javaDriverExector.ExecuteScript("arguments[0].scrollIntoView(true);", Element);
                string countString = Driver.FindElement(NumOfItems_Text).Text;
                string[] countArray = countString.Split(' ');
                int count = 0;
                int.TryParse(countArray[2], out count);
                List<int> ListOfSerials = new List<int>();
                var NumOfPage = Driver.FindElement(NumOfPages_Text).Text;
                string[] NumOfPages_Text_List = NumOfPage.Split(' ');
                int NumOfPages = int.Parse(NumOfPages_Text_List[1]);
                int NumOfCurrentPage = int.Parse(Driver.FindElement(NumOfCurrentPage_Text).GetAttribute("value"));

                for (int i = 1; i <= count; i++)
                {
                    string name = Driver.FindElement(By.XPath("/html/body/div[2]/main/div/div/div[2]/div/div[2]/section/div/div/div[2]/div/div/div[6]/div[1]/div[2]/div[2]/div/div[" + i + "]/div/div[2]/div/a[1]/span")).Text;
                    string[] Serial_Text_List = name.Split('-');
                    int Serial = int.Parse(Serial_Text_List[1]);
                    ListOfSerials.Add(Serial);
                }

                while (NumOfCurrentPage < NumOfPages)
                {
                    Driver.FindElement(NextButton).Click();
                    countString = Driver.FindElement(NumOfItems_Text).Text;
                    countArray = countString.Split(' ');
                    int counter = int.Parse(countArray[2]) - int.Parse(countArray[0]) + 1 ;
                    for (int x = 1; x <= counter; x++)
                    {
                        if (Driver.FindElement(By.XPath("/html/body/div[2]/main/div/div/div[2]/div/div[2]/section/div/div/div[2]/div/div/div[6]/div[1]/div[2]/div[2]/div/div[" + x + "]/div/div[2]/div/a[1]/span")).Displayed){
                        string name = Driver.FindElement(By.XPath("/html/body/div[2]/main/div/div/div[2]/div/div[2]/section/div/div/div[2]/div/div/div[6]/div[1]/div[2]/div[2]/div/div[" + x + "]/div/div[2]/div/a[1]/span")).Text;
                        string[] Serial_Text_List = name.Split('-');
                        int Serial = int.Parse(Serial_Text_List[1]);
                        ListOfSerials.Add(Serial);
                    }
                }
                    NumOfCurrentPage++;
                }
                string Max_ListOfSerials = (ListOfSerials.Max()).ToString();
                return Max_ListOfSerials.PadLeft(6, '0');
             
                


        }

    }
}