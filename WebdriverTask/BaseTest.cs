using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebdriverTask;

public abstract class BaseTest
{
    protected IWebDriver webDriver;

    [OneTimeSetUp]
    protected void DoBeforeAllTests()
    {
        webDriver = new ChromeDriver();
    }
    
    [TearDown]
    protected void DoAfterEach()
    {
        webDriver.Manage().Cookies.DeleteAllCookies();
    }

    [OneTimeTearDown]
    protected void DoAfterAllTests()
    {
        webDriver.Quit();
    }
}