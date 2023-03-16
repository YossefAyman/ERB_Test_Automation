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
//using System.Windows.Forms;

namespace ERP_Automation_Testing
{
    public class M1_Profiles_N3_Owner_Test
    {
        [SetUp]
        public static void Test_Init()
        {
            Automation_Testing.Common.Driver.Manage().Window.Maximize();
            Login_Page.LoginAsAdmin();
            Owner_Page.Goto();
        }

        [Test]
        public void T1_AddOwner()
        {
            Owner_Page.add_owner();
        }
        [Test]
        public void T2_EditOwner()
        {
            Owner_Page.edit_Teacher(Data.Owner.Name, Data.Owner.Name + "_edit");
        }
        [Test]
        public void T3_DeleteOwner()
        {
            Owner_Page.delete_owner( Data.Owner.Name + "_edit");
        }
        [Test]
        public void T4_Owner_HappyScenario()
        {
            Owner_Page.add_owner();
            Owner_Page.edit_Teacher( Data.Owner.Name, Data.Owner.Name + "_edit");
            Owner_Page.delete_owner( Data.Owner.Name + "_edit");
        }
        [Test]
        public void T5_Owner_ShortKeys()
        {
            Owner_Page.ShortKeys_Scenrio( "Edit Owner");

        }
    }

}
