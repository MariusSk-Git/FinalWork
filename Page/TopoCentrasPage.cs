using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestLeson1.Page
{
    public class TopoCentrasPage : PageBase
    {

        private const string PageAddress = "https://www.topocentras.lt/";

        private IWebElement _searchInsert => driver.FindElement(By.ClassName("HeaderContent-searchInput-3Ks"));
        private IWebElement _searchButton => driver.FindElement(By.ClassName("HeaderContent-searchButton-1mR"));

        private IWebElement _searchResult => driver.FindElement(By.ClassName("CategoryPage-categoryTitle-1-b"));
        private SelectElement _selectTool => new SelectElement(driver.FindElement(By.ClassName("Sort-selectBox-2qH")));

        private IWebElement _sortedUSBPrice => driver.FindElement(By.CssSelector("#categoryPage > div:nth-child(1) > div.ProductGrid-productContainer-3sR.ProductGrid-productFeatured-13f > div.ProductGrid-productPrice-1wU > div > div > span"));

        
        public TopoCentrasPage(IWebDriver webdriver) : base(webdriver)
        { }
        public TopoCentrasPage NavigateToPage()
        {
            if (driver.Url != PageAddress)
                driver.Url = PageAddress;
            return this;
        }


        public TopoCentrasPage InsertSearch(string income)
        {
            _searchInsert.Clear();
            _searchInsert.SendKeys(income);
            return this;
        }
        public TopoCentrasPage ClickSearchButton()
        {
            _searchButton.Click();
            return this;
        }

        [Obsolete]
        public TopoCentrasPage SelectprisoLowToHigh()
        {
            GetWait(3).Until(ExpectedConditions.ElementToBeClickable(_searchResult));
            _selectTool.SelectByText("Pigiausios viršuje");
            
            return this;
        }

        public TopoCentrasPage AssertUSBPrice(int myMoney)
        {
            string prepareWebResult = _sortedUSBPrice.Text.Replace(",", "").Replace("€", "").Trim();
            int numberResult = Convert.ToInt32(prepareWebResult);
            int moneyInCents = myMoney * 100;
            Assert.IsTrue(numberResult < moneyInCents, "You dont have money for USB drive");
            return this;
        }
    }
}
