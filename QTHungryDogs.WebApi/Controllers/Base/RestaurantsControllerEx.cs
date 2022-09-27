using Microsoft.AspNetCore.Mvc;
using QTHungryDogs.WebApi.Models.OpeningState;
using System.Xml.Linq;

namespace QTHungryDogs.WebApi.Controllers.Base
{
    partial class RestaurantsController
    {
        /// <summary>
        /// Gets a time table with open state for a day and a restaurant.
        /// </summary>
        /// <param name="restaurantId">id for the restaurant.</param>
        /// <param name="date">The date for the time table.</param>
        /// <returns>
        /// List of FromToTime items.
        /// </returns>
        [HttpGet("QueryOpeningStates", Name = nameof(QueryTimeTableByDayAsync))]
        public async Task<ActionResult<IEnumerable<Models.OpeningState.FromToTime>>> QueryTimeTableByDayAsync(
            [FromQuery(Name = "restaurantId")] int restaurantId,
            [FromQuery(Name = "date")] DateTime date)
        {
            var instanceAccess = DataAccess as Logic.Contracts.Base.IRestaurantsAccess<Logic.Entities.Base.Restaurant>;

            return instanceAccess == null ? Array.Empty<FromToTime>() : (await instanceAccess.CreateDayOpeningStates(restaurantId, date)).Select(e => FromToTime.Create(e)).ToArray();
        }

    }
}
