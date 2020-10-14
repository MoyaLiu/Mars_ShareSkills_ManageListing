using System;
using MarsFramework.Global;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }
        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'][1]")]
        private IWebElement view { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "//table[1]/tbody[1]")]
        private IWebElement delete { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement edit { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']")]
        private IWebElement clickActionsButton { get; set; }

        private By LocatorTitle(int index)
        {
            string xpath = "//tbody/tr[" + index.ToString() + "]/td[3]";
            Console.WriteLine("Title xpath = " + xpath);
            return By.XPath(xpath);
        }

        private By LocatorView(int index)
        {
            string xpath = "//tbody/tr[" + index.ToString() + "]//i[@class='eye icon'][1]";
            Console.WriteLine("View xpath = " + xpath);
            return By.XPath(xpath);
        }
        private By LocatorEdit(int index)
        {
            string xpath = "//tbody/tr[" + index.ToString() + "]//i[@class='outline write icon'][1]";
            Console.WriteLine("Edit xpath = " + xpath);
            return By.XPath(xpath);
        }
        private By LocatorDelete(int index)
        {
            string xpath = "//tbody/tr[" + index.ToString() + "]//i[@class='remove icon'][1]";
            Console.WriteLine("Delete xpath = " + xpath);
            return By.XPath(xpath);
        }

        internal void Listings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");

        }

        internal void ClickManageListingButton()
        {
            GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, manageListingsLink, 5).Click();
        }

        internal string GetTheTitleText(int index)
        {
            return GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, LocatorTitle(index), 5).Text;
        }
        internal void ViewSkillItem(int index)
        {
            GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, LocatorView(index), 5).Click();
        }
        internal void EditSkillItem(int index)
        {
            GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, LocatorEdit(index), 5).Click();
        }
        internal void DeleteSkillItem(int index)
        {
            GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, LocatorDelete(index), 5).Click();
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//div[@class='ui tiny modal transition visible active']"), 5);
            GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, By.XPath("//button[@class='ui icon positive right labeled button']"), 5).Click();
        }
    }
}
