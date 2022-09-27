using QTHungryDogs.Logic.Extensions;
using QTHungryDogs.Logic.Modules.Common;

namespace QTHungryDogs.Logic.Models.OpeningState
{
    public class FromToTime
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public OpenState State { get; set; }

        internal long FromDateSecondStamp => From.GetDateSecondStamp();
        internal long FromTimeSecondStamp => From.GetTimeSecondStamp();
        internal long ToDateSecondStamp => To.GetDateSecondStamp();
        internal long ToTimeSecondStamp => To.GetTimeSecondStamp();

        public bool IsEquals(FromToTime other)
        {
            other.CheckArgument(nameof(other));

            return FromDateSecondStamp == other.FromDateSecondStamp
                   && ToDateSecondStamp == other.ToDateSecondStamp
                   && State == other.State;
        }
        public bool IsBetween(DateTime date)
        {
            var stamp = date.GetDateSecondStamp();

            return FromDateSecondStamp <= stamp && ToDateSecondStamp >= stamp;
        }
        public bool InRange(FromToTime fromToTime)
        {
            return IsOverlap(fromToTime.FromDateSecondStamp) && IsOverlap(fromToTime.ToDateSecondStamp);
        }
        public bool IsOverlap(FromToTime fromToTime)
        {
            return IsOverlap(fromToTime.FromDateSecondStamp) || IsOverlap(fromToTime.ToDateSecondStamp);
        }
        public bool IsOverlap(long secondStamp)
        {
            return FromDateSecondStamp >= secondStamp && secondStamp <= ToDateSecondStamp;
        }
        public override string ToString()
        {
            return $"{From.ToString("HH:mm:ss")} - {To.ToString("HH:mm:ss")} - {State}";
        }
    }
}
