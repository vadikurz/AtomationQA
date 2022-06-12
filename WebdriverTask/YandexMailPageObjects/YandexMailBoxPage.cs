using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebdriverTask.YandexMailPageObjects;

public class YandexMailBoxPage
{
    private IWebDriver webDriver;
    
    private readonly By messages = By.XPath("//div[@class = 'mail-MessageSnippet-Content']");
    private readonly By allMessages = By.XPath("//div[contains(@class, 'mail-MessagesList')]");
    private readonly By messageContainer = By.XPath("//div[contains(@class, 'MessageBody')]");
    
    public YandexMailBoxPage(IWebDriver webDriver)
    {
        this.webDriver = webDriver;
    }

    private IWebElement FindNewMessageBySender(string sender)
    {
        return webDriver
            .FindElements(messages)
            .First(message => message
                                  .FindElements(By.TagName("span"))
                                  .Select(span => span.GetAttribute("title")).Any(title => title.Contains(sender)) &&
                              message
                                  .FindElements(By.TagName("span"))
                                  .Select(span => span.GetAttribute("class")).Any(_class => _class.Contains("is-active")));
    }

    public string MessageText()
    {
        var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
        wait.Until(ExpectedConditions.ElementIsVisible(messageContainer));
        var div = webDriver
            .FindElement(messageContainer)
            .FindElements(By.TagName("div"))
            .First(div => !div.Text.Contains("&nbsp"));
        
        return div.Text == String.Empty ? div.FindElement(By.TagName("span")).Text : div.Text;
    }

    public string ReadMessage(string sender)
    {
        var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
        wait.Until(ExpectedConditions.ElementIsVisible(allMessages));
        
        FindNewMessageBySender(sender).Click();

        return MessageText();
    }
}