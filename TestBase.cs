using AutoTestLeson1.Drivers;
using AutoTestLeson1.Page;
using AutoTestLeson1.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestLeson1.Test
{
    public class TestBase
    {
        public static IWebDriver _driver;
        public static DecathlonPage _page;


       [OneTimeSetUp]
        public static void SetUp()
        {
            _driver = CustomDriver.GetDriver(Browsers.Chrome);
            _page = new DecathlonPage(_driver);
        }

        [TearDown]
        public static void TakeScreenshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                MyScreenShot.MakeScreeshot(_driver);
            }
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _page.CloseBrowser();
        }
    }
}
