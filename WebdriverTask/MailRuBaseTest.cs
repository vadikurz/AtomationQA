using NUnit.Framework;

namespace WebdriverTask;

public class MailRuBaseTest : BaseTest
{
    [SetUp]
    protected void DoBeforeEach()
    {
        webDriver.Navigate().GoToUrl("https://mail.ru");
        webDriver.Manage().Window.Maximize();
    }
}