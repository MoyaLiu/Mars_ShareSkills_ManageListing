using System;
using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;

namespace MarsFramework.Test
{
    [TestFixture]
    [Category("ShareSkill")]
    [Parallelizable]
    class ShareSkillTests : Global.Base
    {


        [Test, Description("Check if the user is able to click on 'Share Skill' button in Profile page")]
        public void TC_001_01_Click_ShareSkill_Button()
        {
            ShareSkill shareSkill = new ShareSkill();
            shareSkill.ClickShareSkillButton();

            Assert.AreEqual("http://localhost:5000/Home/ServiceListing", GlobalDefinitions.driver.Url);
        }

        [Test, Description("Check if the user is able to 'Upload' the 'Work Sample'")]
        public void TC_010_02_Upload_WorkSample()
        {


        }


    }
}
