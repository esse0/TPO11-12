using OpenQA.Selenium;

namespace Lab9.Pages
{
    public abstract class PageObject
    {
        protected readonly IWebDriver? driver;

        public PageObject(IWebDriver? driver)
        {
            this.driver = driver;
        }

        public abstract PageObject OpenPage();
    }
}
