using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestLeson1.Drivers
{
    class CustomDriver
    {
        public static IWebDriver GetChrome()
        {
            IWebDriver driver = new ChromeDriver();
            return driver;
        }

        public static IWebDriver GetFireFox()
        {
            IWebDriver driver = new FirefoxDriver();
            return driver;
        }
 
        public static IWebDriver GetIncognitoChrome()
        {
            return GetDriver(Browsers.ChromeIncognito);
        }
        private static IWebDriver GetChromeWithOptions()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArgument("incognito");

            return new ChromeDriver(options);
        }

        public static IWebDriver GetDriver(Browsers browser)
        {
            IWebDriver driver = null;
            switch (browser)
            {
                case Browsers.Chrome:
                    driver = GetChrome();
                    break;
                case Browsers.ChromeIncognito:
                    driver = GetChromeWithOptions();
                    break;

                case Browsers.Firefox:
                    driver = GetFireFox();
                    break;
                default:
                    driver = GetChrome();
                    break;      
            }
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;
        }
    }
}
