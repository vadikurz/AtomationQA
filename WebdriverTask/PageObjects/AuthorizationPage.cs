using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebdriverTask.PageObjects;

public class AuthorizationPage
{
    private IWebDriver webdriver;

    private readonly By loginInput = By.XPath("//input[@name='username']");
    private readonly By continueButon = By.XPath("//button[@data-test-id = 'next-button']");
    private readonly By passwordInput = By.XPath("//input[@name = 'password']");
    private readonly By submitButton = By.XPath("//button[@data-test-id = 'submit-button']");
    private readonly By loginFormFrame = By.XPath("//iframe[contains(@src, 'mail.ru/login')]");
    
    public AuthorizationPage(IWebDriver webdriver)
    {
        this.webdriver = webdriver;
    }

    public MailBoxPage Login(string login, string password)
    {
        webdriver.SwitchTo().Frame(webdriver.FindElement(loginFormFrame));
        
        var wait = new WebDriverWait(webdriver, TimeSpan.FromSeconds(10));
        wait.Until(ExpectedConditions.ElementIsVisible(loginInput));

        webdriver.FindElement(loginInput).SendKeys(login);

        webdriver.FindElement(continueButon).Click();

        wait.Until(ExpectedConditions.ElementIsVisible(passwordInput));

        webdriver.FindElement(passwordInput).SendKeys(password);
        webdriver.FindElement(submitButton).Click();

        return new MailBoxPage(webdriver);
    }
}