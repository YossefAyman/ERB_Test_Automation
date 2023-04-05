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
    public class Discussion_Topic_page
    {
        static IWebDriver Driver = Automation_Testing.Common.Driver;

        // Selectors
        static By Add_Button = By.ClassName("btnAddItem");
        static By Discussion_Topic_Textbox = By.Id("DiscussionTopic_DiscussionTopicName");
        static By Save_Button = By.CssSelector("#mainModal > div > div > div.modal-body > div.modal-footer > input");
        //static By Search_TextBox = By.ClassName("ng-valid");
        static By Search_TextBox = By.XPath("//*[@placeholder=\"بحث\"]");
        static By Search_Button = By.ClassName("btn-light");
        static By FirstItemEdit_Button = By.ClassName("btnEditItem");
        static By FirstItemDelete_Button = By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button = By.ClassName("confirm");
        static By NumOfItems_Text = By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");

        public static void Goto()
        {
            Pages.DiscussionTopic();
        }
        public static void Add_DiscussionTopic()
        {
            time.Sleep(1000);
            Driver.FindElement(Add_Button).Click();
            time.Sleep(1000);
            Driver.FindElement(Discussion_Topic_Textbox).SendKeys(Data.DiscussionTopic.DiscussionTobicName);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(3000);
        }

        public static void Edit_DiscussionTopic_(string DiscussionTopic, string newName)
        {
            Search(DiscussionTopic);
            time.Sleep(3000);
            Driver.FindElement(FirstItemEdit_Button).Click();
            time.Sleep(3000);
            Driver.FindElement(Discussion_Topic_Textbox).Clear();
            Driver.FindElement(Discussion_Topic_Textbox).SendKeys(newName);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(3000);


        }


        public static void Delete_DiscussionTopic(string DiscussionTopic)
        {
            Search(DiscussionTopic);
            time.Sleep(1000);
            Driver.FindElement(FirstItemDelete_Button).Click();
            time.Sleep(3000);
            Driver.FindElement(DeleteConfirm_Button).Click();
            time.Sleep(3000);
        }

        public static Common.SEARCH_Result Search(string item)
        {
            Driver.FindElement(Search_TextBox).Clear();
            Driver.FindElement(Search_TextBox).SendKeys(item);
            Driver.FindElement(Search_Button).Click();
            time.Sleep(1000);

            if (Driver.FindElement(NumOfItems_Text).Text == "1 - 1 من 1")
            {
                return Common.SEARCH_Result.EXIST;
            }
            else if (Driver.FindElement(NumOfItems_Text).GetAttribute("class") == "ng-binding ng-hide")
            {
                return Common.SEARCH_Result.NOT_EXIST;
            }
            else
            {
                return Common.SEARCH_Result.REPEATED;
            }
        }

    }
}
    
