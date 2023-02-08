using ClassLibrary1.Source.Helpers;
using OpenQA.Selenium;

namespace ClassLibrary1.Source.PageObjects
{
    public class PostPage : BasePage
    {

        private IWebDriver driver;
        public readonly By bodyLetterLocator = By.CssSelector("#mail-app-component");
        public readonly By calendarPanelLocator = By.XPath("//*[@data-test-id='calendar-right-rail-pane']");
        public readonly By settingsButtonLocator = By.XPath("//button[@aria-label='Nuostatų meniu']");
        public readonly By settingsPanelLocator = By.XPath("//button[@aria-label='Nuostatų meniu']");
        public readonly By photoGalleryLocator = By.XPath("//span[contains(text(),'Nuotraukos')]");
        public readonly By photoGalleryTitleLocator = By.XPath("//*[contains(text(),'Nuotraukos iš el. pašto')]");
        public readonly By countOfLetterInfoLocator = By.XPath("//span[@data-name='unreadWrapper']");
        public string email = "testqatesttest@yahoo.com";
        public string password = "QAZWSX!741852963";
        public string contactEmail = "thebestqateamepam@gmail.com";
        public string topic = "Hello, my dear";
        public string message = "I wish you a Marry Cristmas";
        private readonly By draftZeroInfoIconLocator = By.XPath("//span[@title='Juodraščiai, pasirinkta – nėra juodraščių ']");
        private readonly By messageFieldLocator = By.XPath("//*[@aria-label='Pagrindinė žinutės dalis']");
        private readonly By inputLetterButtonLocator = By.XPath("//*[contains(text(),'Gauta')]");
        private readonly By draftButtonLocator = By.XPath("//*[contains(text(),'Juodraščiai')]");
        private readonly By draftLetterButtonLocator = By.XPath("//*[contains(@class,'message-list-item')]");
        private readonly By calendarButtonLocator = By.CssSelector("button[title = 'Kalendorius']");
        private readonly By createNewLetterButtonLocator = By.XPath("//a[@aria-label='Rašyti']");
        private readonly By emailAdressLetterFieldLocator = By.XPath("//input[@id='message-to-field']");
        private readonly By topicLetterFieldLocator = By.XPath("//input[@placeholder='Tema']");
        private readonly By sendLetterButtonLocator = By.XPath("//span[contains(text(),'Siųsti')]");
        private readonly By sendingLettersButtonLocator = By.XPath("//span[contains(text(),'Išsiųsta')]");
        private readonly By closeButtonLocator = By.XPath("//span[contains(text(),'Pradžia')]");

        public PostPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement createNewLetterButton => driver.FindElement(createNewLetterButtonLocator);
        private IWebElement emailAdressLetterField => driver.FindElement(emailAdressLetterFieldLocator);
        private IWebElement topicLetterField => driver.FindElement(topicLetterFieldLocator);
        private IWebElement messageField => driver.FindElement(messageFieldLocator);
        private IWebElement inputLetterButton => driver.FindElement(inputLetterButtonLocator);
        private IWebElement draftButton => driver.FindElement(draftButtonLocator);
        private IWebElement draftLetterButton => driver.FindElement(draftLetterButtonLocator);
        private IWebElement sendLetterButton => driver.FindElement(sendLetterButtonLocator);
        private IWebElement sendingLettersButton => driver.FindElement(sendingLettersButtonLocator);
        private IWebElement closeButton => driver.FindElement(closeButtonLocator);
        private IWebElement calendarButton => driver.FindElement(calendarButtonLocator);
        private IWebElement settingsButton => driver.FindElement(settingsButtonLocator);
        private IWebElement photoGalleryButton => driver.FindElement(photoGalleryLocator);

        public PostPage CreateLetter()
        {
            DriverExtensions.WaitUntilElementIsVisible(createNewLetterButtonLocator, driver);
            createNewLetterButton.Click();
            DriverExtensions.WaitUntilElementIsVisible(emailAdressLetterFieldLocator, driver);
            emailAdressLetterField.SendKeys(contactEmail);
            topicLetterField.SendKeys(topic);
            messageField.SendKeys(message);
            inputLetterButton.Click();
            DriverExtensions.WaitUntilElementIsVisible(countOfLetterInfoLocator, driver);
            return new PostPage(driver);
        }

        public PostPage ClickOnTheDraftLetter()
        {
            DriverExtensions.WaitUntilElementIsVisible(draftButtonLocator, driver);
            draftButton.Click();
            DriverExtensions.WaitUntilElementIsVisible(draftLetterButtonLocator, driver);
            draftLetterButton.Click();
            DriverExtensions.WaitUntilElementIsVisible(topicLetterFieldLocator, driver);
            return new PostPage(driver);
        }

        public PostPage SendTheLetterForDarft()
        {
            sendLetterButton.Click();
            DriverExtensions.WaitUntilElementIsVisible(draftZeroInfoIconLocator, driver);
            sendingLettersButton.Click();
            DriverExtensions.WaitUntilElementIsVisible(closeButtonLocator, driver);
            return new PostPage(driver);
        }
        public PostPage clickOnCalendarLetter()
        {
            calendarButton.Click();
            DriverExtensions.WaitUntilElementIsVisible(calendarPanelLocator, driver);
            return new PostPage(driver);
        }
        public PostPage clickOnSettings()
        {
            DriverExtensions.WaitUntilElementIsVisible(settingsButtonLocator, driver);
            settingsButton.Click();
            DriverExtensions.WaitUntilElementIsVisible(settingsPanelLocator, driver);
            return new PostPage(driver);
        }

        public PostPage clickOnPhotoGallery()
        {
            DriverExtensions.WaitUntilElementIsVisible(photoGalleryLocator, driver);
            photoGalleryButton.Click();
            DriverExtensions.WaitUntilElementIsVisible(photoGalleryTitleLocator, driver);
            return new PostPage(driver);
        }
        public PostPage LogOff()
        {
            closeButton.Click();
            return new PostPage(driver);
        }
    }
}
