using Lab9.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Lab9.Tests
{
    public class Tests
    {
        IWebDriver? driver;

        [SetUp]
        public void ChromeBrowserStart()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        /*[Test]
        public void TestCountOfGoodsInShoppingBasket()
        {
            if (driver == null)
            {
                Assert.Fail("Driver not found!");
            }

            int countOfProducts = new OnlinerHomePage(driver)
                .OpenPage()
                .OpenShoppingCard()
                .InputItemsCount(1000)
                .CountItemsResultNumber();

            Assert.IsTrue(countOfProducts < 100);
        }*/

        [Test]
        public void PositiveTestSearch()
        {
            if (driver == null)
            {
                Assert.Fail("Driver not found!");
            }

            int numberOfFoundProducts = new OnlinerSearchPage(driver)
                .OpenPage()
                .SearchItem("chair")
                .NumberOfFoundProducts();

            Console.WriteLine(numberOfFoundProducts);

            Assert.True(numberOfFoundProducts > 0);
        }

        [TearDown]
        public void ChromeBrowserStop()
        {
            driver?.Quit();
        }
    }
}
