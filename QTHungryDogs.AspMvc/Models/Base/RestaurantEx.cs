using QTHungryDogs.AspMvc.Models.Account;
using QTHungryDogs.AspMvc.Models.OpeningState;

namespace QTHungryDogs.AspMvc.Models.Base
{
    partial class Restaurant
    {
        public Identity[]? IdentityList { get; set; }

        public Identity[] AddIdentityList
        {
            get
            {
                Identity[]? result = null;

                if (IdentityList != null)
                {
                   result = IdentityList.Where(e => Managers.Any(m => m.Id == e.Id) == false).ToArray();
                }
                return result ?? Array.Empty<Identity>();
            }
        }
        public Identity[] ManagerIdentities
        {
            get
            {
                var result = IdentityList?.Where(e => Managers.Any(m => m.IdentityId == e.Id)).ToArray();

                return result ?? Array.Empty<Identity>();
            }
        }
        public FromToTime[] OpeningStates { get; set; } = Array.Empty<FromToTime>();

    }
}
