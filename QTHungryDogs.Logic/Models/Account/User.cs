//@CodeCopy
//MdStart
#if ACCOUNT_ON
namespace QTHungryDogs.Logic.Models.Account
{
    using System;
    public partial class User : VersionModel
    {
        static User()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public User()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        new internal QTHungryDogs.Logic.Entities.Account.User Source
        {
            get => (QTHungryDogs.Logic.Entities.Account.User)(_source ??= new QTHungryDogs.Logic.Entities.Account.User());
            set => _source = value;
        }
        public System.Int32 IdentityId
        {
            get => Source.IdentityId;
            set => Source.IdentityId = value;
        }
        public System.String FirstName
        {
            get => Source.FirstName;
            set => Source.FirstName = value;
        }
        public System.String LastName
        {
            get => Source.LastName;
            set => Source.LastName = value;
        }
        internal void CopyProperties(QTHungryDogs.Logic.Entities.Account.User other)
        {
            bool handled = false;
            BeforeCopyProperties(other, ref handled);
            if (handled == false)
            {
                IdentityId = other.IdentityId;
                FirstName = other.FirstName;
                LastName = other.LastName;
                RowVersion = other.RowVersion;
                Id = other.Id;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(QTHungryDogs.Logic.Entities.Account.User other, ref bool handled);
        partial void AfterCopyProperties(QTHungryDogs.Logic.Entities.Account.User other);
        public void CopyProperties(QTHungryDogs.Logic.Models.Account.User other)
        {
            bool handled = false;
            BeforeCopyProperties(other, ref handled);
            if (handled == false)
            {
                IdentityId = other.IdentityId;
                FirstName = other.FirstName;
                LastName = other.LastName;
                RowVersion = other.RowVersion;
                Id = other.Id;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(QTHungryDogs.Logic.Models.Account.User other, ref bool handled);
        partial void AfterCopyProperties(QTHungryDogs.Logic.Models.Account.User other);
        public override bool Equals(object? obj)
        {
            bool result = false;
            if (obj is Models.Account.User other)
            {
                result = IsEqualsWith(RowVersion, other.RowVersion)
                && Id == other.Id;
            }
            return result;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(IdentityId, FirstName, LastName, RowVersion, Id);
        }
        public static QTHungryDogs.Logic.Models.Account.User Create()
        {
            BeforeCreate();
            var result = new QTHungryDogs.Logic.Models.Account.User();
            AfterCreate(result);
            return result;
        }
        public static QTHungryDogs.Logic.Models.Account.User Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new QTHungryDogs.Logic.Models.Account.User();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static QTHungryDogs.Logic.Models.Account.User Create(QTHungryDogs.Logic.Models.Account.User other)
        {
            BeforeCreate(other);
            var result = new QTHungryDogs.Logic.Models.Account.User();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        internal static QTHungryDogs.Logic.Models.Account.User Create(QTHungryDogs.Logic.Entities.Account.User other)
        {
            BeforeCreate(other);
            var result = new QTHungryDogs.Logic.Models.Account.User();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(QTHungryDogs.Logic.Models.Account.User instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(QTHungryDogs.Logic.Models.Account.User instance, object other);
        static partial void BeforeCreate(QTHungryDogs.Logic.Models.Account.User other);
        static partial void AfterCreate(QTHungryDogs.Logic.Models.Account.User instance, QTHungryDogs.Logic.Models.Account.User other);
        static partial void BeforeCreate(QTHungryDogs.Logic.Entities.Account.User other);
        static partial void AfterCreate(QTHungryDogs.Logic.Models.Account.User instance, QTHungryDogs.Logic.Entities.Account.User other);
    }
}
#endif
//MdEnd
