using System;
using Entelect.Extensions;

namespace Entelect.Types
{
    /// <summary>
    /// Extension methods for working with CLR types
    /// </summary>
    public class TypeExtensions
    {
        /// <summary>
        /// Takes in a type name string and tries to get the built in system type from that
        /// Adapted from http://stackoverflow.com/questions/721870/c-sharp-how-can-i-get-type-from-a-string-representation
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns>Null if type is not recognized</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Type GetTypeFromTypeName(string typeName)
        {
            if (typeName == null)
            {
                throw new ArgumentNullException("typeName");
            }

            var isArray = typeName.IndexOf("[]", StringComparison.OrdinalIgnoreCase) != -1;
            var isNullable = typeName.IndexOf("?", StringComparison.OrdinalIgnoreCase) != -1;

            var formattedTypeName = FormatTypeName(typeName, isArray, isNullable);

            var systemTypeName = ExtractSystemTypeNames(formattedTypeName);

            var extractedTypeName = ExtractType(systemTypeName, isArray, isNullable, formattedTypeName);

            return Type.GetType(extractedTypeName);
        }

        private static string ExtractType(string systemTypeName, bool isArray, bool isNullable, string formattedTypeName)
        {
            var extractedTypeName = systemTypeName;
            if (extractedTypeName != null)
            {
                if(isArray)
                {
                    extractedTypeName = extractedTypeName + "[]";
                }

                if(isNullable)
                {
                    extractedTypeName = String.Concat("System.Nullable`1[", extractedTypeName, "]");
                }
            }
            else
            {
                extractedTypeName = formattedTypeName;
            }
            return extractedTypeName;
        }

        private static string FormatTypeName(string typeName, bool isArray, bool isNullable)
        {
            var name = typeName;
            if(isArray)
            {
                name = name.Remove(name.IndexOf("[]", StringComparison.OrdinalIgnoreCase), 2);
            }

            if(isNullable)
            {
                name = name.Remove(name.IndexOf("?", StringComparison.OrdinalIgnoreCase), 1);
            }

            name = name.ToLower();
            name = name.ReplaceIgnoreCase("system.", "");
            return name;
        }

        private static string ExtractSystemTypeNames(string typeName)
        {
            switch(typeName)
            {
                case "bool":
                case "boolean":
                    return "System.Boolean";
                case "byte":
                    return "System.Byte";
                case "char":
                    return "System.Char";
                case "datetime":
                    return "System.DateTime";
                case "datetimeoffset":
                    return "System.DateTimeOffset";
                case "decimal":
                    return "System.Decimal";
                case "double":
                    return "System.Double";
                case "float":
                    return "System.Single";
                case "int16":
                case "short":
                    return "System.Int16";
                case "int32":
                case "int":
                    return "System.Int32";
                case "int64":
                case "long":
                    return "System.Int64";
                case "object":
                    return "System.Object";
                case "sbyte":
                    return "System.SByte";
                case "string":
                    return "System.String";
                case "timespan":
                    return "System.TimeSpan";
                case "uint16":
                case "ushort":
                    return "System.UInt16";
                case "uint32":
                case "uint":
                    return "System.UInt32";
                case "uint64":
                case "ulong":
                    return "System.UInt64";
                default:
                    return null;
            }
        }
    }
}