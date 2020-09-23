using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestLeson1.Test
{
    public class SenukaiTest : TestBase
    {
        [TestCase("Kareivių g. 11B, LT-09109 Vilnius, Lietuva", TestName = "Ar sutampa Senuku adresas")]
        [Obsolete]
        public void TestUSBPrice(string address)
        {
            _senukaiPage.NavigateToPage()
                .ClickContacts()
                .AssertSenukaiAddress(address);
        }
    }
}
