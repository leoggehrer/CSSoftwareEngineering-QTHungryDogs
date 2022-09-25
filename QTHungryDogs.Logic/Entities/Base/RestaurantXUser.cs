using QTHungryDogs.Logic.Entities.Account;

namespace QTHungryDogs.Logic.Entities.Base
{
    [Table("RestaurantXUsers", Schema = "base")]
    [Index(nameof(RestaurantId), nameof(UserId), IsUnique = true)]
    public class RestaurantXUser : VersionEntity
    {
        public int RestaurantId { get; set; }
        public int UserId { get; set; }

        // Navigation properties
        public Restaurant? Restaurant { get; set; }
        internal User? User { get; set; }
    }
}
