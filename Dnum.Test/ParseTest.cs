using System;
using System.Linq;
using Dnum;
using NUnit.Framework;

namespace Dnum.Test
{
	[TestFixture]
	public class ParseTest
	{
		[Flags] enum Color : byte 
        { 
            None = 0, 
            Red = 1, 
            Green = 2, 
            Blue = 4,
        };

        [Test]
        public void ParseExistantIntegralValueString()
        {
            Assert.AreEqual(Color.None, Dnum<Color>.Parse("0"));
            Assert.AreEqual(Color.Green, Dnum<Color>.Parse("2"));
        }

        [Test]
        public void ParseNonExistantIntegralValueString()
        {
            var color = Dnum<Color>.Parse("8");
            Assert.IsFalse(Dnum<Color>.IsDefined(color));
        }

        [Test]
        public void ParseTooLargeIntegralValueString()
        {
            Assert.That(() => Dnum<Color>.Parse("256"), Throws.TypeOf<OverflowException>());
        }

        [Test]
        public void ParseLowerCaseConstantName()
        {            
            Assert.That(() => Dnum<Color>.Parse("blue"), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void ParseLowerCaseConstantNameWithIgnoreCase()
        {
            var color = Dnum<Color>.Parse("blue", true /* Ignore case */);
            Assert.AreEqual(Color.Blue, color);
        }

        [Test]
        public void ParseNonExistantConstantName()
        {
            Assert.That(() => Dnum<Color>.Parse("Yellow"), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void ParseConstantNameList()
        {
            Assert.IsTrue(Dnum<Color>.Parse("Red, Green").ToString().Contains(","));
        }

	}
}
