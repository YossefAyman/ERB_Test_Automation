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
    public class M3_Educational_Institution_N2_Certificate_Test
    {
        [SetUp]
        public static void Test_Init()
        {
            Automation_Testing.Common.Driver.Manage().Window.Maximize();
            Login_Page.LoginAsAdmin();
            Certificate_Page.Goto();
        }

        [Test]
        public void T1_AddEducationalLevel()
        {
            Certificate_Page.Add_Certificate_Level();
            Assert.IsTrue(Certificate_Page.Search(Data.Certificate.CertificateName) == Common.SEARCH_Result.EXIST, "T1_AddCertificate Failed");

        }

        [Test]
        public void T2_EditEducationalLevel()
        {
            Certificate_Page.Edit_Certificate_Level(Data.Certificate.CertificateName, Data.Certificate.CertificateName + "_edit");
            Assert.IsTrue(Certificate_Page.Search(Data.Certificate.CertificateName + "_edit") == Common.SEARCH_Result.EXIST, "T2_EditCertificate Failed");

        }

        [Test]
        public void T3_DeleteEducationalLevel()
        {
            Certificate_Page.Delete_Certificate(Data.Certificate.CertificateName + "_edit");
            Assert.IsTrue(Certificate_Page.Search(Data.Certificate.CertificateName + "_edit") == Common.SEARCH_Result.NOT_EXIST, "T3_DeleteCertificate Failed");

        }

        [Test]
        public void T4_EducationalLevel_HappyScenario()
        {
            Certificate_Page.Add_Certificate_Level();
            Assert.IsTrue(Certificate_Page.Search(Data.Certificate.CertificateName) == Common.SEARCH_Result.EXIST, "T1_AddCertificate Failed");

            Certificate_Page.Edit_Certificate_Level(Data.Certificate.CertificateName, Data.Certificate.CertificateName + "_edit");
            Assert.IsTrue(Certificate_Page.Search(Data.Certificate.CertificateName + "_edit") == Common.SEARCH_Result.NOT_EXIST, "T2_EditCertificate Failed");

            Certificate_Page.Delete_Certificate(Data.Certificate.CertificateName + "_edit");
            Assert.IsTrue(Certificate_Page.Search(Data.Certificate.CertificateName   + "_edit") == Common.SEARCH_Result.NOT_EXIST, "T3_DeleteCertificate Failed");

        }
    }
}