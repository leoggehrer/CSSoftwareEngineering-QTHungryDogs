namespace CommonBase.Extensions
{ 
    public static class TimeSpanExtensions
    {
        public static DateTime CreateDate(this TimeSpan source)
        {
            var now = DateTime.Now;

            return new DateTime(now.Year, now.Month, now.Day, source.Hours, source.Minutes, source.Seconds);
        }
        public static long GetTimeMinuteStamp(this TimeSpan source)
        {
            return source.Hours * 100 + source.Minutes;
        }
        public static long GetTimeSecondStamp(this TimeSpan source)
        {
            return source.GetTimeMinuteStamp() * 100 + source.Seconds;
        }
    }
}
