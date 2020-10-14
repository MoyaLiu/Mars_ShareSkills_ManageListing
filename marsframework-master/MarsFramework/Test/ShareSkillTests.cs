using System;
using System.Threading;
using MarsFramework.Config;
using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;

namespace MarsFramework.Test
{
    [TestFixture]
    [Category("ShareSkill")]
    [Order(0)]
    class ShareSkillTests : Base
    {
        public ShareSkill shareSkill;
        public int RowNumber = 2;

        [SetUp, Test, Description("Check if the user is able to click on 'Share Skill' button in Profile page")]
        public void TC_001_01_Click_ShareSkill_Button()
        {
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");
            shareSkill = new ShareSkill();
            shareSkill.ClickShareSkillButton();

            Assert.AreEqual(MarsResource.ServiceListingUrl, GlobalDefinitions.driver.Url);
        }

        [Test, Description("Check if the user is able to 'Enter' the 'Title'")]
        public void TC_002_01_Enter_Title()
        {
            var title = GlobalDefinitions.ExcelLib.ReadData(RowNumber, "Title");
            shareSkill.EnterTitle(title);

            Assert.AreEqual(title, shareSkill.GetTitle());
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
            var description = GlobalDefinitions.ExcelLib.ReadData(RowNumber, "Description");
            shareSkill.EnterDescription(description);

            Assert.AreEqual(description, shareSkill.GetDescriptionText());
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
            var category = GlobalDefinitions.ExcelLib.ReadData(RowNumber, "Category");
            shareSkill.SelectCategory(category);

            Assert.AreEqual(category, shareSkill.GetCategoryText());
        }

        [Test, Description("Check if the user is able to 'Select' the 'Sub Category'")]
        public void TC_004_03_Select_Sub_Category()
        {
            var subCategory = GlobalDefinitions.ExcelLib.ReadData(RowNumber, "SubCategory");
            shareSkill.SelectCategory(GlobalDefinitions.ExcelLib.ReadData(RowNumber, "Category"));
            shareSkill.SelectSubCategory(subCategory);

            Assert.AreEqual(subCategory, shareSkill.GetSubCategoryText());
        }

        [Test, Description("Check if the user is able to 'Add' the 'Tag'")]
        public void TC_005_02_Add_Tag()
        {
            var tag = GlobalDefinitions.ExcelLib.ReadData(RowNumber, "Tags");
            shareSkill.EnterTag(tag);
            shareSkill.AddTag();

            Assert.IsTrue(shareSkill.GetAddedTagNameText().Contains(tag));
        }

        [Test, Description("Check if the user is able to 'Select' the 'Service Type' o-> 'One-off service'")]
        public void TC_006_02_Select_ServiceType_OneoffService()
        {
            shareSkill.SelectServiceType(GlobalDefinitions.ExcelLib.ReadData(RowNumber, "ServiceType"));

            Assert.IsTrue(shareSkill.IsSelectedOnOneOffService());
        }

        [Test, Description("Check if the user is able to 'Select' the 'Location Type' -> 'On-Site'")]
        public void TC_007_01_Select_LocationType_OnSite()
        {
            shareSkill.SelectLocationType(GlobalDefinitions.ExcelLib.ReadData(RowNumber, "LocationType"));
            Assert.IsTrue(shareSkill.IsSelectedOnSite());
        }

        [Test, Description("Check if the user is able to 'Select'  the 'Avaliable Days' -> 'Start date'")]
        public void TC_008_01_Select_AvaliableDays_StartDate()
        {
            var startDate = GlobalDefinitions.ExcelLib.ReadData(RowNumber, "Startdate");
            Console.WriteLine("Start date  = " + startDate);
            shareSkill.SelectStartDate(startDate);

            Assert.AreEqual(GlobalDefinitions.FormatDateFromExcel(startDate), shareSkill.GetStartDateText());
        }

        [Test, Description("Check if the user is able to 'Tick'  the 'Avaliable Days' -> 'day'")]
        public void TC_008_05_Tick_AvaliableDays_Day()
        {
            var day = GlobalDefinitions.ExcelLib.ReadData(RowNumber, "Selectday");
            shareSkill.TickDay(day);

            Assert.IsTrue(shareSkill.IsSelectedDay());
        }

        [Test, Description("Check if the user is able to 'Select'  the 'Avaliable Days' -> 'day' -> 'Start time'")]
        public void TC_008_07_Select_AvaliableDays_Day_StartTime()
        {
            var startTime = GlobalDefinitions.ExcelLib.ReadData(RowNumber, "Starttime");
            shareSkill.SelectStartTime(startTime);//Just for Monday

            Assert.AreEqual(GlobalDefinitions.FormatTimeFromExcel(startTime), shareSkill.GetStartTimeOnMondayText());
        }

        [Test, Description("Check if the user is able to 'Select'  the 'Skill Trade' -> 'Skill-Exchange'")]
        public void TC_009_01_Select_SkillTrade_SkillExchange()
        {
            shareSkill.SelectSkillTrade(GlobalDefinitions.ExcelLib.ReadData(RowNumber, "SkillTrade"));

            Assert.IsTrue(shareSkill.IsSelectedSkillExchange());
        }

        [Test, Description("Check if the user is able to 'Enter'  the tagname of 'Skill Trade' -> 'Skill-Exchange'")]
        public void TC_009_02_Enter_TagName_SkillExchange()
        {
            var skillExchange = GlobalDefinitions.ExcelLib.ReadData(RowNumber, "Skill-Exchange");
            shareSkill.EnterTagNameSkillExchange(skillExchange);

            Assert.AreEqual(skillExchange, shareSkill.GetSkillExchangeTagFieldText());
        }

        [Test, Description("Check if the user is able to 'Enter'  the tagname of 'Skill Trade' -> 'Skill-Exchange'")]
        public void TC_009_03_Add_TagName_SkillExchange()
        {
            var skillExchange = GlobalDefinitions.ExcelLib.ReadData(RowNumber, "Skill-Exchange");
            shareSkill.EnterTagNameSkillExchange(skillExchange);
            shareSkill.AddTagNameSkillExchange();

            Assert.IsTrue(shareSkill.GetSkillExchangeTagNameText().Contains(skillExchange));
        }

        [Test, Ignore("Need to add data in excel"), Description("Check if the user is able to 'Select'  the 'Skill Trade' -> 'Credit'")]
        public void TC_009_05_Select_SkillTrade_Credit()
        {
            shareSkill.SelectSkillTrade(GlobalDefinitions.ExcelLib.ReadData(RowNumber, "SkillTrade"));

            Assert.IsTrue(shareSkill.IsSelectedCredit());
        }

        [Test, Ignore("Need to add data in excel"), Description("Check if the user is able to 'Enter'  the 'Skill Trade' -> 'Credit' -> 'CreditAmount'")]
        public void TC_009_06_Enter_SkillTrade_CreditAmount()
        {
            var creditAmount = GlobalDefinitions.ExcelLib.ReadData(RowNumber, "CreditAmount");
            shareSkill.SelectSkillTrade("Credit");
            shareSkill.EnterCreditAmount(creditAmount);

            Assert.AreEqual(creditAmount, shareSkill.GetCreditAmountText());
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

            Assert.IsTrue(shareSkill.IsSelectedHidden());
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
            shareSkill.ClickWorkSampleButton();
            shareSkill.UploadFileToWorkSample();
            shareSkill.SelectActive(GlobalDefinitions.ExcelLib.ReadData(RowNumber, "Active"));
            shareSkill.ClickSave();
            Assert.AreEqual("Service Listing Added successfully", Common.getAlertDialogText());
        }


    }
}
