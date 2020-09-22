using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestLeson1.Test
{
    class DecathlonTest : TestBase
    {
        [Order(1)]
        [TestCase("BARN 60 HOT TIGER", "5", TestName = "Ar teisingai paskaiciuoja kaina krepselyje pasirinkus kelis vienetus")]
        [Obsolete]
        public void TestPriceMatchInChart(string searchName, string unitsInChart)
        {
            _page.NavigateToPage()
                 .InsertSearch(searchName)
                 .ClickSearch()
                 .ClickSearchResult()
                 .AddToChart()
                 .GoToChart()
                 .SelectQuantity(unitsInChart)
                 .AssertTotalPrice(unitsInChart);
        }

        [Order(2)]
        [TestCase("Kamuolys", 50, "High to Low", TestName = "Ar galima nusipirkti brangiausia kalmuoli uz 50 euru")]

        public void TestMostExpensiveBall(string itemInShop, double myMoney, string sortingBy)
        {
            _page.NavigateToPage()
                 .InsertSearch(itemInShop)
                 .ClickSearch()
                 .SortingByPriceHighToLow(sortingBy)
                 .AssertBallPrice(myMoney);
        }

        [Order(3)]
        [TestCase(20, "Vikingų g. 5", TestName = "Ar sestadieni 20h dar galima uzeiti i parduotuve Vikingu gatveje")]
        [Obsolete]
        public void TestSaturdayAvailableShopTime(int wantedHourToWisitShop, string shopAddress)
        {
            _page.NavigateToPage()
                 .ClinkMyStore()
                 .AssertAddressFirstLine(shopAddress)
                 .ClickOnVilniusStore()
                 .AssertShopTime(wantedHourToWisitShop);
        }

        [Order(4)]

        [TestCase("SKYRAZER 500", "TeastName", "TestSurename", TestName = "Tirinam nepilnai uzpildyta rezervacja")]
        [Obsolete]
        public void TestReservGlasesWithoutEmailAndPhone(string searchGlassName, string testName, string testSurename)
        {
            _page.NavigateToPage()
                 .InsertSearch(searchGlassName)
                 .ClickSearch()
                 .ClickGlasesSearchResult()
                 .ClickReserveButton()
                 .ClickReserve5HButton()
                 .InsertReserveFirstName(testName)
                 .InsertReserveLastName(testSurename)
                 .ClickAgreeReserveButton()
                 .AssertReservationErrors();
        }

        [Order(5)]

        [TestCase("saudymo is lanko rinkinys", 1000, TestName = "Ar lankas turi daugiau nei 1000 atsiliepimu")]
        [Obsolete]
        public void TestArcherySetReviews(string searchArcherySet, int expectedReviewCount)
        {
            _page.NavigateToPage()
                 .InsertSearch(searchArcherySet)
                 .ClickSearch()
                 .ClickBowSearchResult()
                 .AssertBowReviewCount(expectedReviewCount);
        }
    }
}
