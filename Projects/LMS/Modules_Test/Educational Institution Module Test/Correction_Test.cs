using Automation_Testing;
using LMS_Automation_Testing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS_Automation_Testing
{
    [TestFixture]

    public class M3_Educational_Institution_N3_Correctionway_Test
    {
        [SetUp]
        public static void Test_Init()
        {
            Automation_Testing.Common.Driver.Manage().Window.Maximize();
            Login_Page.LoginAsAdmin();
            CorrectionWay_page.Goto();
        }


        public static IEnumerable<TestCaseData> T01_AddCorrectionWay_TestCases
        {
            get
            {
                yield return new TestCaseData(Data.CorrectionWay.CorrectionWayName).SetName("TC01_AddCorrectionWayWithFullData");
                yield return new TestCaseData("").SetName("TC02_AddCorrectionWayWithEmptyName");
            }
        }

        [Test]
        [Category("T01_AddCorrectionWay_TestCases")]
        [TestCaseSource("T01_AddCorrectionWay_TestCases")]
        public void T1_AddCorrectionWay(string CorrectionWayName)
        {
            CorrectionWay_page.Add_CorrectionWay(CorrectionWayName);
            Assert.IsTrue(Certificate_Page.Search(Data.CorrectionWay.CorrectionWayName) == Common.SEARCH_Result.EXIST, "T1_AddCertificate Failed");

        }

        [Test]
        [Category("T02_EditCorrectionWay_TestCases")]
        public void T2_EditCorrectionWay()
        {
            CorrectionWay_page.Search("");
            CorrectionWay_page.Edit_CorrectionWay(
                Data.CorrectionWay.CorrectionWayName,
                Data.CorrectionWay.CorrectionWayName + "_edit");
            Assert.IsTrue(Certificate_Page.Search(Data.CorrectionWay.CorrectionWayName + "_edit") == Common.SEARCH_Result.EXIST, "T2_EditCertificate Failed");

        }

        [Test]
        [Category("T03_Delete_Correction_TestCases")]
        public void T3_Delete_CorrectionWay()
        {
            CorrectionWay_page.Delete_CorrectionWay(Data.CorrectionWay.CorrectionWayName + "_edit");
            Assert.IsTrue(Certificate_Page.Search(Data.Certificate.CertificateName + "_edit") == Common.SEARCH_Result.NOT_EXIST, "T3_DeleteCertificate Failed");

        }



        [Test]
        [Category("T04_CorrectionWay_HappyScenario_TestCases")]
        public void T4_CorrectionWay_HappyScenario()
        {
            CorrectionWay_page.Add_CorrectionWay(Data.CorrectionWay.CorrectionWayName);
            Assert.IsTrue(CorrectionWay_page.Search(Data.CorrectionWay.CorrectionWayName) == Common.SEARCH_Result.EXIST, "T1_AddCertificate Failed");

            CorrectionWay_page.Edit_CorrectionWay(Data.CorrectionWay.CorrectionWayName, Data.CorrectionWay.CorrectionWayName + "_edit");
            Assert.IsTrue(CorrectionWay_page.Search(Data.CorrectionWay.CorrectionWayName + "_edit") == Common.SEARCH_Result.NOT_EXIST, "T2_EditCertificate Failed");

            CorrectionWay_page.Delete_CorrectionWay(Data.CorrectionWay.CorrectionWayName + "_edit");
            Assert.IsTrue(CorrectionWay_page.Search(Data.CorrectionWay.CorrectionWayName + "_edit") == Common.SEARCH_Result.NOT_EXIST, "T3_DeleteCertificate Failed");

        }

        [Test]
        [Category("T04_CorrectionWay_HappyScenario_TestCases")]
        public void T5_DeleteMultiSelect_CorrectionWay()
        {
            CorrectionWay_page.MultiSelect_CorrectionWay();
            // Assert.IsTrue(Certificate_Page.Search(Data.Certificate.CertificateName + "_edit") == Common.SEARCH_Result.NOT_EXIST, "T3_DeleteCertificate Failed");

        }
        [Test]
        [Category("T06_ActivateMultiSelect_TestCases")]
        public void T6_ActivateMultiSelect_CorrectionWay()
        {
            CorrectionWay_page.MultiSelect_CorrectionWay();
            CorrectionWay_page.ActivateSelected_CorrectionWay();
        }
        [Test]
        [Category("T07_DisactiveMultiSelect_TestCases")]
        public void T7_DisactiveMultiSelect_CorrectionWay()
        {
            CorrectionWay_page.MultiSelect_CorrectionWay();
            CorrectionWay_page.DisactivateSelected_CorrectionWay();
        }
        [Test]
        [Category("T08_DeleteSelected_TestCases")]
        public void T8_DeleteactiveSelect_CorrectionWay()
        {
            CorrectionWay_page.MultiSelect_CorrectionWay();
            CorrectionWay_page.DeleteSelected_CorrectionWay();
            CorrectionWay_page.ConfirmSweetAlert_CorrectionWay();
        }
        [Test]
        [Category("T09_DeleteSelected_TestCases")]
        public void T9_DeleteactiveSelect_CorrectionWay()
        {
            CorrectionWay_page.MultiSelect_CorrectionWay();
            CorrectionWay_page.DeleteSelected_CorrectionWay();
            CorrectionWay_page.CancelSweetAlert_CorrectionWay();
        }

        [Test]
        [Category("T10_Active_TestCases")]
        public void T10_FirstItemActivate_CorrectionWay()
        {
            CorrectionWay_page.FirstItemActivate_CorrectionWay();
        }

        [Test]
        [Category("T11_DeActive_TestCases")]
        public void T10_FirstItemDeActivate_CorrectionWay()
        {
            CorrectionWay_page.FirstItemDeActivate_CorrectionWay();
        }
        [Test]
        [Category("T12_Localization_TestCases")]
        public void T12_AddLocalization_CorrectionWay()
        {
            CorrectionWay_page.Localization_CorrectionWay();
        }
    }
}