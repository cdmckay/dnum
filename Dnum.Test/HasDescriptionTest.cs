using System;
using DotNet = System.ComponentModel;
using Dnum;
using NUnit.Framework;

namespace Dnum.Test
{
	[TestFixture]
	public class HasDescriptionTest
	{
        [Flags]
        public enum Pet : byte
        {
            None = 0,
            Dog = 1,
            Cat = 2,
            Rodent = 4,
            Bird = 8,
            [DotNet.Description("Komodo Dragon")]
            KomodoDragon = 16,
            Other = 32
        }

        [Test]
        public void HasDescriptionWorksForValidIntegralValue()
        {
            Assert.IsTrue(Dnum<Pet>.HasDescription(16));
        }
		
        [Test]
        public void HasDescriptionWorksForInvalidIntegralValue()
        {
            Assert.IsFalse(Dnum<Pet>.HasDescription(64));
        }

        [Test]
        public void HasDescriptionWorksForTooLargeIntegralValue()
        {
            Assert.That(() => Dnum<Pet>.HasDescription(256), Throws.TypeOf<OverflowException>());
        }
		
        [Test]
        public void IsDefinedWorksForConstantName()
        {
            Assert.IsTrue(Dnum<Pet>.HasDescription("KomodoDragon"));
        }

        [Test]
        public void IsDefinedWorksForConstant()
        {
            Assert.IsTrue(Dnum<Pet>.HasDescription(Pet.KomodoDragon));
        }

        [Test]
        public void IsDefinedWorksForUppercasedConstantName()
        {
            Assert.IsTrue(Dnum<Pet>.HasDescription("KomodoDragon"));
            Assert.IsFalse(Dnum<Pet>.HasDescription("KOMODODRAGON"));
        }
		
	}
}
