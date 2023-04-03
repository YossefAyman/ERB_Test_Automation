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
using System.Windows.Forms;
using System.IO;
using OpenQA.Selenium.Firefox;

namespace LMS_Automation_Testing
{
    public class Data  
    {
        //public static IWebDriver Driver = new ChromeDriver(@"F:\WebSites\Test\ERPAutomation\TestNeeds\");
        public static string LMS_URL = "https://test.boniantech.com/lms/";
        // admin 
        public static string user = "admin";
        public static string pwd = "9999";

        // fin1
        //public static string user = "fin1";
        //// fin2
        //public static string user = "fin2";
        //// inv1
        //public static string user = "inv1";
        //// inv2
        //public static string user = "inv2";

        //public static string pwd = "1234";
        public static bool TestPassed = true;
        public static string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" ,"K","L","M","N","O","P","Q","I","S"};
        public const int TEST_INDEX = 17;
        public static string Date = DateTime.Today.ToShortDateString().Replace("/", "-");


        public struct Place
        {
            public static string CountryName = "Country_" + TEST_INDEX;
            public static string Nationality = "Nationality_" + TEST_INDEX;
            public static string AreaName = "AreaName_" + TEST_INDEX;
            public static string CityName = "CityName_" + TEST_INDEX;
            public static string DistrictName = "DistrictName_" + TEST_INDEX;
        }
        // الملفات التعريفية
        public struct Student
        {
            public static string Name = "Customer_" + Data.TEST_INDEX;
            public static string Email = "Customer_" + Data.TEST_INDEX + "@gmail.com";
            public static string Number = Data.TEST_INDEX.ToString();
            public static string ID_Type = "بطاقة شخصية";
            public static string ID_Number = "12345123451234";
            public static string Phone = "234234234";
            public static string Mobile = "01112345678";
            public static string Address = Data.TEST_INDEX + " Abbas El-Aqqad ST";
            public static string Country = Data.Place.CountryName;
            public static string Area = Data.Place.AreaName;
            public static string City = Data.Place.CityName;
            public static string District = Data.Place.DistrictName;
            public static string Nationality = Data.Place.Nationality;
            
        }
        
        public struct Teacher
        {
            public static string Name = "Customer_" + Data.TEST_INDEX;
            public static string Email = "Customer_" + Data.TEST_INDEX + "@gmail.com";
            public static string Number = Data.TEST_INDEX.ToString();
            public static string ID_Type = "بطاقة شخصية";
            public static string ID_Number = "12345123451234";
            public static string Phone = "234234234";
            public static string Mobile = "01112345678";
            public static string Address = Data.TEST_INDEX + " Abbas El-Aqqad ST";
            public static string Country = Data.Place.CountryName;
            public static string Area = Data.Place.AreaName;
            public static string City = Data.Place.CityName;
            public static string District = Data.Place.DistrictName;
            public static string Nationality = Data.Place.Nationality;
            
        }

       

        public struct EducationalLevel
        {
            public static string EducationalLevelName = "EducationalLevel_" + TEST_INDEX;
           
        }

        public struct Certificate
        {
            public static string CertificateName = "Certificate" + TEST_INDEX;

        }


        public struct CorrectionWay
        {
            public static string  CorrectionWayName = "CorrectionWay" + TEST_INDEX;

        }

        public struct DiscussionTopic
        {
            public static string DiscussionTobicName = " DiscussionTobic" + TEST_INDEX;
        }

        internal static void Shortcut(string v)
        {
            throw new NotImplementedException();
        }

        internal static void Add_Attachment()
        {
            throw new NotImplementedException();
        }
    }
}
       

