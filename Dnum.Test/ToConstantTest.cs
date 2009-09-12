using System;
using Dnum;
using NUnit.Framework;

namespace Dnum.Test
{
	[TestFixture()]
	public class ToConstantTest
	{
		enum Color { Red, Green, Blue, Yellow };
	    enum Style { Plaid, Striped, Tartan, Corduroy };			
		enum Officer : byte { Picard, Riker, Data, Worf, LaForge };		
		enum Planet : uint { Earth, Vulcan, Betazed, Risa = uint.MaxValue }
		
		[Test()]
		public void GetConstantWorksForIntegralValue()
		{
            Assert.AreEqual(Color.Yellow, Dnum<Color>.ToConstant(3));
            Assert.AreEqual(Style.Corduroy, Dnum<Style>.ToConstant(3));
		}

        [Test()]
        public void GetConstantWorksForNonExistantIntegralValue()
        {
            var color = Dnum<Color>.ToConstant(8);
            Assert.IsFalse(Dnum<Color>.IsDefined(color));
        }

        [Test()]
        public void GetConstantDoesNotWorksForTooLargeIntegralValue()
        {
            Assert.That(() => Dnum<Officer>.ToConstant((uint) 256), Throws.TypeOf<OverflowException>());            
        }
		
		[Test()]
		public void GetConstantWorksForByteValue()
		{
            Assert.AreEqual(Officer.Data, Dnum<Officer>.ToConstant((byte) 2));				
		}	
		
		[Test()]
		public void GetConstantWorksForUintValue()
		{
			Assert.AreEqual(Planet.Risa, Dnum<Planet>.ToConstant(uint.MaxValue));				
		}					
		
	}
}
