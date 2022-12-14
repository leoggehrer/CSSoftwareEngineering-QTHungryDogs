//@GeneratedCode
namespace QTHungryDogs.AspMvc.Models.App
{
    using System;
    ///
    /// Generated by the generator
    ///
    public partial class SpecialOpeningHour
    {
        ///
        /// Generated by the generator
        ///
        static SpecialOpeningHour()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        ///
        /// Generated by the generator
        ///
        public SpecialOpeningHour()
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
        [DataType(DataType.DateTime)]
        public System.DateTime From
        {
            get;
            set;
        }
        ///
        /// Generated by the generator
        ///
        [DataType(DataType.DateTime)]
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
        public QTHungryDogs.AspMvc.Models.Base.Restaurant? Restaurant
        {
            get;
            set;
        }
        ///
        /// Generated by the generator
        ///
        public static QTHungryDogs.AspMvc.Models.App.SpecialOpeningHour Create()
        {
            BeforeCreate();
            var result = new QTHungryDogs.AspMvc.Models.App.SpecialOpeningHour();
            AfterCreate(result);
            return result;
        }
        ///
        /// Generated by the generator
        ///
        public static QTHungryDogs.AspMvc.Models.App.SpecialOpeningHour Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new QTHungryDogs.AspMvc.Models.App.SpecialOpeningHour();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(QTHungryDogs.AspMvc.Models.App.SpecialOpeningHour instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(QTHungryDogs.AspMvc.Models.App.SpecialOpeningHour instance, object other);
        ///
        /// Generated by the generator
        ///
        public static QTHungryDogs.AspMvc.Models.App.SpecialOpeningHour Create(QTHungryDogs.Logic.Entities.App.SpecialOpeningHour other)
        {
            BeforeCreate(other);
            var result = new QTHungryDogs.AspMvc.Models.App.SpecialOpeningHour();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate(QTHungryDogs.Logic.Entities.App.SpecialOpeningHour other);
        static partial void AfterCreate(QTHungryDogs.AspMvc.Models.App.SpecialOpeningHour instance, QTHungryDogs.Logic.Entities.App.SpecialOpeningHour other);
        ///
        /// Generated by the generator
        ///
        public void CopyProperties(QTHungryDogs.Logic.Entities.App.SpecialOpeningHour other)
        {
            bool handled = false;
            BeforeCopyProperties(other, ref handled);
            if (handled == false)
            {
                RestaurantId = other.RestaurantId;
                From = other.From;
                To = other.To;
                Notes = other.Notes;
                State = other.State;
                Restaurant = other.Restaurant != null ? QTHungryDogs.AspMvc.Models.Base.Restaurant.Create((object)other.Restaurant) : null;
                RowVersion = other.RowVersion;
                Id = other.Id;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(QTHungryDogs.Logic.Entities.App.SpecialOpeningHour other, ref bool handled);
        partial void AfterCopyProperties(QTHungryDogs.Logic.Entities.App.SpecialOpeningHour other);
        ///
        /// Generated by the generator
        ///
        public void CopyProperties(QTHungryDogs.AspMvc.Models.App.SpecialOpeningHour other)
        {
            bool handled = false;
            BeforeCopyProperties(other, ref handled);
            if (handled == false)
            {
                RestaurantId = other.RestaurantId;
                From = other.From;
                To = other.To;
                Notes = other.Notes;
                State = other.State;
                Restaurant = other.Restaurant;
                RowVersion = other.RowVersion;
                Id = other.Id;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(QTHungryDogs.AspMvc.Models.App.SpecialOpeningHour other, ref bool handled);
        partial void AfterCopyProperties(QTHungryDogs.AspMvc.Models.App.SpecialOpeningHour other);
        ///
        /// Generated by the generator
        ///
        public override bool Equals(object? obj)
        {
            bool result = false;
            if (obj is Models.App.SpecialOpeningHour other)
            {
                result = IsEqualsWith(RowVersion, other.RowVersion)
                && Id == other.Id;
            }
            return result;
        }
        ///
        /// Generated by the generator
        ///
        public override int GetHashCode()
        {
            return HashCode.Combine(RestaurantId, From, To, Notes, State, Restaurant, HashCode.Combine(RowVersion, Id));
        }
    }
}
