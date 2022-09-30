﻿using QTHungryDogs.Logic.Entities.App;
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
                if (OpeningStatesCreator.IsClosedPermanent(restaurant, date))
                {
                    result = new[] { OpeningStatesCreator.CreateClosedPermanentItem(date) };
                }
                else
                {
                    result = OpeningStatesCreator.CreateDayOpeningStates(restaurant.OpeningHours, restaurant.SpecialOpeningHours, date);
                }
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

        public async Task<bool> CloseNowAsync(int id)
        {
            var result = false;
            var restaurant = await GetByIdAsync(id).ConfigureAwait(false);

            if (restaurant != null)
            {
                var now = DateTime.Now;
                var openingStates = OpeningStatesCreator.CreateDayOpeningStates(restaurant.OpeningHours, restaurant.SpecialOpeningHours, now);
                var nowOpeningState = openingStates.Where(e => e.IsBetween(now)).FirstOrDefault();

                if (nowOpeningState != null)
                {
                    if ((nowOpeningState.State & Modules.Common.OpenState.OpenState) > 0)
                    {
                        var specialOpeningHour = new SpecialOpeningHour
                        {
                            Restaurant = restaurant,
                            From = now,
                            To = nowOpeningState.To,
                            State = Modules.Common.OpenState.ClosedNow,
                        };
                        restaurant.SpecialOpeningHours.Add(specialOpeningHour);
                        await UpdateAsync(restaurant).ConfigureAwait(false);
                        result = true;
                    }
                }
            }
            return result;
        }
        public async Task<bool> OpenNowAsync(int id)
        {
            var result = false;
            var restaurant = await GetByIdAsync(id).ConfigureAwait(false);

            if (restaurant != null)
            {
                var now = DateTime.Now;

                if (restaurant.State == Modules.Common.RestaurantState.Locked
                    || restaurant.State == Modules.Common.RestaurantState.Closed)
                {
                    restaurant.State = Modules.Common.RestaurantState.Active;
                    await UpdateAsync(restaurant).ConfigureAwait(false);
                    result = true;
                }

                var openingStates = OpeningStatesCreator.CreateDayOpeningStates(restaurant.OpeningHours, restaurant.SpecialOpeningHours, now);
                var nowOpeningState = openingStates.Where(e => e.IsBetween(now)).FirstOrDefault();

                if (nowOpeningState != null)
                {
                    if (nowOpeningState.State == Modules.Common.OpenState.ClosedPermanent)
                    {
                        restaurant.SpecialOpeningHours.Where(e => e.State == Modules.Common.OpenState.ClosedPermanent && e.To.HasValue == false)
                                                      .ForEach(e => e.To = now);
                        await UpdateAsync(restaurant).ConfigureAwait(false);
                        result = true;
                    }
                    else if ((nowOpeningState.State & Modules.Common.OpenState.ClosedState) > 0)
                    {
                        var specialOpeningHour = new SpecialOpeningHour
                        {
                            Restaurant = restaurant,
                            From = now,
                            To = nowOpeningState.To,
                            State = Modules.Common.OpenState.OpenNow,
                        };
                        restaurant.SpecialOpeningHours.Add(specialOpeningHour);
                        await UpdateAsync(restaurant).ConfigureAwait(false);
                        result = true;
                    }
                }
            }
            return result;
        }
        public async Task<bool> SetBusyAsync(int id)
        {
            var result = false;
            var restaurant = await GetByIdAsync(id).ConfigureAwait(false);

            if (restaurant != null)
            {
                var now = DateTime.Now;
                var openingStates = OpeningStatesCreator.CreateDayOpeningStates(restaurant.OpeningHours, restaurant.SpecialOpeningHours, now);
                var nowOpeningState = openingStates.Where(e => e.IsBetween(now)).FirstOrDefault();

                if (nowOpeningState != null)
                {
                    if ((nowOpeningState.State & Modules.Common.OpenState.OpenState) > 0)
                    {
                        var specialOpeningHour = new SpecialOpeningHour
                        {
                            Restaurant = restaurant,
                            From = now,
                            To = now.GetDateSecondStamp() + (15 * 60) < nowOpeningState.To.GetDateSecondStamp() ? now.AddMinutes(15) : nowOpeningState.To,
                            State = Modules.Common.OpenState.IsBusy,
                        };
                        restaurant.SpecialOpeningHours.Add(specialOpeningHour);
                        await UpdateAsync(restaurant).ConfigureAwait(false);
                        result = true;
                    }
                }
            }
            return result;
        }
    }
}
