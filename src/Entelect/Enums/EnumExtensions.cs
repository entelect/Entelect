using System;
namespace Entelect.Extensions
{
    /// <summary>
    /// Set of helper methods to make working with enums easier
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Takes an enum, that has pascal casing, splits it and returns a string that is more user friendly
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static string ToSpacedString(this Enum source)
        {
            /*todo rk, specify the type of casing, should the words be lowercase? first one upper i.e. sentance case?*/
            return source.ToString().PascalToSpacedString();
        }

        #region parsing
        /// <summary>
        /// Takes in a string and parses it to the provided enum
        /// Adapted from http://stackoverflow.com/questions/79126/create-generic-method-constraining-t-to-an-enum
        /// </summary>
        /// <typeparam name="T">The enum type.</typeparam>
        /// <param name="value">The value to parse.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">T must be an enumerated type</exception>
        public static T Parse<T>(string value) where T : struct, IConvertible
        {
            if(!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }
            return ParseEnum<T>(value, default(T), true);
        }


        /// <summary>
        /// Takes in a string and parses it to the provided enum
        /// Adapted from http://stackoverflow.com/questions/79126/create-generic-method-constraining-t-to-an-enum
        /// </summary>
        /// <typeparam name="T">The enum type.</typeparam>
        /// <param name="value">The value to parse.</param>
        /// <param name="defaultValue">The default value if unable to parse.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">T must be an enumerated type</exception>
        public static T Parse<T>(string value, T defaultValue) where T : struct, IConvertible
        {
            if(!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }
                
            if(string.IsNullOrWhiteSpace(value))
            {
                return defaultValue;
            }
                
            return ParseEnum(value, defaultValue, false);

        }

        /// <summary>
        /// Takes in a string and parses it to the provided enum
        /// Adapted from http://stackoverflow.com/questions/79126/create-generic-method-constraining-t-to-an-enum
        /// </summary>
        /// <typeparam name="T">The enum type.</typeparam>
        /// <param name="value">The value to parse.</param>
        /// <param name="defaultValue">The default value if unable to parse.</param>
        /// <param name="throwExceptionIfNotFound">specifies if the exception should be swallowed if the code fails to parse the provided value to an enum</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">T must be an enumerated type</exception>
        private static T ParseEnum<T>(string value, T defaultValue, bool throwExceptionIfNotFound) where T : struct, IConvertible
        {
            foreach (T item in Enum.GetValues(typeof(T)))
            {
                if(item.ToString().Equals(value.RemoveAllWhitespace(), StringComparison.OrdinalIgnoreCase))
                {
                    return item;
                }
                    
            }
            if(!throwExceptionIfNotFound)
            {
                return defaultValue;
            }
                
            throw new ArgumentException(string.Format("value {0} could not be converted to an enum of type {1}", value,
                                                      defaultValue.GetType().FullName));
        }
        #endregion

        #region Flags enum
        /* todo rk */
        /*public static IEnumerable<Enum> GetFlags(this Enum value)
        {
            return GetFlags(value, Enum.GetValues(value.GetType()).Cast<Enum>().ToArray());
        }

        public static IEnumerable<Enum> GetIndividualFlags(this Enum value)
        {
            return GetFlags(value, GetFlagValues(value.GetType()).ToArray());
        }

        private static IEnumerable<Enum> GetFlags(Enum value, Enum[] values)
        {
            ulong bits = Convert.ToUInt64(value);
            List<Enum> results = new List<Enum>();
            for (int i = values.Length - 1; i >= 0; i--)
            {
                ulong mask = Convert.ToUInt64(values[i]);
                if (i == 0 && mask == 0L)
                    break;
                if ((bits & mask) == mask)
                {
                    results.Add(values[i]);
                    bits -= mask;
                }
            }
            if (bits != 0L)
                return Enumerable.Empty<Enum>();
            if (Convert.ToUInt64(value) != 0L)
                return results.Reverse<Enum>();
            if (bits == Convert.ToUInt64(value) && values.Length > 0 && Convert.ToUInt64(values[0]) == 0L)
                return values.Take(1);
            return Enumerable.Empty<Enum>();
        }

        private static IEnumerable<Enum> GetFlagValues(Type enumType)
        {
            ulong flag = 0x1;
            foreach (var value in Enum.GetValues(enumType).Cast<Enum>())
            {
                ulong bits = Convert.ToUInt64(value);
                if (bits == 0L)
                    //yield return value;
                    continue; // skip the zero value
                while (flag < bits) flag <<= 1;
                if (flag == bits)
                    yield return value;
            }
        }*/
        #endregion
    }
}
