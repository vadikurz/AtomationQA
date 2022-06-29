using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebdriverTask.MailRuPageObjects;

public class MailRuMailBoxPage
{
    private IWebDriver webDriver;

    private readonly By sideBarButton = By.XPath("//div[@data-testid = 'whiteline-account']");
    private readonly By NewEmailButton = By.XPath("//span[@class = 'compose-button__wrapper']");
    private readonly By messages = By.XPath("//div/a[contains(@href,'/inbox/')]");
    private readonly By searchButton = By.XPath("//div[@class = 'search-panel__right-col']");
    private readonly By searchInput = By.XPath("//input[contains(@class,'mail-operands')]");
    private readonly By findButton = By.XPath("//span[text() = 'Найти']");
    private readonly By messageText = By.XPath("//div[contains(@class,'js-readmsg')]//div[@class]/div");
    private readonly By personalDataButton = By.XPath("//div[text()='Личные данные']");
    private readonly By nickNameInput = By.XPath("//input[@id = 'nickname']");
    private readonly By saveButton = By.XPath("//button[@data-test-id = 'save-button']");
   
    public MailRuMailBoxPage(IWebDriver webDriver)
    {
        this.webDriver = webDriver;
    }

    public string UserLogin()
    {
        var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));

        wait.Until(ExpectedConditions.ElementIsVisible(sideBarButton));

        return webDriver.FindElement(sideBarButton).Text;
    }

    public MailRuNewEmailPage EnterNewEmailButton()
    {
        var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));

        wait.Until(ExpectedConditions.ElementIsVisible(NewEmailButton));

        webDriver.FindElement(NewEmailButton).Click();

        return new MailRuNewEmailPage(webDriver);
    }

    private IWebElement FindNewMessageBySender(string sender)
    {
        var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(7));
        wait.Until(ExpectedConditions.ElementToBeClickable(searchButton)).Click();
        
        wait.Until(ExpectedConditions.ElementIsVisible(searchInput)).SendKeys(sender);
        webDriver.FindElement(findButton).Click();

        wait.Until(ExpectedConditions.ElementIsVisible(messages));
        return webDriver.FindElements(messages).First();
    }

    public string ReadMessage(string sender)
    { 
        FindNewMessageBySender(sender).Click();
        
        var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(7));
        
        return wait.Until(ExpectedConditions.ElementIsVisible(messageText)).Text;
    }

    public void RenameUser(string newUserFirstName)
    {
        var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
        
        webDriver.FindElement(sideBarButton).Click();
        
        wait.Until(ExpectedConditions.ElementIsVisible(personalDataButton)).Click();

        var input = wait.Until(ExpectedConditions.ElementIsVisible(nickNameInput));
        input.Clear();
        input.SendKeys(newUserFirstName);
        
        webDriver.FindElement(saveButton).Click();
    }

    public string GetUserNickName()
    {
        return webDriver.FindElement(nickNameInput).GetAttribute("value");
    }
}