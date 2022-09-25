using QTHungryDogs.Logic.Modules.Common;

namespace QTHungryDogs.Logic.Entities.Base
{
    [Table("OpeningHours", Schema = "base")]
    [Index(nameof(RestaurantId), nameof(Weekday), IsUnique = true)]
    public class OpeningHour : VersionEntity
    {
        public int RestaurantId { get; set; }
        public Weekday Weekday { get; set; }
        public TimeSpan OpenFrom { get; set; }
        public TimeSpan OpenTo { get; set; }
        [MaxLength(2048)]
        public string? Notes { get; set; }

        // Navigation properties
        public Restaurant? Restaurant { get; set; }
    }
}
