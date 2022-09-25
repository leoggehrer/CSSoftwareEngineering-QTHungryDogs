using QTHungryDogs.Logic.Entities.App;
using QTHungryDogs.Logic.Modules.Common;

namespace QTHungryDogs.Logic.Entities.Base
{
    [Table("Restaurants", Schema = "base")]
    [Index(nameof(UniqueName), IsUnique = true)]
    public class Restaurant : VersionEntity
    {
        [MaxLength(256)]
        public string Name { get; set; } = String.Empty;
        [MaxLength(256)]
        public string OwnerName { get; set; } = String.Empty;
        [MaxLength(256)]
        public string UniqueName { get; set; } = String.Empty;
        [MaxLength(256)]
        public string Email { get; set; } = String.Empty;
        public RestaurantState State { get; set; }

        // Navigation properties
<<<<<<< HEAD
        public List<OpeningHour> OpeningHours { get; set; } = new();
        public List<SpecialOpeningHour> SpecialOpeningHours { get; set; } = new();
=======
        public List<Base.OpeningHour> OpeningHoures { get; set; } = new();
        public List<App.SpecialOpeningHour> SpecialOpeningHoures { get; set; } = new();
>>>>>>> 8fc0e462a8c5680e30c26f1fea337fb686db3a29
    }
}
