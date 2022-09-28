using Microsoft.AspNetCore.Mvc;

namespace QTHungryDogs.AspMvc.Controllers.App
{
    partial class SpecialOpeningHoursController
    {
        public override IActionResult BackToIndex()
        {
            var backController = SessionWrapper.GetStringValue($"{ControllerName}.BackController", "Restaurants");
            var backAction = SessionWrapper.GetStringValue($"{ControllerName}.BackAction", "Index");
            var backParam = SessionWrapper.GetStringValue($"{ControllerName}.BackParam", string.Empty);

            return string.IsNullOrEmpty(backParam) ? RedirectToAction(backAction, backController) : RedirectToAction(backAction, backController, new { id = Convert.ToInt32(backParam) });
        }
        protected override RedirectToActionResult RedirectAfterAction(ActionMode actionMode, Logic.Entities.App.SpecialOpeningHour accessModel)
        {
            return RedirectToAction("Edit", "Restaurants", new { id = accessModel.RestaurantId });
        }
        protected override Models.App.SpecialOpeningHour BeforeView(Models.App.SpecialOpeningHour viewModel, ActionMode actionMode)
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
        public IActionResult AddSpecialOpeningHour(int restaurantId)
        {
            var accessModel = new Models.App.SpecialOpeningHour
            {
                RestaurantId = restaurantId,
                From = DateTime.Now,
            };
            SessionWrapper.SetStringValue($"{ControllerName}.BackController", "Restaurants");
            SessionWrapper.SetStringValue($"{ControllerName}.BackAction", "Edit");
            SessionWrapper.SetStringValue($"{ControllerName}.BackParam", restaurantId.ToString());
            return View("Create", BeforeView(accessModel, ActionMode.ViewCreate));
        }
    }
}

