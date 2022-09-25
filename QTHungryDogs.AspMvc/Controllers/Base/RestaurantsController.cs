//@GeneratedCode
namespace QTHungryDogs.AspMvc.Controllers.Base
{
    using Microsoft.AspNetCore.Mvc;
    using TAccessModel = QTHungryDogs.Logic.Entities.Base.Restaurant;
    using TViewModel = QTHungryDogs.AspMvc.Models.Base.Restaurant;
    using TFilterModel = QTHungryDogs.AspMvc.Models.Base.RestaurantFilter;
    using TAccessContract = QTHungryDogs.Logic.Contracts.Base.IRestaurantsAccess<QTHungryDogs.Logic.Entities.Base.Restaurant>;
    ///
    /// Generated by the generator
    ///
    public sealed partial class RestaurantsController : Controllers.FilterGenericController<TAccessModel, TViewModel, TFilterModel, TAccessContract>
    {
        ///
        /// Generated by the generator
        ///
        static RestaurantsController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        protected override string ControllerName => "Restaurants";
        ///
        /// Generated by the generator
        ///
        public RestaurantsController(QTHungryDogs.Logic.Contracts.Base.IRestaurantsAccess<TAccessModel> other)
        : base(other)
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        ///
        /// Generated by the generator
        ///
        protected override TViewModel ToViewModel(TAccessModel accessModel, ActionMode actionMode)
        {
            var handled = false;
            var result = default(TViewModel);
            BeforeToViewModel(accessModel, actionMode, ref result, ref handled);
            if (handled == false || result == null)
            {
                result = TViewModel.Create(accessModel);
            }
            AfterToViewModel(result, actionMode);
            return BeforeView(result, actionMode);
        }
        partial void BeforeToViewModel(TAccessModel accessModel, ActionMode actionMode, ref TViewModel? viewModel, ref bool handled);
        partial void AfterToViewModel(TViewModel viewModel, ActionMode actionMode);
    }
}
