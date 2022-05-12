using System;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using WebdriverTask.Exceptions;

namespace WebdriverTask.PageObjects;

public class AuthorizationPage
{
    private IWebDriver webDriver;

    private readonly By loginInput = By.XPath("//input[@name='username']");
    private readonly By continueButon = By.XPath("//button[@data-test-id = 'next-button']");
    private readonly By passwordInput = By.XPath("//input[@name = 'password']");
    private readonly By submitButton = By.XPath("//button[@data-test-id = 'submit-button']");
    private readonly By loginFormFrame = By.XPath("//iframe[contains(@src, 'mail.ru/login')]");

    private readonly string invalidCredentialsMessageElement = "data-test-id=\"error-footer-text\"";
    


    public AuthorizationPage(IWebDriver webDriver)
    {
        this.webDriver = webDriver;
    }

    public MailBoxPage Login(string login, string password)
    {
        var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
        
        EnterLogin(login, wait);
        
        EnterPassword(password, wait);
        
        return new MailBoxPage(webDriver);
    }

    private void EnterLogin(string login, WebDriverWait wait)
    {
        webDriver.SwitchTo().Frame(webDriver.FindElement(loginFormFrame));
        
        wait.Until(ExpectedConditions.ElementIsVisible(loginInput));

        webDriver.FindElement(loginInput).SendKeys(login);
        
        webDriver.FindElement(continueButon).Click();

        Task.Delay(TimeSpan.FromSeconds(2)).Wait();

        if (CheckPresenceInvalidLoginMessageElement)
        {
            throw new InvalidUserLoginException("Invalid login");
        }
    }

    private void EnterPassword(string password, WebDriverWait wait)
    {
        wait.Until(ExpectedConditions.ElementIsVisible(passwordInput));

        webDriver.FindElement(passwordInput).SendKeys(password);
        
        webDriver.FindElement(submitButton).Click();
        
        Task.Delay(TimeSpan.FromSeconds(1)).Wait();
        
        if (CheckPresenceInvalidLoginMessageElement)
        {
            throw new InvalidUserPasswordException("Invalid password");
        }
    }

    public bool CheckPresenceInvalidLoginMessageElement => webDriver.PageSource.Contains(invalidCredentialsMessageElement);
}