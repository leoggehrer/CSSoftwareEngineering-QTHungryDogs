namespace QTHungryDogs.AspMvc.Controllers.Base
{
    partial class RestaurantsController
    {
        protected override Models.Base.Restaurant BeforeView(Models.Base.Restaurant viewModel, ActionMode actionMode)
        {
            if (actionMode == ActionMode.Details)
            {
                var dayStamp = DateTime.Now.GetDayStamp();
                var instanceAccess = DataAccess as Logic.Contracts.Base.IRestaurantsAccess<Logic.Entities.Base.Restaurant>;
                var openingStates = Task.Run(async () => await instanceAccess!.CreateFromToOpeningStates(viewModel.Id, DateTime.Now.CreateDate().AddDays(-1), DateTime.Now.CreateDate().AddDays(1))).Result;

                viewModel.OpeningStates = openingStates.Where(e => e.From.GetDayStamp() == dayStamp || e.To.GetDayStamp() == dayStamp).Select(e => Models.OpeningState.FromToTime.Create(e)).ToArray();
            }
            return base.BeforeView(viewModel, actionMode);
        }
    }
}
