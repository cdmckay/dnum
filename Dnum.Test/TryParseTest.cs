using System;
using System.Linq;
using Dnum;
using NUnit.Framework;

namespace Dnum.Test
{
	[TestFixture]
	public class TryParseTest
	{
		[Flags] enum Color : byte { None = 0, Red = 1, Green = 2, Blue = 4 };

        [Test]
        public void ParseExistantIntegralValueString()
        {
            Color? none;
            Assert.IsTrue(Dnum<Color>.TryParse("0", out none));
            Assert.AreEqual(Color.None, none.Value);

            Color? green;
            Assert.IsTrue(Dnum<Color>.TryParse("2", out green));
            Assert.AreEqual(Color.Green, green.Value);
        }
       
		[Test]
        public void ParseNonExistantIntegralValueString()
        {
            Color? color;
            Assert.IsTrue(Dnum<Color>.TryParse("8", out color));
            Assert.IsFalse(Dnum<Color>.IsDefined(color.Value));
        }

        [Test]
        public void ParseTooLargeIntegralValueString()
        {
            Color? color;
            Assert.IsFalse(Dnum<Color>.TryParse("256", out color));
            Assert.IsNull(color);
        }

        [Test]
        public void ParseLowerCaseConstantName()
        {
            Color? color;            
            Assert.IsFalse(Dnum<Color>.TryParse("blue", out color));
            Assert.IsNull(color);
        }

        [Test]
        public void ParseLowerCaseConstantNameWithIgnoreCase()
        {
            Color? color;
            Assert.IsTrue(Dnum<Color>.TryParse("blue", out color, true /* Ignore case */));
            Assert.AreEqual(Color.Blue, color.Value);
        }

        [Test]
        public void ParseNonExistantConstantName()
        {
            Color? color;
            Assert.IsFalse(Dnum<Color>.TryParse("Yellow", out color));
            Assert.IsNull(color);
        }

        [Test]
        public void ParseConstantNameList()
        {
            Color? color;
            Assert.IsTrue(Dnum<Color>.TryParse("Red, Green", out color));
            Assert.IsTrue(color.Value.ToString().Contains(","));
        }

	}
}
