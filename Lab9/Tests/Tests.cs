using Lab9.Model;
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

        [Test]
        public void PositiveSearchTest()
        {
            int numberOfFoundProducts = new OnlinerSearchPage(driver)
                .OpenPage()
                .SearchItem("chair")
                .NumberOfFoundProducts();

            Assert.True(numberOfFoundProducts > 0);
        }

        [Test]
        public void GoodsFilterTest()
        {
            bool isSearchResultRight = new OnlinerHomePage(driver)
                .OpenPage()
                .OpenNotebooksPage()
                .IsNotebookFilterRight(Model.NotebookProducer.APPLE);

            Assert.True(isSearchResultRight);
        }

        [Test]
        public void ComparisonOfProductsTest()
        {
            int countCompareProducts = new OnlinerHomePage(driver).OpenPage()
                .OpenNotebooksPage()
                .AddProductsToComparison()
                .openComparisonPage()
                .GetCountOfCompareProducts();
                
            Assert.True(countCompareProducts > 2);
        }

        [Test]
        public void PromotionalPriceTest()
        {
            bool priceIsRight = new OnlinerHomePage(driver).OpenPage()
                .OpenNotebooksPage()
                .SelectDiscountProducts()
                .OpenNotebookItemPage()
                .CompareOldPriceWithPromotionalPrice();

            Assert.True(priceIsRight);
        }
    }
}
