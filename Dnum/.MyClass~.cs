using System;

namespace Couchware
{
	public static class Dnum<T>
	{
		/// <summary>
		/// Retrieves the name of the constant in the specified enumeration that has the specified value. 
		/// </summary>
		/// <param name="value">
		/// A <see cref="System.Object"/>
		/// </param>
		/// <returns>
		/// A <see cref="T"/>
		/// </returns>
		public static T GetName(object value)
		{
			return Enum.GetName(typeof (T), value);
		}
		
	}
}
