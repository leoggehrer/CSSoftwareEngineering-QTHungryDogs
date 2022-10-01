//@GeneratedCode
namespace QTHungryDogs.WebApi.Models.Base
{
    using System;
    ///
    /// Generated by the generator
    ///
    public partial class RestaurantXIdentity
    {
        ///
        /// Generated by the generator
        ///
        static RestaurantXIdentity()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        ///
        /// Generated by the generator
        ///
        public RestaurantXIdentity()
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
        public System.Int32? IdentityId
        {
            get;
            set;
        }
        ///
        /// Generated by the generator
        ///
        public static QTHungryDogs.WebApi.Models.Base.RestaurantXIdentity Create()
        {
            BeforeCreate();
            var result = new QTHungryDogs.WebApi.Models.Base.RestaurantXIdentity();
            AfterCreate(result);
            return result;
        }
        ///
        /// Generated by the generator
        ///
        public static QTHungryDogs.WebApi.Models.Base.RestaurantXIdentity Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new QTHungryDogs.WebApi.Models.Base.RestaurantXIdentity();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(QTHungryDogs.WebApi.Models.Base.RestaurantXIdentity instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(QTHungryDogs.WebApi.Models.Base.RestaurantXIdentity instance, object other);
        ///
        /// Generated by the generator
        ///
        public static QTHungryDogs.WebApi.Models.Base.RestaurantXIdentity Create(QTHungryDogs.Logic.Entities.Base.RestaurantXIdentity other)
        {
            BeforeCreate(other);
            var result = new QTHungryDogs.WebApi.Models.Base.RestaurantXIdentity();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate(QTHungryDogs.Logic.Entities.Base.RestaurantXIdentity other);
        static partial void AfterCreate(QTHungryDogs.WebApi.Models.Base.RestaurantXIdentity instance, QTHungryDogs.Logic.Entities.Base.RestaurantXIdentity other);
        ///
        /// Generated by the generator
        ///
        public void CopyProperties(QTHungryDogs.Logic.Entities.Base.RestaurantXIdentity other)
        {
            bool handled = false;
            BeforeCopyProperties(other, ref handled);
            if (handled == false)
            {
                RestaurantId = other.RestaurantId;
                IdentityId = other.IdentityId;
                RowVersion = other.RowVersion;
                Id = other.Id;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(QTHungryDogs.Logic.Entities.Base.RestaurantXIdentity other, ref bool handled);
        partial void AfterCopyProperties(QTHungryDogs.Logic.Entities.Base.RestaurantXIdentity other);
        ///
        /// Generated by the generator
        ///
        public void CopyProperties(QTHungryDogs.WebApi.Models.Base.RestaurantXIdentity other)
        {
            bool handled = false;
            BeforeCopyProperties(other, ref handled);
            if (handled == false)
            {
                RestaurantId = other.RestaurantId;
                IdentityId = other.IdentityId;
                RowVersion = other.RowVersion;
                Id = other.Id;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(QTHungryDogs.WebApi.Models.Base.RestaurantXIdentity other, ref bool handled);
        partial void AfterCopyProperties(QTHungryDogs.WebApi.Models.Base.RestaurantXIdentity other);
        ///
        /// Generated by the generator
        ///
        public override bool Equals(object? obj)
        {
            bool result = false;
            if (obj is Models.Base.RestaurantXIdentity other)
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
            return HashCode.Combine(RestaurantId, IdentityId, RowVersion, Id);
        }
    }
}
