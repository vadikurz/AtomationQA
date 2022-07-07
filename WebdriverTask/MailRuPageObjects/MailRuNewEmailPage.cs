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
    private readonly By closeUndoWindowButton = By.XPath("//span[@title = 'Закрыть']");

    public MailRuNewEmailPage(IWebDriver webDriver)
    {
        this.webDriver = webDriver;
    }

    public MailRuMailBoxPage SendEmail(string recipient, string text)
    {
        var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));

        wait.Until(ExpectedConditions.ElementIsVisible(recipientInput)).SendKeys(recipient);
        
        webDriver.FindElement(textInput).SendKeys(text);
        webDriver.FindElement(sendButton).Click();
        
        CloseUndoSendWindow();

        return new MailRuMailBoxPage(webDriver);
    }

    private void CloseUndoSendWindow()
    {
        var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));

        wait.Until(ExpectedConditions.ElementIsVisible(closeUndoWindowButton)).Click();
    }
}