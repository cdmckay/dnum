using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Couchware
{
	public static class Dnum<T> where T : struct
	{
		/// <summary>
		/// Retrieves the name of the constant in the enumeration that has the specified value. 
		/// </summary>
		/// <param name="value">
		/// The value of a particular enumerated constant in terms of its underlying type. 
		/// </param>
		/// <returns>
		/// A string containing the name of the enumerated constant in enumType whose value is value,
		/// or null if no such constant is found.
		/// </returns>
		public static string GetName(T constant)
		{
			return Enum.GetName(typeof (T), constant);
		}
		
		public static string GetName(sbyte  value) { return Enum.GetName(typeof (T), value); }
		public static string GetName(byte   value) { return Enum.GetName(typeof (T), value); }
		public static string GetName(char   value) { return Enum.GetName(typeof (T), value); }
		public static string GetName(short  value) { return Enum.GetName(typeof (T), value); }
		public static string GetName(ushort value) { return Enum.GetName(typeof (T), value); }
		public static string GetName(int    value) { return Enum.GetName(typeof (T), value); }
		public static string GetName(uint   value) { return Enum.GetName(typeof (T), value); }
		public static string GetName(long   value) { return Enum.GetName(typeof (T), value); }
		public static string GetName(ulong  value) { return Enum.GetName(typeof (T), value); }
		
		/// <summary>
		/// Retrieves an array of the names of the constants in the enumeration. 
		/// </summary>
		/// <returns>
		/// A string enumerable of the names of the constants in enumType. 
		/// </returns>
		public static IEnumerable<string> GetNames()
		{
			return Enum.GetNames(typeof (T));
		}			
		
		/// <summary>
		/// Returns the underlying type of the enumeration. 
		/// </summary>
		/// <returns>
		/// The underlying Type of T.
		/// </returns>
		public static Type GetUnderlyingType()
		{
			return Enum.GetUnderlyingType(typeof (T));
		}
		
		/// <summary>
		/// Retrieves an array of the values of the constants in the enumeration. 
		/// </summary>
		/// <returns>
		/// An enumerable of the values of the constants in the enumeration. 
		/// The elements of the enumerable are sorted by the binary values of the enumeration constants.
		/// </returns>
		public static IEnumerable<T> GetValues()
		{
			return Enum.GetValues(typeof (T)).Cast<T>();
		}
		
		/// <summary>
		/// Returns an indication whether a constant with a specified value exists in the enumeration. 
		/// </summary>
		/// <param name="value">
		/// The value of a constant in the enumeration. 
		/// </param>
		/// <returns>
		/// True if a constant in the enumeration has a value equal to value; otherwise, false.
		/// </returns>
		public static bool IsDefined(T constant)
		{
			return Enum.IsDefined(typeof (T), constant);
		}			
				
		public static bool IsDefined(string name)		
		{
			return Enum.IsDefined(typeof (T), name);
		}
		
		public static bool IsDefined(sbyte  value) { return Enum.IsDefined(typeof (T), value); }
		public static bool IsDefined(byte   value) { return Enum.IsDefined(typeof (T), value); }
		public static bool IsDefined(char   value) { return Enum.IsDefined(typeof (T), value); }
		public static bool IsDefined(short  value) { return Enum.IsDefined(typeof (T), value); }
		public static bool IsDefined(ushort value) { return Enum.IsDefined(typeof (T), value); }
		public static bool IsDefined(int    value) { return Enum.IsDefined(typeof (T), value); }
		public static bool IsDefined(uint   value) { return Enum.IsDefined(typeof (T), value); }
		public static bool IsDefined(long   value) { return Enum.IsDefined(typeof (T), value); }
		public static bool IsDefined(ulong  value) { return Enum.IsDefined(typeof (T), value); }
		
		/// <summary>
		/// Converts the string representation of the name or numeric value of one or more 
		/// enumerated constants to an equivalent enumerated object. 
		/// </summary>
		/// <param name="name">
		/// A string containing the name or value to convert.
		/// </param>
		/// <param name="ignoreCase">
		/// If true, ignore case; otherwise, regard case.
		/// </param>
		/// <returns>
		/// An object of type T whose value is represented by value.
		/// </returns>
		public static T Parse(string name, bool ignoreCase)
		{
			return (T) Enum.Parse(typeof (T), name, ignoreCase);
		}
		
		/// <summary>
		/// Converts the string representation of the name or numeric value of one or more 
		/// enumerated constants to an equivalent enumerated object. 
		/// </summary>
		/// <param name="name">
		/// A string containing the name or value to convert.
		/// </param>		
		/// <returns>
		/// An object of type T whose value is represented by value.
		/// </returns>
		public static T Parse(string name)
		{
			return Dnum<T>.Parse(name, false);
		}
		
		/// <summary>
		/// Converts the string representation of the name or numeric value of one or more 
		/// enumerated constants to an equivalent enumerated object and returns a value that 
		/// indicates whether the conversion succeeded. 
		/// </summary>
		/// <param name="name">
		/// A string containing the name or value to convert.
		/// </param>
		/// <param name="constant">
		/// A <see cref="T"/>
		/// </param>
		/// <param name="ignoreCase">
		/// If true, ignore case; otherwise, regard case.
		/// </param>
		/// <returns>
		/// When this method returns, contains the T value equivalent to name or numeric value in name 
		/// if the conversion succeeded, or default(T) if the conversion failed.
		/// </returns>
		public static bool TryParse(string name, out T result, bool ignoreCase)
		{
			try
			{
				result = Dnum<T>.Parse(name, ignoreCase);
				return true;
			}
			catch
			{
				result = default(T);
				return false;
			}
		}
		
		/// <summary>
		/// Converts the string representation of the name or numeric value of one or more 
		/// enumerated constants to an equivalent enumerated object and returns a value that 
		/// indicates whether the conversion succeeded. 
		/// </summary>
		/// <param name="name">
		/// A string containing the name or value to convert.
		/// </param>
		/// <param name="result">
		/// When this method returns, result contains the T value equivalent to name or numeric value in name 
		/// if the conversion succeeded, or default(T) if the conversion failed.
		/// </param>		
		/// <returns>
		/// True if the name parameter was converted successfully; otherwise, false.
		/// </returns>
		public static bool TryParse(string name, out T result)
		{
			return Dnum<T>.TryParse(name, out result, false);
		}
		
		/// <summary>
		/// Returns an enumeration constant that matches the given integral value.
		/// </summary>
		/// <param name="value">
		/// An integral value.
		/// </param>
		/// <returns>
		/// An enumeration object whose value is value.
		/// </returns>
		public static T ToConstant(object value) 
		{ 
			return (T) Enum.ToObject(typeof (T), value); 
		}
		
		public static T ToConstant(sbyte  value) { return (T) Enum.ToObject(typeof (T), value); }
		public static T ToConstant(byte   value) { return (T) Enum.ToObject(typeof (T), value); }
		public static T ToConstant(char   value) { return (T) Enum.ToObject(typeof (T), value); }
		public static T ToConstant(short  value) { return (T) Enum.ToObject(typeof (T), value); }
		public static T ToConstant(ushort value) { return (T) Enum.ToObject(typeof (T), value); }
		public static T ToConstant(int    value) { return (T) Enum.ToObject(typeof (T), value); }
		public static T ToConstant(uint   value) { return (T) Enum.ToObject(typeof (T), value); }
		public static T ToConstant(long   value) { return (T) Enum.ToObject(typeof (T), value); }
		public static T ToConstant(ulong  value) { return (T) Enum.ToObject(typeof (T), value); }
		
	}
}
