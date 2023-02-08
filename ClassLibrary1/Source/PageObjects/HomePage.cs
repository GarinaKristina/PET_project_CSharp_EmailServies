using OpenQA.Selenium;

namespace ClassLibrary1.Source.PageObjects
{
    public class HomePage : BasePage
    {

        private IWebDriver driver;
        private readonly By cookieButtonLocator = By.CssSelector("button.btn.primary");
        private readonly By signInButtonLocator = By.XPath("//a[contains(text(),'Sign in')]");
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement coockieButton => driver.FindElement(cookieButtonLocator);
        private IWebElement signInButton => driver.FindElement(signInButtonLocator);
        public void OpenAutorizationPage()
        {
            coockieButton.Click();
            signInButton.Click();
        }
    }
}