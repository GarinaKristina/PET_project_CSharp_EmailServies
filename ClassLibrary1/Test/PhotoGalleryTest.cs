using ClassLibrary1.Source.PageObjects;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ClassLibrary1.Test
{
    [TestClass]
    public class PhotoGalleryTest
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

            postPage.clickOnPhotoGallery();
            var photoGallery = driver.FindElement(postPage.photoGalleryTitleLocator).Text;
            photoGallery.Should().Contain("Nuotraukos");

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
