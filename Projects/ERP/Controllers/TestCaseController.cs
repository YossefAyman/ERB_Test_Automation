using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP_Automation_Test.Models;
using ERP_Automation_Testing;

namespace ERP_Automation_Test.Controllers
{
    public class TestCaseController : Controller
    {
        public static int SelectedModuleID = 0;
        public static bool testStatus = false;

        public static string testPassedColor = "Green";
        public static string testNotPassedColor = "Red";

        public static string checked_TC_Color = "white";
        public static string checked_TC_BGColor = "#74b5e3";
        public static string unchecked_TC_Color = "black";
        public static string unchecked_TC_BGColor = "white";

        public static List<Module> modulesList = new List<Module>(){
            new Module(1,"Financial", new List<Page>()
            {
                 new Page(1,"CurrencyPage",M3_Financial_N1_Currency_Test.Test_Init,new List<TestCase>()
                {
                    new TestCase(1, "T1_AddCurrency",M3_Financial_N1_Currency_Test.T1_AddCurrency),                           
                    new TestCase(2, "T2_EditCurrency",M3_Financial_N1_Currency_Test.T2_EditCurrency),                           
                    new TestCase(3, "T3_DeleteCurrency",M3_Financial_N1_Currency_Test.T3_DeleteCurrency),                           
                    new TestCase(4, "T4_CurrencyHappyScenario",M3_Financial_N1_Currency_Test.T4_CurrencyHappyScenario),                                                          
                }       ),      

                 new Page(2,"TaxPage",M3_Financial_N2_Tax_Test.Test_Init,new List<TestCase>()
                {
                    new TestCase(1, "T1_AddTax",M3_Financial_N2_Tax_Test.T1_AddTax),                           
                    new TestCase(2, "T2_EditTax",M3_Financial_N2_Tax_Test.T2_EditTax),                           
                    new TestCase(3, "T3_DeleteTax",M3_Financial_N2_Tax_Test.T3_DeleteTax),                           
                    new TestCase(4, "T4_TaxHappyScenario",M3_Financial_N2_Tax_Test.T4_TaxHappyScenario),                                                          
                }       ),   

                new Page(3,"CostCenterPage",M3_Financial_N3_CostCenter_Test.Test_Init,new List<TestCase>()
                {
                    new TestCase(1, "T1_AddCostCenter",M3_Financial_N3_CostCenter_Test.T1_AddCostCenter),                           
                    new TestCase(2, "T2_EditCostCenter",M3_Financial_N3_CostCenter_Test.T2_EditCostCenter),                           
                    new TestCase(3, "T3_DeleteCostCenter",M3_Financial_N3_CostCenter_Test.T3_DeleteCostCenter),                           
                    new TestCase(4, "T4_CostCenterHappyScenario",M3_Financial_N3_CostCenter_Test.T4_CostCenterHappyScenario),                                                          
                }       ),  

                new Page(4,"BankPage",M3_Financial_N4_Bank_Test.Test_Init,new List<TestCase>()
                {
                    new TestCase(1, "T1_AddBank",M3_Financial_N4_Bank_Test.T1_AddBank),                           
                    new TestCase(2, "T2_EditBank",M3_Financial_N4_Bank_Test.T2_EditBank),                           
                    new TestCase(3, "T3_DeleteBank",M3_Financial_N4_Bank_Test.T3_DeleteBank),                           
                    new TestCase(4, "T4_Bank_HappyScenario",M3_Financial_N4_Bank_Test.T4_Bank_HappyScenario),                                                          
                }       ),                                                                 
               
            }

            ),

            new Module(2,"Inventories", new List<Page>()
            {
                 new Page(1,"BrandPage",M4_Inventories_N1_Brand_Test.TestInit,new List<TestCase>()
                {
                    new TestCase(1, "T1_AddBrand",M4_Inventories_N1_Brand_Test.T1_AddBrand),                           
                    new TestCase(2, "T2_EditBrand",M4_Inventories_N1_Brand_Test.T2_EditBrand),                           
                    new TestCase(3, "T3_DeleteBrand",M4_Inventories_N1_Brand_Test.T3_DeleteBrand),                           
                    new TestCase(4, "T4_BrandHappyScenario",M4_Inventories_N1_Brand_Test.T4_BrandHappyScenario),                                                          
                }       ),      

                 new Page(2,"StorePage",M4_Inventories_N2_Store_Test.TestInit,new List<TestCase>()
                {
                    new TestCase(1, "T1_AddStore",M4_Inventories_N2_Store_Test.T1_AddStore),                           
                    new TestCase(2, "T2_EditStore",M4_Inventories_N2_Store_Test.T2_EditStore),                           
                    new TestCase(3, "T3_DeleteStore",M4_Inventories_N2_Store_Test.T3_DeleteStore),                           
                    new TestCase(4, "T4_StoreHappyScenario",M4_Inventories_N2_Store_Test.T4_StoreHappyScenario),                                                          
                }       ),   

                new Page(3,"InventoyCategoryPage",M4_Inventories_N3_InventoryCategory_Test.TestInit,new List<TestCase>()
                {
                    new TestCase(1, "T1_AddInventoryCategory",M4_Inventories_N3_InventoryCategory_Test.T1_AddInventoryCategory),                           
                    new TestCase(2, "T2_EditInventoryCategory",M4_Inventories_N3_InventoryCategory_Test.T2_EditInventoryCategory),                           
                    new TestCase(3, "T3_DeleteInventoryCategory",M4_Inventories_N3_InventoryCategory_Test.T3_DeleteInventoryCategory),                           
                    new TestCase(4, "T4_InventoryCategoryHappyScenario",M4_Inventories_N3_InventoryCategory_Test.T4_InventoryCategoryHappyScenario),                                                          
                }       ),  

                new Page(4,"ItemTypePage",M4_Inventories_N4_ItemType_Test.Test_Init,new List<TestCase>()
                {
                    new TestCase(1, "T1_AddItemType",M4_Inventories_N4_ItemType_Test.T1_AddItemType),                           
                    new TestCase(2, "T2_EditItemType",M4_Inventories_N4_ItemType_Test.T2_EditItemType),                           
                    new TestCase(3, "T3_DeleteItemType",M4_Inventories_N4_ItemType_Test.T3_DeleteItemType),                           
                    new TestCase(4, "T4_ItemTypeHappyScenario",M4_Inventories_N4_ItemType_Test.T4_ItemTypeHappyScenario),                                                          
                }       ),                                                                 
               
            }

            ),

        };

       
        //
        // GET: /TestCase/
        public ActionResult Index(string Module = "0")
        {
            SelectedModuleID = Int32.Parse(Module);
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "--Select Module--", Value = "0", Selected = true });

            foreach( var module in modulesList)
            {
                if (module.id == SelectedModuleID)
                {
                    items.Add(new SelectListItem { Text = module.name, Value = module.id.ToString() , Selected = true });
                }
                else
                {
                    items.Add(new SelectListItem { Text = module.name, Value = module.id.ToString() });
                }

            }
         
            ViewBag.Module = items;

            if (SelectedModuleID == 0)
            {
                return View(modulesList);
            }
            else
            {
                 //Find a module by its ID.
                Module selectedModule = modulesList.Find(

                delegate(Module _module)
                {
                    return _module.id == SelectedModuleID;
                }
                );

                List<Module> SelectedModules = new List<Module>();
                SelectedModules.Add(selectedModule);

                return View(SelectedModules) ;
            }
        }
        public ActionResult Check(int module_id, int page_id ,int TC_id)
        {
             //Find a module by its ID.
            Module module = modulesList.Find(

            delegate(Module _module)
            {
                return _module.id == module_id;
            }
            ); 
            
            //Find a page by its ID.
            Page page = module.pages.Find(

            delegate(Page _page)
            {
                return _page.id == page_id;
            }
            );

             //Find a testCase by its ID.
            TestCase testCase = page.testcases.Find(

            delegate(TestCase _testCase)
            {
                return _testCase.id == TC_id;
            }
            );
            testCase.selected = true ;
            testCase.color = checked_TC_Color;
            testCase.BGcolor = checked_TC_BGColor;

            return RedirectToAction("Index");
        }
        public ActionResult CheckAndUncheck(int module_id, int page_id, int TC_id)
        {

            //Find a module by its ID.
            Module module = modulesList.Find(

            delegate(Module _module)
            {
                return _module.id == module_id;
            }
            );

            //Find a page by its ID.
            Page page = module.pages.Find(

            delegate(Page _page)
            {
                return _page.id == page_id;
            }
            );

            //Find a testCase by its ID.
            TestCase testCase = page.testcases.Find(

            delegate(TestCase _testCase)
            {
                return _testCase.id == TC_id;
            }
            );
            if (testCase.selected == true)
            {
                testCase.selected = false;
                testCase.color = unchecked_TC_Color;
                testCase.BGcolor = unchecked_TC_BGColor;
            }
            else
            {
                testCase.selected = true;
                testCase.color = checked_TC_Color;
                testCase.BGcolor = checked_TC_BGColor;
            }
            

            return RedirectToAction("Index");
        }
        public ActionResult RunTestCases()
        {
            Data.testingOnWebsite = true;

            foreach (var module in modulesList)
            {
                foreach (var page in module.pages)
                {
                    foreach (var testCase in page.testcases)
                    {
                        if (testCase.selected == true)
                        {
                            page.PageTestInit();
                            testCase.invokedFunction();

                            testCase.passed = Data.TestPassed;
                            if( testCase.passed == true)
                            {
                                testCase.BGcolor = testPassedColor;                                
                            }
                            else
                            {
                                testCase.BGcolor = testNotPassedColor;                                
                            }

                            Data.TestPassed = true;
                        }
                    }
                }
            }


            Login_Page.CloseDriver();

            return RedirectToAction("Index");

        }

        public ActionResult SelectAll(int module_id, int page_id)
        {
             //Find a module by its ID.
            Module module = modulesList.Find(

            delegate(Module _module)
            {
                return _module.id == module_id;
            }
            );

            //Find a page by its ID.
            Page page = module.pages.Find(

            delegate(Page _page)
            {
                return _page.id == page_id;
            }
            );

            
            foreach(var testCase in page.testcases )
            {
                testCase.selected = true;
                testCase.color = checked_TC_Color;
                testCase.BGcolor = checked_TC_BGColor;

            }
            return RedirectToAction("Index");
        }

        public ActionResult UnSelectAll(int module_id, int page_id)
        {
            //Find a module by its ID.
            Module module = modulesList.Find(

            delegate(Module _module)
            {
                return _module.id == module_id;
            }
            );

            //Find a page by its ID.
            Page page = module.pages.Find(

            delegate(Page _page)
            {
                return _page.id == page_id;
            }
            );


            foreach (var testCase in page.testcases)
            {
                testCase.selected = false;
                testCase.color = unchecked_TC_Color;
                testCase.BGcolor = unchecked_TC_BGColor;

            }
            return RedirectToAction("Index");
        }

        public ActionResult SelectedModule(string Modules)
        {

            SelectedModuleID = Int32.Parse(Modules);
           

            return RedirectToAction("Index");

        }
	}
}