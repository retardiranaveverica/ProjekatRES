using HistoricalComponent;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricalComponentTest
{
    [TestFixture]
    class HistoricalPropertyTest
    {
        [Test]
        public void EmptyConstructorTest()
        {
            HistoricalProperty historicalProperty = new HistoricalProperty();
            Assert.IsNotNull(historicalProperty);
        }
    }
}
