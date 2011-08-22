using System;
using NUnit.Framework;

namespace DigitalLiberationFront.Dnum.Test {
    [TestFixture]
    public class GetDescriptionTest {

        enum Color {
            [System.ComponentModel.Description("Ruby Red")]
            RubyRed,

            [System.ComponentModel.Description("Emerald Green")]
            EmeraldGreen,

            [System.ComponentModel.Description("Cobalt Blue")]
            CobaltBlue,

            [System.ComponentModel.Description("Pee Yellow")]
            PeeYellow
        };

        enum Officer : byte {
            [System.ComponentModel.Description("Jean-Luc Picard")]
            Picard,

            [System.ComponentModel.Description("William T. Riker")]
            Riker,

            Data,

            [System.ComponentModel.Description("Worf, Son of Mogh")]
            Worf,

            [System.ComponentModel.Description("Geordi LaForge")]
            LaForge
        };

        [Test]
        public void GetDescriptionWorksForIntegralValue() {
            Assert.AreEqual("Pee Yellow", Dnum<Color>.GetDescription(3));
        }

        [Test]
        public void GetDescriptionFallsBackOnEnumName() {
            Assert.AreEqual("Data", Dnum<Officer>.GetDescription(2));
        }

        [Test]
        public void GetDescriptionDoesNotWorkForTooLargeIntegralValue() {
            Assert.That(() => Dnum<Officer>.GetDescription(256), Throws.TypeOf<OverflowException>());
        }

        [Test]
        public void GetNameWorksForConstantValue() {
            Assert.AreEqual("Cobalt Blue", Dnum<Color>.GetDescription(Color.CobaltBlue));
            Assert.AreEqual("William T. Riker", Dnum<Officer>.GetDescription(Officer.Riker));
        }

    }
}
