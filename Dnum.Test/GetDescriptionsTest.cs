using System.Linq;
using NUnit.Framework;

namespace DigitalLiberationFront.Dnum.Test {
    [TestFixture]
    public class GetDescriptionsTest {

        enum Color {
            [System.ComponentModel.Description("Ruby Red")]
            RubyRed,

            [System.ComponentModel.Description("Emerald Green")]
            EmeraldGreen,

            [System.ComponentModel.Description("Cobalt Blue")]
            CobaltBlue,

            Yellow
        };

        [Test]
        public void GetDescriptionsFromEnum() {
            var descriptions = Dnum<Color>.GetDescriptions();
            Assert.AreEqual(4, descriptions.Count());
            Assert.AreEqual("Ruby Red", descriptions[0]);
            Assert.AreEqual("Emerald Green", descriptions[1]);
            Assert.AreEqual("Cobalt Blue", descriptions[2]);
            Assert.AreEqual("Yellow", descriptions[3]);
        }

    }
}
