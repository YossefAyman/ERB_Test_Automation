using Automation_Testing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace LMS_Automation_Testing
{
    [TestFixture]
    public class M3_Educational_Institution_N4_DiscussionTopi_Test
    {
    
        [SetUp]
        public static void Test_Init()
        {
            Automation_Testing.Common.Driver.Manage().Window.Maximize();
            Login_Page.LoginAsAdmin();

            Discussion_Topic_page.Goto();
        }

        [Test]
        public void T1_DiscussionTopic()
        {
            Discussion_Topic_page.Add_DiscussionTopic();
            Assert.IsTrue(Discussion_Topic_page.Search(Data.DiscussionTopic.DiscussionTobicName) == Common.SEARCH_Result.EXIST, "T1_AddEducationalLevel Failed");

        }

            
        [Test]
        public void T2_Edit_DiscussionTopic_()
        {
            Discussion_Topic_page.Edit_DiscussionTopic_(Data.DiscussionTopic.DiscussionTobicName, Data.DiscussionTopic.DiscussionTobicName + "_edit");
            Assert.IsTrue(Discussion_Topic_page.Search(Data.DiscussionTopic.DiscussionTobicName + "_edit") == Common.SEARCH_Result.EXIST, "T2_EditDiscussionTobic Failed");

        }

        [Test]
        public void T3_Delete_correction()
        {
            Discussion_Topic_page.Delete_DiscussionTopic(Data.DiscussionTopic.DiscussionTobicName +"_edit");
            Assert.IsTrue(Discussion_Topic_page.Search(Data.DiscussionTopic.DiscussionTobicName + "_edit") == Common.SEARCH_Result.NOT_EXIST, "T3_DeleteEducationalLevel Failed");

        }

        [Test]
        public void T4_DiscussionTobic_HappyScenario()
        {
            Discussion_Topic_page.Add_DiscussionTopic();
            Assert.IsTrue(Discussion_Topic_page.Search(Data.DiscussionTopic.DiscussionTobicName) == Common.SEARCH_Result.EXIST,  "T1_AddDiscussionTobic failed");

            Discussion_Topic_page.Edit_DiscussionTopic_(Data.DiscussionTopic.DiscussionTobicName, Data.DiscussionTopic.DiscussionTobicName + "_edit");
            Assert.IsTrue(Discussion_Topic_page.Search(Data.DiscussionTopic.DiscussionTobicName + "_edit") == Common.SEARCH_Result.NOT_EXIST, "T2_EditDiscussionTobic Failed");

            Discussion_Topic_page.Delete_DiscussionTopic(Data.DiscussionTopic.DiscussionTobicName + "_edit");
            Assert.IsTrue(Discussion_Topic_page.Search(Data.DiscussionTopic.DiscussionTobicName + "_edit") == Common.SEARCH_Result.NOT_EXIST, "T3_DeleteDiscussionTobic Failed");

        }
    }
}
