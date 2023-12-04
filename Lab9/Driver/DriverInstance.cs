using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Lab9.Driver
{
    public class DriverInstance
    {
        private static IWebDriver? driver = null;

        public DriverInstance() { }

        public static IWebDriver? GetDriverInstance(string browser = "chrome")
        {
            if (driver == null)
            {
                switch (browser)
                {
                    case "firefox":
                    {
                        new DriverManager().SetUpDriver(new FirefoxConfig());
                        driver = new FirefoxDriver();
                        break;
                    }
                    default:
                    {
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        driver = new ChromeDriver();
                        break;
                    }
                }
            }

            driver?.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(30));
            driver?.Manage().Window.Maximize();

            return driver;
        }

        public static void CloseDriver()
        {
            driver?.Quit();
            driver = null;
        }
    }
}
