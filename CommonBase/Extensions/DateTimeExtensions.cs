namespace CommonBase.Extensions
{ 
    public static partial class DateTimeExtensions
    {
        public static TimeSpan CreateTime(this DateTime source)
        {
            return new TimeSpan(source.Hour, source.Minute, source.Second);
        }
        public static DateTime CreateDate(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day);
        }
        public static long GetMonthStamp(this DateTime source)
        {
            return source.Year * 100 + source.Month;
        }
        public static long GetDayStamp(this DateTime source)
        {
            return source.GetMonthStamp() * 100 + source.Day;
        }
        public static long GetDateHourStamp(this DateTime source)
        {
            return source.GetDayStamp() * 100 + source.Hour;
        }
        public static long GetDateMinuteStamp(this DateTime source)
        {
            return source.GetDateHourStamp() * 100 + source.Minute;
        }
        public static long GetDateSecondStamp(this DateTime source)
        {
            return source.GetDateMinuteStamp() * 100 + source.Second;
        }
        public static long GetTimeMinuteStamp(this DateTime source)
        {
            return source.Hour * 100 + source.Minute;
        }
        public static long GetTimeSecondStamp(this DateTime source)
        {
            return source.GetTimeMinuteStamp() * 100 + source.Second;
        }
    }
}
