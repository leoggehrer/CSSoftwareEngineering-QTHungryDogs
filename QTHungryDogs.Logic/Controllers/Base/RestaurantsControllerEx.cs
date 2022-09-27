using QTHungryDogs.Logic.Models.OpeningState;
using QTHungryDogs.Logic.Modules.OpeningState;

namespace QTHungryDogs.Logic.Controllers.Base
{
    partial class RestaurantsController
    {
        internal override IEnumerable<string> Includes => new string[] { nameof(Entities.Base.Restaurant.OpeningHours), nameof(Entities.Base.Restaurant.SpecialOpeningHours) };

        public async Task<IEnumerable<FromToTime>> CreateDayOpeningStates(int id, DateTime date)
        {
            var result = default(IEnumerable<FromToTime>);
            var restaurant = await GetByIdAsync(id).ConfigureAwait(false);

            if (restaurant != null)
            {
                result = OpeningStatesCreator.CreateDayOpeningStates(restaurant.OpeningHours, restaurant.SpecialOpeningHours, date);
            }
            return result ?? Array.Empty<FromToTime>();
        }
        public async Task<IEnumerable<FromToTime>> CreateFromToOpeningStates(int id, DateTime from, DateTime to)
        {
            var result = default(IEnumerable<FromToTime>);
            var restaurant = await GetByIdAsync(id).ConfigureAwait(false);

            if (restaurant != null)
            {
                result = OpeningStatesCreator.CreateFromToOpeningStates(restaurant.OpeningHours, restaurant.SpecialOpeningHours, from, to);
            }
            return result ?? Array.Empty<FromToTime>();
        }
    }
}
