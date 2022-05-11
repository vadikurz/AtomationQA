using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebdriverTask.PageObjects;

public class MailBoxPage
{
    private IWebDriver webDriver;

    private By userLogin = By.XPath("//div[@data-testid = 'whiteline-account']");

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
}