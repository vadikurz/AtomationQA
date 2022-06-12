using OpenQA.Selenium;

namespace WebdriverTask.MailRuPageObjects
{
    public class MailRuMainMenuPage
    {
        private IWebDriver webDriver;

        private readonly By signInButton = By.XPath("//div[@id = 'mailbox']//button");

        public MailRuMainMenuPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public MailRuAuthorizationPage SignIn()
        {
            webDriver.FindElement(signInButton).Click();

            return new MailRuAuthorizationPage(webDriver);
        }
    }
}