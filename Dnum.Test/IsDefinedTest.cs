using System;
using NUnit.Framework;

namespace DigitalLiberationFront.Dnum.Test {
    [TestFixture]
    public class IsDefinedTest {

        [Flags]
        public enum Pet : byte {
            None = 0,
            Dog = 1,
            Cat = 2,
            Rodent = 4,
            Bird = 8,
            Reptile = 16,
            Other = 32
        }

        [Test]
        public void IsDefinedWorksForValidIntegralValue() {
            Assert.IsTrue(Dnum<Pet>.IsDefined(1));
        }

        [Test]
        public void IsDefinedWorksForInvalidIntegralValue() {
            Assert.IsFalse(Dnum<Pet>.IsDefined(64));
        }

        [Test]
        public void IsDefinedWorksForTooLargeIntegralValue() {
            Assert.That(() => Dnum<Pet>.IsDefined(256), Throws.TypeOf<OverflowException>());
        }

        [Test]
        public void IsDefinedWorksForConstantName() {
            Assert.IsTrue(Dnum<Pet>.IsDefined("Rodent"));
        }

        [Test]
        public void IsDefinedWorksForConstant() {
            Assert.IsTrue(Dnum<Pet>.IsDefined(Pet.Dog));
        }

        [Test]
        public void IsDefinedWorksForOredConstants() {
            Assert.IsFalse(Dnum<Pet>.IsDefined(Pet.Cat | Pet.Dog));
        }

        [Test]
        public void IsDefinedWorksForUppercasedConstantName() {
            Assert.IsTrue(Dnum<Pet>.IsDefined("None"));
            Assert.IsFalse(Dnum<Pet>.IsDefined("NONE"));
        }

    }
}
