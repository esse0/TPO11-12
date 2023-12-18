using Lab9.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Lab9.Pages
{
    public class NotebooksListPage : PageObject
    {
        private const string NOTEBOOKSPAGE_URL = "https://catalog.onliner.by/notebook";

        private IWebElement NotebookItemLink
        {
            get => driver.FindElement(By.XPath(".//*[@class=\"schema-product__button button button_orange js-product-price-link\"]"));
        }

        private IWebElement DiscountFilterCheckbox
        {
            get => driver.FindElement(By.XPath("//label[@class='schema-filter__bonus-item schema-filter__bonus-item_additional']"));
        }

        private By ToComparisonPagePath
        {
            get => By.XPath("//a[@class='compare-button__sub compare-button__sub_main']");
        }

        private By NotebookCardTitlesPath
        {
            get => By.XPath("//div[@class='schema-product__group']//a[@class='js-product-title-link']/span");
        }

        private By ProductCheckboxPath
        {
            get => By.XPath("//label[@class='schema-product__control']");
        }

        public NotebooksListPage(IWebDriver driver) : base(driver) { }

        public NotebookItemPage OpenNotebookItemPage()
        {
            _ = new WebDriverWait(driver, TimeSpan.FromSeconds(15)).Until(driver => { return NotebookItemLink; });
           
            NotebookItemLink.Click();

            return new NotebookItemPage(driver);
        }

        public NotebooksListPage SelectDiscountProducts()
        {
            var discountFilterCheckbox = new WebDriverWait(driver, TimeSpan.FromSeconds(15)).Until(driver => { return DiscountFilterCheckbox; });

            discountFilterCheckbox.Click();

            Thread.Sleep(1000);

            return this;
        }

        public NotebooksListPage AddProductsToComparison()
        {
            var productCheckBoxes = new WebDriverWait(driver, TimeSpan.FromSeconds(15))
                 .Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(ProductCheckboxPath));
            
            productCheckBoxes[0].Click();
            productCheckBoxes[1].Click();

            return this;
        }

        public ComparisonPage openComparisonPage()
        {
            var toComparasionPageButton = new WebDriverWait(driver, TimeSpan.FromSeconds(15))
                .Until(ExpectedConditions.ElementToBeClickable(ToComparisonPagePath));
            Thread.Sleep(1000);
            toComparasionPageButton.Click();

            return new ComparisonPage(driver).OpenPage();
        }

        public bool IsNotebookFilterRight(NotebookProducer notebookProducer)
        {
            string notebookProducerName = getNotebookProducerName(notebookProducer);

            driver.Navigate().GoToUrl(NOTEBOOKSPAGE_URL + "/" + notebookProducerName);

            var notebookCardTitles = new WebDriverWait(driver, TimeSpan.FromSeconds(15))
                 .Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(NotebookCardTitlesPath));

            return notebookCardTitles.All(el => el.Text.ToLower().Contains(notebookProducerName));
        }

        private string getNotebookProducerName(NotebookProducer notebookProducer)
        {
            return notebookProducer switch
            {
                NotebookProducer.LENOVO => "lenovo",
                NotebookProducer.ASUS => "asus",
                NotebookProducer.APPLE => "apple",
                NotebookProducer.ACER => "acer",
                NotebookProducer.XIAOMI => "xiaomi",
                NotebookProducer.HUAWEI => "huawei",
                NotebookProducer.HP => "hp",
                NotebookProducer.MSI => "msi",
                _ => "lenovo",
            };
        }

        public override NotebooksListPage OpenPage()
        {
            driver.Navigate().GoToUrl(NOTEBOOKSPAGE_URL);
            return this;
        }
    }
}
