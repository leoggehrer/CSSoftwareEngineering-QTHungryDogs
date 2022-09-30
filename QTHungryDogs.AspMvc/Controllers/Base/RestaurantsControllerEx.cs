using Microsoft.AspNetCore.Mvc;

namespace QTHungryDogs.AspMvc.Controllers.Base
{
    partial class RestaurantsController
    {
        protected override Models.Base.Restaurant BeforeView(Models.Base.Restaurant viewModel, ActionMode actionMode)
        {
            if ((actionMode & ActionMode.EditAction) > 0 || actionMode == ActionMode.Details)
            {
                var dayStamp = DateTime.Now.GetDayStamp();
                var instanceAccess = DataAccess as Logic.Contracts.Base.IRestaurantsAccess<Logic.Entities.Base.Restaurant>;
                var openingStates = instanceAccess!.CreateDayOpeningStates(viewModel.Id, DateTime.Now).Result;

                viewModel.OpeningStates = openingStates.Select(e => Models.OpeningState.FromToTime.Create(e)).ToArray();
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
    }
}
