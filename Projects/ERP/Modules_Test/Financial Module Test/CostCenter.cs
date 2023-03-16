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
    [TestFixture]

    public class M3_Financial_N3_CostCenter_Test
    {

        [SetUp]
        public static void Test_Init()
        {
            Login_Page.LoginAsAdmin();
            CostCenter_Page.Goto();
        }

        [Test]

        public static void T1_AddCostCenter()
        {
            CostCenter_Page.Add_CostCenter();
            Assert.IsTrue(CostCenter_Page.Search(Data.CostCenter) == "Exist", "T1_AddCostCenter Failed");
        }

        [Test]
        public static void T2_EditCostCenter()
        {
            CostCenter_Page.Edit_CostCenter(Data.CostCenter, Data.CostCenter + "_edit");
            Assert.IsTrue(CostCenter_Page.Search(Data.CostCenter + "_edit") == "Exist", "T2_EditCostCenter Failed");

        }

        [Test]
        public static void T3_DeleteCostCenter()
        {
            CostCenter_Page.Delete_CostCenter(Data.CostCenter + "_edit");
            Assert.IsTrue(CostCenter_Page.Search(Data.CostCenter + "_edit") != "Exist", "T3_DeleteCostCenter Failed");
        }

        [Test]
        public static void T4_CostCenterHappyScenario()
        {

            CostCenter_Page.Add_CostCenter();
            if (Data.check(CostCenter_Page.Search(Data.CostCenter) == "Exist", "T1_Add_CostCenter Failed"))
            {
                CostCenter_Page.Edit_CostCenter(Data.CostCenter, Data.CostCenter + "_edit");

                if (Data.check(CostCenter_Page.Search(Data.CostCenter + "_edit") == "Exist", "T2_EditCostCenter Failed"))
                {
                    CostCenter_Page.Delete_CostCenter(Data.CostCenter + "_edit");

                    Data.check(CostCenter_Page.Search(Data.CostCenter + "_edit") == "NotExist", "T3_DeleteCostCenter Failed");


                }

            }    

        }

    
    }
}
