using QTHungryDogs.Logic.Modules.Common;

namespace QTHungryDogs.AspMvc.Models.OpeningState
{
    /// <summary>
    /// Represents a class for representing a time span and its status.
    /// </summary>
    public class FromToTime
    {
        /// <summary>
        /// Gets and sets from value.
        /// </summary>
        public DateTime From { get; set; }
        /// <summary>
        /// Gets and sets to value.
        /// </summary>
        public DateTime To { get; set; }
        /// <summary>
        /// Gets and sets the time span state.
        /// </summary>
        public OpenState State { get; set; }

        public bool IsBetween(DateTime date)
        {
            var fromStamp = From.GetDateSecondStamp();
            var dateStamp = date.GetDateSecondStamp();
            var toStamp = To.GetDateSecondStamp();

            return fromStamp <= dateStamp && dateStamp <= toStamp;
        }
        /// <summary>
        /// Creates an instance of type FromToTime.
        /// </summary>
        /// <param name="fromToTime">The object from which the instance is created.</param>
        /// <returns>The created instance.</returns>
        public static FromToTime Create(Logic.Models.OpeningState.FromToTime fromToTime)
        {
            return new FromToTime
            {
                From = fromToTime.From,
                To = fromToTime.To,
                State = fromToTime.State,
            };
        }
    }
}
