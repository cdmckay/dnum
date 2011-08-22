using System;
using NUnit.Framework;

namespace DigitalLiberationFront.Dnum.Test {
    [TestFixture]
    public class FormatTest {

        enum Color { Red, Green, Blue, Yellow };

        [Test]
        public void FormatConstantAsConstantValue() {
            Assert.AreEqual("Blue", Dnum<Color>.Format(Color.Blue, "g"));
        }

        [Test]
        public void FormatConstantAsIntegralValue() {
            Assert.AreEqual("5", Dnum<Color>.Format(5, "g"));
        }

        [Test]
        public void FormatConstantAsDecimal() {
            Assert.AreEqual("2", Dnum<Color>.Format(Color.Blue, "d"));
        }

        [Test]
        public void FormatConstantAsHexadecimal() {
            Assert.AreEqual("00000002", Dnum<Color>.Format(Color.Blue, "x"));
        }

        [Test]
        public void FormatTooLargeIntegralValue() {
            Assert.That(() => Dnum<Color>.Format(uint.MaxValue, "g"), Throws.TypeOf<ArgumentException>());
        }

    }
}
