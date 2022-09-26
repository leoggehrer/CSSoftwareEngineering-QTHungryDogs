using Microsoft.AspNetCore.Mvc;

namespace QTHungryDogs.AspMvc.Controllers.Base
{
    partial class OpeningHoursController
    {
        public override IActionResult BackToIndex()
        {
            return RedirectToAction("Index", "Restaurants");
        }
        protected override RedirectToActionResult RedirectAfterAction(ActionMode actionMode, Logic.Entities.Base.OpeningHour accessModel)
        {
            return RedirectToAction("Edit", "Restaurants", new { id = accessModel.RestaurantId });
        }
        protected override Models.Base.OpeningHour BeforeView(Models.Base.OpeningHour viewModel, ActionMode actionMode)
        {
            using var masterAccess = new Logic.Controllers.Base.RestaurantsController((DataAccess as Logic.Controllers.ControllerObject)!);
            var masterItem = Task.Run(async () => await masterAccess.GetByIdAsync(viewModel.RestaurantId)).Result;

            if (masterItem == null)
            {
                viewModel.Restaurant = new Models.Base.Restaurant();
            }
            else
            {
                viewModel.Restaurant = Models.Base.Restaurant.Create(masterItem);
            }
            return base.BeforeView(viewModel, actionMode);
        }

        [HttpGet]
        public IActionResult AddOpeningHour(int restaurantId)
        {
            var accessModel = new Models.Base.OpeningHour
            {
                RestaurantId = restaurantId,
                IsActive = true,
            };
            return View("Create", BeforeView(accessModel, ActionMode.ViewCreate));
        }
    }
}
