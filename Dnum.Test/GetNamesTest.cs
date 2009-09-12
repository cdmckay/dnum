using System;
using System.Linq;
using Dnum;
using NUnit.Framework;

namespace Dnum.Test
{
	[TestFixture]
	public class GetNamesTest
	{
		enum Colors { Red, Green, Blue, Yellow };	   
		
		[Test]
		public void GetNamesFromEnum()
		{
			var names = Dnum<Colors>.GetNames();
			Assert.AreEqual( 4, names.Count() );
			Assert.AreEqual( "Red",    names[0] );
			Assert.AreEqual( "Green",  names[1] );
			Assert.AreEqual( "Blue",   names[2] );
			Assert.AreEqual( "Yellow", names[3] );
		}						
		
	}
}
