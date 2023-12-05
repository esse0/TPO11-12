using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Lab9.Pages
{
    public class ShoppingCardPage : PageObject
    {
        private const string SHOPPINGCARDPAGE_URL = "https://cart.onliner.by/";
        private IWebElement ShoppingCardCountField
        {
            get => driver.FindElement(By.XPath("//div[@class='cart-form__control']//input[@type='text']"));
        }
        public ShoppingCardPage(IWebDriver driver) : base(driver) { }

        public ShoppingCardPage InputItemsCount(int count)
        {
            _ = new WebDriverWait(driver, TimeSpan.FromSeconds(15)).Until(driver => { return ShoppingCardCountField; });

            ShoppingCardCountField.SendKeys($"{count}");
            return this;
        }

        public int CountItemsResultNumber()
        {
            return int.Parse(ShoppingCardCountField.GetAttribute("value"));
        }

        public override ShoppingCardPage OpenPage()
        {
            driver.Navigate().GoToUrl(SHOPPINGCARDPAGE_URL);
            return this;
        }
    }
}
