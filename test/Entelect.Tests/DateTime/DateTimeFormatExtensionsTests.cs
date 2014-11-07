using Entelect.Extensions;
using NUnit.Framework;

namespace Entelect.Tests.DateTime
{
    [TestFixture]
    public class DateTimeFormatExtensionsTests
    {
        [Test]
        [TestCase("2014/08/08 13:01", "5.0:0:0.0", "8 August 2014 at 13:01")]
        [TestCase("2014/08/08 13:01", "4.0:0:0.0", "Friday at 13:01")]
        [TestCase("2014/08/08 13:01", "1.0:0:0.0", "Yesterday at 13:01")]
        [TestCase("2014/08/08 13:01", "0.3:0:0.0", "3 hours ago")]
        [TestCase("2014/08/08 13:01", "0.1:0:0.0", "1 hour ago")]
        [TestCase("2014/08/08 13:01", "0.0:15:0.0", "15 mins ago")]
        [TestCase("2014/08/08 13:01", "0.0:1:0.0", "1 min ago")]
        [TestCase("2014/08/08 13:01", "0.0:0:2.0", "Less than a minute ago")]
        public void GivenDifference_ToStatusStyleString_ReturnCorrectText(string inputDateString, string difference, string expectedOutput)
        {
            var inputDate = System.DateTime.Parse(inputDateString);
            var referenceTimeSpan = System.TimeSpan.Parse(difference);
            var referenceDate = inputDate.Add(referenceTimeSpan);
            var output = inputDate.ToStatusStyleString(referenceDate);
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void GivenUtcAsDifference_ToStatusStyleString_ReturnCorrectText()
        {
            var inputDate = System.DateTime.UtcNow;
            var output = inputDate.ToStatusStyleString();
            var expectedOutput = "Less than a minute ago";
            Assert.AreEqual(expectedOutput, output);
        }
        
    }
}