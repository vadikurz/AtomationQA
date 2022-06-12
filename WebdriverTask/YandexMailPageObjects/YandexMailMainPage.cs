using OpenQA.Selenium;

namespace WebdriverTask.YandexMailPageObjects;

public class YandexMailMainPage
{
    private IWebDriver webDriver;
    
    private readonly By signInButton = By.XPath("//a[contains(@class, 'HeadBanner-Button') and contains(@href, 'auth')]");

    public YandexMailMainPage(IWebDriver webDriver)
    {
        this.webDriver = webDriver;
    }

    public YandexAuthorizationPage SignIn()
    {
        webDriver.FindElement(signInButton).Click();

        return new YandexAuthorizationPage(webDriver);
    }
}