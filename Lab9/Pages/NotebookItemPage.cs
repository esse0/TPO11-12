using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Lab9.Pages
{
    public class NotebookItemPage : PageObject
    {
        private const string NOTEBOOKITEMPAGE_URL = "https://catalog.onliner.by/notebook/honor/5301afvl";

        private IWebElement AddItemToCardButton
        {
            get => driver.FindElement(By.XPath("//*[@id=\"container\"]/div/div/div/div/div[2]/div[1]/main/div/div/div[2]/div[1]/div/div[3]/div/div[4]/div[3]/div/div/div[2]/div[1]/a[2]"));
        }

        private IWebElement AsideElementToCardButton
        {
            get => driver.FindElement(By.XPath("//div[@class=\"product-recommended__sidebar-aside\"]//a[@href]"));
        }

        public NotebookItemPage(IWebDriver driver) : base(driver) { }

        public NotebookItemPage AddItemToCard()
        {
            _ = new WebDriverWait(driver, TimeSpan.FromSeconds(15)).Until(driver => { return AddItemToCardButton; });

            AddItemToCardButton.Click();
            return this;
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
