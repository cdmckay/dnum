using System.Linq;
using NUnit.Framework;

namespace DigitalLiberationFront.Dnum.Test {
    [TestFixture]
    public class GetConstantsTest {

        enum Color { Red, Green, Blue, Yellow };
        enum PaperSize : ulong {
            Letter = 0,
            Legal = 256,
            A4 = 0xFFFFFFFFFFFFFFFF
        }

        [Test]
        public void GetConstantsFromEnum() {
            var constants = Dnum<Color>.GetConstants();
            Assert.AreEqual(4, constants.Count());
            Assert.AreNotEqual(0, constants.ToList()[0]);
            Assert.AreEqual(Color.Red, constants.ToList()[0]);
        }

        [Test]
        public void GetConstantsFromUlongEnum() {
            var values = Dnum<PaperSize>.GetConstants();
            Assert.AreEqual(3, values.Count());
            Assert.AreNotEqual(0xFFFFFFFFFFFFFFFF, values.ToList()[2]);
            Assert.AreEqual(PaperSize.A4, values.ToList()[2]);
        }

    }
}
