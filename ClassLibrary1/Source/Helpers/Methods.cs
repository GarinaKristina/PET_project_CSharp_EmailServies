using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace ClassLibrary1.Source.Helpers
{
    public static class DriverExtensions
    {
        public static void WaitUntilPresenceOfAllElements(this By locator, IWebDriver driver, int timeoutSecs = 10)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSecs)).Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
        }

        public static void WaitUntilElementIsVisible(this By locator, IWebDriver driver, int timeoutSecs = 10)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSecs))
          .Until(ExpectedConditions.ElementIsVisible(locator));
        }
    }
}
