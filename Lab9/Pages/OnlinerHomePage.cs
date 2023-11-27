using OpenQA.Selenium;

namespace Lab9.Pages
{
    public class OnlinerHomePage : PageObject
    {
        private const string HOMEPAGE_URL = "https://www.onliner.by/";

        private IWebElement NotebooksLink
        {
            get => driver.FindElement(By.XPath("//*[@id=\"container\"]/div/div/div/div/div[1]/div/div[1]/ul[2]/li[1]/a"));
        }

        private IWebElement NotebookCardLink
        {
            get => driver.FindElement(By.XPath(".//*[@class=\"schema-product__button button button_orange js-product-price-link\"]"));
        }

        private IWebElement AddItemToCard
        {
            get => driver.FindElement(By.XPath("//*[@id=\"container\"]/div/div/div/div/div[2]/div[1]/main/div/div/div[2]/div[1]/div/div[3]/div/div[4]/div[3]/div/div/div[2]/div[1]/a[2]"));

        }

        private IWebElement ShoppingCardCountField
        {
            get => driver.FindElement(By.XPath("//div[@class='cart-form__control']//input[@type='text']"));
        }

        public OnlinerHomePage(IWebDriver driver) : base(driver) {
            driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 30);
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 30);
        }

        public override OnlinerHomePage OpenPage()
        {
            driver.Navigate().GoToUrl(HOMEPAGE_URL);
            return this;
        }

        public OnlinerHomePage OpenShoppingCard()
        {
            NotebooksLink.Click();
            NotebookCardLink.Click();
            AddItemToCard.Click();
            Thread.Sleep(3000);
            driver.Navigate().GoToUrl("https://cart.onliner.by/");

            return this;
        }

        public OnlinerHomePage InputItemsCount(int count)
        {
            ShoppingCardCountField.SendKeys($"{count}");
            return this;
        }

        public int CountItemsResultNumber()
        {
            return int.Parse(ShoppingCardCountField.GetAttribute("value"));
        }
    }
}
