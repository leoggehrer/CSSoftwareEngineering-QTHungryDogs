using QTHungryDogs.Logic.Modules.Common;

namespace QTHungryDogs.Logic.Models.OpeningState
{
    public class FromToTime
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public OpenState State { get; set; }

        public bool IsEquals(FromToTime other)
        {
            other.CheckArgument(nameof(other));

            return From.GetDateSecondStamp() == other.From.GetDateSecondStamp()
                   && To.GetDateSecondStamp() == other.To.GetDateSecondStamp()
                   && State == other.State;
        }
        public bool IsBetween(DateTime date)
        {
            var stamp = date.GetDateSecondStamp();

            return From.GetDateSecondStamp() <= stamp && To.GetDateSecondStamp() >= stamp;
        }
        public bool InRange(FromToTime fromToTime)
        {
            return IsOverlap(fromToTime.From.GetDateSecondStamp()) && IsOverlap(fromToTime.To.GetDateSecondStamp());
        }
        public bool IsOverlap(FromToTime fromToTime)
        {
            return IsOverlap(fromToTime.From.GetDateSecondStamp()) || IsOverlap(fromToTime.To.GetDateSecondStamp());
        }
        public bool IsOverlap(long secondStamp)
        {
            return From.GetDateSecondStamp() >= secondStamp && secondStamp <= To.GetDateSecondStamp();
        }
        public override string ToString()
        {
            return $"{From:dd.MM.yyyy HH:mm:ss} - {To:dd.MM.yyyy HH:mm:ss} - {State}";
        }
    }
}
