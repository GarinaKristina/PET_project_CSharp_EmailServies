using ClassLibrary1.Source.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmailService.Test
{
    [TestClass]
    public class Test
    {
        private IWebDriver driver;
        private string baseUrl;

        [TestInitialize]
        public void Init()
        {
            var service = ChromeDriverService.CreateDefaultService();
            driver = new ChromeDriver(service);
            baseUrl = "https://www.yahoo.com/";
            driver.Navigate().GoToUrl(baseUrl);
            driver.Manage().Window.Maximize();

        }

        [TestMethod]
        public void TestEmail()
        {
            var homePage = new HomePage(driver);
            var autorizationPage = new AutorizationPage(driver);
            var postPage = new PostPage(driver);

            homePage.OpenAutorizationPage();
            autorizationPage.SignIn(autorizationPage.email, autorizationPage.password);       
            postPage.CreateLetter();
            var actualCountDraftLetters = driver.FindElement(postPage.countOfLetterInfoLocator).Text;
            actualCountDraftLetters.Should().Contain("1");
            postPage.ClickOnTheDraftLetter();
            var actualBodyLetter = driver.FindElement(postPage.bodyLetterLocator).Text;
            using (new AssertionScope())
            {
                actualBodyLetter.Should().Contain(postPage.contactEmail);
                actualBodyLetter.Should().Contain(postPage.message);
            }
            postPage.SendTheLetterForDarft();
            actualBodyLetter.Should().Contain(postPage.contactEmail);
            actualBodyLetter.Should().Contain(postPage.message);
            postPage.LogOff();
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
