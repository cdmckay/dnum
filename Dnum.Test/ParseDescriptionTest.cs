using System;
using System.Linq;
using NUnit.Framework;

namespace DigitalLiberationFront.Dnum.Test {
    [TestFixture]
    public class ParseDescriptionTest {

        [Flags]
        enum Color : byte {
            None = 0,
            [System.ComponentModel.Description("Ruby")]
            Red = 1,
            [System.ComponentModel.Description("Emerald")]
            Green = 2,
            [System.ComponentModel.Description("Cobalt")]
            Blue = 4,
            [System.ComponentModel.Description("Dark")]
            Maroon = 8,
            [System.ComponentModel.Description("Dark")]
            Charcoal = 16,
            [System.ComponentModel.Description("dark")]
            Black = 32,
            [System.ComponentModel.Description("DaRk")]
            Soot = 64,
        };

        [Test]
        public void ParseExistantDescription() {
            Assert.AreEqual(Dnum<Color>.ParseDescription("Ruby").First(), Color.Red);
        }

        [Test]
        public void ParseExistantIntegralValueString() {
            Assert.That(() => Dnum<Color>.ParseDescription("0"), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void ParseNonExistantIntegralValueString() {
            Assert.That(() => Dnum<Color>.ParseDescription("128"), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void ParseTooLargeIntegralValueString() {
            Assert.That(() => Dnum<Color>.ParseDescription("256"), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void ParseLowerCaseDescription() {
            Assert.That(() => Dnum<Color>.ParseDescription("ruby"), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void ParseLowerCaseDescriptionWithIgnoreCase() {
            var color = Dnum<Color>.ParseDescription("ruby", true /* Ignore case */).First();
            Assert.AreEqual(Color.Red, color);
        }

        [Test]
        public void ParseNonExistantDescriptionWithIgnoreCase() {
            Assert.That(() => Dnum<Color>.ParseDescription("poo", true /* Ignore case */), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void ParseNonExistantDescription() {
            Assert.That(() => Dnum<Color>.ParseDescription("Moonunit Zappa"), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void ParseDescriptionList() {
            Assert.That(() => Dnum<Color>.ParseDescription("Red, Green"), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void ParseRepeatDescription() {
            var dark = Dnum<Color>.ParseDescription("Dark");
            Assert.AreEqual(2, dark.Count());
            Assert.AreEqual(Color.Maroon, dark.First());
            Assert.AreEqual(Color.Charcoal, dark.Last());
        }

        [Test]
        public void ParseRepeatDescriptionWithIgnoreCase() {
            var dark = Dnum<Color>.ParseDescription("Dark", true /* Ignore case */);
            Assert.AreEqual(4, dark.Count());
            Assert.AreEqual(Color.Maroon, dark.First());
            Assert.AreEqual(Color.Soot, dark.Last());
        }

    }
}
