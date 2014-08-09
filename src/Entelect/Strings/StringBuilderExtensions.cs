using System.Text;

namespace Entelect.Extensions
{
    public static class StringBuilderExtensions
    {
        /// <summary>
        /// Appends the args and a new line character
        /// </summary>
        public static StringBuilder AppendLineFormat(this StringBuilder input, string value, object arg0)
        {
            return input.AppendFormat(value, arg0).AppendLine();
        }
        /// <summary>
        /// Appends the args and a new line character
        /// </summary>
        public static StringBuilder AppendLineFormat(this StringBuilder input, string value, object arg0, object arg1)
        {
            return input.AppendFormat(value, arg0, arg1).AppendLine();
        }
        /// <summary>
        /// Appends the args and a new line character
        /// </summary>
        public static StringBuilder AppendLineFormat(this StringBuilder input, string value, object arg0, object arg1, object arg2)
        {
            return input.AppendFormat(value, arg0, arg1, arg2).AppendLine();
        }
        /// <summary>
        /// Appends the args and a new line character
        /// </summary>
        public static StringBuilder AppendLineFormat(this StringBuilder input, string value, params object[] args)
        {
            return input.AppendFormat(value, args).AppendLine();
        }
    }
}
