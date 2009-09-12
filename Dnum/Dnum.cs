using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format"></param>
        /// <returns></returns>
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

        public static string GetName(sbyte value)  { return GetName((object) value); }
        public static string GetName(byte value)   { return GetName((object) value); }
        public static string GetName(char value)   { return GetName((object) value); }
        public static string GetName(short value)  { return GetName((object) value); }
        public static string GetName(ushort value) { return GetName((object) value); }
        public static string GetName(int value)    { return GetName((object) value); }
        public static string GetName(uint value)   { return GetName((object) value); }
        public static string GetName(long value)   { return GetName((object) value); }
        public static string GetName(ulong value)  { return GetName((object) value); }

        private static string GetName(object value)
        {
            // This code is here to cause an overflow exception to be emitted
            // if this is a narrowing conversion.
            Convert.ChangeType(value, GetUnderlyingType());
            return Enum.GetName(typeof(E), value);
        }

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

        public static bool IsDefined(sbyte value)  { return IsDefined((object) value); }
        public static bool IsDefined(byte value)   { return IsDefined((object) value); }
        public static bool IsDefined(char value)   { return IsDefined((object) value); }
        public static bool IsDefined(short value)  { return IsDefined((object) value); }
        public static bool IsDefined(ushort value) { return IsDefined((object) value); }
        public static bool IsDefined(int value)    { return IsDefined((object) value); }
        public static bool IsDefined(uint value)   { return IsDefined((object) value); }
        public static bool IsDefined(long value)   { return IsDefined((object) value); }
        public static bool IsDefined(ulong value)  { return IsDefined((object) value); }

        private static bool IsDefined(object value)
        {
            var converted = Convert.ChangeType(value, GetUnderlyingType());
            return Enum.IsDefined(typeof(E), converted);
        }

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
        /// When this method returns, result contains the E value equivalent to name or numeric value in name 
        /// if the conversion succeeded, or default(E) if the conversion failed.
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
        /// When this method returns, result contains the E value equivalent to name or numeric value in name 
        /// if the conversion succeeded, or default(E) if the conversion failed.
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
        public static E ToConstant(sbyte value)  { return ToConstant((object) value); }
        public static E ToConstant(byte value)   { return ToConstant((object) value); }
        public static E ToConstant(char value)   { return ToConstant((object) value); }
        public static E ToConstant(short value)  { return ToConstant((object) value); }
        public static E ToConstant(ushort value) { return ToConstant((object) value); }
        public static E ToConstant(int value)    { return ToConstant((object) value); }
        public static E ToConstant(uint value)   { return ToConstant((object) value); }
        public static E ToConstant(long value)   { return ToConstant((object) value); }
        public static E ToConstant(ulong value)  { return ToConstant((object) value); }

        private static E ToConstant(object value)
        {            
            // This code is here to cause an overflow exception to be emitted
            // if this is a narrowing conversion.
            Convert.ChangeType(value, GetUnderlyingType());
            return (E) Enum.ToObject(typeof(E), value);
        }

        /// <summary>
        /// Retrieves the description of the constant in the enumeration that has the specified value. 
        /// </summary>
        /// <param name="constant">A constant in the enumeration.</param>
        /// <returns></returns>
        public static string GetDescription(E constant)
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

        public static string GetDescription(sbyte value)  { return GetDescription((object) value); }
        public static string GetDescription(byte value)   { return GetDescription((object) value); }
        public static string GetDescription(char value)   { return GetDescription((object) value); }
        public static string GetDescription(short value)  { return GetDescription((object) value); }
        public static string GetDescription(ushort value) { return GetDescription((object) value); }
        public static string GetDescription(int value)    { return GetDescription((object) value); }
        public static string GetDescription(uint value)   { return GetDescription((object) value); }
        public static string GetDescription(long value)   { return GetDescription((object) value); }
        public static string GetDescription(ulong value)  { return GetDescription((object) value); }

        private static string GetDescription(object value)
        {
            // This code is here to cause an overflow exception to be emitted
            // if this is a narrowing conversion.            
            return GetDescription(ToConstant(value));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IList<string> GetDescriptions()
        {
            return (from c in GetConstants() select GetDescription(c)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="constant"></param>
        /// <returns></returns>
        public static bool HasDescription(E constant)
        {
            var attribute = constant
                .GetType()
                .GetField(constant.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attribute.Length != 0;
        }

        public static bool HasDescription(string name)
        {
            return IsDefined(name) ? HasDescription(Parse(name)) : false;                
        }

        public static bool HasDescription(sbyte value)  { return HasDescription((object) value); }
        public static bool HasDescription(byte value)   { return HasDescription((object) value); }
        public static bool HasDescription(char value)   { return HasDescription((object) value); }
        public static bool HasDescription(short value)  { return HasDescription((object) value); }
        public static bool HasDescription(ushort value) { return HasDescription((object) value); }
        public static bool HasDescription(int value)    { return HasDescription((object) value); }
        public static bool HasDescription(uint value)   { return HasDescription((object) value); }
        public static bool HasDescription(long value)   { return HasDescription((object) value); }
        public static bool HasDescription(ulong value)  { return HasDescription((object) value); }

        private static bool HasDescription(object value)
        {            
            return IsDefined(value) ? HasDescription(ToConstant(value)) : false;
        }

    }
}
