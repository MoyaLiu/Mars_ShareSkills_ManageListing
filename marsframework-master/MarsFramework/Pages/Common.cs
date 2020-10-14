using System;
using MarsFramework.Global;
using OpenQA.Selenium;

namespace MarsFramework.Pages
{
    public class Common
    {
        internal static string GetTextOfElement(IWebElement iwebElement)
        {
            return GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, iwebElement, 5).Text;
        }
        internal static Boolean IsSelectedOfElement(IWebElement iwebElement)
        {
            Console.WriteLine("Selected = " + iwebElement.Selected);
            return iwebElement.Selected;
        }

        public static string getAlertDialogText()
        {
            By AlertDialogBy = By.XPath("//div[@class='ns-box-inner']");
            var text = GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, AlertDialogBy, 8).Text;
            Console.WriteLine("text = " + text);
            return text;
        }
    }
}
