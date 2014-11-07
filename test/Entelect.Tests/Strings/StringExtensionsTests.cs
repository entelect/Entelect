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

        [Test]
        [TestCase("a","A")]
        [TestCase("aasdasd", "Aasdasd")]
        [TestCase("Aasd", "Aasd")]
        [TestCase("AAAAA", "AAAAA")]
        [TestCase("aAaAa", "AAaAa")]
        public void CapitaliseFirstLetter(string input, string expected)
        {
            input = input.CapitaliseFirstLetter();
            StringAssert.AreEqualIgnoringCase(expected, input);
        }

        [Test]
        [TestCase("A", "A", "a", "a")]
        [TestCase("AaaaaAAaaa", "A", "a", "aaaaaaaaaa")]
        [TestCase("AaaEaa A A aaEa", "A", "a", "aaaEaa a a aaEa")]
        public void ReplaceIgnoreCase(string input, string oldValue, string newValue, string expected)
        {
            input = input.ReplaceIgnoreCase(oldValue, newValue);
            StringAssert.AreEqualIgnoringCase(expected, input);
        }
    }
}