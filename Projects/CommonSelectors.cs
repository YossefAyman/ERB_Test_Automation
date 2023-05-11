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
using Keys = OpenQA.Selenium.Keys;

namespace Automation_Testing
{
    public class CommonSelectors
    {       
        protected static By Add_Button =                                    By.ClassName("btnAddItem");
        protected static By Save_Button =                                   By.ClassName("  ");
        protected static By Search_TextBox =                                By.XPath("//*[@placeholder=\"بحث\"]");
        protected static By Search_Button =                                 By.ClassName("btn-light");
        protected static By FirstItemEdit_Button =                          By.ClassName("btnEditItem");
        protected static By FirstItemDelete_Button =                        By.ClassName("btnDeleteItem");
        protected static By DeleteConfirm_Button =                          By.ClassName("confirm");
        protected static By MultiSelect_Button =                            By.ClassName("ui-grid-selection-row-header-buttons");
        protected static By NumOfItems_Text =                               By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");
        protected static By ActivateSelect_Button =                         By.ClassName("btnActivateSelected");
        protected static By Disactivate_Button =                            By.ClassName("btnDeavtivateSelected");
        protected static By Deleteactivate_Button =                         By.ClassName("btnDeleteSelected");
        protected static By Confirmdeleteactivate_Button =                  By.ClassName("confirm");
        protected static By cancildeleteactivate_Button =                   By.ClassName("cancel");
        protected static By FirstItemActivate_Button =                      By.ClassName("fa-check-circle");
        protected static By FirstItemDeActivate_Button =                    By.ClassName("fa-times-circle");
        protected static By FirstItemLocalzation_Button =                   By.ClassName("actoionsButtonColoredTranslator");
        protected static By AddLocalization_Button =                        By.ClassName("btnAddItem");
        protected static By Grid_Row =                                      By.ClassName("ui-grid-row");
        protected static By Totalammount =                                  By.CssSelector("#accountBalanceController > div:nth-child(2) > section > div > div > div.main-box-content > div > div > div:nth-child(7) > div:nth-child(5) > table > tbody > tr:nth-child(55) > td:nth-child(4)");

    }
}


