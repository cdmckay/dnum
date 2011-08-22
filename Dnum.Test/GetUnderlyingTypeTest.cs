using NUnit.Framework;

namespace DigitalLiberationFront.Dnum.Test {
    [TestFixture]
    public class GetUnderlyingTypeTest {

        enum Color { Red, Green, Blue, Yellow };
        enum PaperSize : short { Letter, Legal, A4 }

        [Test]
        public void GetUnderlyingTypeOfIntEnum() {
            var type = Dnum<Color>.GetUnderlyingType();
            Assert.AreEqual(typeof(int), type);
        }

        [Test]
        public void GetUnderlyingTypeOfShortEnum() {
            var type = Dnum<PaperSize>.GetUnderlyingType();
            Assert.AreEqual(typeof(short), type);
        }

    }
}
