using System;
using Entelect.Extensions;
using NUnit.Framework;

namespace Entelect.Tests.Enum
{
    [TestFixture]
    public class EnumExtensionTests
    {
        [Test]
        [TestCase(TestEnum.SomeValue, "Some Value")]
        [TestCase(TestEnum.SomeOtherValue, "Some Other Value")]
        [TestCase(TestEnum.AVeryAwesomeValue, "A Very Awesome Value")]
        [TestCase(TestEnum.Potato, "Potato")]
        public void ToSpacedString(TestEnum enumValue, string expectedString)
        {
            var stringValue = enumValue.ToSpacedString();
            StringAssert.AreEqualIgnoringCase(expectedString,stringValue);
        }

        [Test]
        [TestCase("SomeValue", TestEnum.SomeValue)]
        [TestCase("Some Value", TestEnum.SomeValue)]
        [TestCase("asd", null)]
        [TestCase("SomeOtherValue", TestEnum.SomeOtherValue)]
        [TestCase("SomeOther Value", TestEnum.SomeOtherValue)]
        [TestCase("Some OtherValue", TestEnum.SomeOtherValue)]
        [TestCase("Some Other Value", TestEnum.SomeOtherValue)]
        public void Parse(string input, TestEnum? expectedOutput)
        {
            TestEnum output;
            try
            {
                output = EnumExtensions.Parse<TestEnum>(input);
            }
            catch (ArgumentException)
            {
                if (!expectedOutput.HasValue)
                {
                    Assert.Pass("Exception when parsing, but expected no output");
                    return;
                }
                throw;
            }
            Assert.AreEqual(expectedOutput, output);
        }
    }

    public enum TestEnum
    {
        SomeValue,
        SomeOtherValue,
        AVeryAwesomeValue,
        Potato
    }
}