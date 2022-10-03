//@GeneratedCode
namespace QTHungryDogs.AspMvc.Models.Base
{
    using System;
    ///
    /// Generated by the generator
    ///
    public partial class Restaurant
    {
        ///
        /// Generated by the generator
        ///
        static Restaurant()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        ///
        /// Generated by the generator
        ///
        public Restaurant()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        ///
        /// Generated by the generator
        ///
        public System.String DisplayName
        {
            get;
            set;
        }
        = string.Empty;
        ///
        /// Generated by the generator
        ///
        public System.String OwnerName
        {
            get;
            set;
        }
        = string.Empty;
        ///
        /// Generated by the generator
        ///
        public System.String UniqueName
        {
            get;
            set;
        }
        = string.Empty;
        ///
        /// Generated by the generator
        ///
        public System.String Email
        {
            get;
            set;
        }
        = string.Empty;
        ///
        /// Generated by the generator
        ///
        [DisplayName("Street")]
        public System.String AddressStreet
        {
            get;
            set;
        }
        = string.Empty;
        ///
        /// Generated by the generator
        ///
        public System.String AddressHousenumber
        {
            get;
            set;
        }
        = string.Empty;
        ///
        /// Generated by the generator
        ///
        public System.String AddressZipcode
        {
            get;
            set;
        }
        = string.Empty;
        ///
        /// Generated by the generator
        ///
        public System.String AddressCity
        {
            get;
            set;
        }
        = string.Empty;
        ///
        /// Generated by the generator
        ///
        public QTHungryDogs.Logic.Modules.Common.OpenState OpenState
        {
            get;
            set;
        }
        ///
        /// Generated by the generator
        ///
        public QTHungryDogs.Logic.Modules.Common.RestaurantState State
        {
            get;
            set;
        }
        ///
        /// Generated by the generator
        ///
        public System.Collections.Generic.List<QTHungryDogs.AspMvc.Models.Base.OpeningHour> OpeningHours
        {
            get;
            set;
        }
        = new();
        ///
        /// Generated by the generator
        ///
        public System.Collections.Generic.List<QTHungryDogs.AspMvc.Models.App.SpecialOpeningHour> SpecialOpeningHours
        {
            get;
            set;
        }
        = new();
        ///
        /// Generated by the generator
        ///
        public System.Collections.Generic.List<QTHungryDogs.AspMvc.Models.Base.RestaurantXIdentity> Managers
        {
            get;
            set;
        }
        = new();
        ///
        /// Generated by the generator
        ///
        public static QTHungryDogs.AspMvc.Models.Base.Restaurant Create()
        {
            BeforeCreate();
            var result = new QTHungryDogs.AspMvc.Models.Base.Restaurant();
            AfterCreate(result);
            return result;
        }
        ///
        /// Generated by the generator
        ///
        public static QTHungryDogs.AspMvc.Models.Base.Restaurant Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new QTHungryDogs.AspMvc.Models.Base.Restaurant();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(QTHungryDogs.AspMvc.Models.Base.Restaurant instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(QTHungryDogs.AspMvc.Models.Base.Restaurant instance, object other);
        ///
        /// Generated by the generator
        ///
        public static QTHungryDogs.AspMvc.Models.Base.Restaurant Create(QTHungryDogs.Logic.Entities.Base.Restaurant other)
        {
            BeforeCreate(other);
            var result = new QTHungryDogs.AspMvc.Models.Base.Restaurant();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate(QTHungryDogs.Logic.Entities.Base.Restaurant other);
        static partial void AfterCreate(QTHungryDogs.AspMvc.Models.Base.Restaurant instance, QTHungryDogs.Logic.Entities.Base.Restaurant other);
        ///
        /// Generated by the generator
        ///
        public void CopyProperties(QTHungryDogs.Logic.Entities.Base.Restaurant other)
        {
            bool handled = false;
            BeforeCopyProperties(other, ref handled);
            if (handled == false)
            {
                DisplayName = other.DisplayName;
                OwnerName = other.OwnerName;
                UniqueName = other.UniqueName;
                Email = other.Email;
                AddressStreet = other.AddressStreet;
                AddressHousenumber = other.AddressHousenumber;
                AddressZipcode = other.AddressZipcode;
                AddressCity = other.AddressCity;
                OpenState = other.OpenState;
                State = other.State;
                OpeningHours = other.OpeningHours.Select(e => QTHungryDogs.AspMvc.Models.Base.OpeningHour.Create((object)e)).ToList();
                SpecialOpeningHours = other.SpecialOpeningHours.Select(e => QTHungryDogs.AspMvc.Models.App.SpecialOpeningHour.Create((object)e)).ToList();
                Managers = other.Managers.Select(e => QTHungryDogs.AspMvc.Models.Base.RestaurantXIdentity.Create((object)e)).ToList();
                RowVersion = other.RowVersion;
                Id = other.Id;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(QTHungryDogs.Logic.Entities.Base.Restaurant other, ref bool handled);
        partial void AfterCopyProperties(QTHungryDogs.Logic.Entities.Base.Restaurant other);
        ///
        /// Generated by the generator
        ///
        public void CopyProperties(QTHungryDogs.AspMvc.Models.Base.Restaurant other)
        {
            bool handled = false;
            BeforeCopyProperties(other, ref handled);
            if (handled == false)
            {
                DisplayName = other.DisplayName;
                OwnerName = other.OwnerName;
                UniqueName = other.UniqueName;
                Email = other.Email;
                AddressStreet = other.AddressStreet;
                AddressHousenumber = other.AddressHousenumber;
                AddressZipcode = other.AddressZipcode;
                AddressCity = other.AddressCity;
                OpenState = other.OpenState;
                State = other.State;
                OpeningHours = other.OpeningHours;
                SpecialOpeningHours = other.SpecialOpeningHours;
                Managers = other.Managers;
                RowVersion = other.RowVersion;
                Id = other.Id;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(QTHungryDogs.AspMvc.Models.Base.Restaurant other, ref bool handled);
        partial void AfterCopyProperties(QTHungryDogs.AspMvc.Models.Base.Restaurant other);
        ///
        /// Generated by the generator
        ///
        public override bool Equals(object? obj)
        {
            bool result = false;
            if (obj is Models.Base.Restaurant other)
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
            return HashCode.Combine(DisplayName, OwnerName, UniqueName, Email, AddressStreet, AddressHousenumber, HashCode.Combine(AddressZipcode, AddressCity, OpenState, State, OpeningHours, SpecialOpeningHours, HashCode.Combine(Managers, RowVersion, Id)));
        }
    }
}
