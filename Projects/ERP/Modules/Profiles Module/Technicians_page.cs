using Automation_Testing;
using ERP_Automation_Testing;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using time = System.Threading.Thread;

namespace ERP_Automation_Testing
{
    class Technicians_page : CommonSelectors
    {
        static IWebDriver Driver = Automation_Testing.Common.Driver;

        // Selectors
        static By Add_Button = By.ClassName("btnAddItem");
        static By TechniciansName_TextBox = By.Id("Profile_ProfileName");
        static By TechniciansEmail_TextBox = By.Id("Profile_Email");
        static By TechniciansPhone_TextBox = By.Id("Supplier_Phone");
        static By TechniciansMobile_TextBox = By.Id("Supplier_Mobile");
        static By TechniciansAddress_TextBox = By.Id("Profile_Address");
        static By UISelect_DDL = By.ClassName("ui-select-container");
        static By UISelectSearch_TextBox = By.ClassName("ui-select-search");
        static By Description_TextBox = By.Id("Profile_Description");
        static By updateuserinfo_button = By.ClassName("btn-info");
        static By Description_TextBox1 = By.Id("Profile_Description1");

        internal static string Search(string name)
        {
            throw new NotImplementedException();
        }

        static By username_TextBox = By.Id("UserViewModel_User_Username");
        static By password_TextBox = By.Id("UserViewModel_User_Password");
        static By confirmpassword_Textbox = By.Id("UserViewModel_User_ConfirmPassword");
        static By mopilenumber_Textbox = By.Id("Technicians_Mobile");

        internal static void Edit_Technicians_(object discussionTobicName, object p)
        {
            throw new NotImplementedException();
        }

        internal static Common.SEARCH_Result Search(object p)
        {
            throw new NotImplementedException();
        }

        static By personalidentificationnumber_Textbox = By.Id("Technicians_PersonalIdentificationNumber");
        static By ReleaseDate = By.Id("DateControlundefinedpicker94");
        static By salary_Textbox = By.Id("Technicians_Salary");
        static By Reasonofending = By.Id("Technicians_ReasonOfEnding");
        static By save_button = By.ClassName("btn btn-primary");
        static By Delete_button = By.ClassName("btnDeleteItem ");
        static By AddAttachment_Button = By.CssSelector("#AttachmentFormManager > div:nth-child(3) > div:nth-child(1) > div > div.drop-box.w-100.ng-pristine.ng-untouched.ng-valid.ng-empty > i");
        static By Save_Button = By.CssSelector("#mainModal > div > div > div.modal-body > div.modal-footer > input");
        // static By Search_TextBox = By.ClassName("ng-valid");
        static By Search_TextBox = By.XPath("//*[@placeholder=\"بحث\"]");
        static By Search_Button = By.ClassName("btn-light");
        static By FirstItemEdit_Button = By.ClassName("btnEditItem");
        static By FirstItemDelete_Button = By.ClassName("btnDeleteItem");
        static By DeleteConfirm_Button = By.ClassName("confirm");
        static By NumOfItems_Text = By.XPath("//*[@id=\"grid\"]/div[2]/div[2]/div/span");
        static By save_button2 = By.ClassName("btn btn-primary");

        public static void Goto()
        {
            Pages.TechniciansPage();
            time.Sleep(2000);
        }

        public static void Add_Technicians(int numOfRepeats = 0)
        {
            try
            {
                for (int i = 0; i <= numOfRepeats; i++)
                {
                    Driver.FindElement(Add_Button).Click();
                    time.Sleep(3000);
                    Driver.FindElement(TechniciansName_TextBox).SendKeys(Data.Technicians.Name+i);
                    Driver.FindElement(TechniciansEmail_TextBox).SendKeys(Data.Technicians.Email+i+ Data.gmail);
                    Driver.FindElement(TechniciansAddress_TextBox).SendKeys(Data.Technicians.Address+i);


                    if (Automation_Testing.Common.IsElementPresent(Description_TextBox1))
                    {
                        Driver.FindElement(Description_TextBox1).SendKeys(Data.Technicians.Description);
                    }

                    if (Automation_Testing.Common.IsElementPresent(Description_TextBox))
                    {
                        Driver.FindElement(Description_TextBox).SendKeys(Data.Technicians.Description);
                    }
                    Driver.FindElement(updateuserinfo_button).Click();
                    Driver.FindElement(username_TextBox).SendKeys(Data.Technicians.username + i);
                    Driver.FindElement(password_TextBox).SendKeys(Data.Technicians.password);
                    Driver.FindElement(confirmpassword_Textbox).SendKeys(Data.Technicians.password);


                    Driver.FindElements(UISelect_DDL)[1].Click();
                    Driver.FindElements(UISelectSearch_TextBox)[1].SendKeys(Data.Technicians.specialist + Keys.Enter);
                    Driver.FindElements(UISelect_DDL)[2].Click();
                    Driver.FindElements(UISelectSearch_TextBox)[2].SendKeys(Data.Technicians.Degree + Keys.Enter);
                    Driver.FindElement(mopilenumber_Textbox).SendKeys(Data.Technicians.mobilnumber);

                    Driver.FindElements(UISelect_DDL)[3].Click();
                    Driver.FindElements(UISelectSearch_TextBox)[3].SendKeys(Data.Technicians.kind + Keys.Enter);
                    Driver.FindElements(UISelect_DDL)[4].Click();
                    Driver.FindElements(UISelectSearch_TextBox)[4].SendKeys(Data.Technicians.Nationality + Keys.Enter);
                    Driver.FindElements(UISelect_DDL)[5].Click();
                    Driver.FindElements(UISelectSearch_TextBox)[5].SendKeys(Data.Technicians.Identity + Keys.Enter);
                    Driver.FindElements(UISelect_DDL)[6].Click();
                    Driver.FindElements(UISelectSearch_TextBox)[6].SendKeys(Data.Technicians.status + Keys.Enter);
                    Driver.FindElement(personalidentificationnumber_Textbox).SendKeys(Data.Technicians.perseonalidentificationnumber);
                    Driver.FindElement(salary_Textbox).SendKeys(Data.Technicians.salary);
                    Driver.FindElement(Reasonofending).SendKeys(Data.Technicians.Reasonofending);
                    Driver.FindElement(Save_Button).Click();
                    time.Sleep(3000);

                    //Driver.FindElement(AddAttachment_Button).Click();
                    //time.Sleep(2000);
                    //Data.Add_Attachment();
                    //time.Sleep(2000);
                    //Driver.FindElement(Save_Button).Click();
                    //time.Sleep(3000);
                }

            }
            catch (NoSuchElementException ex)
            {
                Assert.IsTrue(false, ex.Message);
            }
        }

        //#############################################################################################   
        public static void Edit_Technicians(string TechnicianName, string newName)
        {
            Common.Search(TechnicianName);
            Driver.FindElement(FirstItemEdit_Button).Click();
            time.Sleep(1000);
            Driver.FindElement(TechniciansName_TextBox).Clear();
            Driver.FindElement(TechniciansName_TextBox).SendKeys(newName);
            Driver.FindElement(Save_Button).Click();
            time.Sleep(2000);
        }

        //##############################################################################################        
        public static void Delete_Technicians(string Technicians)
        {
            //Search(Technicians);
            //Driver.FindElement(Delete_button).Click();
            //time.Sleep(2000);
            //Driver.FindElement(DeleteConfirm_Button).Click();
            //time.Sleep(1000);
            Common.Delete(Technicians);

        }
        public static void MultiSelect_Technicians()

        {
            Common.MultiSelect();

        }
        public static void ActivateSelected_Technicians()
        {
            Common.ActivateSelected();


        }
        public static void DisactivateSelected_Technicians()
        {
            Common.DisactivateSelected();
        }
        public static void DeleteSelected_Technicians()
        {
            Common.DeleteSelected();
        }
    }
}


