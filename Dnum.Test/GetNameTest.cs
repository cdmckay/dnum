using System;
using Dnum;
using NUnit.Framework;

namespace Dnum.Test
{
	[TestFixture()]
	public class GetNameTest
	{
		enum Color { Red, Green, Blue, Yellow };
	    enum Style { Plaid, Striped, Tartan, Corduroy };			
		enum Officer : byte { Picard, Riker, Data, Worf, LaForge };		
		enum Planet : uint { Earth, Vulcan, Betazed, Risa }
		
		[Test()]
		public void GetNameWorksForIntegralValueWithConstant()
		{
			Assert.AreEqual( "Yellow", Dnum<Color>.GetName(3) );	
			Assert.AreEqual( "Corduroy", Dnum<Style>.GetName(3) );
		}

        [Test()]
        public void GetNameWorksForIntegralValueWithoutConstant()
        {
            Assert.IsNull(Dnum<Color>.GetName(100));            
        }

        [Test]
        public void GetNameDoesNotWorkForTooLargeIntegralValue()
        {            
            Assert.That(() => Dnum<Officer>.GetName(256), Throws.TypeOf<OverflowException>());
        }

		[Test()]
		public void GetNameWorksForByteValue()
		{
			Assert.AreEqual( "Data", Dnum<Officer>.GetName(2) );				
		}	
		
		[Test()]
		public void GetNameWorksForUintValue()
		{
			Assert.AreEqual( "Betazed", Dnum<Planet>.GetName(2) );				
		}	
		
		[Test()]
		public void GetNameWorksForConstantValue()
		{
			Assert.AreEqual( "Yellow", Dnum<Color>.GetName(Color.Yellow) );	
			Assert.AreEqual( "Corduroy", Dnum<Style>.GetName(Style.Corduroy) );
		}	
		
	}
}
