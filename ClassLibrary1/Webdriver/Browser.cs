using OpenQA.Selenium;
using System;

namespace ClassLibrary1.Webdriver
{
    public static class Browser
    {
        private static IWebDriver driver = null;
        private static IJavaScriptExecutor js = null;

        public static IWebDriver GetDriver() => driver == null
            ? driver = BrowserFactory.GetDriver(BrowserFactory.BrowserType.remoteChrome, 10)
            : driver;

        public static IJavaScriptExecutor GetJsExecutor() => js == null ? (IJavaScriptExecutor)driver : js;

        public static void WindowsMaximize()
        {
            driver.Manage().Window.Maximize();
        }

        public static void CleanAfterTest()
        {
            driver.Close();
            driver.Quit();
            driver = null;
            js = null;
        }

        public static void GoToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
    }
}
