using System;

namespace Entelect.Extensions
{
    /// <summary>
    /// A collection of formating extensions for the built in <see cref="System.DateTime" /> class.
    /// </summary>
    public static class DateTimeFormatExtensions
    {
        /// <summary>
        /// Returns a a status-style string for a given time (as on facbeook , + etc), using a forced reference time. 
        /// The string is shown as a difference between timestamp and reference time for renderings such as "yesterday", "x minutes/hours ago", "Monday etc"
        /// Use the overload without a reference parameter to default to UTC NOW
        /// </summary>
        /// <param name="timestamp">The timestamp of the event</param>
        /// <param name="referenceTime">A reference time to calculate the difference from the timestamp</param>
        /// <returns>A nice human friendly "status style" string of the difference between the timestamp and reference time. </returns>
        public static string ToStatusStyleString(this DateTime timestamp, DateTime referenceTime)
        {
            const string timeformat = @"hh\:mm";

            var time = (referenceTime - timestamp);
            if (time.Days >= 5)
            {
                return string.Format("{0} at {1}", timestamp.ToString("d MMMM yyyy"), timestamp.TimeOfDay.ToString(timeformat));
            }
            if (time.Days >= 1)
            {
                if(time.Days == 1)
                {
                    return string.Format("Yesterday at {0}", timestamp.TimeOfDay.ToString(timeformat));
                }
                return string.Format("{0} at {1}", timestamp.DayOfWeek.ToString(), timestamp.TimeOfDay.ToString(timeformat));
            }
            if (time.Hours >= 1)
            {
                return string.Format("{0} hour{1} ago", time.Hours, time.Hours == 1 ? "" : "s");
            }
            if (time.Minutes >= 1)
            {
                return string.Format("{0} min{1} ago", time.Minutes, time.Minutes == 1 ? "" : "s");
            }
            return "Less than a minute ago";
        }

        /// <summary>
        /// Returns a status-message (eg Facebook, + etc) style format for a timestamp, using the current UTC time as reference.
        /// The string is shown as a difference between timestamp and reference time for renderings such as "yesterday", "x minutes/hours ago", "Monday etc"
        /// </summary>
        /// <param name="timestamp">The timestamp for the event</param>
        /// <returns>A nice human friendly "status style" string of the difference between the timestamp and reference time.</returns>
        public static string ToStatusStyleString(this DateTime timestamp)
        {
            return ToStatusStyleString(timestamp, DateTime.UtcNow);
        }
    }
}