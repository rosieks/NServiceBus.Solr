using System;

namespace NServiceBus.Solr
{
    public static class TimeSpanDsl
    {
        public static TimeSpan Seconds(this int seconds)
        {
            return TimeSpan.FromSeconds(seconds);
        }

        public static TimeSpan Minutes(this int minutes)
        {
            return TimeSpan.FromMinutes(minutes);
        }

        public static TimeSpan Hours(this int hours)
        {
            return TimeSpan.FromHours(hours);
        }

        public static TimeSpan Days(this int days)
        {
            return TimeSpan.FromDays(days);
        }
    }
}
