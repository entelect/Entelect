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

        [Test]
        public void PascalCaseToSpacedString()
        {
            const string input = "SomePascalCasedString";
            const string expectedOutput = "Some Pascal Cased String";
            var actualOutput = input.PascalToSpacedString();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void PascalCaseToSpacedStringArray()
        {
            const string input = "SomePascalCasedString";
            var expectedOutput = new []{"Some", "Pascal", "Cased","String"};
            var actualOutput = input.PascalToSpacedStringArray();
            Assert.That(expectedOutput, Is.EquivalentTo(actualOutput));
        }
    }
}