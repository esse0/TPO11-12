using Lab9.Driver;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Lab9.Tests
{
    public class CommonConditions
    {
        protected IWebDriver? driver;

        [SetUp]
        public void ChromeBrowserStart()
        {
            driver = DriverInstance.GetDriverInstance();
        }

        [TearDown]
        public void BrowserStop()
        {
            DriverInstance.CloseDriver();
        }
    }
}
