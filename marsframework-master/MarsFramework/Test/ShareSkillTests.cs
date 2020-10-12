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
        public ShareSkill shareSkill;

        [SetUp, Test, Description("Check if the user is able to click on 'Share Skill' button in Profile page")]
        public void TC_001_01_Click_ShareSkill_Button()
        {
            shareSkill = new ShareSkill();
            shareSkill.ClickShareSkillButton();

            Assert.AreEqual("http://localhost:5000/Home/ServiceListing", GlobalDefinitions.driver.Url);
        }

        [Test, Description("Check if the user is able to 'Enter' the 'Title'")]
        public void TC_002_01_Enter_Title()
        {
            shareSkill.EnterTitle();
        }

        [Test, Description("Check if the user is able to 'Edit' the 'Title'")]
        [Ignore("Implement later")]
        public void TC_002_02_Edit_Title()
        {

        }

        [Test, Ignore("Implement later"), Description("Check if the user is able to 'Delete' the 'Title'")]
        public void TC_002_03_Delete_Title()
        {

        }

        [Test, Description("Check if the user is able to 'Enter' the 'Description'")]
        public void TC_003_01_Enter_Description()
        {
            shareSkill.EnterDescription();
        }

        [Test, Ignore("Implement later"),Description("Check if the user is able to 'Edit' the 'Description'")]
        public void TC_003_02_Edit_Description()
        {

        }

        [Test, Ignore("Implement later"),Description("Check if the user is able to 'Delete' the 'Description'")]
        public void TC_003_03_Delete_Description()
        {

        }

        [Test, Description("Check if the user is able to 'Select' the 'Category'")]
        public void TC_004_01_Select_Category()
        {
            shareSkill.SelectCategory();
        }

        [Test, Description("Check if the user is able to 'Select' the 'Sub Category'")]
        public void TC_004_03_Select_Sub_Category()
        {
            shareSkill.SelectSubCategory();
        }

        [Test, Description("Check if the user is able to 'Add' the 'Tag'")]
        public void TC_005_02_Add_Tag()
        {
            shareSkill.AddTag();
        }

        [Test, Description("Check if the user is able to 'Select' the 'Service Type' o-> 'One-off service'")]
        public void TC_006_02_Select_ServiceType_OneoffService()
        {
            shareSkill.SelectServiceTypeOneoffService();
        }

        [Test, Description("Check if the user is able to 'Select' the 'Location Type' -> 'On-Site'")]
        public void TC_007_01_Select_LocationType_OnSite()
        {
            shareSkill.SelectLocationTypeOnSite();
        }

        [Test, Description("Check if the user is able to 'Select'  the 'Avaliable Days' -> 'Start date'")]
        public void TC_008_01_Select_AvaliableDays_StartDate()
        {
            shareSkill.SelectStartDate();
        }

        [Test, Description("Check if the user is able to 'Tick'  the 'Avaliable Days' -> 'day'")]
        public void TC_008_05_Tick_AvaliableDays_Day()
        {
            shareSkill.TickDay();
        }

        [Test, Description("Check if the user is able to 'Select'  the 'Avaliable Days' -> 'day' -> 'Start time'")]
        public void TC_008_07_Select_AvaliableDays_Day_StartTime()
        {
            shareSkill.SelectStartTime();
        }

        [Test, Description("Check if the user is able to 'Select'  the 'Skill Trade' -> 'Credit'")]
        public void TC_008_07_SkillTrade_Credit()
        {
            shareSkill.SelectSkillTradeCredit();
        }

        [Test, Description("Check if the user is able to 'Upload' the 'Work Sample'")]
        public void TC_009_05_Upload_WorkSample()
        {
            shareSkill.ClickWorkSampleButton();
            shareSkill.UploadFileToWorkSample();

            Assert.AreEqual("su.jpg", shareSkill.GetWorkSamplesFileName());
        }

        [Test, Description("Check if the user is able to 'Select'  the 'Active' -> 'Hidden'")]
        public void TC_011_02_Active_Hidden()
        {
            shareSkill.SelectActiveHidden();
        }

        [Test, Description("Check If the user is able to click 'Save' button and save the form")]
        public void TC_012_01_Save()
        {
            shareSkill.ClickSave();
        }


    }
}
