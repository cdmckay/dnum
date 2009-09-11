using System;
using Dnum;
using NUnit.Framework;

namespace Dnum.Test
{
	[TestFixture()]
	public class GetNameTest
	{
		enum Colors { Red, Green, Blue, Yellow };
	    enum Styles { Plaid, Striped, Tartan, Corduroy };			
		enum Officers : byte { Picard, Riker, Data, Worf, LaForge };		
		enum Planets : uint { Earth, Vulcan, Betazed, Risa }
		
		[Test()]
		public void GetNameWorksForIntegralValue()
		{
			Assert.AreEqual( "Yellow", Dnum<Colors>.GetName(3) );	
			Assert.AreEqual( "Corduroy", Dnum<Styles>.GetName(3) );
		}			
		
		[Test()]
		public void GetNameWorksForByteValue()
		{
			Assert.AreEqual( "Data", Dnum<Officers>.GetName(2) );				
		}	
		
		[Test()]
		public void GetNameWorksForUintValue()
		{
			Assert.AreEqual( "Betazed", Dnum<Planets>.GetName(2) );				
		}	
		
		[Test()]
		public void GetNameWorksForConstantValue()
		{
			Assert.AreEqual( "Yellow", Dnum<Colors>.GetName(Colors.Yellow) );	
			Assert.AreEqual( "Corduroy", Dnum<Styles>.GetName(Styles.Corduroy) );
		}	
		
	}
}
