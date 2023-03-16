using Automation_Testing;
using ERP_Automation_Testing;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using time = System.Threading.Thread;

namespace ERP_Automation_Testing
{

    class item_page
    {
        static IWebDriver Driver = Automation_Testing.Common.Driver;
        static IJavaScriptExecutor javaDriverExector = Driver as IJavaScriptExecutor;

        // Selectors
        static By Add_Button = By.ClassName("btnAddItem");

        // static By Search_TextBox = By.ClassName("ng-valid");
        static By Search_TextBox = By.XPath("//*[@placeholder=\"بحث\"]");
        static By Search_Button = By.ClassName("btn-light");
        static By CountryName_TextBox = By.CssSelector("#FormManager > div:nth-child(3) > div:nth-child(1) > div > div > div > div > input");
        static By AreaName_TextBox = By.CssSelector("#FormManager > div:nth-child(3) > div:nth-child(2) > div > div > div > div > input");
        static By CityName_TextBox = By.CssSelector("#FormManager > div:nth-child(3) > div:nth-child(3) > div > div > div > div > input");
        static By DistrictName_TextBox = By.CssSelector("#FormManager > div:nth-child(3) > div:nth-child(4) > div > div > div > div > input");
        static By FirstItemEdit_Button = By.ClassName("btnEditItem");
        static By FirstItemDelete_Button = By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button = By.ClassName("confirm");
        static By NumOfItems_Text = By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");
        static By UISelect_DDL = By.ClassName("ui-select-container");
        static By UISelectSearch_TextBox = By.ClassName("ui-select-search");
        static By ItemName_TextBox = By.Id("Item_ItemName");
        static By Itemcode_TextBox = By.Id("Item_ItemCode");
        static By ItemDescription_TextBox = By.Id("Item_ItemDescription");
        static By ItemPurchaseprice_TextBox = By.Id("Item_ItemPurchasePrice");
        static By Itemunit_TextBox = By.Id("Item_ItemUnit");
        static By Discountforsale_Textbox = By.Id("Item_DiscountForSale");

       

        static By DefaultPurchaseDiscount = By.Id("Item_DefaultPurchaseDiscount");
        static By MaxDiscount = By.Id("Item_MaxDiscount");
        static By ItemPrice = By.Id("Item_ItemPrice");
        static By Demandlimit_Textbox = By.Id("Item_DemandLimit");
        static By DemandlimitforInventory_Textbox = By.Id("Item_DemandLimitForInventory");
        static By Barcode_Textbox = By.Id("Item_BarCode");
        static By validityDuration_Textbox = By.Id("Item_ValidityDuration");
        static By Save_Button = By.CssSelector("#mainModal > div > div > div.modal-body > div.modal-footer > input");


     
        public static void Goto()
        {
            Pages.itempage();
            time.Sleep(3000);

        }

        public static void Add_item()
        {
            
                
                Driver.FindElement(Add_Button).Click();


            var ddlElements = Driver.FindElements(UISelect_DDL);
            var ddlTextBoxElements = Driver.FindElements(UISelectSearch_TextBox);
            /*            for (int DDlCounter = 2; DDlCounter < ddlElements.Count; DDlCounter++)
                        {
                            Common.Click(ddlElements[DDlCounter]);
                            Common.WriteEnter(ddlTextBoxElements[DDlCounter]);
                        }*/

                ddlElements[2].Click();
                ddlTextBoxElements[2].SendKeys(Data.item.Brand + Keys.Enter);
                ddlElements[3].Click();
                ddlTextBoxElements[3].SendKeys(Data.item.category + Keys.Enter);
                ddlElements[4].Click();
                ddlTextBoxElements[4].SendKeys(Data.item.Tax + Keys.Enter);
                ddlElements[5].Click();
                ddlTextBoxElements[5].SendKeys(Data.item.ItemTypeName + Keys.Enter);



                Common.ClearThenWrite(ItemName_TextBox, Data.item.ItemName );
                Common.ClearThenWrite(Itemcode_TextBox, Data.item.Itemcode);
                Common.ClearThenWrite(ItemDescription_TextBox, Data.item.ItemDescription);
                Common.ClearThenWrite(ItemPurchaseprice_TextBox, Data.item.ItempurchasePrice);
                Common.ClearThenWrite(Itemunit_TextBox, Data.item.ItemUnit);
                Common.ClearThenWrite(Discountforsale_Textbox, Data.item.Discountforsale);
                Common.ClearThenWrite(DefaultPurchaseDiscount, Data.item.DefaultPurchaseDiscount);
                Common.ClearThenWrite(MaxDiscount, Data.item.MaxDiscount);
                Common.ClearThenWrite(ItemPrice, Data.item.ItemPrice);
                Common.ClearThenWrite(Demandlimit_Textbox, Data.item.Demandlimit);
                Common.ClearThenWrite(DemandlimitforInventory_Textbox, Data.item.Demandlimitforinventory);
                Driver.FindElement(Barcode_Textbox).SendKeys(Data.item.Barcode);
                Driver.FindElement(validityDuration_Textbox).SendKeys(Data.item.Validityduration);


                IWebElement Element = Driver.FindElement(Save_Button);
                javaDriverExector.ExecuteScript("arguments[0].scrollIntoView();", Element);


                Driver.FindElement(Save_Button).Click();
                time.Sleep(1000);

                // Driver.FindElement(Discountforsale_Textbox).SendKeys(Data.item.Discountforsale);

            
        }
        public static void Edit_items(string ItemName, string newName)
        {
            Common.Search(ItemName);
            Driver.FindElement(FirstItemEdit_Button).Click();
            time.Sleep(1000);
            Driver.FindElement(ItemName_TextBox).Clear();
            Driver.FindElement(ItemName_TextBox).SendKeys(newName);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }

        public static void Delete_items(string items)
        {
            Common.Delete(items);
        }
        //#############################################################################################   


        //##############################################################################################        



    }
}

