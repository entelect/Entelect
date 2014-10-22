using System;
using System.Collections.Generic;

namespace Entelect.Extensions
{
    /// <summary>
    /// A collection of custom extensions for the built in <see cref="System.DateTime" /> class.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Returns the date part of the input date with the time of day as 00:00:00. Equivalent to DateTime.Date.
        /// </summary>
        /// <param name="input">The input date</param>
        /// <returns>The input date at midnight</returns>
        public static DateTime Midnight(this DateTime input)
        {
            return input.Date;
        }

        /// <summary>
        /// Returns the date part of the input date with the time of day as 12:00:00.
        /// </summary>
        /// <param name="input">The input date</param>
        /// /// <returns>The input date at Noon</returns>
        public static DateTime Noon(this DateTime input)
        {
            return input.Date.AddHours(12);
        }

        /// <summary>
        /// Sets the time of the current date with minute precision
        /// </summary>
        /// <param name="input">The current date</param>
        /// <param name="hour">The hour</param>
        /// <param name="minute">The minute</param>
        /// <returns>The input date at specified time</returns>
        public static DateTime SetTime(this DateTime input, int hour, int minute)
        {
            return SetTime(input, hour, minute, 0, 0);
        }

        /// <summary>
        /// Sets the time of the current date with second precision
        /// </summary>
        /// <param name="input">The current date</param>
        /// <param name="hour">The hour</param>
        /// <param name="minute">The minute</param>
        /// <param name="second">The second</param>
        /// <returns>The input date at specified time</returns>
        public static DateTime SetTime(this DateTime input, int hour, int minute, int second)
        {
            return SetTime(input, hour, minute, second, 0);
        }

        /// <summary>
        /// Sets the time of the current date with millisecond precision
        /// </summary>
        /// <param name="input">The input date</param>
        /// <param name="hour">The hour</param>
        /// <param name="minute">The minute</param>
        /// <param name="second">The second</param>
        /// <param name="millisecond">The millisecond</param>
        /// <returns>The input date at specified time</returns>
        public static DateTime SetTime(this DateTime input, int hour, int minute, int second, int millisecond)
        {
            var time = new TimeSpan(0, hour, minute, second, millisecond);
            return input.Date.Add(time);
        }

        /// <summary>
        /// Gets the first day of the month at time 00:00:00 for the supplied date
        /// </summary>
        /// <param name="input">The input date</param>
        /// <returns>First of the month</returns>
        public static DateTime ToFirstDayOfMonth(this DateTime input)
        {
            var daysToSubtract = input.Day - 1;
            return input.Date.AddDays(-daysToSubtract);
        }

        /// <summary>
        /// Gets the last day of the month at time 00:00:00 for the supplied date
        /// </summary>
        /// <param name="input">The input date</param>
        /// <returns>Last day of the month</returns>
        public static DateTime ToLastDayOfMonth(this DateTime input)
        {
            return input.ToFirstDayOfMonth().AddMonths(1).AddDays(-1);
        }

        /// <summary>
        /// Gets the date time one milisecond before midnight on the current day
        /// </summary>
        /// <param name="input">The input date</param>
        /// <returns>Last second of input date</returns>
        public static DateTime ToLastMillisecondOfDay(this DateTime input)
        {
            return input.Date.AddDays(1).AddMilliseconds(-1);
        }

        /// <summary>
        /// Gets the first day of the next month of the input datetime
        /// </summary>
        /// <param name="input">The input date</param>
        /// <returns>First day of the next month</returns>
        public static DateTime ToFirstDayOfNextMonth(this DateTime input)
        {
            return input.ToFirstDayOfMonth().AddMonths(1);
        }

        /// <summary>
        /// Gets the timespan between two dates
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date subtracted from start date</param>
        /// <returns>Time difference</returns>
        public static TimeSpan GetTimespanBetweenDates(DateTime startDate, DateTime endDate)
        {
            TimeSpan timeSpan = startDate - endDate;
            return timeSpan;
        }

        /// <summary>
        /// Gets the number of months between the current date and the supplied date
        /// </summary>
        /// <param name="startDate">The date to calculate from</param>
        /// <param name="endDate">The date to calculate to</param>
        /// <returns>The difference in months</returns>
        public static int MonthsFromStartDateToEndDate(this DateTime startDate, DateTime endDate)
        {
            return (endDate.Month - startDate.Month) + (12 * (endDate.Year - startDate.Year));
        }

        /// <summary>
        /// Converts regional time to utc
        /// </summary>
        /// <param name="regionalTime">The regional dateTime</param>
        /// <param name="timeZone">The timezone to convert from</param>
        /// <returns>UTC Time</returns>
        /// <exception cref="T:System.OutOfMemoryException"></exception>
        /// <exception cref="T:System.Security.SecurityException"></exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="timeZone"/> is null. </exception>
        /// <exception cref="T:System.ArgumentException"></exception>
        /// <exception cref="T:System.TimeZoneNotFoundException"><paramref name="timeZone"/> is not found. </exception>
        /// <exception cref="T:System.InvalidTimeZoneException"><paramref name="timeZone"/> is invalid. </exception>
        public static DateTime ConvertRegionalTimeToUtc(this DateTime regionalTime, string timeZone)
        {
            DateTime returnTime = TimeZoneInfo.ConvertTime(regionalTime, TimeZoneInfo.FindSystemTimeZoneById(timeZone), TimeZoneInfo.Utc);
            return returnTime;
        }

        /// <summary>
        /// Converts utc to regional time
        /// </summary>
        /// <param name="utcTime">The UTC dateTime</param>
        /// <param name="timeZone">The timezone to convert to</param>
        /// <returns>Regional Time</returns>
        /// <exception cref="T:System.OutOfMemoryException"></exception>
        /// <exception cref="T:System.Security.SecurityException"></exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="timeZone"/> is null. </exception>
        /// <exception cref="T:System.ArgumentException"></exception>
        /// <exception cref="T:System.TimeZoneNotFoundException"><paramref name="timeZone"/> is not found. </exception>
        /// <exception cref="T:System.InvalidTimeZoneException"><paramref name="timeZone"/> is invalid. </exception>
        public static DateTime ConvertUtcToRegionalTime(this DateTime utcTime, string timeZone)
        {
            DateTime returnTime = TimeZoneInfo.ConvertTime(utcTime, TimeZoneInfo.Utc,
                                                   TimeZoneInfo.FindSystemTimeZoneById(timeZone));
            return returnTime;
        }


        //Used to convert to JSON date format
        private static readonly DateTime jsdate = new DateTime(1970, 1, 1);

        /// <summary>
        /// Returns a JSON representation of the provided date time
        /// </summary>
        /// <param name="input">DateTime to convert</param>
        /// <returns>Converted date time in JSON format</returns>
        public static long ToJSONTicks(this DateTime input)
        {
            return (long)(input - jsdate).TotalMilliseconds;
        }

        /* From http://stackoverflow.com/questions/1617049/calculate-the-number-of-business-days-between-two-dates */
        /// <summary>
        /// Calculates number of business days, taking into account:
        ///  - weekends (Saturdays and Sundays)
        ///  - bank holidays in the middle of the week
        /// </summary>
        /// <param name="startDateTime">First day in the time interval</param>
        /// <param name="endDateTime">Last day in the time interval</param>
        /// <param name="bankHolidays">List of bank holidays excluding weekends</param>
        /// <returns>Number of business days during the 'span'</returns>
        /// <exception cref="System.ArgumentException">If <paramref name="startDateTime"/> is after <paramref name="endDateTime"/></exception>
        public static int NumberOfBusinessDaysUntil(this DateTime startDateTime, DateTime endDateTime, params DateTime[] bankHolidays)
        {
            var startDate = startDateTime.Date;
            var endDate = endDateTime.Date;
            if(startDate > endDate)
            {
                throw new ArgumentException("Incorrect last day " + endDate);
            }

            TimeSpan span = endDate - startDate;
            int businessDays = span.Days + 1;
            int fullWeekCount = businessDays / 7;
            businessDays = SubtractWeekendDaysDuringRemainingTime(businessDays, fullWeekCount, startDate, endDate);

            // subtract the weekends during the full weeks in the interval
            businessDays -= fullWeekCount + fullWeekCount;

            businessDays = SubtractBankHolidays(bankHolidays, startDate, endDate, businessDays);

            return businessDays;
        }

        private static int SubtractWeekendDaysDuringRemainingTime(int businessDays, int fullWeekCount, DateTime startDate, DateTime endDate)
        {
            // find out if there are weekends during the time exceeding the full weeks
            if(businessDays > fullWeekCount * 7)
            {
                // we are here to find out if there is a 1-day or 2-days weekend
                // in the time interval remaining after subtracting the complete weeks
                int firstDayOfWeek = (int)startDate.DayOfWeek;
                int lastDayOfWeek = (int)endDate.DayOfWeek;
                if(lastDayOfWeek < firstDayOfWeek)
                {
                    lastDayOfWeek += 7;
                }

                if(firstDayOfWeek <= 6)
                {
                    if(lastDayOfWeek >= 7) // Both Saturday and Sunday are in the remaining time interval
                    {
                        businessDays -= 2;
                    }
                    else if(lastDayOfWeek >= 6) // Only Saturday is in the remaining time interval
                    {
                        businessDays -= 1;
                    }
                    else if(firstDayOfWeek == 0) // Sunday is First day
                    {
                        businessDays -= 1;
                    }
                }
                else if(firstDayOfWeek <= 7 && lastDayOfWeek >= 7) // Only Sunday is in the remaining time interval
                {
                    businessDays -= 1;
                }
            }
            return businessDays;
        }

        private static int SubtractBankHolidays(IEnumerable<DateTime> bankHolidays, DateTime startDate, DateTime endDate, int businessDays)
        {
            // subtract the number of bank holidays during the time interval
            foreach(DateTime bankHoliday in bankHolidays)
            {
                DateTime bh = bankHoliday.Date;
                if(startDate <= bh && bh <= endDate)
                {
                    --businessDays;
                }
            }
            return businessDays;
        }
    }
}