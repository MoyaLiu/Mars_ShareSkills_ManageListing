using System;
using MarsFramework.Config;
using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;

namespace MarsFramework.Test
{

    [TestFixture]
    [Category("Manage Listings")]
    [Order(1)]
    class ManageListingsTests : Base
    {
        public ManageListings manageListings;
        public int RowNumber = 2;
        public int Index = 1;

        [SetUp, Test, Description("Check if the user is able to click on 'Manage Listings' button on Home page")]
        public void TC_001_01_Click_ManageListings_Button()
        {
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");
            manageListings = new ManageListings();
            manageListings.ClickManageListingButton();

            Assert.AreEqual(MarsResource.ListingManagementUrl, GlobalDefinitions.driver.Url);
        }

        [Test, Description("Check if the user is able to 'View' the 'Listings'")]
        public void TC_002_01_View_SkillListings()
        {
            var title = GlobalDefinitions.ExcelLib.ReadData(RowNumber, "Title");

            Assert.AreEqual(title, manageListings.GetTheTitleText(Index));
        }
        [Test, Description("Check if the user is able to 'View' the 'Skill Item'")]
        public void TC_003_01_View_SkillItem()
        {
            manageListings.ViewSkillItem(Index);

            Assert.IsTrue(GlobalDefinitions.driver.Url.Contains(MarsResource.ServiceDetailUrl));

        }
        [Test, Description("Check if the user is able to 'Edit' the 'Skill Item'")]
        public void TC_004_01_Edit_SkillItem()
        {
            manageListings.EditSkillItem(Index);

            Assert.IsTrue(GlobalDefinitions.driver.Url.Contains(MarsResource.ServiceListingUrl));
        }
        [Test, Description("Check if the user is able to 'Delete' the 'Skill Item'")]
        public void TC_005_01_Delete_SkillItem()
        {
            manageListings.DeleteSkillItem(Index);

            Assert.IsTrue(Common.getAlertDialogText().Contains("has been deleted"));
        }

    }
}
