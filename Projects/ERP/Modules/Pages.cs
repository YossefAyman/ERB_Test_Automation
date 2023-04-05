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

    class Pages 
    {
        private enum MENU_ITEMS
        {
            PROFILES = 4, GENERAL_SITTINGS = 6, FINANCIALS = 8, INVENTORIES = 9, SALES = 10, PURCHASES = 11, ESTATE = 14, assets = 3 , PERSONAL_AFFAIRS = 20
        }

        private enum PROFILES_ITEMS
        {
            CUSTOMERS = 3, SUPPLIERS = 6, OWNERS = 7, Technicians = 4
        }

        private enum GENERAL_SITTING_ITEMS
        {
            COUNTRIES = 1, AREAS = 2, CITIES = 3, DISTRICTS = 4
        }

        private enum FINANCIALS_ITEMS
        {
            CURRENCY = 4, BANK = 7, BANK_ACCOUNT = 8, TAX = 9, COST_CENTER = 10, Receiptvoucher = 1, DailyRestrictions = 13, AccountReport = 14


        }

        private enum INVENTORIES_ITEMS
        {
            BRAND = 6, STORE = 5, INVENTORY_CATEGORY = 3, INVENTORY_PERMISSION = 4, ADDING_PERMISSION = 8, ITEM_TYPE = 12, ITEM = 13, Itemstatus = 12,
        }
        private enum PURCHASES_ITEMS
        {
            PURCHASES_BILL = 1, PURCHASES_RETURNS_BILL = 2
        }
        private enum SALES_ITEMS
        {
            SALES_BILL = 2, SALES_BILL_RETURNS = 1
        }
        private enum Estate_ITEMS
        {
            BAN_REASON = 1, property = 2, property_Type = 3, suspension_Reason = 4, buildings = 5, Apartements = 6, villa = 7, property_Reports = 8,

        }
        private enum assets_items
        {
            assets = 3
        }
         private enum PersonnalAffairs_ITEMS
        {
            DesignationType = 1 , JobGrade = 2 , FinancialDisclosure = 3
        }

        static By Profiling_Module = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.PROFILES + ") > a");
        static By Customers_Page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.PROFILES + ") > ul > li:nth-child(" + (int)PROFILES_ITEMS.CUSTOMERS + ") > a");
        static By Supplier_Page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.PROFILES + ") > ul > li:nth-child(" + (int)PROFILES_ITEMS.SUPPLIERS + ") > a");
        static By Owners_Page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.PROFILES + ") > ul > li:nth-child(" + (int)PROFILES_ITEMS.OWNERS + ") > a");
        static By Technicians_page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.PROFILES + ") > ul > li:nth-child(" + (int)PROFILES_ITEMS.Technicians + ") > a");

        static By Financial_Module = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.FINANCIALS + ") > a");
        static By Daily_Restrictions = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.FINANCIALS + ") > ul > li:nth-child(" + (int)FINANCIALS_ITEMS.DailyRestrictions + ") > a");
        static By Currency_Page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.FINANCIALS + ") > ul > li:nth-child(" + (int)FINANCIALS_ITEMS.CURRENCY + ") > a");
        static By Tax_Page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.FINANCIALS + ") > ul > li:nth-child(" + (int)FINANCIALS_ITEMS.TAX + ") > a");
        static By AccountReport_Page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.FINANCIALS + ") > ul > li:nth-child(" + (int)FINANCIALS_ITEMS.AccountReport + ") > a");
        static By CostCenter_Page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.FINANCIALS + ") > ul > li:nth-child(" + (int)FINANCIALS_ITEMS.COST_CENTER + ") > a");
        static By Bank_Page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.FINANCIALS + ") > ul > li:nth-child(" + (int)FINANCIALS_ITEMS.BANK + ") > a");
        static By BankAccount_Page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.FINANCIALS + ") > ul > li:nth-child(" + (int)FINANCIALS_ITEMS.BANK_ACCOUNT + ") > a");
        static By Receiptvoucher_page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.FINANCIALS + ") > ul > li:nth-child(" + (int)FINANCIALS_ITEMS.Receiptvoucher + ") > a");


        static By Inventories_Module = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.INVENTORIES + ") > a");
        static By Brand_Page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.INVENTORIES + ") > ul > li:nth-child(" + (int)INVENTORIES_ITEMS.BRAND + ") > a");
        static By Store_Page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.INVENTORIES + ") > ul > li:nth-child(" + (int)INVENTORIES_ITEMS.STORE + ") > a");
        static By InventoryCategory_Page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.INVENTORIES + ") > ul > li:nth-child(" + (int)INVENTORIES_ITEMS.INVENTORY_CATEGORY + ") > a");
        static By ItemTypes_Page = By.CssSelector("body > div.wrapper > aside > div > ul > libody > div:nth-child(2) > aside:nth-child(1) > div:n:nth-child(" + (int)MENU_ITEMS.INVENTORIES + ") > ul > li:nth-child(" + (int)INVENTORIES_ITEMS.ITEM_TYPE + ") > a");
        static By Item_Page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(9) > ul > li:nth-child(" + (int)INVENTORIES_ITEMS.ITEM + ") > a");
        static By AddingPermission_Page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.INVENTORIES + ") > ul > li:nth-child(" + (int)INVENTORIES_ITEMS.ADDING_PERMISSION + ") > a");
        static By InventoryPermission_Page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.INVENTORIES + ") > ul > li:nth-child(" + (int)INVENTORIES_ITEMS.INVENTORY_PERMISSION + ") > a");
        static By Itemstatus_page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.INVENTORIES + ") > ul > li:nth-child(" + (int)INVENTORIES_ITEMS.Itemstatus + ") > a");


        static By GeneralSittings_Module = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.GENERAL_SITTINGS + ") > a");
        static By Countries_Page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.GENERAL_SITTINGS + ") > ul > li:nth-child(" + (int)GENERAL_SITTING_ITEMS.COUNTRIES + ") > a");
        static By Areas_Page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.GENERAL_SITTINGS + ") > ul > li:nth-child(" + (int)GENERAL_SITTING_ITEMS.AREAS + ") > a");
        static By Cities_Page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.GENERAL_SITTINGS + ") > ul > li:nth-child(" + (int)GENERAL_SITTING_ITEMS.CITIES + ") > a");
        static By Districts_Page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.GENERAL_SITTINGS + ") > ul > li:nth-child(" + (int)GENERAL_SITTING_ITEMS.DISTRICTS + ") > a");

        static By Purchases_Module = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.PURCHASES + ") > a");
        static By PurchasesBill_Page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.PURCHASES + ") > ul > li:nth-child(" + (int)PURCHASES_ITEMS.PURCHASES_BILL + ") > a");
        static By PurchasesReturnsBill_Page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.PURCHASES + ") > ul > li:nth-child(" + (int)PURCHASES_ITEMS.PURCHASES_RETURNS_BILL + ") > a");
        static By Sales_Module = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.SALES + ") > a");


        static By Assets_Module = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.assets + ") > a");
        static By Assets_page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.assets + ") > ul > li:nth-child(" + (int)assets_items.assets + ") > a");


        static By SalesBill_Page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.SALES + ") > ul > li:nth-child(" + (int)SALES_ITEMS.SALES_BILL + ") > a");
        static By Building_page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.SALES + ") > ul > li:nth-child(" + (int)Estate_ITEMS.buildings + ") > a");


        static By Estate_Module = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.ESTATE + ") > a");
        static By BanResaon_Page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.ESTATE + ") > ul > li:nth-child(" + (int)Estate_ITEMS.BAN_REASON + ") > a");
        static By Property_page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.ESTATE + ") > ul > li:nth-child(" + (int)Estate_ITEMS.property + ") > a");


        static By PersonnalAffairs_Module =             By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.PERSONAL_AFFAIRS + ") > a");
        static By DesignationType_Page =                By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.PERSONAL_AFFAIRS + ") > ul > li:nth-child(" + (int)PersonnalAffairs_ITEMS.DesignationType + ") > a");
        static By JobGrade_Page =                       By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.PERSONAL_AFFAIRS + ") > ul > li:nth-child(" + (int)PersonnalAffairs_ITEMS.JobGrade + ") > a");
        static By FinancialDisclosure_Page =            By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.PERSONAL_AFFAIRS + ") > ul > li:nth-child(" + (int)PersonnalAffairs_ITEMS.FinancialDisclosure + ") > a");




        public static void Open(By Module, By Page)
        {
            if (Automation_Testing.Common.Driver.FindElement(Module).GetAttribute("class") != "open")
            {
                Automation_Testing.Common.Driver.FindElement(Module).Click();
            }
            time.Sleep(1000);
            Automation_Testing.Common.Driver.FindElement(Page).Click();
            time.Sleep(3000);
        }

        // الملفات التعريفية
        public static void CustomersPage()
        {
            Open(Profiling_Module, Customers_Page);
        }

        public static void SupplierPage()
        {
            Open(Profiling_Module, Supplier_Page);
        }
        public static void OwnersPage()
        {
            Open(Profiling_Module, Owners_Page);
        }
        // الاعدادات العامة
        public static void CountriesPage()
        {
            Open(GeneralSittings_Module, Countries_Page);
        }

        public static void AreaPage()
        {
            Open(GeneralSittings_Module, Areas_Page);
        }

        public static void CityPage()
        {
            Open(GeneralSittings_Module, Cities_Page);
        }

        public static void DistrictsPage()
        {
            Open(GeneralSittings_Module, Districts_Page);
        }

        // الحسابات
        public static void BankPage()
        {
            Open(Financial_Module, Bank_Page);
        }

        public static void BankAccountPage()
        {
            Open(Financial_Module, BankAccount_Page);
        }
        public static void TaxPage()
        {
            Open(Financial_Module, Tax_Page);
        }

        public static void AccountReportPage()
        {
            Open(Financial_Module, AccountReport_Page);
        }

        public static void CostCenterPage()
        {
            Open(Financial_Module, CostCenter_Page);
        }

        public static void CurrencyPage()
        {
            Open(Financial_Module, Currency_Page);
        }

        // المخازن
        public static void BrandPage()
        {
            Open(Inventories_Module, Brand_Page);
        }

        public static void StoresPage()
        {
            Open(Inventories_Module, Store_Page);
        }

        public static void InventoryCategoriesPage()
        {
            Open(Inventories_Module, InventoryCategory_Page);
        }

        public static void ItemPage()
        {
            Open(Inventories_Module, Item_Page);
        }


        public static void AddingPermissionPage()
        {
            Open(Inventories_Module, AddingPermission_Page);
        }

        public static void InventoryPermissionPage()
        {
            Open(Inventories_Module, InventoryPermission_Page);
        }

        // المشتريات
        public static void PurchasesBillPage()
        {
            Open(Purchases_Module, PurchasesBill_Page);
        }

        public static void PurchaseReturnBill_Page()
        {
            Open(Purchases_Module, PurchasesReturnsBill_Page);
        }
        // المبيعات
        public static void SalessBillPage()
        {
            Open(Sales_Module, SalesBill_Page);
        }
        // الأملاك
        public static void BanReasonPage()
        {
            Open(Estate_Module, BanResaon_Page);
        }
        public static void BuildingPage()
        {
            Open(Estate_Module, Building_page);
        }

        public static void TechniciansPage()
        {
            Open(Profiling_Module, Technicians_page);
        }


        public static void itempage()
        {
            Open(Inventories_Module, Item_Page);
        }
        public static void itemTypepage()
        {

            Open(Inventories_Module, ItemTypes_Page);
        }

        public static void itemstatuspage()
        {

            Open(Inventories_Module, Itemstatus_page);
        }



        public static void receiptvoucher()
        {
            Open(Financial_Module, Receiptvoucher_page);
        }



        public static void property()
        {
            Open(Estate_Module, Property_page);
        }



        public static void Assets()
        {

            Open(Assets_Module, Assets_page);
        }


        public static void DailyRestrictionspage()
        {

            Open(Estate_Module, Bank_Page);
        }
        public static void DailyRestrictionPage()
        {
            Open(Financial_Module, Daily_Restrictions);
        }

        public static void DesignationTypePage()
        {
            Open(PersonnalAffairs_Module, DesignationType_Page);
        }
        public static void JobGradePage()
        {
            Open(PersonnalAffairs_Module, JobGrade_Page);
        }
        public static void FinancialDisclosurePage()
        {
            Open(PersonnalAffairs_Module, FinancialDisclosure_Page);
        }

    }
}