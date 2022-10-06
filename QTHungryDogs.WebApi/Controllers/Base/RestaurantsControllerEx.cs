using Microsoft.AspNetCore.Mvc;
using QTHungryDogs.WebApi.Models.Base;
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

        /// <summary>
        /// Close the restaurant and return the achievement.
        /// </summary>
        /// <param name="restaurantId">id for the restaurant.</param>
        /// <returns>The achievement.</returns>
        [HttpGet("CloseNow", Name = nameof(CloseNowAsync))]
        public async Task<bool> CloseNowAsync([FromQuery(Name = "restaurantId")] int restaurantId)
        {
            var instanceAccess = DataAccess as Logic.Contracts.Base.IRestaurantsAccess<Logic.Entities.Base.Restaurant>;

            return instanceAccess != null && await instanceAccess.CloseNowAsync(restaurantId);
        }

        /// <summary>
        /// Opens the restaurant and return the achievement.
        /// </summary>
        /// <param name="restaurantId">id for the restaurant.</param>
        /// <returns>The achievement.</returns>
        [HttpGet("OpenNow", Name = nameof(OpenNowAsync))]
        public async Task<bool> OpenNowAsync([FromQuery(Name = "restaurantId")] int restaurantId)
        {
            var instanceAccess = DataAccess as Logic.Contracts.Base.IRestaurantsAccess<Logic.Entities.Base.Restaurant>;

            return instanceAccess != null && await instanceAccess.OpenNowAsync(restaurantId);
        }

        /// <summary>
        /// Sets the restaurant to full for 15 minutes.
        /// </summary>
        /// <param name="restaurantId">id for the restaurant.</param>
        /// <returns>The achievement.</returns>
        [HttpGet("SetBusy", Name = nameof(SetBusyAsync))]
        public async Task<bool> SetBusyAsync([FromQuery(Name = "restaurantId")] int restaurantId)
        {
            var instanceAccess = DataAccess as Logic.Contracts.Base.IRestaurantsAccess<Logic.Entities.Base.Restaurant>;

            return instanceAccess != null && await instanceAccess.SetBusyAsync(restaurantId);
        }
    }
}
