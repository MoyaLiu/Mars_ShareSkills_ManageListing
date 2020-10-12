using System;
using System.Threading;
using AutoIt;
using MarsFramework.Global;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace MarsFramework.Pages
{
    internal class ShareSkill
    {
        public ShareSkill()
        {
            PageFactory.InitElements(GlobalDefinitions.driver, this);
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");
        }

        //Click on ShareSkill Button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        private IWebElement Tags { get; set; }

        //Select the Service type -> Hourly basis service
        [FindsBy(How = How.XPath, Using = "//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']")]
        private IWebElement ServiceTypeOptionsHourlyBasisService { get; set; }
        //Select the Service type -> One-off Service
        [FindsBy(How = How.XPath, Using = "//form/div[5]/div[@class='twelve wide column']/div/div[@class='field'][2]")]
        private IWebElement ServiceTypeOptionsOneOffService { get; set; }

        //Select the Location Type -> On-site
        [FindsBy(How = How.XPath, Using = "//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement LocationTypeOptionOnSite { get; set; }

        //Select the Location Type -> Online
        [FindsBy(How = How.XPath, Using = "//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field'][2]")]
        private IWebElement LocationTypeOptionOnline { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }

        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "//input[@tabindex='0'][@index = '1']")]
        private IWebElement Days { get; set; }

        //Storing the starttime
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTimeOnMon { get; set; }

        //Click on StartTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTimeDropDown { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[3]/input[1]")]
        private IWebElement EndTimeOnMon { get; set; }

        //Click on Skill Trade option -> Skill-exchange
        [FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement SkillTradeOptionSkillExchange { get; set; }

        //Click on Skill Trade option -> Credit
        [FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field'][2]")]
        private IWebElement SkillTradeOptionCredit { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchange { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }

        //Click on Active -> Active
        [FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement ActiveOptionActive { get; set; }

        //Click on Active -> Hidden
        [FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field'][2]")]
        private IWebElement ActiveOptionHidden { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        //Click on WorkSamples icon
        [FindsBy(How = How.XPath, Using = "//i[@class='huge plus circle icon padding-25']")]
        private IWebElement WorkSamplesAdd { get; set; }

        //WorkSamples filename
        [FindsBy(How = How.XPath, Using = "//div[@class='serviceListing worksampleImage']/a")]
        private IWebElement WorSamplesFileName { get; set; }

        //WorkSamples FileElement
        [FindsBy(How = How.XPath, Using = "//input[@type='file']")]
        private IWebElement WorSamplesFileElement { get; set; }
        internal void EnterShareSkill()
        {
        }

        internal void EditShareSkill()
        {
        }

        internal void ClickShareSkillButton()
        {
            GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, ShareSkillButton, 10).Click();
        }

        //Title
        internal void EnterTitle()
        {
            var eTitle = GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, Title, 5);
            eTitle.Click();
            eTitle.Clear();
            eTitle.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
        }

        //Description
        internal void EnterDescription()
        {
            var eDescription = GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, Description, 5);
            eDescription.Click();
            eDescription.Clear();
            eDescription.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
        }

        //Category
        internal void SelectCategory()
        {
            GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, CategoryDropDown, 5).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));
        }
        //Sub Category
        internal void SelectSubCategory()
        {
            GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, SubCategoryDropDown, 5).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));
        }

        //TAGS
        internal void AddTag()
        {
            GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, Tags, 5).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
        }

        //One-off Service
        internal void SelectServiceTypeOneoffService()
        {
            GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, ServiceTypeOptionsOneOffService, 5).Click();
        }

        // Online
        internal void SelectLocationTypeOnSite()
        {
            GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, LocationTypeOptionOnline, 5).Click();
        }

        //Available days
        internal void SelectStartDate()
        {
            GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, StartDateDropDown, 5).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Startdate"));
        }

        internal void SelectEndDate()
        {
            GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, EndDateDropDown, 5).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Startdate"));
        }

        internal void TickDay()
        {
            //GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, Days, 5).Click();
            GlobalDefinitions.wait(2);
            Days.Click();
        }

        internal void SelectStartTime()
        {
            GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, StartTimeOnMon, 5).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
        }
        internal void SelectEndTime()
        {
            GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, EndTimeOnMon, 5).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));
        }

        //Skill Trade -> Credit
        internal void SelectSkillTradeCredit()
        {
            GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, SkillTradeOptionCredit, 5).Click();
        }
        internal void EnterCreditAmount()
        {
            GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, CreditAmount, 5).SendKeys("5");
        }

        //Work Sample category
        internal void ClickWorkSampleButton()
        {
            GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, WorkSamplesAdd, 5).Click();
        }

        internal void UploadFileToWorkSample()
        {
            string FilePath = Base.WorkSampleFile;
            Console.WriteLine("FilePath = " + FilePath);
            if (GlobalDefinitions.IsWindows())
            {
                //System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                //Info.FileName = GlobalDefinitions.GetCodeDirectory() + @"..\..\FileUpload.exe";
                //try
                //{
                //    System.Diagnostics.Process.Start(Info);
                //}
                //catch (System.ComponentModel.Win32Exception e)
                //{
                //    Console.WriteLine("Can not find the exe", e.Message);
                //}
                //Thread.Sleep(10000);
                string WindowTitle = "Open";
                AutoItX.WinActivate(WindowTitle, "");
                AutoItX.ControlFocus(WindowTitle, "", "Edit1");
                //AutoItX.ControlSetText(WindowTitle, "", "Edit1", FilePath);
                AutoItX.Sleep(5000);
                AutoItX.Send(FilePath);
                AutoItX.Sleep(5000);
                AutoItX.ControlClick(WindowTitle, "", "Button1");
                Thread.Sleep(5000);
            }
            else
            {
                GlobalDefinitions.wait(5);
                WorSamplesFileElement.SendKeys(FilePath);
                GlobalDefinitions.wait(5);
            }
        }
        internal string GetWorkSamplesFileName()
        {
            return GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, WorSamplesFileName, 5).Text;
        }

        //Active
        internal void SelectActiveHidden()
        {
            GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, ActiveOptionHidden, 5).Click();
        }

        internal void ClickSave()
        {
            GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, Save, 5).Click();
        }
    }
}
