//@GeneratedCode
namespace QTHungryDogs.WebApi.Models.App
{
    using System;
    ///
    /// Generated by the generator
    ///
    public partial class SpecialOpeningHourEdit
    {
        ///
        /// Generated by the generator
        ///
        static SpecialOpeningHourEdit()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        ///
        /// Generated by the generator
        ///
        public SpecialOpeningHourEdit()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        ///
        /// Generated by the generator
        ///
        public System.Int32 RestaurantId
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
        public QTHungryDogs.Logic.Modules.Common.OpenState State
        {
            get;
            set;
        }
        ///
        /// Generated by the generator
        ///
        public QTHungryDogs.WebApi.Models.Base.Restaurant? Restaurant
        {
            get;
            set;
        }
    }
}
