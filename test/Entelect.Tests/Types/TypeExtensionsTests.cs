using System;
using Entelect.Types;
using NUnit.Framework;

namespace Entelect.Tests.Types
{
    [TestFixture]
    public class TypeExtensionsTests
    {
        [Test]
        [TestCase("string", typeof(String))]
        [TestCase("system.string", typeof(String))]
        [TestCase("bool", typeof(bool))]
        [TestCase("boolean", typeof(bool))]
        [TestCase("byte", typeof(byte))]
        [TestCase("char", typeof(char))]
        [TestCase("datetime", typeof(System.DateTime))]
        [TestCase("datetimeoffset", typeof(DateTimeOffset))]
        [TestCase("decimal", typeof(Decimal))]
        [TestCase("double", typeof(Double))]
        [TestCase("float", typeof(Single))]
        [TestCase("int16", typeof(Int16))]
        [TestCase("short", typeof(Int16))]
        [TestCase("int32", typeof(Int32))]
        [TestCase("int", typeof(Int32))]
        [TestCase("int64", typeof(Int64))]
        [TestCase("long", typeof(Int64))]
        [TestCase("object", typeof(Object))]
        [TestCase("sbyte", typeof(SByte))]
        [TestCase("timespan", typeof(TimeSpan))]
        [TestCase("uint16", typeof(UInt16))]
        [TestCase("ushort", typeof(UInt16))]
        [TestCase("uint32", typeof(UInt32))]
        [TestCase("uint", typeof(UInt32))]
        [TestCase("uint64", typeof(UInt64))]
        [TestCase("ulong", typeof(UInt64))]
        public void GetTypeFromTypeName(string typeString, Type expectedType)
        {
            var type = TypeExtensions.GetTypeFromTypeName(typeString);
            Assert.AreEqual(expectedType, type);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GivenNullTypeString_WhenGetTypeFromTypeName_ThrowException()
        {
            TypeExtensions.GetTypeFromTypeName(null);
        }

        [Test]
        public void GivenTypeNameAsArray_WhenGetTypeFromTypeName_ReturnArrayOfType()
        {
            var type = TypeExtensions.GetTypeFromTypeName("string[]");
            Assert.AreEqual(typeof(String[]), type);
        }

        [Test]
        public void GivenNullableTypeName_WhenGetTypeFromTypeName_ReturnNullableType()
        {
            var type = TypeExtensions.GetTypeFromTypeName("Int?");
            Assert.AreEqual(typeof(Int32?), type);
        }

        [Test]
        public void GivenUnKnowntype_WhenGetTypeFromTypeName_ReturnNull()
        {
            var type = TypeExtensions.GetTypeFromTypeName("SomeType");
            Assert.IsNull(type);
        }
    }
}