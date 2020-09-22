using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoTestLeson1.Page
{
    public class DecathlonPage : PageBase
    {
        private const string PageAddress = "https://www.decathlon.lt/";

        // 1
        private IWebElement _searchBar => driver.FindElement(By.Id("search"));
        private IWebElement _searchButton => driver.FindElement(By.CssSelector("#search_mini_form > div.input-box > button"));
        private IWebElement _searchLuresResult => driver.FindElement(By.CssSelector("#product_shop_319051"));
        private IWebElement _addToChartButton => driver.FindElement(By.Id("addtocart"));
        private IWebElement _goToChart => driver.FindElement(By.CssSelector("#header > div.page-header-container > div > div.header-right > div > div.header-minicart.dropdown.dropdown--right > a > span.label"));
        private IWebElement _checkoutButton => driver.FindElement(By.CssSelector("#header-cart > div.minicart-wrapper > div.minicart-bottom > div.minicart-actions > ul > li > a"));
        private SelectElement _quantityChange => new SelectElement(driver.FindElement(By.ClassName("qty-change")));
        private IWebElement _singlePrice => driver.FindElement(By.CssSelector("#item-1593155 > td.product-cart-price.product-cart-total-price > span > span"));
        private IWebElement _totalPrice => driver.FindElement(By.CssSelector("#item-1593155 > td.product-cart-total > span > span"));
        
        // 2
        private SelectElement _selectTool => new SelectElement(driver.FindElement(By.Id("selecttool")));
        private IWebElement _sortedExpensiveBallPrice => driver.FindElement(By.CssSelector("#product-price-480483 > span"));

        // 3
        private IWebElement _myStore => driver.FindElement(By.CssSelector("#header-links > ul > li.store > a"));
        private IWebElement _storeVilnius => driver.FindElement(By.CssSelector("#country-list-wrapper > div > div > div > div > a"));
        private IWebElement _addressFirstLine => driver.FindElement(By.CssSelector("#country-list-wrapper > div > div > div > div > div:nth-child(2)"));
        private IWebElement _lowestElement => driver.FindElement(By.CssSelector("body > div.wrapper > div > div.page-footer > div.footer--bottom.clearfix > div > div.footer--menu > div > ul > li:nth-child(1) > a"));
        private IWebElement _saturdayClosingTime => driver.FindElement(By.CssSelector("#your-shop > div > div.st-p-main > div:nth-child(1) > div:nth-child(2) > ul > li:nth-child(6) > span.schedule > big:nth-child(3)"));
        
        // 4
        private IWebElement _searchGlasesResult => driver.FindElement(By.CssSelector("#product-collection-image-435126"));
        private IWebElement _reserveButton => driver.FindElement(By.CssSelector("#product_shop > div.product-shop__box.product-shop__box--buy > div > div:nth-child(2) > a.btn-stock-store.cta-v2.button.step1"));
        private IWebElement _reserve5HButton => driver.FindElement(By.CssSelector("#step1 > div > div.content > div > a"));
        private IWebElement _reserveFormFirstname => driver.FindElement(By.Id("reserveForm_firstname"));
        private IWebElement _reserveFormLastname => driver.FindElement(By.Id("reserveForm_lastname"));
        private IWebElement _agreeReservButton => driver.FindElement(By.XPath("//button[@id='subform']"));
        private IWebElement _reserveFormEmailError => driver.FindElement(By.Id("reserveForm_email-error"));
        private IWebElement _reserveFormPhoneError => driver.FindElement(By.Id("reserveForm_phone-error"));

        // 5
        private IWebElement _searchBowResult => driver.FindElement(By.CssSelector("#product-collection-image-421401"));
        private IWebElement _reviewnumber => driver.FindElement(By.CssSelector("#product-review > div > div.small-12.columns.product-section__content-container > div.review-stats > div.review-stats__avg > div.review-stats__numbers > div.review-number > span"));

        
        public DecathlonPage(IWebDriver webdriver) : base(webdriver)
        { }
        public DecathlonPage NavigateToPage()
        {
            if (driver.Url != PageAddress)
                driver.Url = PageAddress;
            return this;
        }

        // Test 1 stuff
        public DecathlonPage InsertSearch(string income)
        {
            _searchBar.Clear();
            _searchBar.SendKeys(income);
            return this;
        }
        public DecathlonPage ClickSearch()
        {
            _searchButton.Click();
            return this;
        }
        public DecathlonPage ClickSearchResult()
        {
            _searchLuresResult.Click();
            return this;
        }
        public DecathlonPage AddToChart()
        {
            Thread.Sleep(2000);
            _addToChartButton.Click();
            Thread.Sleep(2000);
            return this;
        }
        [Obsolete]
        public DecathlonPage GoToChart()
        {
            GetWait(3).Until(ExpectedConditions.ElementToBeClickable(_goToChart));
            _goToChart.Click();
            GetWait(3).Until(ExpectedConditions.ElementToBeClickable(_checkoutButton));
            _checkoutButton.Click();
            return this;
        }
        public DecathlonPage SelectQuantity(string value)
        {
            _quantityChange.SelectByValue(value);
            return this;
        }
        public DecathlonPage AssertTotalPrice(string units)
        {
            Thread.Sleep(2000);
            string prepareResult1 = _singlePrice.Text.Replace(",", "").Replace("€", "").Trim();
            string prepareResult2 = _totalPrice.Text.Replace(",", "").Replace("€", "").Trim();
            int howManyUnitsSelected = Convert.ToInt32(units);
            int singlePrice = Int32.Parse(prepareResult1);
            int totalPrice = Int32.Parse(prepareResult2);
            int countedprice = singlePrice * howManyUnitsSelected;
            Assert.IsTrue(countedprice == totalPrice, "Prise is not correct");
            return this;
        }

        // Test 2 stuff
        public DecathlonPage SortingByPriceHighToLow(string sorting)
        {
            string HidhToLow = "High to Low";
            if (HidhToLow == sorting)
            {
                _selectTool.SelectByValue("https://www.decathlon.lt/lt_lt/catalogsearch/result/index/?dir=desc&order=price&q=Kamuolys");
                return this;
            }
            return this;
        }

        public DecathlonPage AssertBallPrice(double result)
        {
            string prepareWebResult = _sortedExpensiveBallPrice.Text.Replace(",", "").Replace("€", "").Trim();
            Assert.IsTrue((Int32.Parse(prepareWebResult) / 100) <= result, "You dont have money for expensive ball");
            return this;
        }

        // Test 3 stuff
        public DecathlonPage ClinkMyStore()
        {
            _myStore.Click();
            return this;
        }

        public DecathlonPage AssertAddressFirstLine(string shopAddress)
        {
            var builder = new Actions(driver);
            builder.MoveToElement(_lowestElement);
            builder.Build().Perform();
            Assert.AreEqual(shopAddress, _addressFirstLine.Text, "Address dont match");
            return this;
        }

        [Obsolete]
        public DecathlonPage ClickOnVilniusStore()
        {
            GetWait(3).Until(ExpectedConditions.ElementToBeClickable(_storeVilnius));
            _storeVilnius.Click();
            return this;
        }

        public DecathlonPage AssertShopTime(int wantedHour)
        {
            Assert.IsTrue(Int32.Parse(_saturdayClosingTime.Text) > wantedHour, "Shop is closed at your wanted hour");
            return this;
        }

        // Test 4 stuff
        [Obsolete]
        public DecathlonPage ClickGlasesSearchResult()
        {
            GetWait(2).Until(ExpectedConditions.ElementToBeClickable(_searchGlasesResult));
            _searchGlasesResult.Click();
            return this;
        }
        [Obsolete]
        public DecathlonPage ClickReserveButton()
        {
            GetWait(3).Until(ExpectedConditions.ElementToBeClickable(_reserveButton));
            _reserveButton.Click();
            return this;
        }

        [Obsolete]
        public DecathlonPage ClickReserve5HButton()
        {
            GetWait(3).Until(ExpectedConditions.ElementToBeClickable(_reserve5HButton));
            _reserve5HButton.Click();
            return this;
        }

        public DecathlonPage InsertReserveFirstName(string income)
        {
            _reserveFormFirstname.Clear();
            _reserveFormFirstname.SendKeys(income);
            return this;
        }

        public DecathlonPage InsertReserveLastName(string income)
        {
            _reserveFormLastname.Clear();
            _reserveFormLastname.SendKeys(income);
            return this;
        }

        [Obsolete]
        public DecathlonPage ClickAgreeReserveButton()
        {
            GetWait(3).Until(ExpectedConditions.ElementToBeClickable(_agreeReservButton));
            _agreeReservButton.Click();
            return this;
        }

        public DecathlonPage AssertReservationErrors()
        {
            string emailError = "Please enter a valid email address";
            string phoneError = "Please enter your phone number";
            Assert.AreEqual(emailError, _reserveFormEmailError.Text, "Email error dont match");
            Assert.AreEqual(phoneError, _reserveFormPhoneError.Text, "Phone error dont match");
            return this;
        }

        // Test 5 stuff
        [Obsolete]
        public DecathlonPage ClickBowSearchResult()
        {
            GetWait(3).Until(ExpectedConditions.ElementToBeClickable(_searchBowResult));
            _searchBowResult.Click();
            return this;
        }

        public DecathlonPage AssertBowReviewCount(int expectedReviewCount)
        {
            Assert.IsTrue(Int32.Parse(_reviewnumber.Text) > expectedReviewCount, "There is less review then expected");
            return this;
        }

    }
}
