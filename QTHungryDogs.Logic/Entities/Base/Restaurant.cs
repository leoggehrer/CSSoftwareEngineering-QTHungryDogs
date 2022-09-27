using QTHungryDogs.Logic.Entities.App;
using QTHungryDogs.Logic.Modules.Common;

namespace QTHungryDogs.Logic.Entities.Base
{
    [Table("Restaurants", Schema = "base")]
    [Index(nameof(UniqueName), IsUnique = true)]
    public class Restaurant : VersionEntity
    {
        [MaxLength(256)]
        public string DisplayName { get; set; } = String.Empty;
        [MaxLength(256)]
        public string OwnerName { get; set; } = String.Empty;
        [MaxLength(256)]
        public string UniqueName { get; set; } = String.Empty;
        [MaxLength(256)]
        public string Email { get; set; } = String.Empty;
        [MaxLength(128)]
        public string AddressStreet { get; set; } = String.Empty;
        [MaxLength(8)]
        public string AddressHousenumber { get; set; } = String.Empty;
        [MaxLength(10)]
        public string AddressZipcode { get; set; } = String.Empty;
        [MaxLength(64)]
        public string AddressCity { get; set; } = String.Empty;
        [NotMapped]
        public OpenState OpenState 
        {
            get 
            {
                var openState = State == RestaurantState.InActive 
                             || State == RestaurantState.Closed ? OpenState.ClosedPermanent : OpenState.Open;

                return openState;
            }
        }
        public RestaurantState State { get; set; }

        // Navigation properties
        public List<OpeningHour> OpeningHours { get; set; } = new();
        public List<SpecialOpeningHour> SpecialOpeningHours { get; set; } = new();
    }
}
