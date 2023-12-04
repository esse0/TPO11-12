using OpenQA.Selenium;
using System.Collections.ObjectModel;


namespace Lab9.Pages
{
    public class OnlinerSearchPage : PageObject
    {
        private const string HOMEPAGE_URL = "https://www.onliner.by/";

        private IWebElement? SearchBar
        {
            get => driver?.FindElement(By.XPath("//*[@class=\"fast-search__input\"]"));
        }

        private ReadOnlyCollection<IWebElement>? SearchResult
        {
            get => driver?.FindElements(By.XPath("//*[@class=\"search__result\"]"));
        }

        public OnlinerSearchPage(IWebDriver? driver) : base(driver)
        {
            driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 20);
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 30);
        }

        public override OnlinerSearchPage OpenPage()
        {
            driver.Navigate().GoToUrl(HOMEPAGE_URL);
            return this;
        }

        public OnlinerSearchPage SearchItem(string itemName)
        {
            SearchBar.SendKeys(itemName);
            return this;
        }

        public int NumberOfFoundProducts()
        {
            return SearchResult.Count;
        }
    }
}
