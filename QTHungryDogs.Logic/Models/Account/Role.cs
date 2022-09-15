//@CodeCopy
//MdStart
namespace QTHungryDogs.Logic.Models.Account
{
    public partial class Role
    {
        public string Designation { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

#if ACCOUNT_ON
        public static Role Create(Entities.Account.Role role)
        {
            var result = new Role();

            result.CopyFrom(role);
            return result;
        }
#endif
    }
}
//MdEnd
