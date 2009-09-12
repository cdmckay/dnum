using System;
using System.Linq;
using Dnum;
using NUnit.Framework;

namespace Dnum.Test
{
	[TestFixture]
	public class GetConstantsTest
	{
		enum Color { Red, Green, Blue, Yellow };
        enum PaperSize : ulong
        {
            Letter = 0,
            Legal  = 256,
            A4     = 0xFFFFFFFFFFFFFFFF
        }
		
		[Test]
		public void GetConstantsFromEnum()
		{
			var constants = Dnum<Color>.GetConstants();
            Assert.AreEqual( 4, constants.Count() );
            Assert.AreEqual( Color.Red, constants.ToList()[0] );
		}

        [Test]
        public void GetConstantsFromUlongEnum()
        {
            var values = Dnum<PaperSize>.GetValues<ulong>();
            Assert.AreEqual(3, values.Count());
            Assert.AreEqual(0xFFFFFFFFFFFFFFFF, values.ToList()[2]);
        }      
		
	}
}
