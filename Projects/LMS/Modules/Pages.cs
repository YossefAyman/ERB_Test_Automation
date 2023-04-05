
using Automation_Testing;
using OpenQA.Selenium;
using System;
using time = System.Threading.Thread;
//using System.Windows.Forms;

namespace LMS_Automation_Testing
{

    class Pages
    {
        private enum MENU_ITEMS
        {
            PROFILES = 3,
            GENERAL_SITTINGS = 5,
            EDUCATIONAL_INSTITUTION = 6,
            ReservationManagementS = 7,
            Course = 8,
            Payment = 9,
            StudentManagement = 11,
            OrganizationManagement = 12,
            Semester = 13,
        }

        private enum PROFILES_ITEMS
        {
            Students = 2,
        }

        private enum GENERAL_SITTING_ITEMS
        {
            COUNTRIES = 1, AREAS = 2, CITIES = 3, DISTRICTS = 4
        }

        private enum EDUCATIONAL_INSTITUTION_ITEMS
        {
            EDUCATIONAL_LEVELS = 1,
            CERTIFICATE = 2,
            Correction = 3,
            Discussion_Topic = 4,

        }





        static IWebDriver Driver = Automation_Testing.Common.Driver;

        static By Profiling_Module = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.PROFILES + ") > a");
        static By Students_Page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.PROFILES + ") > ul > li:nth-child(" + (int)PROFILES_ITEMS.Students + ") > a");


        static By GeneralSittings_Module = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.GENERAL_SITTINGS + ") > a");
        static By Countries_Page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.GENERAL_SITTINGS + ") > ul > li:nth-child(" + (int)GENERAL_SITTING_ITEMS.COUNTRIES + ") > a");
        static By Areas_Page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.GENERAL_SITTINGS + ") > ul > li:nth-child(" + (int)GENERAL_SITTING_ITEMS.AREAS + ") > a");
        static By Cities_Page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.GENERAL_SITTINGS + ") > ul > li:nth-child(" + (int)GENERAL_SITTING_ITEMS.CITIES + ") > a");
        static By Districts_Page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.GENERAL_SITTINGS + ") > ul > li:nth-child(" + (int)GENERAL_SITTING_ITEMS.DISTRICTS + ") > a");


        static By Educational_Institution_Module = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.EDUCATIONAL_INSTITUTION + ") > a");
        static By Educational_Levels_Page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.EDUCATIONAL_INSTITUTION + ") > ul > li:nth-child(" + (int)EDUCATIONAL_INSTITUTION_ITEMS.EDUCATIONAL_LEVELS + ") > a");

        static By Correction_Page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.EDUCATIONAL_INSTITUTION + ") > ul > li:nth-child(" + (int)EDUCATIONAL_INSTITUTION_ITEMS.Correction + ") > a");
        static By Certificate_Levels_Page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.EDUCATIONAL_INSTITUTION + ") > ul > li:nth-child(" + (int)EDUCATIONAL_INSTITUTION_ITEMS.CERTIFICATE + ") > a");
        static By DiscussionTopic_page = By.CssSelector("body > div.wrapper > aside > div > ul > li:nth-child(" + (int)MENU_ITEMS.EDUCATIONAL_INSTITUTION + ") > ul > li:nth-child(" + (int)EDUCATIONAL_INSTITUTION_ITEMS.Discussion_Topic + ") > a");
        public static void Open(By Module, By Page)
        {
            if (Driver.FindElement(Module).GetAttribute("class") != "open")
            {
                Driver.FindElement(Module).Click();
            }
            Driver.FindElement(Page).Click();
            time.Sleep(3000);
        }

        // الملفات التعريفية
        public static void StudentsPage()
        {
            Open(Profiling_Module, Students_Page);
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

        internal static void TeacherPage()
        {
            throw new NotImplementedException();
        }

        // النظام التعليمي
        public static void EducationalLevelsPage()
        {
            Open(Educational_Institution_Module, Educational_Levels_Page);
        }
        public static void CorrectionWayPage()
        {
            Open(Educational_Institution_Module, Correction_Page);
        }
        public static void CirtificatesLevelPage()
        {
            Open(Educational_Institution_Module, Certificate_Levels_Page);
        }
        public static void DiscussionTopic()
        {
            Open(Educational_Institution_Module, DiscussionTopic_page);
        }
    }
}
