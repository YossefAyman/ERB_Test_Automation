using Automation_Testing;
using LMS_Automation_Testing;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using time = System.Threading.Thread;
namespace LMS_Automation_Testing
{
    public class CorrectionWay_page
    {
        static IWebDriver Driver = Automation_Testing.Common.Driver;
        static By CorrectionWay_Textbox = By.Id("CorrectionWay_CorrectionWayName");


        public static void Goto()
        {
            Pages.CorrectionWayPage();
        }
        public static void Add_CorrectionWay(string itemName)
        {
            Common.Add(itemName, CorrectionWay_Textbox);          
        }

        public static void Edit_CorrectionWay(string CorrectionWay, string newName)
        {
            Common.Edit(CorrectionWay, newName, CorrectionWay_Textbox);
        }

        public static void Delete_CorrectionWay(string CorrectionWay)
        {
            Common.Delete(CorrectionWay);
        }  
        public static void MultiSelect_CorrectionWay()
        {
            Common.MultiSelect();
        }
        public static void ActivateSelected_CorrectionWay()
        {
            Common.ActivateSelected();

        }
        public static void DisactivateSelected_CorrectionWay()
        {
            Common.DisactivateSelected();
        }
        public static void DeleteSelected_CorrectionWay()
        {
            Common.DeleteSelected();

        }
        public static void ConfirmSweetAlert_CorrectionWay()
        {
            Common.ConfirmSweetAlert();

        } 
        public static void CancelSweetAlert_CorrectionWay()
        {
            Common.CancelSweetAlert();

        }
        public static void FirstItemActivate_CorrectionWay()
        {
            Common.FirstItemActivate();
        } 
        public static void FirstItemDeActivate_CorrectionWay()
        {
            Common.FirstItemDeActivate();
        }
        public static void Localization_CorrectionWay()
        {
            Common.AddLocalization();
        }
        public static Common.SEARCH_Result Search(string item)
        {
            return Common.Search(item);

        }

    }
}