﻿using Microsoft.AspNetCore.Mvc;
using QTHungryDogs.Logic.Contracts;
using System.ComponentModel;

namespace QTHungryDogs.WebApi.Controllers.Base
{
    ///
    /// Generated by the developer
    ///
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantInfosController : ControllerBase
    {
        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="predicate">A string to test each element for a condition.</param>
        /// <param name="orderBy">Sorts the elements of a sequence according to a sort clause.</param>
        /// <returns>The query result.</returns>
        [HttpGet("QueryInfos", Name = nameof(QueryInfosAysync))]
        public async Task<Models.Base.Restaurant[]> QueryInfosAysync(
            [FromQuery(Name = "predicate")] string? predicate,
            [FromQuery(Name = "orderBy")]string? orderBy)
        {
            var instanceAccess = HttpContext.RequestServices.GetRequiredService<Logic.Contracts.Base.IRestaurantsAccess<Logic.Entities.Base.Restaurant>>();
            var entities = instanceAccess != null ? await instanceAccess.QueryRestaurantInfosAsync(predicate, orderBy) : Array.Empty<Logic.Entities.Base.Restaurant>();

            return entities.Select(e => Models.Base.Restaurant.Create(e)).ToArray();
        }
    }
}
