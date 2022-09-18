//@GeneratedCode
namespace QTHungryDogs.WebApi.Models.Base
{
    using System;
    ///
    /// Generated by the generator
    ///
    public partial class OpeningHour
    {
        ///
        /// Generated by the generator
        ///
        static OpeningHour()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        ///
        /// Generated by the generator
        ///
        public OpeningHour()
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
        public System.Int32 Weekday
        {
            get;
            set;
        }
        ///
        /// Generated by the generator
        ///
        public System.TimeSpan OpenFrom
        {
            get;
            set;
        }
        ///
        /// Generated by the generator
        ///
        public System.TimeSpan OpenTo
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
        public QTHungryDogs.WebApi.Models.Base.Restaurant? Restaurant
        {
            get;
            set;
        }
        ///
        /// Generated by the generator
        ///
        public static QTHungryDogs.WebApi.Models.Base.OpeningHour Create()
        {
            BeforeCreate();
            var result = new QTHungryDogs.WebApi.Models.Base.OpeningHour();
            AfterCreate(result);
            return result;
        }
        ///
        /// Generated by the generator
        ///
        public static QTHungryDogs.WebApi.Models.Base.OpeningHour Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new QTHungryDogs.WebApi.Models.Base.OpeningHour();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(QTHungryDogs.WebApi.Models.Base.OpeningHour instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(QTHungryDogs.WebApi.Models.Base.OpeningHour instance, object other);
        ///
        /// Generated by the generator
        ///
        public static QTHungryDogs.WebApi.Models.Base.OpeningHour Create(QTHungryDogs.Logic.Entities.Base.OpeningHour other)
        {
            BeforeCreate(other);
            var result = new QTHungryDogs.WebApi.Models.Base.OpeningHour();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate(QTHungryDogs.Logic.Entities.Base.OpeningHour other);
        static partial void AfterCreate(QTHungryDogs.WebApi.Models.Base.OpeningHour instance, QTHungryDogs.Logic.Entities.Base.OpeningHour other);
        ///
        /// Generated by the generator
        ///
        public void CopyProperties(QTHungryDogs.Logic.Entities.Base.OpeningHour other)
        {
            bool handled = false;
            BeforeCopyProperties(other, ref handled);
            if (handled == false)
            {
                RestaurantId = other.RestaurantId;
                Weekday = other.Weekday;
                OpenFrom = other.OpenFrom;
                OpenTo = other.OpenTo;
                Notes = other.Notes;
                Restaurant = other.Restaurant != null ? QTHungryDogs.WebApi.Models.Base.Restaurant.Create((object)other.Restaurant) : null;
                RowVersion = other.RowVersion;
                Id = other.Id;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(QTHungryDogs.Logic.Entities.Base.OpeningHour other, ref bool handled);
        partial void AfterCopyProperties(QTHungryDogs.Logic.Entities.Base.OpeningHour other);
        ///
        /// Generated by the generator
        ///
        public void CopyProperties(QTHungryDogs.WebApi.Models.Base.OpeningHour other)
        {
            bool handled = false;
            BeforeCopyProperties(other, ref handled);
            if (handled == false)
            {
                RestaurantId = other.RestaurantId;
                Weekday = other.Weekday;
                OpenFrom = other.OpenFrom;
                OpenTo = other.OpenTo;
                Notes = other.Notes;
                Restaurant = other.Restaurant;
                RowVersion = other.RowVersion;
                Id = other.Id;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(QTHungryDogs.WebApi.Models.Base.OpeningHour other, ref bool handled);
        partial void AfterCopyProperties(QTHungryDogs.WebApi.Models.Base.OpeningHour other);
        ///
        /// Generated by the generator
        ///
        public override bool Equals(object? obj)
        {
            if (obj is not QTHungryDogs.Logic.Entities.Base.OpeningHour instance)
            {
                return false;
            }
            return base.Equals(instance) && Equals(instance);
        }
        ///
        /// Generated by the generator
        ///
        protected bool Equals(QTHungryDogs.Logic.Entities.Base.OpeningHour other)
        {
            return IsEqualsWith(RowVersion, other.RowVersion)
            && Id == other.Id;
        }
        ///
        /// Generated by the generator
        ///
        public override int GetHashCode()
        {
            return HashCode.Combine(RestaurantId, Weekday, OpenFrom, OpenTo, Notes, Restaurant, HashCode.Combine(RowVersion, Id));
        }
    }
}
