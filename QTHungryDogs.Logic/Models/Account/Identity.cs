//@CodeCopy
//MdStart
#if ACCOUNT_ON
namespace QTHungryDogs.Logic.Models.Account
{
    using System;
    public partial class Identity : VersionModel
    {
        static Identity()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public Identity()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        new internal QTHungryDogs.Logic.Entities.Account.Identity Source
        {
            get => (QTHungryDogs.Logic.Entities.Account.Identity)(_source ??= new QTHungryDogs.Logic.Entities.Account.Identity());
            set => _source = value;
        }
        public System.String Guid
        {
            get => Source.Guid;
            set => Source.Guid = value;
        }
        public System.String Name
        {
            get => Source.Name;
            set => Source.Name = value;
        }
        public System.String Email
        {
            get => Source.Email;
            set => Source.Email = value;
        }
        public System.Int32 TimeOutInMinutes
        {
            get => Source.TimeOutInMinutes;
            set => Source.TimeOutInMinutes = value;
        }
        public System.Int32 AccessFailedCount
        {
            get => Source.AccessFailedCount;
            set => Source.AccessFailedCount = value;
        }
        public QTHungryDogs.Logic.Modules.Common.State State
        {
            get => Source.State;
            set => Source.State = value;
        }
        public System.Collections.Generic.List<QTHungryDogs.Logic.Models.Account.Role> Roles
        {
            get => Source.Roles.Select(e => QTHungryDogs.Logic.Models.Account.Role.Create(e)).ToList();
            set => Source.Roles = value.Select(e => e.Source).ToList();
        }
        internal void CopyProperties(QTHungryDogs.Logic.Entities.Account.Identity other)
        {
            bool handled = false;
            BeforeCopyProperties(other, ref handled);
            if (handled == false)
            {
                Guid = other.Guid;
                Name = other.Name;
                Email = other.Email;
                TimeOutInMinutes = other.TimeOutInMinutes;
                AccessFailedCount = other.AccessFailedCount;
                State = other.State;
                Roles = other.Roles.Select(e => QTHungryDogs.Logic.Models.Account.Role.Create((object)e)).ToList();
                RowVersion = other.RowVersion;
                Id = other.Id;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(QTHungryDogs.Logic.Entities.Account.Identity other, ref bool handled);
        partial void AfterCopyProperties(QTHungryDogs.Logic.Entities.Account.Identity other);
        internal void CopyProperties(QTHungryDogs.Logic.Models.Account.Identity other)
        {
            bool handled = false;
            BeforeCopyProperties(other, ref handled);
            if (handled == false)
            {
                Guid = other.Guid;
                Name = other.Name;
                Email = other.Email;
                TimeOutInMinutes = other.TimeOutInMinutes;
                AccessFailedCount = other.AccessFailedCount;
                State = other.State;
                Roles = other.Roles;
                RowVersion = other.RowVersion;
                Id = other.Id;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(QTHungryDogs.Logic.Models.Account.Identity other, ref bool handled);
        partial void AfterCopyProperties(QTHungryDogs.Logic.Models.Account.Identity other);
        public override bool Equals(object? obj)
        {
            bool result = false;
            if (obj is Models.Account.Identity other)
            {
                result = IsEqualsWith(RowVersion, other.RowVersion)
                && Id == other.Id;
            }
            return result;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Guid, Name, Email, TimeOutInMinutes, AccessFailedCount, HashCode.Combine(State, Roles, HashCode.Combine(RowVersion, Id)));
        }
        public static QTHungryDogs.Logic.Models.Account.Identity Create()
        {
            BeforeCreate();
            var result = new QTHungryDogs.Logic.Models.Account.Identity();
            AfterCreate(result);
            return result;
        }
        public static QTHungryDogs.Logic.Models.Account.Identity Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new QTHungryDogs.Logic.Models.Account.Identity();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static QTHungryDogs.Logic.Models.Account.Identity Create(QTHungryDogs.Logic.Models.Account.Identity other)
        {
            BeforeCreate(other);
            var result = new QTHungryDogs.Logic.Models.Account.Identity();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        internal static QTHungryDogs.Logic.Models.Account.Identity Create(QTHungryDogs.Logic.Entities.Account.Identity other)
        {
            BeforeCreate(other);
            var result = new QTHungryDogs.Logic.Models.Account.Identity
            {
                Source = other
            };
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(QTHungryDogs.Logic.Models.Account.Identity instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(QTHungryDogs.Logic.Models.Account.Identity instance, object other);
        static partial void BeforeCreate(QTHungryDogs.Logic.Models.Account.Identity other);
        static partial void AfterCreate(QTHungryDogs.Logic.Models.Account.Identity instance, QTHungryDogs.Logic.Models.Account.Identity other);
        static partial void BeforeCreate(QTHungryDogs.Logic.Entities.Account.Identity other);
        static partial void AfterCreate(QTHungryDogs.Logic.Models.Account.Identity instance, QTHungryDogs.Logic.Entities.Account.Identity other);
    }
}
#endif
//MdEnd
