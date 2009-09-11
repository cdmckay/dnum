using System;
using System.Linq;
using Dnum;
using NUnit.Framework;

namespace Dnum.Test
{
	[TestFixture]
	public class GetValuesTest
	{
		enum Color { Red, Green, Blue, Yellow };
        enum PaperSize : ulong
        {
            Letter = 0,
            Legal  = 256,
            A4     = 0xFFFFFFFFFFFFFFFF
        }
		
		[Test]
		public void GetValuesFromEnum()
		{
			var values = Dnum<Color>.GetValues();
            Assert.AreEqual( 4, values.Count() );
            Assert.AreEqual( 0, values.ToList()[0] );
		}

        [Test]
        public void GetValuesFromUlongEnum()
        {
            var values = Dnum<PaperSize>.GetValues<ulong>();
            Assert.AreEqual(3, values.Count());
            Assert.AreEqual(0xFFFFFFFFFFFFFFFF, values.ToList()[2]);
        }      
		
	}
}
