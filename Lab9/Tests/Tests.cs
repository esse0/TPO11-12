using Lab9.Pages;
using NUnit.Framework;

namespace Lab9.Tests
{
    public class Tests : CommonConditions
    {
        [Test]
        public void TestCountOfGoodsInShoppingBasket()
        {
            int countOfProducts = new OnlinerHomePage(driver)
                .OpenPage()
                .OpenNotebooksPage()
                .OpenNotebookItemPage()
                .AddItemToCard()
                .OpenShoppingCard()
                .InputItemsCount(1000)
                .CountItemsResultNumber();

            Assert.IsTrue(countOfProducts < 100);
        }

        /*[Test]
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

            Assert.True(numberOfFoundProducts > 0);
        }*/
    }
}
