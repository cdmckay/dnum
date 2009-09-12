using System;
using DotNet = System.ComponentModel;
using Dnum;
using NUnit.Framework;

namespace Dnum.Test
{
    [TestFixture]
	public class GetDescriptionTest
	{
        enum Color
        {
            [DotNet.Description("Ruby Red")]
            RubyRed,

            [DotNet.Description("Emerald Green")]
            EmeraldGreen,

            [DotNet.Description("Cobalt Blue")]
            CobaltBlue,

            [DotNet.Description("Pee Yellow")]
            PeeYellow
        };

        enum Officer : byte
        {
            [DotNet.Description("Jean-Luc Picard")]
            Picard,

            [DotNet.Description("William T. Riker")]
            Riker,

            Data,

            [DotNet.Description("Worf, Son of Mogh")]
            Worf,

            [DotNet.Description("Geordi LaForge")]
            LaForge
        };

        [Test]
        public void GetDescriptionWorksForIntegralValue()
        {
            Assert.AreEqual("Pee Yellow", Dnum<Color>.GetDescription(3));
        }

        [Test]
        public void GetDescriptionFallsBackOnEnumName()
        {
            Assert.AreEqual("Data", Dnum<Officer>.GetDescription(2));
        }

        [Test]
        public void GetDescriptionDoesNotWorkForTooLargeIntegralValue()
        {
            Assert.That(() => Dnum<Officer>.GetDescription(256), Throws.TypeOf<OverflowException>());
        }		        
		
        [Test]
        public void GetNameWorksForConstantValue()
        {
            Assert.AreEqual("Cobalt Blue", Dnum<Color>.GetDescription(Color.CobaltBlue));
            Assert.AreEqual("William T. Riker", Dnum<Officer>.GetDescription(Officer.Riker));
        }	
		
	}
}
