using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ERP_Automation_Test.Models
{
    public class TestCase
    {
        public int id { get; set; }

        [Display(Name="Test Case")]
        public string name { get; set; }

        public bool selected { get; set; }
        public string color { get; set; }
        public string BGcolor { get; set; }

        public bool passed { get; set; }

        public delegate void TC_delegate() ;
        public TC_delegate invokedFunction = null;

        public TestCase(int TestCaseID, string TestCaseName, TC_delegate TestCaseInvokedFunction = null)
        {
            id = TestCaseID;
            name = TestCaseName;
            selected = false;
            color = "black";
            BGcolor = "white";
            passed = false;
            invokedFunction = TestCaseInvokedFunction;
        }
    }

    public class Page
    {
        public int id { get; set; }

        [Display(Name="Page")]
        public string name { get; set; }

        public List<TestCase> testcases = new List<TestCase>();

        public delegate void Test_Init_delegate();
        public Test_Init_delegate PageTestInit = null;

        public Page(int PageID, string PageName, Test_Init_delegate TestInitInvokedFunction, List<TestCase> PageTestCases)
        {
            id = PageID;
            name = PageName;
            PageTestInit = TestInitInvokedFunction;
            testcases = PageTestCases;
            
        }

    }

    public class Module
    {
        public int id { get; set; }

        [Display(Name = "Page")]
        public string name { get; set; }

        public List<Page> pages = new List<Page>();

        public Module(int ModuleID, string ModuleName, List<Page> ModulePages)
        {
            id = ModuleID;
            name = ModuleName;
            pages = ModulePages;

        }

    }
}