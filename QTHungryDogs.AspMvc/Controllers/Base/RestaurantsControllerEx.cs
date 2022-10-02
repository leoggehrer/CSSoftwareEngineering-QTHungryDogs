using Microsoft.AspNetCore.Mvc;

namespace QTHungryDogs.AspMvc.Controllers.Base
{
    partial class RestaurantsController
    {
        private Models.Account.Identity[]? identities;
        public Models.Account.Identity[] Identities
        {
            get
            {
                if (identities == null)
                {
                    var services = HttpContext.RequestServices;
                    using var ctrl = (Logic.Contracts.Account.IIdentitiesAccess<Logic.Models.Account.Identity>)services.GetService(typeof(Logic.Contracts.Account.IIdentitiesAccess<Logic.Models.Account.Identity>))!;

                    ctrl.SessionToken = SessionWrapper.SessionToken;

                    identities = ctrl.GetAllAsync("Email asc").Result.Select(e => Models.Account.Identity.Create(e)).ToArray();
                }
                return identities;
            }
        }

        protected override Models.Base.Restaurant BeforeView(Models.Base.Restaurant viewModel, ActionMode actionMode)
        {
            viewModel.IdentityList = Identities;

            if ((actionMode & ActionMode.EditAction) > 0 || actionMode == ActionMode.Details)
            {
                if (viewModel.State != Logic.Modules.Common.RestaurantState.Locked)
                {
                    var dayStamp = DateTime.Now.GetDayStamp();
                    var instanceAccess = DataAccess as Logic.Contracts.Base.IRestaurantsAccess<Logic.Entities.Base.Restaurant>;
                    var openingStates = instanceAccess!.CreateDayOpeningStates(viewModel.Id, DateTime.Now).Result;

                    viewModel.OpeningStates = openingStates.Select(e => Models.OpeningState.FromToTime.Create(e)).ToArray();
                }
            }
            return base.BeforeView(viewModel, actionMode);
        }

        public async Task<IActionResult> CloseNow(int restaurantId)
        {
            var instanceAccess = DataAccess as Logic.Contracts.Base.IRestaurantsAccess<Logic.Entities.Base.Restaurant>;

            if (instanceAccess != null)
            {
                var result = await instanceAccess.CloseNowAsync(restaurantId);

                if (result)
                {
                    instanceAccess.SaveChangesAsync().Wait();
                }
            }
            return RedirectToAction("Edit", new { id = restaurantId });
        }
        public async Task<IActionResult> OpenNow(int restaurantId)
        {
            var instanceAccess = DataAccess as Logic.Contracts.Base.IRestaurantsAccess<Logic.Entities.Base.Restaurant>;

            if (instanceAccess != null)
            {
                var result = await instanceAccess.OpenNowAsync(restaurantId);

                if (result)
                {
                    instanceAccess.SaveChangesAsync().Wait();
                }
            }
            return RedirectToAction("Edit", new { id = restaurantId });
        }
        public async Task<IActionResult> SetBusy(int restaurantId)
        {
            var instanceAccess = DataAccess as Logic.Contracts.Base.IRestaurantsAccess<Logic.Entities.Base.Restaurant>;

            if (instanceAccess != null)
            {
                var result = await instanceAccess.SetBusyAsync(restaurantId);

                if (result)
                {
                    instanceAccess.SaveChangesAsync().Wait();
                }
            }
            return RedirectToAction("Edit", new { id = restaurantId });
        }

        public async Task<IActionResult> AddStoreManager(int id, int identityId)
        {
            try
            {
                var instanceAccess = DataAccess as Logic.Contracts.Base.IRestaurantsAccess<Logic.Entities.Base.Restaurant>;

                await instanceAccess!.AddStoreManagerAsync(id, identityId);
                await DataAccess.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                if (ex.InnerException != null)
                {
                    ViewBag.Error = ex.InnerException.Message;
                }
            }
            return RedirectToAction("Edit", new { id });
        }

        public async Task<IActionResult> RemoveStoreManager(int id, int identityId)
        {
            try
            {
                var instanceAccess = DataAccess as Logic.Contracts.Base.IRestaurantsAccess<Logic.Entities.Base.Restaurant>;

                await instanceAccess!.RemoveStoreManagerAsync(id, identityId);
                await DataAccess.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                if (ex.InnerException != null)
                {
                    ViewBag.Error = ex.InnerException.Message;
                }
            }
            return RedirectToAction("Edit", new { id });
        }

    }
}
