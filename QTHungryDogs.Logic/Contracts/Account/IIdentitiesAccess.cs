//@CodeCopy
//MdStart
#if ACCOUNT_ON
namespace QTHungryDogs.Logic.Contracts.Account
{
    public partial interface IIdentitiesAccess<T> : Contracts.IDataAccess<T>
    {
        public Task AddRoleAsync(int id, int roleId);
        public Task RemoveRoleAsync(int id, int roleId);
    }
}
#endif
//MdEnd
