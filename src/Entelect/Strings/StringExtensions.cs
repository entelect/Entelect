using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace - All extensions are within the same name space otherwise they don't show up in intellisense


namespace Entelect.Extensions
{
    /// <summary>
    /// Contains a variety of extensions for strings
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Checks if a string contains the specified value according to the provided comparison rules
        /// </summary>
        /// <param name="input">the string to check</param>
        /// <param name="value">the value to check for</param>
        /// <param name="stringComparison">the rules to use in the check</param>
        /// <returns>the value of the expression</returns>
        public static bool Contains(this string input, string value, StringComparison stringComparison)
        {
            return input.IndexOf(value, stringComparison) >= 0;
        }

        /// <summary>
        /// Determines whether the provided list of strings contains the specified string using the provided StringComparison object.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="value">The value.</param>
        /// <param name="stringComparison">The string comparison object to use.</param>
        /// <returns>True if the list contains the value otherwise false</returns>
        public static bool Contains(this IEnumerable<string> input, string value, StringComparison stringComparison)
        {
            return input.Any(item => item.Equals(value, stringComparison));
        }
    }
}