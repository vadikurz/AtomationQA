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
        
    }
    
    [TearDown]
    protected void DoAfterEach()
    {
        webDriver.Quit();
    }

    [OneTimeTearDown]
    protected void DoAfterAllTests()
    {
        
    }
}