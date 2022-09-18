//@GeneratedCode
namespace QTHungryDogs.AspMvc.Models.App
{
    using System;
    ///
    /// Generated by the generator
    ///
    public partial class SpecialOpeningHourFilter : Models.View.IFilterModel
    {
        ///
        /// Generated by the generator
        ///
        static SpecialOpeningHourFilter()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        ///
        /// Generated by the generator
        ///
        public SpecialOpeningHourFilter()
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
        public System.DateTime? From
        {
            get;
            set;
        }
        ///
        /// Generated by the generator
        ///
        public System.DateTime? To
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
        public QTHungryDogs.Logic.Modules.Common.SpecialOpenState? State
        {
            get;
            set;
        }
        ///
        /// Generated by the generator
        ///
        public bool HasEntityValue => RestaurantId != null || From != null || To != null || Notes != null || State != null;
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
            if (From != null)
            {
                if (result.Length > 0)
                {
                    result.Append(" || ");
                }
                result.Append($"(From != null && From == {From})");
            }
            if (To != null)
            {
                if (result.Length > 0)
                {
                    result.Append(" || ");
                }
                result.Append($"(To != null && To == {To})");
            }
            if (Notes != null)
            {
                if (result.Length > 0)
                {
                    result.Append(" || ");
                }
                result.Append($"(Notes != null && Notes.Contains(\"{Notes}\"))");
            }
            if (State != null)
            {
                if (result.Length > 0)
                {
                    result.Append(" || ");
                }
                var ev = Convert.ChangeType(State, typeof(int));
                result.Append($"(State != null && State =={ev})");
            }
            return result.ToString();
        }
        ///
        /// Generated by the generator
        ///
        public override string ToString()
        {
            return $"RestaurantId: {(RestaurantId != null ? RestaurantId : "---")} From: {(From != null ? From : "---")} To: {(To != null ? To : "---")} Notes: {(Notes ?? "---")} State: {(State != null ? State : "---")} ";
        }
    }
}
