using QTHungryDogs.Logic.Entities.Base;
using QTHungryDogs.Logic.Modules.Common;

namespace QTHungryDogs.Logic.Entities.App
{
    [Table("SpecialOpeningHours", Schema = "app")]
    public class SpecialOpeningHour : VersionEntity
    {
        public int RestaurantId { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        [MaxLength(2048)]
        public string? Notes { get; set; }
        public SpecialOpenState State { get; set; }

        // Navigation properties
        public Restaurant? Restaurant { get; set; }
    }
}
