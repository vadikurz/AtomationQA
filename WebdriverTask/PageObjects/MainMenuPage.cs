using OpenQA.Selenium;

namespace WebdriverTask.PageObjects
{
    public class MainMenuPage
    {
        private IWebDriver webDriver;

        private readonly By signInButton = By.XPath("//div[@id = 'mailbox']//button");

        public MainMenuPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public AuthorizationPage SignIn()
        {
            webDriver.FindElement(signInButton).Click();

            return new AuthorizationPage(webDriver);
        }
    }
}