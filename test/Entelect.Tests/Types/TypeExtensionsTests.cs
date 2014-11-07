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
        public void GetTypeFromTypeName(string typeString, Type expectedType)
        {
            var type = TypeExtensions.GetTypeFromTypeName(typeString);
            Assert.AreEqual(expectedType, type);
        }
    }
}