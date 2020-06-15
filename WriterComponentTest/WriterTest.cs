using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriterComponent;

namespace WriterComponentTest
{
    [TestFixture]
    public class WriterTest
    {
        [Test]
        
        public void EnumTest_Success()
        {
            string code = "CODE_SOURCE";
            bool postoji = Enum.IsDefined(typeof(ListOfCodes), code);
            Assert.IsTrue(postoji);
        }

        [Test]

        public void EnumTest_Fail()
        {
            string code = "CODE_DEFINED";
            bool postoji = Enum.IsDefined(typeof(ListOfCodes), code);
            Assert.IsFalse(postoji);
        }


    }
}
