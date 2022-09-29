//@CustomCode
namespace QTHungryDogs.AspMvc.Models.Base
{
    using System;
    ///
    /// Generated by the generator
    ///
    public partial class RestaurantFilter : Models.View.IFilterModel
    {
        ///
        /// Generated by the generator
        ///
        static RestaurantFilter()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        ///
        /// Generated by the generator
        ///
        public RestaurantFilter()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        ///
        /// Generated by the generator
        ///
        public System.String? DisplayName
        {
            get;
            set;
        }
        ///
        /// Generated by the generator
        ///
        public System.String? OwnerName
        {
            get;
            set;
        }
        ///
        /// Generated by the generator
        ///
        public System.String? UniqueName
        {
            get;
            set;
        }
        ///
        /// Generated by the generator
        ///
        public System.String? Email
        {
            get;
            set;
        }
        ///
        /// Generated by the generator
        ///
        public System.String? AddressStreet
        {
            get;
            set;
        }
        ///
        /// Generated by the generator
        ///
        public System.String? AddressHousenumber
        {
            get;
            set;
        }
        ///
        /// Generated by the generator
        ///
        public System.String? AddressZipcode
        {
            get;
            set;
        }
        ///
        /// Generated by the generator
        ///
        public System.String? AddressCity
        {
            get;
            set;
        }
        ///
        /// Generated by the generator
        ///
        public QTHungryDogs.Logic.Modules.Common.State? State
        {
            get;
            set;
        }
        ///
        /// Generated by the generator
        ///
        public bool HasEntityValue => DisplayName != null || OwnerName != null || UniqueName != null || Email != null || AddressStreet != null || AddressHousenumber != null || AddressZipcode != null || AddressCity != null || State != null;
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
            if (DisplayName != null)
            {
                if (result.Length > 0)
                {
                    result.Append(" || ");
                }
                result.Append($"(DisplayName != null && DisplayName.Contains(\"{DisplayName}\"))");
            }
            if (OwnerName != null)
            {
                if (result.Length > 0)
                {
                    result.Append(" || ");
                }
                result.Append($"(OwnerName != null && OwnerName.Contains(\"{OwnerName}\"))");
            }
            if (UniqueName != null)
            {
                if (result.Length > 0)
                {
                    result.Append(" || ");
                }
                result.Append($"(UniqueName != null && UniqueName.Contains(\"{UniqueName}\"))");
            }
            if (Email != null)
            {
                if (result.Length > 0)
                {
                    result.Append(" || ");
                }
                result.Append($"(Email != null && Email.Contains(\"{Email}\"))");
            }
            if (AddressStreet != null)
            {
                if (result.Length > 0)
                {
                    result.Append(" || ");
                }
                result.Append($"(AddressStreet != null && AddressStreet.Contains(\"{AddressStreet}\"))");
            }
            if (AddressHousenumber != null)
            {
                if (result.Length > 0)
                {
                    result.Append(" || ");
                }
                result.Append($"(AddressHousenumber != null && AddressHousenumber.Contains(\"{AddressHousenumber}\"))");
            }
            if (AddressZipcode != null)
            {
                if (result.Length > 0)
                {
                    result.Append(" || ");
                }
                result.Append($"(AddressZipcode != null && AddressZipcode.Contains(\"{AddressZipcode}\"))");
            }
            if (AddressCity != null)
            {
                if (result.Length > 0)
                {
                    result.Append(" || ");
                }
                result.Append($"(AddressCity != null && AddressCity.Contains(\"{AddressCity}\"))");
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
            return $"DisplayName: {(DisplayName ?? "---")} Email: {(Email ?? "---")} AddressZipcode: {(AddressZipcode ?? "---")} AddressCity: {(AddressCity ?? "---")} State: {(State != null ? State : "---")} ";
        }
    }
}
