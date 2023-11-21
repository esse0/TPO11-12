using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Lab9
{
    internal class Tests
    {
        IWebDriver? driver;

        [SetUp]
        public void ChromeBrowserStart()
        {
            driver = new ChromeDriver
            {
                Url = "https://www.onliner.by/"
            };
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void TestCountOfGoodsInShoppingBasket()
        {
            var notebooksLink = driver?.FindElement(By.XPath("//*[@id=\"container\"]/div/div/div/div/div[1]/div/div[1]/ul[2]/li[1]/a"));
            notebooksLink?.Click();

            Thread.Sleep(1000);

            var notebookCardLink = driver?.FindElement(By.XPath(".//*[@class=\"schema-product__button button button_orange js-product-price-link\"]"));
            notebookCardLink?.Click();

            Thread.Sleep(2000);

            var addToShopingCartButton = driver?.FindElement(By.XPath("//*[@id=\"container\"]/div/div/div/div/div[2]/div[1]/main/div/div/div[2]/div[1]/div/div[3]/div/div[4]/div[3]/div/div/div[2]/div[1]/a[2]"));
            addToShopingCartButton?.Click();

            Thread.Sleep(1000);

            var shopingCardLink = driver?.FindElement(By.XPath("//*[@id=\"container\"]/div/div/div/div/div[2]/div[1]/main/div/div/div[2]/div[1]/div/div[3]/div/div[4]/div[3]/div/div[2]/div[2]/div[2]/div/div[3]/a[2]"));
            shopingCardLink?.Click();

            Thread.Sleep(1000);

            var shoppingCardCountField = driver?.FindElement(By.XPath("//div[@class='cart-form__control']//input[@type='text']"));

            shoppingCardCountField?.SendKeys("1000");

            Thread.Sleep(1000);

            _ = int.TryParse(shoppingCardCountField?.GetAttribute("value"), out int countOfProduct);

            driver?.Quit();

            Console.WriteLine(countOfProduct);

            Assert.IsTrue(countOfProduct < 100);
        }
    }
}
