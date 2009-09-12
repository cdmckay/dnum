using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace Dnum
{
    public static class Dnum<E> where E : struct
    {
        /// <summary>
        /// Converts the constant of an enumeration to its equivalent string 
        /// representation according to the specified format.
        /// </summary>
        /// <param name="constant">A constant in the enumeration.</param>
        /// <param name="format">The output format to use. </param>
        /// <returns>A string representation of the constant or value.</returns>
        public static string Format(E constant, string format)
        {
            return Enum.Format(typeof(E), constant, format);
        }

        public static string Format(sbyte value, string format)  { return Enum.Format(typeof(E), value, format); }
        public static string Format(byte value, string format)   { return Enum.Format(typeof(E), value, format); }
        public static string Format(char value, string format)   { return Enum.Format(typeof(E), value, format); }
        public static string Format(short value, string format)  { return Enum.Format(typeof(E), value, format); }
        public static string Format(ushort value, string format) { return Enum.Format(typeof(E), value, format); }
        public static string Format(int value, string format)    { return Enum.Format(typeof(E), value, format); }
        public static string Format(uint value, string format)   { return Enum.Format(typeof(E), value, format); }
        public static string Format(long value, string format)   { return Enum.Format(typeof(E), value, format); }
        public static string Format(ulong value, string format)  { return Enum.Format(typeof(E), value, format); }

        /// <summary>
        /// Retrieves the name of the constant in the enumeration that has the specified value. 
        /// </summary>
        /// <param name="constant">
        /// A constant in the enumeration.
        /// </param>
        /// <returns>
        /// A string containing the name of the enumerated constant in enumType whose value is value,
        /// or null if no such constant is found.
        /// </returns>
        public static string GetName(E constant)
        {
            return Enum.GetName(typeof(E), constant);
        }

        public static string GetName(sbyte value)  { return Enum.GetName(typeof(E), value); }
        public static string GetName(byte value)   { return Enum.GetName(typeof(E), value); }
        public static string GetName(char value)   { return Enum.GetName(typeof(E), value); }
        public static string GetName(short value)  { return Enum.GetName(typeof(E), value); }
        public static string GetName(ushort value) { return Enum.GetName(typeof(E), value); }
        public static string GetName(int value)    { return Enum.GetName(typeof(E), value); }
        public static string GetName(uint value)   { return Enum.GetName(typeof(E), value); }
        public static string GetName(long value)   { return Enum.GetName(typeof(E), value); }
        public static string GetName(ulong value)  { return Enum.GetName(typeof(E), value); }

        /// <summary>
        /// Retrieves an array of the names of the constants in the enumeration. 
        /// </summary>
        /// <returns>
        /// A string enumerable of the names of the constants in enumType. 
        /// </returns>
        public static IList<string> GetNames()
        {
            return Enum.GetNames(typeof(E)).ToList();
        }

        /// <summary>
        /// Returns the underlying type of the enumeration. 
        /// </summary>
        /// <returns>
        /// The underlying Type of T.
        /// </returns>
        public static Type GetUnderlyingType()
        {
            return Enum.GetUnderlyingType(typeof(E));
        }

        /// <summary>
        /// Retrieves an array of the values of the constants in the enumeration. 
        /// </summary>
        /// <returns>
        /// An enumerable of the values of the constants in the enumeration. 
        /// The elements of the enumerable are sorted by the binary values of the enumeration constants.
        /// </returns>
        public static IEnumerable<int> GetValues()
        {
            return Enum.GetValues(typeof(E)).Cast<int>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> GetValues<T>() where T
            : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            return Enum.GetValues(typeof(E)).Cast<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<E> GetConstants()
        {
            return Enum.GetValues(typeof(E)).Cast<E>();
        }

        /// <summary>
        /// Returns an indication whether a constant with a specified value exists in the enumeration. 
        /// </summary>
        /// <param name="constant">
        /// A constant in the enumeration. 
        /// </param>
        /// <returns>
        /// True if a constant in the enumeration has a value equal to value; otherwise, false.
        /// </returns>
        public static bool IsDefined(E constant)
        {
            return Enum.IsDefined(typeof(E), constant);
        }

        public static bool IsDefined(string name)
        {
            return Enum.IsDefined(typeof(E), name);
        }

        public static bool IsDefined(sbyte value)  { return Enum.IsDefined(typeof(E), value); }
        public static bool IsDefined(byte value)   { return Enum.IsDefined(typeof(E), value); }
        public static bool IsDefined(char value)   { return Enum.IsDefined(typeof(E), value); }
        public static bool IsDefined(short value)  { return Enum.IsDefined(typeof(E), value); }
        public static bool IsDefined(ushort value) { return Enum.IsDefined(typeof(E), value); }
        public static bool IsDefined(int value)    { return Enum.IsDefined(typeof(E), value); }
        public static bool IsDefined(uint value)   { return Enum.IsDefined(typeof(E), value); }
        public static bool IsDefined(long value)   { return Enum.IsDefined(typeof(E), value); }
        public static bool IsDefined(ulong value)  { return Enum.IsDefined(typeof(E), value); }

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
        /// An object of type T whose value is represented by value.
        /// </returns>
        public static E Parse(string name)
        {
            return Dnum<E>.Parse(name, false);
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
        /// <param name="ignoreCase">
        /// If true, ignore case; otherwise, regard case.
        /// </param>
        /// <returns>
        /// True if the name parameter was converted successfully; otherwise, false.
        /// </returns>
        public static bool TryParse(string name, out E result, bool ignoreCase)
        {
            try
            {
                result = Dnum<E>.Parse(name, ignoreCase);
                return true;
            }
            catch
            {
                result = default(E);
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
        public static bool TryParse(string name, out E result)
        {
            return Dnum<E>.TryParse(name, out result, false);
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
        public static E ToConstant(sbyte value)  { return (E) Enum.ToObject(typeof(E), value); }
        public static E ToConstant(byte value)   { return (E) Enum.ToObject(typeof(E), value); }
        public static E ToConstant(char value)   { return (E) Enum.ToObject(typeof(E), value); }
        public static E ToConstant(short value)  { return (E) Enum.ToObject(typeof(E), value); }
        public static E ToConstant(ushort value) { return (E) Enum.ToObject(typeof(E), value); }
        public static E ToConstant(int value)    { return (E) Enum.ToObject(typeof(E), value); }
        public static E ToConstant(uint value)   { return (E) Enum.ToObject(typeof(E), value); }
        public static E ToConstant(long value)   { return (E) Enum.ToObject(typeof(E), value); }
        public static E ToConstant(ulong value)  { return (E) Enum.ToObject(typeof(E), value); }

        /// <summary>
        /// Retrieves the description of the constant in the enumeration that has the specified value. 
        /// </summary>
        /// <param name="constant">A constant in the enumeration.</param>
        /// <returns></returns>
        public static string GetDescription(E constant)
        {
            var attribute = constant.GetType()
                .GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attribute.Length != 0)
                return attribute
                    .Cast<DescriptionAttribute>()
                    .First()
                    .Description;

            return constant.ToString();
        }

        public static IList<string> GetDescriptions()
        {
            return (from c in GetConstants() select GetDescription(c)).ToList();
        }

        public static bool HasDescription(E constant)
        {
            var attribute = constant.GetType()
                .GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attribute.Length != 0;
        }

    }
}
