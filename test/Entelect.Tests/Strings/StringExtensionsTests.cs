using System;
using NUnit.Framework;
using Entelect.Extensions;
namespace Entelect.Tests.Strings
{
    [TestFixture]
    public class StringExtensionsTests
    {
        [Test]
        public void ContainsIgnoringCase()
        {
            var doesContain = "asd".Contains("S",StringComparison.OrdinalIgnoreCase);
            Assert.True(doesContain);
        }
        [Test]
        public void ListContainsIgnoringCase()
        {
            var list = new[] {"asd", "qwe", "zxc"};
            var doesContain = list.Contains("ASD", StringComparison.OrdinalIgnoreCase);
            Assert.True(doesContain);
        }
    }
}