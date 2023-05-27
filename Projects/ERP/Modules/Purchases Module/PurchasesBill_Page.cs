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
        static IJavaScriptExecutor javaDriverExector = Driver as IJavaScriptExecutor;

        // Selectors

        static By Add_Button =                                  By.XPath("//button[@class='btn btn-circle btn-success']");
        static By UISelect_DDL =                                By.ClassName("ui-select-container");
        static By UISelectSearch_TextBox =                      By.ClassName("ui-select-search");
        static By Date =                                        By.ClassName("dataPickerInputMainClass");
        static By ItemSelect_Droplist =                         By.XPath("/html/body/div[2]/main/div/div/div[2]/section/div[1]/div/div[2]/div/form/fieldset[2]/div[1]/div[1]/div/div/div[1]/input");
        static By quantity =                                    By.Id("EmptyPurchasesInvoiceDetails_Quantity");
        static By BillWithoutTax =                              By.XPath("//*[@id=\"FormManager\"]/fieldset[2]/div[4]/div[7]/div/label");
        static By Save_Button =                                 By.CssSelector("#frm > input");
        static By Total_Amount_Of_Bill =                        By.XPath("/html/body/div[2]/main/div/div/div[2]/section/div[1]/div/div[2]/div/form/fieldset[3]/div/div[11]/div/div/input");
        static By NumOfItems_Text =                             By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");
        static By NumOfPages_Text =                             By.XPath("//*[@id=\"grid\"]/div[2]/div[1]/div[1]/span");
        static By NumOfCurrentPage_Text =                       By.XPath("//*[@id=\"grid\"]/div[2]/div[1]/div[1]/input");
        static By NextButton =                                  By.XPath("//*[@id=\"grid\"]/div[2]/div[1]/div[1]/button[3]");
        static By BackButton =                                  By.XPath("/html/body/div[2]/main/div/div/div[2]/section/div[1]/div/div[2]/div/button");

        public static void Goto()
        {
            Pages.PurchasesBillPage();

            time.Sleep(2000);
        }

        public static List<string> Add_purchaseBill()
        {
            Driver.FindElement(Add_Button).Click();
            Driver.FindElements(UISelect_DDL)[0].Click();
            Driver.FindElements(UISelectSearch_TextBox)[0].SendKeys(Data.Purchase.supplierName + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[1].Click();
            Driver.FindElements(UISelectSearch_TextBox)[1].SendKeys(Data.Sales.Store + Keys.Enter);
            Driver.FindElement(Date).Clear();
            Driver.FindElement(Date).SendKeys(Data.RandomDate() + Keys.Enter);
            Driver.FindElement(ItemSelect_Droplist).Click();
            Driver.FindElement(ItemSelect_Droplist).SendKeys(Data.Sales.Item_Name);
            time.Sleep(1000);
            Driver.FindElement(ItemSelect_Droplist).SendKeys(Keys.Enter);
            /*Driver.FindElements(UISelect_DDL)[2].Click();
            Driver.FindElements(UISelectSearch_TextBox)[2].SendKeys(Data.Purchase.ItemType + Keys.Enter);*/
            /*Driver.FindElement(NameCodeInput).SendKeys(Data.Purchase.codeName + Keys.Enter);
            Driver.FindElement(itemcode).SendKeys(Data.Purchase.itemcode + Keys.Enter);*/
            Driver.FindElement(quantity).Clear();
            Driver.FindElement(quantity).SendKeys(Data.Purchase.quantity + Keys.Enter);
            Automation_Testing.Common.ScrollDown(12);
            time.Sleep(2000);
            Driver.FindElement(BillWithoutTax).Click();
            Automation_Testing.Common.ScrollDown(8);
            string total_Amount_OfTheBill = Driver.FindElement(Total_Amount_Of_Bill).GetAttribute("value");
            Driver.FindElement(Save_Button).Click();
            time.Sleep(4000);
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
                int counter = int.Parse(countArray[2]) - int.Parse(countArray[0]) + 1;
                for (int x = 1; x <= counter; x++)
                {
                    if (Driver.FindElement(By.XPath("/html/body/div[2]/main/div/div/div[2]/div/div[2]/section/div/div/div[2]/div/div/div[6]/div[1]/div[2]/div[2]/div/div[" + x + "]/div/div[2]/div/a[1]/span")).Displayed)
                    {
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