using System;
using MarsFramework.Config;
using MarsFramework.Global;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace MarsFramework.Pages
{
    class SignIn
    {
        public SignIn()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 
        //Finding the Sign Link
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sign')]")]
        private IWebElement SignIntab { get; set; }

        // Finding the Email Field
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement Email { get; set; }

        //Finding the Password Field
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password { get; set; }

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        private IWebElement LoginBtn { get; set; }

        #endregion

        internal void LoginSteps()
        {
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");
            GlobalDefinitions.driver.Navigate().GoToUrl(GlobalDefinitions.ExcelLib.ReadData(2, "Url"));
            GlobalDefinitions.driver.Manage().Window.Maximize();

            SignIntab.Click();

            Email.Click();
            Email.Clear();
            Console.WriteLine("username = " + GlobalDefinitions.ExcelLib.ReadData(2, "Username"));
            Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Username"));
            
            Password.Click();
            Password.Clear();
            Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));
            Console.WriteLine("password = " + GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            LoginBtn.Click();


        }
    }
}