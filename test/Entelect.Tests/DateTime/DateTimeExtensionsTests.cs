using System;
using Entelect.Extensions;
using NUnit.Framework;

namespace Entelect.Tests.DateTime
{
    [TestFixture]
    public class DateTimeExtensionsTests
    {
        private const string rsaTimeZone = "South Africa Standard Time";

        [Test]
        public void GetMidnight_ReturnsCorrectDate()
        {
            var date = new System.DateTime(2014, 08, 08, 13, 01, 00);
            var midnight = date.Midnight();
            Assert.AreEqual(date.Date, midnight);
        }

        [Test]
        public void GetNoon_ReturnsCorrectDate()
        {
            var date = new System.DateTime(2014, 08, 08, 13, 01, 00);
            var noon = date.Noon();
            var expectedDate = date.Date.AddHours(12);
            Assert.AreEqual(expectedDate, noon);
        }

        [Test]
        public void SetTimeToMillisecondPrecision_ReturnsCorrectDate()
        {
            var date = new System.DateTime(2014, 08, 08);
            var actualDate = date.SetTime(12, 13, 13, 14);
            var expectedDate = new System.DateTime(2014, 08, 08, 12, 13, 13, 14);
            Assert.AreEqual(expectedDate, actualDate);
        }

        [Test]
        public void SetTimeToSecondPrecision_ReturnsCorrectDate()
        {
            var date = new System.DateTime(2014, 08, 08);
            var actualDate = date.SetTime(12, 13, 13, 14);
            var expectedDate = new System.DateTime(2014, 08, 08, 12, 13, 13, 14);
            Assert.AreEqual(expectedDate, actualDate);
        }

        [Test]
        public void SetTimeToMinutePrecision_ReturnsCorrectDate()
        {
            var date = new System.DateTime(2014, 08, 08);
            var actualDate = date.SetTime(12, 13, 13, 14);
            var expectedDate = new System.DateTime(2014, 08, 08, 12, 13, 13, 14);
            Assert.AreEqual(expectedDate, actualDate);
        }

        [Test]
        public void ToFirstDayOfMonth_ReturnsCorrectDate()
        {
            var date = System.DateTime.Now;
            var actualDate = date.ToFirstDayOfMonth();
            var expectedDate = new System.DateTime(date.Year,date.Month,1);
            Assert.AreEqual(expectedDate, actualDate);
        }

        [Test]
        public void ToLastDayOfMonth_ReturnsCorrectDate()
        {
            var date = new System.DateTime(2014, 01, 08);
            var actualDate = date.ToLastDayOfMonth();
            var expectedDate = new System.DateTime(date.Year, date.Month, 31);
            Assert.AreEqual(expectedDate, actualDate);
        }

        [Test]
        public void ToLastMillisecond_ReturnsCorrectDate()
        {
            var date = new System.DateTime(2014, 01, 08);
            var actualDate = date.ToLastMillisecondOfDay();
            var expectedDate = new System.DateTime(date.Year, date.Month, date.Day,23,59,59,999);
            Assert.AreEqual(expectedDate, actualDate);
        }

        [Test]
        public void ToFirstDayOfNextMonth_ReturnsCorrectDate()
        {
            var date = new System.DateTime(2014, 01, 08);
            var actualDate = date.ToFirstDayOfNextMonth();
            var expectedDate = new System.DateTime(date.Year, date.Month + 1, 1);
            Assert.AreEqual(expectedDate, actualDate);
        }

        [Test]
        public void GetTimespanBetweenDates_ReturnsCorrectTimeSpan()
        {
            var date1 = new System.DateTime(2014, 01, 08);
            var date2 = new System.DateTime(2014, 01, 08, 12, 12, 12, 35);
            var actualTimespan = DateTimeExtensions.GetTimespanBetweenDates(date2, date1);
            var expectedTimespan = new TimeSpan(0, 12, 12, 12, 35);
            Assert.AreEqual(expectedTimespan, actualTimespan);
        }

        [Test]
        [TestCase("1 Jan 2014", "15 Jan 2014", 0)]
        [TestCase("1 Jan 2014", "15 Dec 2014", 11)]
        [TestCase("1 Feb 2014", "15 Jan 2014", -1)]
        [TestCase("1 Jan 2014", "15 Dec 2015", 23)]
        public void GetMonthDifference_ReturnsCorrectTimeSpan(string startDateString, string endDateString, int expectedValue)
        {
            var startDate = System.DateTime.Parse(startDateString);
            var endDate = System.DateTime.Parse(endDateString);
            var actualValue = startDate.MonthsFromStartDateToEndDate(endDate);
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void GetUtcTime_ReturnsCorrectTimeSpan()
        {
            var redionalDate = new System.DateTime(2014, 01, 01,12,0,0, DateTimeKind.Unspecified);
            var utcDate = redionalDate.ConvertRegionalTimeToUtc(rsaTimeZone);
            var expectedDate = new System.DateTime(2014, 01, 01, 10, 0, 0, DateTimeKind.Utc);
            Assert.AreEqual(expectedDate, utcDate);
        }

        [Test]
        public void GetRetgionalTime_ReturnsCorrectTimeSpan()
        {
            var utcDate = new System.DateTime(2014, 01, 01, 10, 0, 0, DateTimeKind.Unspecified);
            var regionalDate = utcDate.ConvertUtcToRegionalTime(rsaTimeZone);
            var expectedDate = new System.DateTime(2014, 01, 01, 12, 0, 0, DateTimeKind.Local);
            Assert.AreEqual(expectedDate, regionalDate);
        }

        [Test]
        public void ToJSONTicks_ReturnsCorrectValue()
        {
            var date = new System.DateTime(1970, 1, 1, 0, 0, 0, 5);
            var jsonDate = date.ToJSONTicks();
            var expected = 5;
            Assert.AreEqual(expected, jsonDate);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenCalculatingTheNumberOfBusinessDays_GivenStartDateAfterEndDate_ThrowArgumentException()
        {
            var date = System.DateTime.Now;
            date.NumberOfBusinessDaysUntil(date.AddDays(-1));
        }

        [Test]
        [TestCase("1 Oct 2014", "1 Oct 2014", 1)]
        [TestCase("1 Oct 2014", "3 Oct 2014", 3)]
        [TestCase("1 Oct 2014", "4 Oct 2014", 3)]
        [TestCase("1 Oct 2014", "5 Oct 2014", 3)]
        [TestCase("1 Oct 2014", "6 Oct 2014", 4)]
        [TestCase("1 Oct 2014", "10 Oct 2014", 8)]
        [TestCase("1 Oct 2014", "12 Oct 2014", 8)]
        [TestCase("1 Oct 2014", "15 Oct 2014", 11)]
        [TestCase("11 Dec 2013", "16 Jan 2014", 27)]
        public void WhenCalculatingTheNumberOfBusinessDays_ReturnCorrectValue(string startDateString, string endDateString, int expectedNumberOfDays)
        {
            var startDate = System.DateTime.Parse(startDateString);
            var endDate = System.DateTime.Parse(endDateString);
            var numberOfDays = startDate.NumberOfBusinessDaysUntil(endDate);
            Assert.AreEqual(expectedNumberOfDays, numberOfDays);
        }

        [Test]
        public void WhenCalculatingTheNumberOfBusinessDays_GivenBankHolidays_ReturnCorrectValue()
        {
            var startDate = new System.DateTime(2014, 10, 1);
            var bankHoliday = new System.DateTime(2014, 10, 2);
            var endDate = new System.DateTime(2014, 10, 3);
            var numberOfDays = startDate.NumberOfBusinessDaysUntil(endDate, bankHoliday);
            Assert.AreEqual(2, numberOfDays);
        }
    }
}