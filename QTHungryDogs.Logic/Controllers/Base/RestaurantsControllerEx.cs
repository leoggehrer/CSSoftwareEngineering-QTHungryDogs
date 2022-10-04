using QTHungryDogs.Logic.Controllers.Account;
using QTHungryDogs.Logic.Entities.App;
using QTHungryDogs.Logic.Entities.Base;
using QTHungryDogs.Logic.Models.OpeningState;
using QTHungryDogs.Logic.Modules.Account;
using QTHungryDogs.Logic.Modules.Exceptions;
using QTHungryDogs.Logic.Modules.OpeningState;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;

namespace QTHungryDogs.Logic.Controllers.Base
{
    partial class RestaurantsController
    {
        internal override IEnumerable<string> Includes => new string[] { nameof(Entities.Base.Restaurant.OpeningHours), nameof(Entities.Base.Restaurant.SpecialOpeningHours), nameof(Entities.Base.Restaurant.Managers) };

        public async Task<IEnumerable<FromToTime>> CreateDayOpeningStates(int id, DateTime date)
        {
            var result = default(IEnumerable<FromToTime>);
            var restaurant = await ExecuteGetByIdAsync(id).ConfigureAwait(false);

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

        public async Task AddStoreManagerAsync(int id, int identityId)
        {
            await CheckAuthorizationAsync(GetType(), MethodBase.GetCurrentMethod(), AccessType.Create).ConfigureAwait(false);

            using var identityCtrl = new IdentitiesController(this);
            var restaurant = await GetByIdAsync(id).ConfigureAwait(false);
            var identity = await identityCtrl.GetByIdAsync(identityId).ConfigureAwait(false);

            if (restaurant != null && identity != null)
            {
                restaurant.Managers.Add(new Entities.Base.RestaurantXIdentity
                {
                    RestaurantId = restaurant.Id,
                    IdentityId = identity.Id,
                });
                await UpdateAsync(restaurant).ConfigureAwait(false);
            }
        }
        public async Task RemoveStoreManagerAsync(int id, int identityId)
        {
            await CheckAuthorizationAsync(GetType(), MethodBase.GetCurrentMethod(), AccessType.Create).ConfigureAwait(false);

            var restaurant = await GetByIdAsync(id).ConfigureAwait(false);

            if (restaurant != null)
            {
                var manager = restaurant.Managers.FirstOrDefault(e => e.RestaurantId == restaurant.Id && e.IdentityId == identityId);

                if (manager != null)
                {
                    using var resXIdeCtrl = new RestaurantXIdentitiesController(this);

                    await resXIdeCtrl.DeleteAsync(manager.Id).ConfigureAwait(false);
                }
            }
        }

        [Modules.Security.Authorize("SysAdmin", "AppAdmin", "StoreManager")]
        public async Task<bool> CloseNowAsync(int id)
        {
            await CheckAuthorizationAsync(GetType(), MethodBase.GetCurrentMethod(), AccessType.Create).ConfigureAwait(false);

            var result = false;
            var restaurant = await ExecuteGetByIdAsync(id).ConfigureAwait(false);

            if (restaurant != null)
            {
                await CheckAuthorizationAsync(restaurant).ConfigureAwait(false);

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
                        await ExecuteUpdateAsync(restaurant).ConfigureAwait(false);
                        result = true;
                    }
                }
            }
            return result;
        }
        [Modules.Security.Authorize("SysAdmin", "AppAdmin", "StoreManager")]
        public async Task<bool> OpenNowAsync(int id)
        {
            await CheckAuthorizationAsync(GetType(), MethodBase.GetCurrentMethod(), AccessType.Create).ConfigureAwait(false);

            var result = false;
            var restaurant = await ExecuteGetByIdAsync(id).ConfigureAwait(false);

            if (restaurant != null)
            {
                await CheckAuthorizationAsync(restaurant).ConfigureAwait(false);

                var now = DateTime.Now;

                if (restaurant.State == Modules.Common.RestaurantState.Closed)
                {
                    restaurant.State = Modules.Common.RestaurantState.Active;
                    await ExecuteUpdateAsync(restaurant).ConfigureAwait(false);
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
                        await ExecuteUpdateAsync(restaurant).ConfigureAwait(false);
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
                        await ExecuteUpdateAsync(restaurant).ConfigureAwait(false);
                        result = true;
                    }
                }
            }
            return result;
        }
        [Modules.Security.Authorize("SysAdmin", "AppAdmin", "StoreManager")]
        public async Task<bool> SetBusyAsync(int id)
        {
            await CheckAuthorizationAsync(GetType(), MethodBase.GetCurrentMethod(), AccessType.Create).ConfigureAwait(false);

            var result = false;
            var restaurant = await ExecuteGetByIdAsync(id).ConfigureAwait(false);

            if (restaurant != null)
            {
                await CheckAuthorizationAsync(restaurant).ConfigureAwait(false);

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
                        if (nowOpeningState.Type == FromToTime.FromToType.SpecialOpeningHour)
                        {
                            var specialOpeningHourAfter = new SpecialOpeningHour
                            {
                                Restaurant = restaurant,
                                From = specialOpeningHour.To.Value.AddSeconds(1),
                                To = nowOpeningState.To,
                                State = nowOpeningState.State,
                            };
                            restaurant.SpecialOpeningHours.Add(specialOpeningHourAfter);
                        }
                        await ExecuteUpdateAsync(restaurant).ConfigureAwait(false);
                        result = true;
                    }
                }
            }
            return result;
        }

        public override Task<Restaurant?> GetByIdAsync(int id)
        {
            return base.ExecuteGetByIdAsync(id);
        }
        public Task<Restaurant[]> QueryRestaurantInfos(string? predicate, string? orderBy)
        {
            var query = EntitySet.AsQueryable();

            foreach (var includeItem in Includes)
            {
                query = query.Include(includeItem);
            }

            query = query.Where(e => e.State == Modules.Common.RestaurantState.Active || e.State == Modules.Common.RestaurantState.Closed);

            if (string.IsNullOrEmpty(predicate) == false)
            {
                query = query.Where(predicate);
            }
            if (string.IsNullOrEmpty(orderBy) == false)
            {
                query = query.OrderBy(orderBy);
            }
            return query.ToArrayAsync();
        }

        private async Task CheckAuthorizationAsync(Restaurant restaurant)
        {
            var curSession = await AccountManager.QueryAliveSessionAsync(SessionToken).ConfigureAwait(false);

            if (curSession == null)
                throw new AuthorizationException(ErrorType.InvalidSessionToken);

            if (curSession.Roles.Any(e => e.Equals("StoreManager"))
                && restaurant.Managers.Any(e => e.IdentityId == curSession.IdentityId) == false)
            {
                throw new AuthorizationException(ErrorType.NotAuthorized);
            }
        }
    }
}
