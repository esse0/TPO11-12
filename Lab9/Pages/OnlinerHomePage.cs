using OpenQA.Selenium;

namespace Lab9.Pages
{
    public class OnlinerHomePage : PageObject
    {
        private const string HOMEPAGE_URL = "https://www.onliner.by/";

        public OnlinerHomePage(IWebDriver driver) : base(driver) {
            driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 30);
        }

        public override OnlinerHomePage OpenPage()
        {
            driver.Navigate().GoToUrl(HOMEPAGE_URL);
            return this;
        }

        public NotebooksListPage OpenNotebooksPage()
        {
            return new NotebooksListPage(driver).OpenPage();
        }
    }
}
