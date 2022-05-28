using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebdriverTask.PageObjects;

public class MailBoxPage
{
    private IWebDriver webDriver;

    private By userLogin = By.XPath("//div[@data-testid = 'whiteline-account']");
    private By NewEmailButton = By.XPath("//span[@class = 'compose-button__wrapper']");
    

    public MailBoxPage(IWebDriver webDriver)
    {
        this.webDriver = webDriver;
    }

    public string UserLogin()
    {
        var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
        
        wait.Until(ExpectedConditions.ElementIsVisible(userLogin));
        
        return webDriver.FindElement(userLogin).Text;
    }

    public NewEmailPage EnterNewEmailButton()
    {
        var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
        
        wait.Until(ExpectedConditions.ElementIsVisible(NewEmailButton));
        
        webDriver.FindElement(NewEmailButton).Click();
        
        return new NewEmailPage(webDriver);
    }
}