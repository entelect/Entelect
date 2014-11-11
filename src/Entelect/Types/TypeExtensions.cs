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

            bool isArray = false, isNullable = false;

            if (typeName.IndexOf("[]", StringComparison.OrdinalIgnoreCase) != -1)
            {
                isArray = true;
                typeName = typeName.Remove(typeName.IndexOf("[]", StringComparison.OrdinalIgnoreCase), 2);
            }

            if (typeName.IndexOf("?", StringComparison.OrdinalIgnoreCase) != -1)
            {
                isNullable = true;
                typeName = typeName.Remove(typeName.IndexOf("?", StringComparison.OrdinalIgnoreCase), 1);
            }

            typeName = typeName.ToLower();
            typeName = typeName.ReplaceIgnoreCase("system.", "");
            string parsedTypeName = null;
            switch (typeName)
            {
                case "bool":
                case "boolean":
                    parsedTypeName = "System.Boolean";
                    break;
                case "byte":
                    parsedTypeName = "System.Byte";
                    break;
                case "char":
                    parsedTypeName = "System.Char";
                    break;
                case "datetime":
                    parsedTypeName = "System.DateTime";
                    break;
                case "datetimeoffset":
                    parsedTypeName = "System.DateTimeOffset";
                    break;
                case "decimal":
                    parsedTypeName = "System.Decimal";
                    break;
                case "double":
                    parsedTypeName = "System.Double";
                    break;
                case "float":
                    parsedTypeName = "System.Single";
                    break;
                case "int16":
                case "short":
                    parsedTypeName = "System.Int16";
                    break;
                case "int32":
                case "int":
                    parsedTypeName = "System.Int32";
                    break;
                case "int64":
                case "long":
                    parsedTypeName = "System.Int64";
                    break;
                case "object":
                    parsedTypeName = "System.Object";
                    break;
                case "sbyte":
                    parsedTypeName = "System.SByte";
                    break;
                case "string":
                    parsedTypeName = "System.String";
                    break;
                case "timespan":
                    parsedTypeName = "System.TimeSpan";
                    break;
                case "uint16":
                case "ushort":
                    parsedTypeName = "System.UInt16";
                    break;
                case "uint32":
                case "uint":
                    parsedTypeName = "System.UInt32";
                    break;
                case "uint64":
                case "ulong":
                    parsedTypeName = "System.UInt64";
                    break;
            }

            if (parsedTypeName != null)
            {
                if (isArray)
                {
                    parsedTypeName = parsedTypeName + "[]";
                }

                if (isNullable)
                {
                    parsedTypeName = String.Concat("System.Nullable`1[", parsedTypeName, "]");
                }
            }
            else
            {
                parsedTypeName = typeName;
            }

            return Type.GetType(parsedTypeName);
        }
    }
}