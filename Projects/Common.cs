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
using OpenQA.Selenium.Interactions;

namespace Automation_Testing
{
    public class Common : CommonSelectors
    {
        public static IWebDriver Driver = new ChromeDriver(@"C:\");
        public static Actions Actions = new Actions(Driver);
        

        public static bool testingOnWebsite = false;

        public enum SEARCH_Result
        {
            EXIST = 1,
            NOT_EXIST = 2,
            REPEATED = 3,
        }
        public static bool IsElementPresent(By by)
        {
            try
            {
                Driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public static void Shortcut(String ShortKeys)
        {

            Driver.FindElement(By.TagName("Html")).SendKeys(ShortKeys);

        }
        public static void ScrollDown(int numOfClicks)
        {
            for (int i = 0; i < numOfClicks; i++)
            {
                Driver.FindElement(By.TagName("Html")).SendKeys(Keys.ArrowDown);

            }

        }

        public static void Add_Attachment()
        {
            SendKeys.SendWait("F:\\222");
            time.Sleep(2000);
            SendKeys.SendWait("{Enter}");

            //SendKeys.SendWait(@"~\TestNeeds\BonianTech.png");
            //time.Sleep(1000);
            SendKeys.SendWait("{Enter}");
        }

        public static bool check(bool condition, string failmsg)
        {
            if (condition == false)
            {
                if (testingOnWebsite == false)
                {
                    Assert.IsTrue(false, failmsg);
                    return false;
                }
                else
                {
                    // TestCases.BankTestCheckbox.BackColor = System.Drawing.Color.FromName("Green");
                    global::System.Windows.Forms.MessageBox.Show(failmsg);
                    return false;
                }

            }
            else
            {
                return true;
            }
        }

        public static void Add(string itemName, By nameTextBox)
        {
            time.Sleep(1000);
            Driver.FindElement(Add_Button).Click();
            time.Sleep(1000);
            Driver.FindElement(nameTextBox).SendKeys(itemName);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(3000);
        }

        public static void Edit(string Correction, string newName, By nameTextBox)
        {
            Search(Correction);
            time.Sleep(3000);
            Driver.FindElement(FirstItemEdit_Button).Click();
            time.Sleep(3000);
            Driver.FindElement(nameTextBox).Clear();
            Driver.FindElement(nameTextBox).SendKeys(newName);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(3000);


        }


        public static void Delete(string itemName)
        {

            if (Search(itemName) == SEARCH_Result.EXIST)
            {
                time.Sleep(1000);
                Driver.FindElement(FirstItemDelete_Button).Click();
                time.Sleep(3000);
                Driver.FindElement(DeleteConfirm_Button).Click();
                time.Sleep(3000);
            }
            else
            {

            }

        }
        public static void MultiSelect()
        {
            Driver.FindElement(MultiSelect_Button).Click();
            time.Sleep(3000);

        }
        public static void ActivateSelected()
        {
            Driver.FindElement(ActivateSelect_Button).Click();
            time.Sleep(3000);

        }
        public static void DisactivateSelected()
        {
            Driver.FindElement(Disactivate_Button).Click();
            time.Sleep(3000);

        }
        public static void DeleteSelected()

        {
            Driver.FindElement(Deleteactivate_Button).Click();
            time.Sleep(3000);
            Driver.FindElement(Confirmdeleteactivate_Button).Click();
            time.Sleep(3000);

        }
        public static void ConfirmSweetAlert()
        {
            Driver.FindElement(Confirmdeleteactivate_Button).Click();
            time.Sleep(3000);

        }
        public static void CancelSweetAlert()
        {
            Driver.FindElement(cancildeleteactivate_Button).Click();
            time.Sleep(3000);

        }
        public static void FirstItemActivate()
        {
            Driver.FindElement(FirstItemActivate_Button).Click();
            time.Sleep(3000);

        }
        public static void FirstItemDeActivate()
        {
            Driver.FindElement(FirstItemDeActivate_Button).Click();
            time.Sleep(3000);

        }
        public static void AddLocalization()
        {
            Driver.FindElement(FirstItemLocalzation_Button).Click();
            time.Sleep(3000);
            Driver.FindElement(AddLocalization_Button).Click();

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
        public static int ReadCountText()
        {
            string countString = Driver.FindElement(NumOfItems_Text).Text;
            string[] countArray = countString.Split(' ');
            int count = 0;
            int.TryParse(countArray[4], out count);
            if (Driver.FindElement(NumOfItems_Text).GetAttribute("class") == "ng-binding ng-hide")
            {
                return 0;
            }
            else
            {
                return count;
            }
        }

        public static void ClearThenWrite(By textBox, string text)
        {
            try
            {
                Driver.FindElement(textBox).Clear();
                Driver.FindElement(textBox).SendKeys(text);
            }
            catch (Exception ex)
            {
                Assert.Warn("Message : \n" + ex.Message + "\nStack Trace : \n" + ex.StackTrace);
                Common.Driver.Close();

            }
        }
        public static void Write(By textBox, string text)
        {
            try
            {
                Driver.FindElement(textBox).SendKeys(text);
            }
            catch (Exception ex)
            {
                Assert.Warn("Message : \n" + ex.Message + "\nStack Trace : \n" + ex.StackTrace);
                Common.Driver.Close();

            }
        }
        public static void Doubleclick()
        {
        }
        public static void WriteEnter(IWebElement textBoxElement)
        {
            try
            {
                textBoxElement.SendKeys(Keys.Enter);
            }
            catch (Exception ex)
            {
                Assert.Warn("Message : \n" + ex.Message + "\nStack Trace : \n" + ex.StackTrace);
            }
        }
        public static void Click(IWebElement element)
        {
            try
            {
                element.Click();
            }
            catch (Exception ex)
            {
                Assert.Warn("Message : \n" + ex.Message + "\nStack Trace : \n" + ex.StackTrace);
            }
        }
        public static void getTotalAccount()
        {
            try
            {
                string countstring = Driver.FindElement(Totalammount).Text;
                double num;
                double.TryParse(countstring, out num);

            }
            catch (Exception ex)
            {
                Assert.Warn("Message : \n" + ex.Message + "\nStack Trace : \n" + ex.StackTrace);
            }


           
            




            
        }

        



           }

      }
       
   