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
          assets = 3 ,  PROFILES = 4, GENERAL_SITTINGS = 6, FINANCIALS = 8, INVENTORIES = 9, SALES = 10, PURCHASES = 11, ESTATE = 15 , Contract=16, PERSONAL_AFFAIRS = 20 , ATTENDANCE_AND_DEPARTURE = 21 , SALARIES = 22
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
            PropertyType = 1, Property = 2 , SuspensionReason = 3 , BAN_REASON = 7,  suspension_Reason = 4, buildings = 5, Apartements = 6, villa = 7, property_Reports = 8

        }
        private enum assets_items
        {
            assets = 3
        }
         private enum PersonnalAffairs_ITEMS
        {
            DesignationType = 1 , JobGrade = 2 , FinancialDisclosure = 3 , MilitaryServiceStatus = 4 , TheLeavingReason =5 , EmploymentType = 6 , N2_EmploymentType = 7 , SpecialNeeds = 8 ,
            ReasonsForFinancialDisclosure = 9 , JobTitle = 10 , Skills = 11 , Qualifications = 12 , Job = 13 , OrganizationUnit = 14 , WorkingYear = 16 , WorkSystem = 17 , ProceduresTypes = 18 ,
            EmployeesProcedures = 19

        }

        private enum AttendanceAndDeparture_ITEMS
        {
            PermissionType = 1 , LeaveType = 2 , AnnualHolidays = 5 , Permissions = 8 , Vacations = 9 , Errands = 10
        }

        private enum Salaries_ITEMS
        {
            AllowanceType = 1 , PeriodicalDeductionType = 2
        }


        private enum Contract_ITEMS
        {
            ContractType_Page = 4


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


        static By Estate_Module =                        By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.ESTATE + ") > a");
        static By BanResaon_Page =                       By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.ESTATE + ") > ul > li:nth-child(" + (int)Estate_ITEMS.BAN_REASON + ") > a");
        static By Property_page =                        By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.ESTATE + ") > ul > li:nth-child(" + (int)Estate_ITEMS.Property + ") > a");
        static By PropertyType_Page =                    By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.ESTATE + ") > ul > li:nth-child(" + (int)Estate_ITEMS.PropertyType + ") > a");
        static By SuspensionReason_Page =                By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.ESTATE + ") > ul > li:nth-child(" + (int)Estate_ITEMS.SuspensionReason + ") > a");


        static By PersonnalAffairs_Module =             By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.PERSONAL_AFFAIRS + ") > a");
        static By DesignationType_Page =                By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.PERSONAL_AFFAIRS + ") > ul > li:nth-child(" + (int)PersonnalAffairs_ITEMS.DesignationType + ") > a");
        static By JobGrade_Page =                       By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.PERSONAL_AFFAIRS + ") > ul > li:nth-child(" + (int)PersonnalAffairs_ITEMS.JobGrade + ") > a");
        static By FinancialDisclosure_Page =            By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.PERSONAL_AFFAIRS + ") > ul > li:nth-child(" + (int)PersonnalAffairs_ITEMS.FinancialDisclosure + ") > a");
        static By MilitaryServiceStatus_Page =          By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.PERSONAL_AFFAIRS + ") > ul > li:nth-child(" + (int)PersonnalAffairs_ITEMS.MilitaryServiceStatus + ") > a");
        static By TheLeavingReason_Page =               By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.PERSONAL_AFFAIRS + ") > ul > li:nth-child(" + (int)PersonnalAffairs_ITEMS.TheLeavingReason + ") > a");
        static By EmploymentType_Page =                 By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.PERSONAL_AFFAIRS + ") > ul > li:nth-child(" + (int)PersonnalAffairs_ITEMS.EmploymentType + ") > a");
        static By N2_EmploymentType_Page =              By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.PERSONAL_AFFAIRS + ") > ul > li:nth-child(" + (int)PersonnalAffairs_ITEMS.N2_EmploymentType + ") > a");
        static By SpecialNeeds_Page =                   By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.PERSONAL_AFFAIRS + ") > ul > li:nth-child(" + (int)PersonnalAffairs_ITEMS.SpecialNeeds + ") > a");
        static By ReasonsForFinancialDisclosure_Page =  By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.PERSONAL_AFFAIRS + ") > ul > li:nth-child(" + (int)PersonnalAffairs_ITEMS.ReasonsForFinancialDisclosure + ") > a");
        static By JobTitle_Page =                       By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.PERSONAL_AFFAIRS + ") > ul > li:nth-child(" + (int)PersonnalAffairs_ITEMS.JobTitle + ") > a");
        static By Skills_Page =                         By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.PERSONAL_AFFAIRS + ") > ul > li:nth-child(" + (int)PersonnalAffairs_ITEMS.Skills + ") > a");
        static By Qualifications_Page =                 By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.PERSONAL_AFFAIRS + ") > ul > li:nth-child(" + (int)PersonnalAffairs_ITEMS.Qualifications + ") > a");
        static By Job_Page =                            By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.PERSONAL_AFFAIRS + ") > ul > li:nth-child(" + (int)PersonnalAffairs_ITEMS.Job + ") > a");
        static By OrganizationUnit_Page =               By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.PERSONAL_AFFAIRS + ") > ul > li:nth-child(" + (int)PersonnalAffairs_ITEMS.OrganizationUnit + ") > a");
        static By WorkingYear_Page =                    By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.PERSONAL_AFFAIRS + ") > ul > li:nth-child(" + (int)PersonnalAffairs_ITEMS.WorkingYear + ") > a");
        static By WorkSystem_Page =                     By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.PERSONAL_AFFAIRS + ") > ul > li:nth-child(" + (int)PersonnalAffairs_ITEMS.WorkSystem + ") > a");
        static By ProceduresTypes_Page =                By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.PERSONAL_AFFAIRS + ") > ul > li:nth-child(" + (int)PersonnalAffairs_ITEMS.ProceduresTypes + ") > a");
        static By EmployeesProcedures_Page =            By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.PERSONAL_AFFAIRS + ") > ul > li:nth-child(" + (int)PersonnalAffairs_ITEMS.EmployeesProcedures + ") > a");


        static By Attendace_And_Departure_Module =      By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.ATTENDANCE_AND_DEPARTURE + ") > a");
        static By PermissionType_Page =                 By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.ATTENDANCE_AND_DEPARTURE + ") > ul > li:nth-child(" + (int)AttendanceAndDeparture_ITEMS.PermissionType + ") > a");
        static By LeaveType_Page =                      By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.ATTENDANCE_AND_DEPARTURE + ") > ul > li:nth-child(" + (int)AttendanceAndDeparture_ITEMS.LeaveType + ") > a");
        static By AnnualHolidays_Page =                 By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.ATTENDANCE_AND_DEPARTURE + ") > ul > li:nth-child(" + (int)AttendanceAndDeparture_ITEMS.AnnualHolidays + ") > a");
        static By Permissions_Page =                    By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.ATTENDANCE_AND_DEPARTURE + ") > ul > li:nth-child(" + (int)AttendanceAndDeparture_ITEMS.Permissions + ") > a");
        static By Vacations_Page =                      By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.ATTENDANCE_AND_DEPARTURE + ") > ul > li:nth-child(" + (int)AttendanceAndDeparture_ITEMS.Vacations + ") > a");
        static By Errands_Page =                        By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.ATTENDANCE_AND_DEPARTURE + ") > ul > li:nth-child(" + (int)AttendanceAndDeparture_ITEMS.Errands + ") > a");


        static By Salaries_Module =                     By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.SALARIES + ") > a");
        static By AllowanceType_Page =                  By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.SALARIES + ") > ul > li:nth-child(" + (int)Salaries_ITEMS.AllowanceType + ") > a");
        static By PeriodicalDeductionType_Page =        By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.SALARIES + ") > ul > li:nth-child(" + (int)Salaries_ITEMS.PeriodicalDeductionType + ") > a");


        static By Contract_Module = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.Contract + ") > a");
        static By ContractType_Page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.Contract + ") > ul > li:nth-child(" + (int)Contract_ITEMS.ContractType_Page + ") > a");


        

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

        /// /////////////////// # HR_MODULE_ONE_PAGES # /////////////////////////////////////////////


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
        public static void MilitaryServiceStatusPage()
        {
            Open(PersonnalAffairs_Module, MilitaryServiceStatus_Page);
        }
        public static void TheLeavingReasonPage()
        {
            Open(PersonnalAffairs_Module, TheLeavingReason_Page);
        }
         public static void EmploymentTypePage()
        {
            Open(PersonnalAffairs_Module, EmploymentType_Page);
        }
        public static void N2_EmploymentTypePage()
        {
            Open(PersonnalAffairs_Module, N2_EmploymentType_Page);
        }
        public static void SpecialNeedsPage()
        {
            Open(PersonnalAffairs_Module, SpecialNeeds_Page);
        }
        public static void ReasonsForFinancialDisclosurePage()
        {
            Open(PersonnalAffairs_Module, ReasonsForFinancialDisclosure_Page);
        }
        public static void JobTitlePage()
        {
            Open(PersonnalAffairs_Module, JobTitle_Page);
        }
        public static void SkillsPage()
        {
            Open(PersonnalAffairs_Module, Skills_Page);
        }
        public static void QualificationsPage()
        {
            Open(PersonnalAffairs_Module, Qualifications_Page);
        }
        public static void JobPage()
        {
            Open(PersonnalAffairs_Module, Job_Page);
        }
        public static void OrganizationUnitPage()
        {
            Open(PersonnalAffairs_Module, OrganizationUnit_Page);
        } 
        public static void WorkingYearPage()
        {
            Open(PersonnalAffairs_Module, WorkingYear_Page);
        } 
        public static void WorkSystemPage()
        {
            Open(PersonnalAffairs_Module, WorkSystem_Page);
        }
        public static void ProceduresTypesPage()
        {
            Open(PersonnalAffairs_Module, ProceduresTypes_Page);
        }
        public static void EmployeesProceduresPage()
        {
            Open(PersonnalAffairs_Module, EmployeesProcedures_Page);
        }

        /// /////////////////// # HR_MODULE_TWO_PAGES # /////////////////////////////////////////////
     
        public static void PermissionTypePage()
        {
            Open(Attendace_And_Departure_Module, PermissionType_Page);
        }
        public static void LeaveTypePage()
        {
            Open(Attendace_And_Departure_Module, LeaveType_Page);
        }
        public static void AnnualHolidaysPage()
        {
            Open(Attendace_And_Departure_Module, AnnualHolidays_Page);
        }

        public static void PermissionsPage()
        {
            Open(Attendace_And_Departure_Module, Permissions_Page);
        }
        public static void VacationsPage()
        {
            Open(Attendace_And_Departure_Module, Vacations_Page);
        } 
        public static void ErrandsPage()
        {
            Open(Attendace_And_Departure_Module, Errands_Page);
        }

        /// /////////////////// # HR_MODULE_THREE_PAGES # /////////////////////////////////////////////

        public static void AllowanceTypePage()
        {
            Open(Salaries_Module, AllowanceType_Page);
        }
        public static void PeriodicalDeductionTypePage()
        {
            Open(Salaries_Module, PeriodicalDeductionType_Page);
        }




        /// /////////////////// # ESTATE_MODULE # /////////////////////////////////////////////
        public static void PropertyTypePage()
        {
            Open(Estate_Module, PropertyType_Page);
        }
        public static void PropertyPage()
        {
            Open(Estate_Module, Property_page);
        }
        public static void SuspensionReasonPage()
        {
            Open(Estate_Module, SuspensionReason_Page);
        }
        public static void BanReasonPage()
        {
            Open(Estate_Module, BanResaon_Page);
        }
        /// /////////////////// # Contract_MODULE # /////////////////////////////////////////////
        public static void ContractTypePage()
        {
            Open(Contract_Module, ContractType_Page);
        }

    }
}