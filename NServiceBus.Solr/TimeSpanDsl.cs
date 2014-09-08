namespace NServiceBus.Solr
{
    using System;

    /// <summary>
    /// Class contains a few extension methods to convert number to <see cref="TimeSpan"/>.
    /// </summary>
    public static class TimeSpanDsl
    {
        /// <summary>
        /// Convert specified number to seconds.
        /// </summary>
        /// <param name="seconds">Number to convert.</param>
        /// <returns>Specified number as seconds.</returns>
        public static TimeSpan Seconds(this int seconds)
        {
            return TimeSpan.FromSeconds(seconds);
        }

        /// <summary>
        /// Convert specified number to minutes.
        /// </summary>
        /// <param name="minutes">Number to convert.</param>
        /// <returns>Specified number as minutes.</returns>
        public static TimeSpan Minutes(this int minutes)
        {
            return TimeSpan.FromMinutes(minutes);
        }

        /// <summary>
        /// Convert specified number to hours.
        /// </summary>
        /// <param name="hours">Number to convert.</param>
        /// <returns>Specified number as hours.</returns>
        public static TimeSpan Hours(this int hours)
        {
            return TimeSpan.FromHours(hours);
        }

        /// <summary>
        /// Convert specified number to days.
        /// </summary>
        /// <param name="days">Number to convert.</param>
        /// <returns>Specified number as days.</returns>
        public static TimeSpan Days(this int days)
        {
            return TimeSpan.FromDays(days);
        }
    }
}
