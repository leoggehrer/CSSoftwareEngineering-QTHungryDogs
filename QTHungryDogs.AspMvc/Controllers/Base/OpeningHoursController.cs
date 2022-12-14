//@GeneratedCode
namespace QTHungryDogs.AspMvc.Controllers.Base
{
    using Microsoft.AspNetCore.Mvc;
    using TAccessModel = QTHungryDogs.Logic.Entities.Base.OpeningHour;
    using TViewModel = QTHungryDogs.AspMvc.Models.Base.OpeningHour;
    using TFilterModel = QTHungryDogs.AspMvc.Models.Base.OpeningHourFilter;
    using TAccessContract = QTHungryDogs.Logic.Contracts.Base.IOpeningHoursAccess<QTHungryDogs.Logic.Entities.Base.OpeningHour>;
    ///
    /// Generated by the generator
    ///
    public sealed partial class OpeningHoursController : Controllers.FilterGenericController<TAccessModel, TViewModel, TFilterModel, TAccessContract>
    {
        ///
        /// Generated by the generator
        ///
        static OpeningHoursController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        protected override string ControllerName => "OpeningHours";
        ///
        /// Generated by the generator
        ///
        public OpeningHoursController(QTHungryDogs.Logic.Contracts.Base.IOpeningHoursAccess<TAccessModel> other)
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
