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

    class item_Typepage : CommonSelectors
    {
        static IWebDriver Driver = Automation_Testing.Common.Driver;

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
        static By ItemTypeName_Textbox = By.Id("ItemType_ItemTypeName");


        static By DefaultPurchaseDiscount = By.Id("Item_DefaultPurchaseDiscount");
        static By MaxDiscount = By.Id("Item_MaxDiscount");
        static By ItemPrice = By.Id("Item_ItemPrice");
        static By Demandlimit_Textbox = By.Id("Item_DemandLimit");
        static By DemandlimitforInventory_Textbox = By.Id("Item_DemandLimitForInventory");
        static By Barcode_Textbox = By.Id("Item_BarCode");
        static By validityDuration_Textbox = By.Id("Item_ValidityDuration");
        static By Save_Button = By.CssSelector("#mainModal > div > div > div.modal-body > div.modal-footer > input");
        static By ItemTypeDescription_Textbox = By.Id("ItemType_ItemTypeDescription");

        public static void Goto() 
        {
            Pages.itemTypepage(); 
            time.Sleep(3000);

        }

        public static void Add_itemtype(int numOfRepeats = 0)
        {

            for (int i = 0; i <= numOfRepeats; i++)
            {


                Driver.FindElement(Add_Button).Click();
                time.Sleep(3000);
                Driver.FindElement(ItemTypeName_Textbox).SendKeys(Data.itemTypes.itemTypeName + i);
                time.Sleep(2000);
                Driver.FindElements(UISelect_DDL)[0].Click();
                Driver.FindElements(UISelectSearch_TextBox)[0].SendKeys(Data.itemTypes.itemnature + Keys.Enter + i);
                time.Sleep(2000);
                Driver.FindElements(UISelect_DDL)[1].Click();
                Driver.FindElements(UISelectSearch_TextBox)[1].SendKeys(Data.itemTypes.status + Keys.Enter + i);
                Driver.FindElement(ItemTypeDescription_Textbox).SendKeys(Data.itemTypes.ItemTypeDescription + i);
                Driver.FindElement(Save_Button).Click();
                time.Sleep(3000);
            }
        }

        public static void Delete_itemsType(string itemstypeName, int numOfRepeats = 0)
        {
            for (int i = 0; i <= numOfRepeats; i++)

                Common.Delete(itemstypeName+i);
        }


        public static void view_itemsType(string itemstypeName)

        {
            Common.Search(itemstypeName);
            time.Sleep(2000);

            Common.Actions.DoubleClick(Driver.FindElement(Grid_Row)).Perform();
            time.Sleep(3000);



        }
        





    }
}


