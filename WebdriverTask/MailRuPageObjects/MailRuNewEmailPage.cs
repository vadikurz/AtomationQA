using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebdriverTask.MailRuPageObjects;

public class MailRuNewEmailPage
{
    private IWebDriver webDriver;

    private readonly By textInput = By.XPath("//div[contains(@class, 'editable-container')]//br");
    private readonly By recipientInput = By.XPath("//div[contains(@class, 'contactsContainer')]//input");
    private readonly By sendButton = By.XPath("//button[@data-test-id = 'send']");

    public MailRuNewEmailPage(IWebDriver webDriver)
    {
        this.webDriver = webDriver;
    }

    public MailRuMailBoxPage SendEmail(string recipient, string text)
    {
        var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));

        wait.Until(ExpectedConditions.ElementIsVisible(recipientInput));

        webDriver.FindElement(recipientInput).SendKeys(recipient);
        webDriver.FindElement(textInput).SendKeys(text);
        webDriver.FindElement(sendButton).Click();

        return new MailRuMailBoxPage(webDriver);
    }
}