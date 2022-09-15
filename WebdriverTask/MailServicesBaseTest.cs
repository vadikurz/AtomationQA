﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebdriverTask;

public class MailServicesBaseTest
{
    protected IWebDriver webDriver;
    
    [SetUp]
    protected void DoBeforeEach()
    {
        webDriver = new ChromeDriver();
        webDriver.Manage().Cookies.DeleteAllCookies();
        webDriver.Navigate().GoToUrl("https://mail.ru");
        webDriver.Manage().Window.Maximize();
    }
    
    [TearDown]
    protected void DoAfterEach()
    {
        webDriver.Quit();
    }
}