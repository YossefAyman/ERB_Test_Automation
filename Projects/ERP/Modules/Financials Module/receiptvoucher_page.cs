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
    class receiptvoucher_Page
    {
        static IWebDriver Driver = Automation_Testing.Common.Driver;

        // Selectors
        static By Add_Button = By.ClassName("btnAddItem");
        static By CostCenterName_TextBox = By.CssSelector("#CostCenter_CostCenterName");
        static By Save_Button = By.CssSelector("#mainModal > div > div > div.modal-body > div.modal-footer > input");
        static By Search_TextBox = By.ClassName("ng-valid");
        static By Search_Button = By.ClassName("btn-light");
        static By FirstItemEdit_Button = By.ClassName("btnEditItem");
        static By FirstItemDelete_Button = By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button = By.ClassName("confirm");
        static By NumOfItems_Text = By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");
        static By UISelect_DDL = By.ClassName("ui-select-container");
        static By UISelectSearch_TextBox = By.ClassName("ui-select-search");
        static By Date = By.ClassName("dataPickerInputMainClass");
        static By AddDetails_button = By.ClassName("btn-success");
        static By Ammountbutton_Textbox = By.Id("EmptyReceiptVoucherItem_Amount");
        static By Describtion_Textbox = By.Id("EmptyReceiptVoucherItem_Description");
        static By Descount_Textbox = By.Id("ReceiptVoucher_Discount");
        static By save_button = By.ClassName("btn-primary");
        static By Additional_tax = By.Id("ReceiptVoucher_AdditionalTax");

        public static void Goto()
        {
            Pages.receiptvoucher();
            time.Sleep(2000);

        }

        public static void Add_Receiptvoucher()
        {
            Driver.FindElement(Add_Button).Click();
            time.Sleep(2000);
            Driver.FindElements(UISelect_DDL)[0].Click();
            time.Sleep(3000);
            Driver.FindElements(UISelectSearch_TextBox)[0].SendKeys(Data.Receiptvoucher.profilType + Keys.Enter);
            time.Sleep(2000);
            Driver.FindElements(UISelect_DDL)[1].Click();
            time.Sleep(3000);
            Driver.FindElements(UISelectSearch_TextBox)[1].SendKeys(Data.Receiptvoucher.receivefrom);
            time.Sleep(2000);
            Driver.FindElements(UISelectSearch_TextBox)[1].SendKeys(Keys.Enter);
            time.Sleep(3000);
            Driver.FindElements(UISelect_DDL)[2].Click();
            Driver.FindElements(UISelectSearch_TextBox)[2].SendKeys(Data.Receiptvoucher.profileaccountid);
            time.Sleep(3000);
            Driver.FindElements(UISelectSearch_TextBox)[2].SendKeys(Keys.Enter);
            time.Sleep(3000);
            Driver.FindElements(Date)[0].Clear();
            Driver.FindElements(Date)[0].SendKeys(Data.Receiptvoucher.Date + Keys.Enter);
            Driver.FindElements(Date)[1].Clear();
            Driver.FindElements(Date)[1].SendKeys(Data.Receiptvoucher.Date + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[3].Click();
            Driver.FindElements(UISelectSearch_TextBox)[3].SendKeys(Data.Receiptvoucher.currency + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[4].Click();
            Driver.FindElements(UISelectSearch_TextBox)[4].SendKeys(Data.Receiptvoucher.paymentmethod + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[6].Click();
            Driver.FindElements(UISelectSearch_TextBox)[6].SendKeys(Data.Receiptvoucher.Treasury + Keys.Enter);
            time.Sleep(3000);
            Driver.FindElement(AddDetails_button).Click();
            time.Sleep(3000);
            Driver.FindElements(UISelect_DDL)[8].Click();
            Driver.FindElements(UISelectSearch_TextBox)[8].SendKeys(Data.Receiptvoucher.referenceType + Keys.Enter);
            Driver.FindElements(UISelect_DDL)[9].Click();
            Driver.FindElements(UISelectSearch_TextBox)[9].SendKeys(Data.Receiptvoucher.serious + Keys.Enter);
            Driver.FindElement(Ammountbutton_Textbox).Clear();
            Driver.FindElement(Ammountbutton_Textbox).SendKeys(Data.Receiptvoucher.Amount);
            Driver.FindElement(Describtion_Textbox).SendKeys(Data.Receiptvoucher.Description);
            Driver.FindElement(Descount_Textbox).Clear();
            Driver.FindElement(Descount_Textbox).SendKeys(Data.Receiptvoucher.Discount);
            Driver.FindElement(Additional_tax).Clear();
            Driver.FindElement(Additional_tax).SendKeys(Data.Receiptvoucher.AdditionalTax);
            time.Sleep(3000);
            Driver.FindElement(By.ClassName("drop-box")).Click();
            time.Sleep(3000);
            Common.Add_Attachment();
            time.Sleep(3000);

            Driver.FindElement(save_button).Click();
            time.Sleep(2000);




            







            

           
        }
    }
}