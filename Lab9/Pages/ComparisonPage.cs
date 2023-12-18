using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Lab9.Pages
{
    public class ComparisonPage : PageObject
    {
        public ComparisonPage(IWebDriver? driver) : base(driver)
        {
        }

        private By NotebookCardsPath
        {
            get => By.XPath("//span[@class='product-summary__caption']");
        }

        public override ComparisonPage OpenPage()
        {
            return this;
        }

        public int GetCountOfCompareProducts()
        {
            var productCards = new WebDriverWait(driver, TimeSpan.FromSeconds(15))
                 .Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(NotebookCardsPath));

            return productCards.ToArray().Length;
        }
    }
}
