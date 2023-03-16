using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ERP_Automation_Testing
{
    class Login_Page 
    {
        static IWebDriver Driver = Automation_Testing.Common.Driver;

        // Selectors
        static By UserName_TextBox = By.CssSelector("#Username");
        static By Password_TextBox = By.CssSelector("#Password");
        static By Login_Button = By.CssSelector("button");

        public static void LoginAsAdmin()
        {
            Driver = Automation_Testing.Common.Driver;
            Driver.Manage().Window.Maximize();            
            Driver.Url = Data.ERP_URL;
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Driver.FindElement(UserName_TextBox).SendKeys(Data.user);
            Driver.FindElement(Password_TextBox).SendKeys(Data.pwd);
            Driver.FindElement(Login_Button).Click();
            //side_toggle = driver.find_element_by_css_selector("body > div > main > header > nav > div.side-toggle > i")
            //side_toggle.click()
        }

         public static void CloseDriver()
        {
            Driver.Close();

        }
        public static void LoginAs(string user, string pwd)
        {
            Driver.Url = Data.ERP_URL;
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Driver.FindElement(UserName_TextBox).SendKeys(user);
            Driver.FindElement(Password_TextBox).SendKeys(pwd);
            Driver.FindElement(Login_Button).Click();
            //side_toggle = driver.find_element_by_css_selector("body > div > main > header > nav > div.side-toggle > i")
            //side_toggle.click()
        }
    }

   

    
}

