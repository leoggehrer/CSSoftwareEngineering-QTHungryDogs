using QTHungryDogs.Logic.Entities.Account;

namespace QTHungryDogs.Logic.Entities.Base
{
    [Table("RestaurantXIdentity", Schema = "base")]
    [Index(nameof(RestaurantId), nameof(IdentityId), IsUnique = true)]
    public class RestaurantXIdentity : VersionEntity
    {
        public int RestaurantId { get; set; }
        public int IdentityId { get; set; }

        // Navigation properties
        public Restaurant? Restaurant { get; set; }
        internal Identity? Identity { get; set; }
    }
}
