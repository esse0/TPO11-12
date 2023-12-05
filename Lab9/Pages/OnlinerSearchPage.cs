using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace Lab9.Pages
{
    public class OnlinerSearchPage : PageObject
    {
        private const string ONLINERSEARCH_URL = "https://catalog.onliner.by/sdapi/catalog/search/iframe";

        private IWebElement? SearchBar
        {
            get => driver?.FindElement(By.XPath("//input[@class=\"search__input\"]"));
        }

        private By SearchResultBy
        {
            get => By.XPath("//ul[@class=\"search__results\"]//li");
        }

        public OnlinerSearchPage(IWebDriver? driver) : base(driver) { }

        public override OnlinerSearchPage OpenPage()
        {
            driver.Navigate().GoToUrl(ONLINERSEARCH_URL);
            return this;
        }

        public OnlinerSearchPage SearchItem(string itemName)
        {
            _ = new WebDriverWait(driver, TimeSpan.FromSeconds(15)).Until(driver => { return SearchBar; });

            SearchBar?.SendKeys(itemName);

            return this;
        }

        public int NumberOfFoundProducts()
        {
            var result = new WebDriverWait(driver, TimeSpan.FromSeconds(15))
                .Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(SearchResultBy));

            return result.Count;
        }
    }
}
