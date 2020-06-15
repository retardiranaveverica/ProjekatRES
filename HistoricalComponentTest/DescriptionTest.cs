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
    public class DescriptionTest
    {
        [Test]
        public void DescriptionTestEmptyConstructorTest()
        {
            Description description = new Description();
            Assert.IsNotNull(description);
        }
    }
}
