using ClassLibrary1.Source.Helpers;
using OpenQA.Selenium;

namespace ClassLibrary1.Source.PageObjects
{
    public class AutorizationPage : BasePage
    {

        private IWebDriver driver;
        public string email = "testqatesttest@yahoo.com";
        public string password = "QAZWSX!741852963";
        private readonly By emailFieldLocator = By.Id("login-username");
        private readonly By passwordFieldLocator = By.Id("login-passwd");
        private readonly By nextButtonLocator = By.Id("login-signin");
        private readonly By mailButtonLocator = By.XPath("//a[@id='ybarMailLink']");
        public AutorizationPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement emailField => driver.FindElement(emailFieldLocator);
        private IWebElement nextButton => driver.FindElement(nextButtonLocator);
        private IWebElement mailButton => driver.FindElement(mailButtonLocator);
        private IWebElement passwordField => driver.FindElement(passwordFieldLocator);

        public AutorizationPage SignIn(string email, string password)
        {
            emailField.SendKeys(email);
            nextButton.Click();
            DriverExtensions.WaitUntilElementIsVisible(passwordFieldLocator, driver);
            passwordField.SendKeys(password);
            nextButton.Click();
            mailButton.Click();
            return new AutorizationPage(driver);
        }
    }
}
