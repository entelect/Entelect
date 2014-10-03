using System;
using NUnit.Framework;
using Entelect.Extensions;
namespace Entelect.Tests.Strings
{
    [TestFixture]
    public class StringExtensionsTests
    {
        [Test]
        public void CanCompareIgnoringCase()
        {
            var doesContain = "asd".Contains("S",StringComparison.OrdinalIgnoreCase);
            Assert.True(doesContain);
        }
    }
}