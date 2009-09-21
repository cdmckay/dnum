using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Dnum
{
	/// <summary>
	/// Dnum is a static class for accessing enumeration values much like the built-in .NET class Enum.
	/// Unlike Enum, Dnum is generified, eliminating the need for casting. Furthermore, Dnum is
	/// type-safe, allowing you catch more errors at compile-time and have fewer surprises at runtime.
	/// 
	/// Dnum also transparently supports the <seealso cref="System.ComponentModel.DescriptionAttribute"/>
	/// attribute, allowing you to use spaces and other characters in your enumeration constants.
	/// </summary>
	public static class Dnum<E> where E : struct
	{
		/// <summary>
		/// Maps the enum constants to their descriptions.
		/// </summary>
		private readonly static IDictionary<E, string> ConstantToDescriptionMap
			= new Dictionary<E, string>();

        private readonly static IDictionary<string, IList<E>> DescriptionToConstantsMap
			= new Dictionary<string, IList<E>>();
		
		static Dnum()
		{
			foreach (var constant in GetConstants())
			{
				var description = GetDescriptionOf(constant);
				ConstantToDescriptionMap[constant] = description;

                var map = DescriptionToConstantsMap;
                if (!map.ContainsKey(description)) map[description] = new List<E>();
                map[description].Add(constant);                
			}
		}
		
		#region Format

		/// <summary>
		/// Converts the constant of an enumeration to its equivalent string
		/// representation according to the specified format.
		/// </summary>
		/// <param name="constant">A constant in the enumeration.</param>
		/// <param name="format">The output format to use.</param>
		/// <returns>A string representation of the <paramref name="constant"/>.</returns>
		public static string Format(E constant, string format)
		{
			return Enum.Format(typeof(E), constant, format);
		}

		/// <summary>
		/// Converts the integral value of an enumeration to its equivalent string
		/// representation according to the specified format.
		/// </summary>
		/// <param name="value">An integral value in the enumeration.</param>
		/// <param name="format">The output format to use.</param>
		/// <returns>A string representation of the <paramref name="value"/>.</returns>
		public static string Format(sbyte value, string format) { return Enum.Format(typeof(E), value, format); }

		/// <summary>
		/// Converts the integral value of an enumeration to its equivalent string
		/// representation according to the specified format.
		/// </summary>
		/// <param name="value">An integral value in the enumeration.</param>
		/// <param name="format">The output format to use.</param>
		/// <returns>A string representation of the <paramref name="value"/>.</returns>
		public static string Format(byte value, string format) { return Enum.Format(typeof(E), value, format); }

		/// <summary>
		/// Converts the integral value of an enumeration to its equivalent string
		/// representation according to the specified format.
		/// </summary>
		/// <param name="value">An integral value in the enumeration.</param>
		/// <param name="format">The output format to use.</param>
		/// <returns>A string representation of the <paramref name="value"/>.</returns>
		public static string Format(char value, string format) { return Enum.Format(typeof(E), value, format); }

		/// <summary>
		/// Converts the integral value of an enumeration to its equivalent string
		/// representation according to the specified format.
		/// </summary>
		/// <param name="value">An integral value in the enumeration.</param>
		/// <param name="format">The output format to use.</param>
		/// <returns>A string representation of the <paramref name="value"/>.</returns>
		public static string Format(short value, string format) { return Enum.Format(typeof(E), value, format); }

		/// <summary>
		/// Converts the integral value of an enumeration to its equivalent string
		/// representation according to the specified format.
		/// </summary>
		/// <param name="value">An integral value in the enumeration.</param>
		/// <param name="format">The output format to use.</param>
		/// <returns>A string representation of the <paramref name="value"/>.</returns>
		public static string Format(ushort value, string format) { return Enum.Format(typeof(E), value, format); }

		/// <summary>
		/// Converts the integral value of an enumeration to its equivalent string
		/// representation according to the specified format.
		/// </summary>
		/// <param name="value">An integral value in the enumeration.</param>
		/// <param name="format">The output format to use.</param>
		/// <returns>A string representation of the <paramref name="value"/>.</returns>
		public static string Format(int value, string format) { return Enum.Format(typeof(E), value, format); }

		/// <summary>
		/// Converts the integral value of an enumeration to its equivalent string
		/// representation according to the specified format.
		/// </summary>
		/// <param name="value">An integral value in the enumeration.</param>
		/// <param name="format">The output format to use.</param>
		/// <returns>A string representation of the <paramref name="value"/>.</returns>
		public static string Format(uint value, string format) { return Enum.Format(typeof(E), value, format); }

		/// <summary>
		/// Converts the integral value of an enumeration to its equivalent string
		/// representation according to the specified format.
		/// </summary>
		/// <param name="value">An integral value in the enumeration.</param>
		/// <param name="format">The output format to use.</param>
		/// <returns>A string representation of the <paramref name="value"/>.</returns>
		public static string Format(long value, string format) { return Enum.Format(typeof(E), value, format); }

		/// <summary>
		/// Converts the integral value of an enumeration to its equivalent string
		/// representation according to the specified format.
		/// </summary>
		/// <param name="value">An integral value in the enumeration.</param>
		/// <param name="format">The output format to use.</param>
		/// <returns>A string representation of the <paramref name="value"/>.</returns>
		public static string Format(ulong value, string format) { return Enum.Format(typeof(E), value, format); }

		#endregion

		#region GetName

		/// <summary>
		/// Retrieves the name of the constant in the enumeration that has the specified value.
		/// </summary>
		/// <param name="constant">A constant in the enumeration.</param>
		/// <returns>
		/// A string containing the name of the enumerated <paramref name="constant"/>,
		/// or null if no such constant is found.
		/// </returns>
		public static string GetName(E constant)
		{
			return Enum.GetName(typeof(E), constant);
		}

		/// <summary>
		/// Retrieves the name of the constant in the enumeration that has the specified value.
		/// </summary>
		/// <param name="value">An integral value in the enumeration.</param>
		/// <returns>
		/// A string containing the name corresponding to the intergral <paramref name="value"/>,
		/// or null if no such constant is found.
		/// </returns>
		public static string GetName(sbyte value) { return GetName((object) value); }

		/// <summary>
		/// Retrieves the name of the constant in the enumeration that has the specified value.
		/// </summary>
		/// <param name="value">An integral value in the enumeration.</param>
		/// <returns>
		/// A string containing the name corresponding to the intergral <paramref name="value"/>,
		/// or null if no such constant is found.
		/// </returns>
		public static string GetName(byte value) { return GetName((object) value); }

		/// <summary>
		/// Retrieves the name of the constant in the enumeration that has the specified value.
		/// </summary>
		/// <param name="value">An integral value in the enumeration.</param>
		/// <returns>
		/// A string containing the name corresponding to the intergral <paramref name="value"/>,
		/// or null if no such constant is found.
		/// </returns>
		public static string GetName(char value) { return GetName((object) value); }

		/// <summary>
		/// Retrieves the name of the constant in the enumeration that has the specified value.
		/// </summary>
		/// <param name="value">An integral value in the enumeration.</param>
		/// <returns>
		/// A string containing the name corresponding to the intergral <paramref name="value"/>,
		/// or null if no such constant is found.
		/// </returns>
		public static string GetName(short value) { return GetName((object) value); }

		/// <summary>
		/// Retrieves the name of the constant in the enumeration that has the specified value.
		/// </summary>
		/// <param name="value">An integral value in the enumeration.</param>
		/// <returns>
		/// A string containing the name corresponding to the intergral <paramref name="value"/>,
		/// or null if no such constant is found.
		/// </returns>
		public static string GetName(ushort value) { return GetName((object) value); }

		/// <summary>
		/// Retrieves the name of the constant in the enumeration that has the specified value.
		/// </summary>
		/// <param name="value">An integral value in the enumeration.</param>
		/// <returns>
		/// A string containing the name corresponding to the intergral <paramref name="value"/>,
		/// or null if no such constant is found.
		/// </returns>
		public static string GetName(int value) { return GetName((object) value); }

		/// <summary>
		/// Retrieves the name of the constant in the enumeration that has the specified value.
		/// </summary>
		/// <param name="value">An integral value in the enumeration.</param>
		/// <returns>
		/// A string containing the name corresponding to the intergral <paramref name="value"/>,
		/// or null if no such constant is found.
		/// </returns>
		public static string GetName(uint value) { return GetName((object) value); }

		/// <summary>
		/// Retrieves the name of the constant in the enumeration that has the specified value.
		/// </summary>
		/// <param name="value">An integral value in the enumeration.</param>
		/// <returns>
		/// A string containing the name corresponding to the intergral <paramref name="value"/>,
		/// or null if no such constant is found.
		/// </returns>
		public static string GetName(long value) { return GetName((object) value); }

		/// <summary>
		/// Retrieves the name of the constant in the enumeration that has the specified value.
		/// </summary>
		/// <param name="value">An integral value in the enumeration.</param>
		/// <returns>
		/// A string containing the name corresponding to the intergral <paramref name="value"/>,
		/// or null if no such constant is found.
		/// </returns>
		public static string GetName(ulong value) { return GetName((object) value); }

		private static string GetName(object value)
		{
			// This code is here to cause an overflow exception to be emitted
			// if this is a narrowing conversion.
			Convert.ChangeType(value, GetUnderlyingType());
			return Enum.GetName(typeof(E), value);
		}

		#endregion

		/// <summary>
		/// Retrieves a list of the names of the constants in the enumeration.
		/// </summary>
		/// <returns>
		/// A string enumerable of the names of the constants in enumeration.
		/// </returns>
		public static IList<string> GetNames()
		{
			return Enum.GetNames(typeof(E)).ToList();
		}

		/// <summary>
		/// Returns the underlying type of the enumeration.
		/// </summary>
		/// <returns>
		/// The underlying type of the enumeration.
		/// </returns>
		public static Type GetUnderlyingType()
		{
			return Enum.GetUnderlyingType(typeof(E));
		}

		/// <summary>
		/// Retrieves an enumerable of the integral values of the constants in the enumeration.
		/// </summary>
		/// <returns>
		/// An enumerable of the integral values of the constants in the enumeration.
		/// The elements of the enumerable are sorted by the binary values of the enumeration constants.
		/// </returns>
		public static IEnumerable<int> GetValues()
		{
			return Enum.GetValues(typeof(E)).Cast<int>();
		}

		/// <summary>
		/// Retrieves an enumerable of the integral values of the constants in the enumeration.
		/// </summary>
		/// <typeparam name="T">The underlying type of the enumeration.</typeparam>
		/// <returns>
		/// An enumerable of the integral values of the constants in the enumeration.
		/// The elements of the enumerable are sorted by the binary values of the enumeration constants.
		/// </returns>
		public static IEnumerable<T> GetValues<T>() where T
			: IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
		{
			return Enum.GetValues(typeof(E)).Cast<T>();
		}

		/// <summary>
		/// Retrieves an enumerable of the constants in the enumeration.
		/// </summary>
		/// <returns>
		/// An enumerable of the the constants in the enumeration.
		/// The elements of the enumerable are sorted by the binary values of the enumeration constants.
		/// </returns>
		public static IEnumerable<E> GetConstants()
		{
			return Enum.GetValues(typeof(E)).Cast<E>();
		}

		#region IsDefined

		/// <summary>
		/// Returns an indication whether a constant is defined in the enumeration.
		/// </summary>
		/// <param name="constant">A constant.</param>
		/// <returns>
		/// True if a constant defined in the enumeration has a value equal to the value
		/// of <paramref name="constant"/>; otherwise, false.
		/// </returns>
		public static bool IsDefined(E constant)
		{
			return Enum.IsDefined(typeof(E), constant);
		}

		/// <summary>
		/// Returns an indication whether a constant name is defined in the enumeration.
		/// </summary>
		/// <param name="name">A constant name.</param>
		/// <returns>
		/// True if a constant defined in the enumeration has a name equal to
		/// <paramref name="name"/>; otherwise, false.
		/// </returns>
		public static bool IsDefined(string name)
		{
			return Enum.IsDefined(typeof(E), name);
		}

		/// <summary>
		/// Returns an indication whether a constant with a specified value exists in a specified enumeration.
		/// </summary>
		/// <param name="value">An integral value in the enumeration.</param>
		/// <returns>
		/// True if a constant in the enumeration has a value equal to <paramref name="value"/>; otherwise, false.
		/// </returns>
		public static bool IsDefined(sbyte value) { return IsDefined((object) value); }

		/// <summary>
		/// Returns an indication whether a constant with a specified value exists in a specified enumeration.
		/// </summary>
		/// <param name="value">An integral value in the enumeration.</param>
		/// <returns>
		/// True if a constant in the enumeration has a value equal to <paramref name="value"/>; otherwise, false.
		/// </returns>
		public static bool IsDefined(byte value) { return IsDefined((object) value); }

		/// <summary>
		/// Returns an indication whether a constant with a specified value exists in a specified enumeration.
		/// </summary>
		/// <param name="value">An integral value in the enumeration.</param>
		/// <returns>
		/// True if a constant in the enumeration has a value equal to <paramref name="value"/>; otherwise, false.
		/// </returns>
		public static bool IsDefined(char value) { return IsDefined((object) value); }

		/// <summary>
		/// Returns an indication whether a constant with a specified value exists in a specified enumeration.
		/// </summary>
		/// <param name="value">An integral value in the enumeration.</param>
		/// <returns>
		/// True if a constant in the enumeration has a value equal to <paramref name="value"/>; otherwise, false.
		/// </returns>
		public static bool IsDefined(short value) { return IsDefined((object) value); }

		/// <summary>
		/// Returns an indication whether a constant with a specified value exists in a specified enumeration.
		/// </summary>
		/// <param name="value">An integral value in the enumeration.</param>
		/// <returns>
		/// True if a constant in the enumeration has a value equal to <paramref name="value"/>; otherwise, false.
		/// </returns>
		public static bool IsDefined(ushort value) { return IsDefined((object) value); }

		/// <summary>
		/// Returns an indication whether a constant with a specified value exists in a specified enumeration.
		/// </summary>
		/// <param name="value">An integral value in the enumeration.</param>
		/// <returns>
		/// True if a constant in the enumeration has a value equal to <paramref name="value"/>; otherwise, false.
		/// </returns>
		public static bool IsDefined(int value) { return IsDefined((object) value); }

		/// <summary>
		/// Returns an indication whether a constant with a specified value exists in a specified enumeration.
		/// </summary>
		/// <param name="value">An integral value in the enumeration.</param>
		/// <returns>
		/// True if a constant in the enumeration has a value equal to <paramref name="value"/>; otherwise, false.
		/// </returns>
		public static bool IsDefined(uint value) { return IsDefined((object) value); }

		/// <summary>
		/// Returns an indication whether a constant with a specified value exists in a specified enumeration.
		/// </summary>
		/// <param name="value">An integral value in the enumeration.</param>
		/// <returns>
		/// True if a constant in the enumeration has a value equal to <paramref name="value"/>; otherwise, false.
		/// </returns>
		public static bool IsDefined(long value) { return IsDefined((object) value); }

		/// <summary>
		/// Returns an indication whether a constant with a specified value exists in a specified enumeration.
		/// </summary>
		/// <param name="value">An integral value in the enumeration.</param>
		/// <returns>
		/// True if a constant in the enumeration has a value equal to <paramref name="value"/>; otherwise, false.
		/// </returns>
		public static bool IsDefined(ulong value) { return IsDefined((object) value); }

		private static bool IsDefined(object value)
		{
			var converted = Convert.ChangeType(value, GetUnderlyingType());
			return Enum.IsDefined(typeof(E), converted);
		}

		#endregion

		/// <summary>
		/// Converts the string representation of the name or numeric value of one or more
		/// enumerated constants to an equivalent enumerated object.
		/// </summary>
		/// <param name="name">A string containing the name or value to convert.</param>
		/// <param name="ignoreCase">If true, ignore case; otherwise, regard case.</param>
		/// <returns>
		/// A constant whose value is represented by <paramref name="name"/>.
		/// </returns>
		public static E Parse(string name, bool ignoreCase)
		{
			return (E) Enum.Parse(typeof(E), name, ignoreCase);
		}

		/// <summary>
		/// Converts the string representation of the name or numeric value of one or more
		/// enumerated constants to an equivalent enumerated object.
		/// </summary>
		/// <param name="name">
		/// A string containing the name or value to convert.
		/// </param>
		/// <returns>
		/// A constant whose value is represented by <paramref name="name"/>.
		/// </returns>
		public static E Parse(string name)
		{
			return Parse(name, false);
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
		/// When this method returns, <paramref name="result"/> contains the E value equivalent
		/// to name or numeric value in <paramref name="name"/> if the conversion succeeded,
		/// or null if the conversion failed.
		/// </param>
		/// <param name="ignoreCase">
		/// If true, ignore case; otherwise, regard case.
		/// </param>
		/// <returns>
		/// True if the <paramref name="name"/> parameter was converted successfully; otherwise, false.
		/// </returns>
		public static bool TryParse(string name, out E? result, bool ignoreCase)
		{
			try
			{
				result = Parse(name, ignoreCase);
				return true;
			}
			catch
			{
				result = null;
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
		/// When this method returns, <paramref name="result"/> contains the E value equivalent
		/// to name or numeric value in <paramref name="name"/> if the conversion succeeded,
		/// or null if the conversion failed.
		/// </param>
		/// <returns>
		/// True if the <paramref name="name"/> parameter was converted successfully; otherwise, false.
		/// </returns>
		public static bool TryParse(string name, out E? result)
		{
			return TryParse(name, out result, false);
		}

		#region ToConstant

		/// <summary>
		/// Returns an enumeration constant that matches the given integral value.
		/// </summary>
		/// <param name="value">An integral value.</param>
		/// <returns>
		/// An enumeration object whose value is <paramref name="value"/>.
		/// </returns>
		public static E ToConstant(sbyte value) { return ToConstant((object) value); }

		/// <summary>
		/// Returns an enumeration constant that matches the given integral value.
		/// </summary>
		/// <param name="value">An integral value.</param>
		/// <returns>
		/// An enumeration object whose value is <paramref name="value"/>.
		/// </returns>
		public static E ToConstant(byte value) { return ToConstant((object) value); }

		/// <summary>
		/// Returns an enumeration constant that matches the given integral value.
		/// </summary>
		/// <param name="value">An integral value.</param>
		/// <returns>
		/// An enumeration object whose value is <paramref name="value"/>.
		/// </returns>
		public static E ToConstant(char value) { return ToConstant((object) value); }

		/// <summary>
		/// Returns an enumeration constant that matches the given integral value.
		/// </summary>
		/// <param name="value">An integral value.</param>
		/// <returns>
		/// An enumeration object whose value is <paramref name="value"/>.
		/// </returns>
		public static E ToConstant(short value) { return ToConstant((object) value); }

		/// <summary>
		/// Returns an enumeration constant that matches the given integral value.
		/// </summary>
		/// <param name="value">An integral value.</param>
		/// <returns>
		/// An enumeration object whose value is <paramref name="value"/>.
		/// </returns>
		public static E ToConstant(ushort value) { return ToConstant((object) value); }

		/// <summary>
		/// Returns an enumeration constant that matches the given integral value.
		/// </summary>
		/// <param name="value">An integral value.</param>
		/// <returns>
		/// An enumeration object whose value is <paramref name="value"/>.
		/// </returns>
		public static E ToConstant(int value) { return ToConstant((object) value); }

		/// <summary>
		/// Returns an enumeration constant that matches the given integral value.
		/// </summary>
		/// <param name="value">An integral value.</param>
		/// <returns>
		/// An enumeration object whose value is <paramref name="value"/>.
		/// </returns>
		public static E ToConstant(uint value) { return ToConstant((object) value); }

		/// <summary>
		/// Returns an enumeration constant that matches the given integral value.
		/// </summary>
		/// <param name="value">An integral value.</param>
		/// <returns>
		/// An enumeration object whose value is <paramref name="value"/>.
		/// </returns>
		public static E ToConstant(long value) { return ToConstant((object) value); }

		/// <summary>
		/// Returns an enumeration constant that matches the given integral value.
		/// </summary>
		/// <param name="value">An integral value.</param>
		/// <returns>
		/// An enumeration object whose value is <paramref name="value"/>.
		/// </returns>
		public static E ToConstant(ulong value) { return ToConstant((object) value); }

		private static E ToConstant(object value)
		{
			// This code is here to cause an overflow exception to be emitted
			// if this is a narrowing conversion.
			Convert.ChangeType(value, GetUnderlyingType());
			return (E) Enum.ToObject(typeof(E), value);
		}

		#endregion
		
		/// <summary>
		/// Gets the description of the constant.
		/// </summary>
		/// <param name="constant"></param>
		/// <returns></returns>
		private static string GetDescriptionOf(E constant)
		{
			var attribute = constant
				.GetType()
				.GetField(constant.ToString())
				.GetCustomAttributes(typeof(DescriptionAttribute), false);

			if (attribute.Length != 0)
				return attribute
					.Cast<DescriptionAttribute>()
					.First()
					.Description;

			return constant.ToString();
		}
		
		#region GetDescription

		/// <summary>
		/// Retrieves the description of the constant in the enumeration that has the specified value.
		/// </summary>
		/// <param name="constant">A constant in the enumeration.</param>
		/// <returns>
		/// The value of the description attribute or, if none existed,
		/// the string value of the constant.
		/// </returns>
		public static string GetDescription(E constant)
		{
			return ConstantToDescriptionMap[constant];
		}

		/// <summary>
		/// Retrieves the description of the constant in the enumeration that has the specified value.
		/// </summary>
		/// <param name="value">An integal value of a constant in the enumeration.</param>
		/// <returns>
		/// The value of the description attribute or, if none existed,
		/// the string value of the constant.
		/// </returns>
		public static string GetDescription(sbyte value) { return GetDescription((object) value); }
		
		/// <summary>
		/// Retrieves the description of the constant in the enumeration that has the specified value.
		/// </summary>
		/// <param name="value">An integal value of a constant in the enumeration.</param>
		/// <returns>
		/// The value of the description attribute or, if none existed,
		/// the string value of the constant.
		/// </returns>
		public static string GetDescription(byte value) { return GetDescription((object) value); }
		
		/// <summary>
		/// Retrieves the description of the constant in the enumeration that has the specified value.
		/// </summary>
		/// <param name="value">An integal value of a constant in the enumeration.</param>
		/// <returns>
		/// The value of the description attribute or, if none existed,
		/// the string value of the constant.
		/// </returns>
		public static string GetDescription(char value) { return GetDescription((object) value); }
		
		/// <summary>
		/// Retrieves the description of the constant in the enumeration that has the specified value.
		/// </summary>
		/// <param name="value">An integal value of a constant in the enumeration.</param>
		/// <returns>
		/// The value of the description attribute or, if none existed,
		/// the string value of the constant.
		/// </returns>
		public static string GetDescription(short value) { return GetDescription((object) value); }
		
		/// <summary>
		/// Retrieves the description of the constant in the enumeration that has the specified value.
		/// </summary>
		/// <param name="value">An integal value of a constant in the enumeration.</param>
		/// <returns>
		/// The value of the description attribute or, if none existed,
		/// the string value of the constant.
		/// </returns>
		public static string GetDescription(ushort value) { return GetDescription((object) value); }
		
		/// <summary>
		/// Retrieves the description of the constant in the enumeration that has the specified value.
		/// </summary>
		/// <param name="value">An integal value of a constant in the enumeration.</param>
		/// <returns>
		/// The value of the description attribute or, if none existed,
		/// the string value of the constant.
		/// </returns>
		public static string GetDescription(int value) { return GetDescription((object) value); }
		
		/// <summary>
		/// Retrieves the description of the constant in the enumeration that has the specified value.
		/// </summary>
		/// <param name="value">An integal value of a constant in the enumeration.</param>
		/// <returns>
		/// The value of the description attribute or, if none existed,
		/// the string value of the constant.
		/// </returns>
		public static string GetDescription(uint value) { return GetDescription((object) value); }
		
		/// <summary>
		/// Retrieves the description of the constant in the enumeration that has the specified value.
		/// </summary>
		/// <param name="value">An integal value of a constant in the enumeration.</param>
		/// <returns>
		/// The value of the description attribute or, if none existed,
		/// the string value of the constant.
		/// </returns>
		public static string GetDescription(long value) { return GetDescription((object) value); }
		
		/// <summary>
		/// Retrieves the description of the constant in the enumeration that has the specified value.
		/// </summary>
		/// <param name="value">An integal value of a constant in the enumeration.</param>
		/// <returns>
		/// The value of the description attribute or, if none existed,
		/// the string value of the constant.
		/// </returns>
		public static string GetDescription(ulong value) { return GetDescription((object) value); }

		private static string GetDescription(object value)
		{
			// This code is here to cause an overflow exception to be emitted
			// if this is a narrowing conversion.
			return GetDescription(ToConstant(value));
		}

		#endregion

		/// <summary>
		/// Retrieves a list of all the descriptions of the constants in the enumeration.
		/// </summary>
		/// <returns>
		/// The elements of the list are sorted by the binary values
		/// of the enumeration constants.
		/// </returns>
		public static IList<string> GetDescriptions()
		{
			return (from c in GetConstants() select GetDescription(c)).ToList();
		}

		/// <summary>
		/// Finds all constants in the enumeration that have a description
		/// matching <paramref name="description"/>.  If a constant has no description,
		/// the constant's string value is used as its description.
		/// </summary>
		/// <param name="description"></param>
		/// <param name="ignoreCase"></param>
		/// <returns>
		/// The constants in the enumeration that have a description
		/// matching <paramref name="description"/>.
		/// </returns>
		public static IEnumerable<E> ParseDescription(string description, bool ignoreCase)
		{						
            var message = "Requested value '{0}' was not found.";
            
            if (ignoreCase)
            {
                var map = ConstantToDescriptionMap;
                var comparison = StringComparison.CurrentCultureIgnoreCase;
                var constants = from k in ConstantToDescriptionMap.Keys
                                where map[k].Equals(description, comparison)
                                select k;

                if (constants.Count() == 0)
                    throw new ArgumentException(string.Format(message, description));

                return constants;
            }
            else
            {
                var map = DescriptionToConstantsMap;

                if (!map.ContainsKey(description) || map[description].Count == 0)
                    throw new ArgumentException(string.Format(message, description));

                return map[description];
            }            
		}

        /// <summary>
		/// Finds all constants in the enumeration that have a description
		/// matching <paramref name="description"/>.  If a constant has no description,
		/// the constant's string value is used as its description.
		/// </summary>
		/// <param name="description"></param>		
		/// <returns>
		/// The constants in the enumeration that have a description
		/// matching <paramref name="description"/>.
		/// </returns>
        public static IEnumerable<E> ParseDescription(string description)
        {
            return ParseDescription(description, false);
        }

		/// <summary>
        /// Finds all constants in the enumeration that have a description
        /// matching <paramref name="description"/> and returns a value that
		/// indicates whether any constants were founded.
		/// </summary>
		/// <param name="description">A string containing the description to convert.</param>
		/// <param name="result">
		/// When this method returns, <paramref name="result"/> contains the enumerable of constants with
		/// the description in <paramref name="description"/> if the conversion succeeded,
		/// or null if the conversion failed.
		/// </param>
		/// <param name="ignoreCase">
		/// If true, ignore case; otherwise, regard case.
		/// </param>
		/// <returns>
		/// True if the <paramref name="description"/> parameter was converted successfully;
		/// otherwise, false.
		/// </returns>
		public static bool TryParseDescription(string description, out IEnumerable<E> result, bool ignoreCase)
		{
			try
			{
				result = ParseDescription(description, ignoreCase);
				return true;
			}
			catch
			{
				result = Enumerable.Empty<E>();
				return false;
			}
		}

        /// <summary>
        /// Finds all constants in the enumeration that have a description
        /// matching <paramref name="description"/> and returns a value that
        /// indicates whether any constants were founded.
        /// </summary>
        /// <param name="description">A string containing the description to convert.</param>
        /// <param name="result">
        /// When this method returns, <paramref name="result"/> contains the enumerable of constants with
        /// the description in <paramref name="description"/> if the conversion succeeded,
        /// or null if the conversion failed.
        /// </param>
		/// <returns>
		/// True if the <paramref name="description"/> parameter was converted successfully;
		/// otherwise, false.
		/// </returns>
		public static bool TryParseDescription(string description, out IEnumerable<E> result)
		{
			return TryParseDescription(description, out result, false);
		}
		
	}
}
