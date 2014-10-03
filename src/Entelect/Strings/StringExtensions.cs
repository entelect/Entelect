using System;
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
    }
}