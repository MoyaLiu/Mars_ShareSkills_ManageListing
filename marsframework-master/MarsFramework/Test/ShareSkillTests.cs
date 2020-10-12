using System;
using System.Threading;
using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;

namespace MarsFramework.Test
{
    [TestFixture]
    [Category("ShareSkill")]
    [Parallelizable]
    class ShareSkillTests : Base
    {
        public ShareSkill shareSkill;
        public int RowNumber = 2;

        [SetUp, Test, Description("Check if the user is able to click on 'Share Skill' button in Profile page")]
        public void TC_001_01_Click_ShareSkill_Button()
        {
            shareSkill = new ShareSkill();
            shareSkill.ClickShareSkillButton();
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");

            Assert.AreEqual("http://localhost:5000/Home/ServiceListing", GlobalDefinitions.driver.Url);
        }

        [Test, Description("Check if the user is able to 'Enter' the 'Title'")]
        public void TC_002_01_Enter_Title()
        {
            shareSkill.EnterTitle(GlobalDefinitions.ExcelLib.ReadData(RowNumber, "Title"));
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
            shareSkill.EnterDescription(GlobalDefinitions.ExcelLib.ReadData(RowNumber, "Description"));
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
            shareSkill.SelectCategory(GlobalDefinitions.ExcelLib.ReadData(RowNumber, "Category"));
        }

        [Test, Description("Check if the user is able to 'Select' the 'Sub Category'")]
        public void TC_004_03_Select_Sub_Category()
        {
            shareSkill.SelectCategory(GlobalDefinitions.ExcelLib.ReadData(RowNumber, "Category"));
            shareSkill.SelectSubCategory(GlobalDefinitions.ExcelLib.ReadData(RowNumber, "SubCategory"));
        }

        [Test, Description("Check if the user is able to 'Add' the 'Tag'")]
        public void TC_005_02_Add_Tag()
        {
            shareSkill.EnterTag(GlobalDefinitions.ExcelLib.ReadData(RowNumber, "Tags"));
            shareSkill.AddTag();
        }

        [Test, Description("Check if the user is able to 'Select' the 'Service Type' o-> 'One-off service'")]
        public void TC_006_02_Select_ServiceType_OneoffService()
        {
            shareSkill.SelectServiceType(GlobalDefinitions.ExcelLib.ReadData(RowNumber, "ServiceType"));
        }

        [Test, Description("Check if the user is able to 'Select' the 'Location Type' -> 'On-Site'")]
        public void TC_007_01_Select_LocationType_OnSite()
        {
            shareSkill.SelectLocationType(GlobalDefinitions.ExcelLib.ReadData(RowNumber, "LocationType"));
        }

        [Test, Description("Check if the user is able to 'Select'  the 'Avaliable Days' -> 'Start date'")]
        public void TC_008_01_Select_AvaliableDays_StartDate()
        {
            shareSkill.SelectStartDate(GlobalDefinitions.ExcelLib.ReadData(RowNumber, "Startdate"));
        }

        [Test, Description("Check if the user is able to 'Tick'  the 'Avaliable Days' -> 'day'")]
        public void TC_008_05_Tick_AvaliableDays_Day()
        {
            shareSkill.TickDay(GlobalDefinitions.ExcelLib.ReadData(RowNumber, "Selectday"));
        }

        [Test, Description("Check if the user is able to 'Select'  the 'Avaliable Days' -> 'day' -> 'Start time'")]
        public void TC_008_07_Select_AvaliableDays_Day_StartTime()
        {
            shareSkill.SelectStartTime(GlobalDefinitions.ExcelLib.ReadData(RowNumber, "Starttime"));
        }

        [Test, Description("Check if the user is able to 'Select'  the 'Skill Trade' -> 'Skill-Exchange'")]
        public void TC_009_01_Select_SkillTrade_SkillExchange()
        {
            shareSkill.SelectSkillTrade(GlobalDefinitions.ExcelLib.ReadData(RowNumber, "SkillTrade"));
        }

        [Test, Description("Check if the user is able to 'Enter'  the tagname of 'Skill Trade' -> 'Skill-Exchange'")]
        public void TC_009_02_Enter_TagName_SkillExchange()
        {
            shareSkill.EnterTagNameSkillExchange(GlobalDefinitions.ExcelLib.ReadData(RowNumber, "Skill-Exchange"));
        }

        [Test, Description("Check if the user is able to 'Enter'  the tagname of 'Skill Trade' -> 'Skill-Exchange'")]
        public void TC_009_02_Add_TagName_SkillExchange()
        {
            shareSkill.EnterTagNameSkillExchange(GlobalDefinitions.ExcelLib.ReadData(RowNumber, "Skill-Exchange"));
            shareSkill.AddTagNameSkillExchange();
        }

        [Test, Description("Check if the user is able to 'Select'  the 'Skill Trade' -> 'Credit'")]
        public void TC_009_05_Select_SkillTrade_Credit()
        {
            shareSkill.SelectSkillTrade(GlobalDefinitions.ExcelLib.ReadData(RowNumber, "SkillTrade"));
        }

        [Test, Description("Check if the user is able to 'Enter'  the 'Skill Trade' -> 'Credit' -> 'CreditAmount'")]
        public void TC_009_06_Enter_SkillTrade_CreditAmount()
        {
            shareSkill.EnterCreditAmount(GlobalDefinitions.ExcelLib.ReadData(RowNumber, "CreditAmount"));
        }

        [Test, Description("Check if the user is able to 'Upload' the 'Work Sample'")]
        public void TC_010_02_Upload_WorkSample()
        {
            shareSkill.ClickWorkSampleButton();
            shareSkill.UploadFileToWorkSample();

            Assert.AreEqual("su.jpg", shareSkill.GetWorkSamplesFileName());
        }

        [Test, Description("Check if the user is able to 'Select'  the 'Active' -> 'Hidden'")]
        public void TC_011_02_Active_Hidden()
        {
            shareSkill.SelectActive(GlobalDefinitions.ExcelLib.ReadData(RowNumber, "Active"));
        }

        [Test, Description("Check If the user is able to click 'Save' button and save the form")]
        public void TC_012_01_Save()
        {
            shareSkill.EnterTitle(GlobalDefinitions.ExcelLib.ReadData(RowNumber, "Title"));
            shareSkill.EnterDescription(GlobalDefinitions.ExcelLib.ReadData(RowNumber, "Description"));
            shareSkill.SelectCategory(GlobalDefinitions.ExcelLib.ReadData(RowNumber, "Category"));
            shareSkill.SelectSubCategory(GlobalDefinitions.ExcelLib.ReadData(RowNumber, "SubCategory"));
            shareSkill.EnterTag(GlobalDefinitions.ExcelLib.ReadData(RowNumber, "Tags"));
            shareSkill.AddTag();
            shareSkill.SelectServiceType(GlobalDefinitions.ExcelLib.ReadData(RowNumber, "ServiceType"));
            shareSkill.SelectLocationType(GlobalDefinitions.ExcelLib.ReadData(RowNumber, "LocationType"));
            shareSkill.SelectStartDate(GlobalDefinitions.ExcelLib.ReadData(RowNumber, "Startdate"));
            shareSkill.SelectEndDate(GlobalDefinitions.ExcelLib.ReadData(RowNumber, "Enddate"));
            shareSkill.TickDay(GlobalDefinitions.ExcelLib.ReadData(RowNumber, "Selectday"));
            shareSkill.SelectStartTime(GlobalDefinitions.ExcelLib.ReadData(RowNumber, "Starttime"));
            shareSkill.SelectSkillTrade(GlobalDefinitions.ExcelLib.ReadData(RowNumber, "SkillTrade"));
            shareSkill.EnterTagNameSkillExchange(GlobalDefinitions.ExcelLib.ReadData(RowNumber, "Skill-Exchange"));
            shareSkill.AddTagNameSkillExchange();
            shareSkill.UploadFileToWorkSample();
            shareSkill.SelectActive(GlobalDefinitions.ExcelLib.ReadData(RowNumber, "Active"));
            shareSkill.ClickSave();
            Thread.Sleep(5000);
        }


    }
}
