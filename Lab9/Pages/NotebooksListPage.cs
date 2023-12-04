using OpenQA.Selenium;

namespace Lab9.Pages
{
    public class NotebooksListPage : PageObject
    {
        private const string NOTEBOOKSPAGE_URL = "https://catalog.onliner.by/notebook";

        private IWebElement NotebookItemLink
        {
            get => driver.FindElement(By.XPath(".//*[@class=\"schema-product__button button button_orange js-product-price-link\"]"));
        }

        public NotebooksListPage(IWebDriver driver) : base(driver) { }

        public NotebookItemPage OpenNotebookItemPage()
        {
            NotebookItemLink.Click();

            return new NotebookItemPage(driver);
        }

        public override NotebooksListPage OpenPage()
        {
            driver.Navigate().GoToUrl(NOTEBOOKSPAGE_URL);
            return this;
        }
    }
}
