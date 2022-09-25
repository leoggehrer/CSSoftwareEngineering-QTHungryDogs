﻿using QTHungryDogs.Logic.Entities.App;
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
        public List<OpeningHour> OpeningHours { get; set; } = new();
        public List<SpecialOpeningHour> SpecialOpeningHours { get; set; } = new();
    }
}
