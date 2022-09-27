using QTHungryDogs.Logic.Models.OpeningState;
using QTHungryDogs.Logic.Modules.OpeningState;

namespace QTHungryDogs.Logic.Controllers.Base
{
    partial class RestaurantsController
    {
        internal override IEnumerable<string> Includes => new string[] { nameof(Entities.Base.Restaurant.OpeningHours), nameof(Entities.Base.Restaurant.SpecialOpeningHours) };

        public async Task<IEnumerable<FromToTime>> LoadDayTimeTable(int id, DateTime date)
        {
            var result = default(IEnumerable<FromToTime>);
            var restaurant = await GetByIdAsync(id).ConfigureAwait(false);

            if (restaurant != null)
            {
                result = TimeTableHelper.LoadDayTimeTable(restaurant.OpeningHours, restaurant.SpecialOpeningHours, date);
            }
            return result ?? Array.Empty<FromToTime>();
        }
    }
}
