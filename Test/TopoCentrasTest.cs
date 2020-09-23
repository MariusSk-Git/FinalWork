using NUnit.Framework;
using System;

namespace AutoTestLeson1.Test
{
    public class TopoCentrasTest : TestBase
    {

        [TestCase("usb raktas", 10, TestName = "Ar iseina pigiausias USB uz 10 euru")]
        [Obsolete]
        public void TestUSBPrice(string searchInput, int ourPrice)
        {
            _topoCentrasPage.NavigateToPage()
                .InsertSearch(searchInput)
                .ClickSearchButton()
                .SelectprisoLowToHigh()
                .AssertUSBPrice(ourPrice);
        }

    }
}
