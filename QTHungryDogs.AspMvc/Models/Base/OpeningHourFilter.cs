//@GeneratedCode
namespace QTHungryDogs.AspMvc.Models.Base
{
    using System;
    ///
    /// Generated by the generator
    ///
    public partial class OpeningHourFilter : Models.View.IFilterModel
    {
        ///
        /// Generated by the generator
        ///
        static OpeningHourFilter()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        ///
        /// Generated by the generator
        ///
        public OpeningHourFilter()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        ///
        /// Generated by the generator
        ///
        public System.Int32? RestaurantId
        {
            get;
            set;
        }
        ///
        /// Generated by the generator
        ///
        public System.Int32? Weekday
        {
            get;
            set;
        }
        ///
        /// Generated by the generator
        ///
        public System.TimeSpan? OpenFrom
        {
            get;
            set;
        }
        ///
        /// Generated by the generator
        ///
        public System.TimeSpan? OpenTo
        {
            get;
            set;
        }
        ///
        /// Generated by the generator
        ///
        public System.String? Notes
        {
            get;
            set;
        }
        ///
        /// Generated by the generator
        ///
        public bool HasEntityValue => RestaurantId != null || Weekday != null || OpenFrom != null || OpenTo != null || Notes != null;
        private bool show = true;
        ///
        /// Generated by the generator
        ///
        public bool Show => show;
        ///
        /// Generated by the generator
        ///
        public string CreateEntityPredicate()
        {
            var result = new System.Text.StringBuilder();
            if (RestaurantId != null)
            {
                if (result.Length > 0)
                {
                    result.Append(" || ");
                }
                result.Append($"(RestaurantId != null && RestaurantId == {RestaurantId})");
            }
            if (Weekday != null)
            {
                if (result.Length > 0)
                {
                    result.Append(" || ");
                }
                result.Append($"(Weekday != null && Weekday == {Weekday})");
            }
            if (OpenFrom != null)
            {
                if (result.Length > 0)
                {
                    result.Append(" || ");
                }
                result.Append($"(OpenFrom != null && OpenFrom == {OpenFrom})");
            }
            if (OpenTo != null)
            {
                if (result.Length > 0)
                {
                    result.Append(" || ");
                }
                result.Append($"(OpenTo != null && OpenTo == {OpenTo})");
            }
            if (Notes != null)
            {
                if (result.Length > 0)
                {
                    result.Append(" || ");
                }
                result.Append($"(Notes != null && Notes.Contains(\"{Notes}\"))");
            }
            return result.ToString();
        }
        ///
        /// Generated by the generator
        ///
        public override string ToString()
        {
            return $"RestaurantId: {(RestaurantId != null ? RestaurantId : "---")} Weekday: {(Weekday != null ? Weekday : "---")} OpenFrom: {(OpenFrom != null ? OpenFrom : "---")} OpenTo: {(OpenTo != null ? OpenTo : "---")} Notes: {(Notes ?? "---")} ";
        }
    }
}
