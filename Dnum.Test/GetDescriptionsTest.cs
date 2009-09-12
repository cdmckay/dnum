using System;
using DotNet = System.ComponentModel;
using System.Linq;
using Dnum;
using NUnit.Framework;

namespace Dnum.Test
{
	[TestFixture]
	public class GetDescriptionsTest
	{
        enum Color
        {
            [DotNet.Description("Ruby Red")]
            RubyRed,

            [DotNet.Description("Emerald Green")]
            EmeraldGreen,

            [DotNet.Description("Cobalt Blue")]
            CobaltBlue,
            
            Yellow
        };   
		
		[Test]
		public void GetDescriptionsFromEnum()
		{
			var descriptions = Dnum<Color>.GetDescriptions();
			Assert.AreEqual( 4, descriptions.Count() );
			Assert.AreEqual( "Ruby Red",    descriptions[0] );
			Assert.AreEqual( "Emerald Green",  descriptions[1] );
			Assert.AreEqual( "Cobalt Blue",   descriptions[2] );
			Assert.AreEqual( "Yellow", descriptions[3] );
		}						
		
	}
}
