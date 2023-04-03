using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation_Testing;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace LMS_Automation_Testing
{
    class Login_Page 
    {
        static IWebDriver Driver = Automation_Testing.Common.Driver;

        // Selectors
        static By UserName_TextBox = By.Id("Username");
        static By Password_TextBox = By.Id("Password");
        static By Login_Button = By.ClassName("btn-primary");
        static By GO_LoginPage_Button = By.CssSelector("#navbarSupportedContent > ul.navbar-nav.right-side.flex-wrap.flex-sm-no-rwap.align-items-center.mx-auto > li:nth-child(1) > a");

        public static void LoginAsAdmin()
        {          
            Driver = Automation_Testing.Common.Driver;
            Driver.Manage().Window.Maximize();            
            Driver.Url = Data.LMS_URL;
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Driver.FindElement(GO_LoginPage_Button).Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

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
            Driver.Url = Data.LMS_URL;
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Driver.FindElement(UserName_TextBox).SendKeys(user);
            Driver.FindElement(Password_TextBox).SendKeys(pwd);
            Driver.FindElement(Login_Button).Click();
            //side_toggle = driver.find_element_by_css_selector("body > div > main > header > nav > div.side-toggle > i")
            //side_toggle.click()
        }
    }

   

    
}
