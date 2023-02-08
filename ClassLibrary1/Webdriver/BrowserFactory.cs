using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;

namespace ClassLibrary1.Webdriver
{

    public class BrowserFactory
    {
        private static IWebDriver driver = null;
        public enum BrowserType
        {
            Chrome,
            FireFox,
            remoteFirefox,
            remoteChrome
        }

        public static IWebDriver GetDriver(BrowserType type, int timeOut)
        {
            switch (type)
            {
                case BrowserType.Chrome:
                    {
                        var service = ChromeDriverService.CreateDefaultService();
                        var option = new ChromeOptions();
                        driver = new ChromeDriver(service, option);
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeOut);
                        break;
                    }
                case BrowserType.FireFox:
                    {
                        var service = FirefoxDriverService.CreateDefaultService();
                        var option = new FirefoxOptions();
                        driver = new FirefoxDriver(service, option, TimeSpan.FromSeconds(timeOut));
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeOut);
                        break;
                    }
                case BrowserType.remoteFirefox:
                    {
                        var option = new FirefoxOptions();
                        driver = new RemoteWebDriver(new Uri("http://localhost:4444"), option.ToCapabilities());
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeOut);
                        break;
                    }
                case BrowserType.remoteChrome:
                    {
                        var option = new ChromeOptions();
                        driver = new RemoteWebDriver(new Uri("http://localhost:4444"), option.ToCapabilities());
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeOut);
                        break;
                    }

            }
            return driver;
        }
    }
}
