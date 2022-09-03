﻿using OpenQA.Selenium;

namespace Framework.PageObjects.GoogleCloudPageObjects
{
    public class MainPage : AbstractPage
    {
        private readonly By searchInput = By.XPath("//input[@placeholder = 'Search']");

        public MainPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public SearchResultsPage Search(string whatToFind)
        {
            webDriver.FindElement(searchInput).Click();
            webDriver.FindElement(searchInput).SendKeys(whatToFind);
            webDriver.FindElement(searchInput).SendKeys(Keys.Enter);

            return new SearchResultsPage(webDriver);
        }
    }
}