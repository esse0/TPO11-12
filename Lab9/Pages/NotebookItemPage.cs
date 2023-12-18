using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Lab9.Pages
{
    public class NotebookItemPage : PageObject
    {
        private const string NOTEBOOKITEMPAGE_URL = "https://catalog.onliner.by/notebook/honor/5301afvl";

        private IWebElement AddItemToCardButton
        {
            get => driver.FindElement(By.XPath("//*[@id=\"container\"]/div/div/div/div/div[2]/div[1]/main/div/div/div[2]/div[1]/div/div[3]/div/div[4]/div[3]/div/div/div[2]/div[1]/a[2]"));
        }

        private List<IWebElement> PriceGroup
        {
            get => new WebDriverWait(driver, TimeSpan.FromSeconds(15))
                 .Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(
                     By.XPath("//div[@class='offers-description__price-group']/div"))).ToList();
        }

        private IWebElement AsideElementToCardButton
        {
            get => driver.FindElement(By.XPath("//div[@class=\"product-recommended__sidebar-aside\"]//a[@href]"));
        }

        private IWebElement DiscountPercentageElement
        {
            get => driver.FindElement(By.XPath("//div[@class='offers-description__hot']"));
        }

        public NotebookItemPage(IWebDriver driver) : base(driver) { }

        public NotebookItemPage AddItemToCard()
        {
            _ = new WebDriverWait(driver, TimeSpan.FromSeconds(15)).Until(driver => { return AddItemToCardButton; });

            AddItemToCardButton.Click();
            return this;
        }

        public bool CompareOldPriceWithPromotionalPrice()
        {
            string discountPercentageStr = DiscountPercentageElement.GetAttribute("innerText").Substring(1);
            discountPercentageStr = discountPercentageStr.Substring(0, discountPercentageStr.Length - 1);

            int discountPercentage = int.Parse(discountPercentageStr);

            string newPriceStr = PriceGroup[0].GetAttribute("innerText").Split(',')[0];
            string oldPriceStr = PriceGroup[1].GetAttribute("innerText").Split(',')[0];

            int newPrice = int.Parse(newPriceStr);
            int oldPrice = int.Parse(oldPriceStr);

            int priceDifference = (oldPrice - ((oldPrice / 100) * discountPercentage)) - newPrice;

            return priceDifference > -50 && priceDifference < 50;
        }

        public ShoppingCardPage OpenShoppingCard()
        {
            _ = new WebDriverWait(driver, TimeSpan.FromSeconds(15)).Until(driver => { return AsideElementToCardButton; });

            AsideElementToCardButton.Click();

            return new ShoppingCardPage(driver);
        }

        public override NotebookItemPage OpenPage()
        {
            driver.Navigate().GoToUrl(NOTEBOOKITEMPAGE_URL);
            return this;
        }
    }
}
