using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestLeson1.Page
{
    public class SenukaiPage : PageBase
    {
        private const string PageAddress = "https://www.senukai.lt/";

        private IWebElement _searchContacts => driver.FindElement(By.CssSelector("body > div.site > div.site-top > div > ul > li:nth-child(2) > a"));
        private IWebElement _searchSenukaiAddress => driver.FindElement(By.CssSelector("#block_90 > div > div:nth-child(16)"));
        public SenukaiPage(IWebDriver webdriver) : base(webdriver)
        { }
        public SenukaiPage NavigateToPage()
        {
            if (driver.Url != PageAddress)
                driver.Url = PageAddress;
            return this;
        }
        public SenukaiPage ClickContacts()
        {
            _searchContacts.Click();
            return this;
        }
        public SenukaiPage AssertSenukaiAddress(string address)
        {
            Assert.AreEqual(address, _searchSenukaiAddress.Text, "Address dont match");
            return this;
        }
    }
}
