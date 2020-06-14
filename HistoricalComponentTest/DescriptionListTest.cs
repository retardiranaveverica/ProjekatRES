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
    class DescriptionListTest
    {
        [Test]
        public void EmptyConstructorTest()
        {
            DescriptionList descriptionList = new DescriptionList();
            Assert.IsNotNull(descriptionList);
        }
    }
}
