//@GeneratedCode
namespace QTHungryDogs.AspMvc.Controllers.Base
{
    using Microsoft.AspNetCore.Mvc;
    using AccessType = QTHungryDogs.Logic.Entities.Base.OpeningHour;
    using ModelType = QTHungryDogs.AspMvc.Models.Base.OpeningHour;
    using FilterType = QTHungryDogs.AspMvc.Models.Base.OpeningHourFilter;
    ///
    /// Generated by the generator
    ///
    public sealed partial class OpeningHoursController : Controllers.GenericController<AccessType, ModelType>
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
        private static string ControllerName => "OpeningHours";
        private static string FilterName => typeof(FilterType).Name;
        private static string OrderByName => "OpeningHours.OrderBy";
        ///
        /// Generated by the generator
        ///
        public OpeningHoursController(QTHungryDogs.Logic.Contracts.Base.IOpeningHoursAccess<AccessType> other)
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
        protected override ModelType ToViewModel(AccessType accessModel, ActionMode actionMode)
        {
            var handled = false;
            var result = default(ModelType);
            BeforeToViewModel(accessModel, actionMode, ref result, ref handled);
            if (handled == false || result == null)
            {
                result = ModelType.Create(accessModel);
            }
            AfterToViewModel(result, actionMode);
            return BeforeView(result, actionMode);
        }
        partial void BeforeToViewModel(AccessType accessModel, ActionMode actionMode, ref ModelType? viewModel, ref bool handled);
        partial void AfterToViewModel(ModelType viewModel, ActionMode actionMode);
        ///
        /// Generated by the generator
        ///
        public IActionResult Clear()
        {
            var filter = new FilterType();
            ViewBag.Filter = filter;
            SessionWrapper.Set<FilterType>(FilterName, filter);
            return RedirectToAction("Index");
        }
        ///
        /// Generated by the generator
        ///
        public override async Task<IActionResult> Index()
        {
            IActionResult? result;
            var modelCount = 0;
            var pageSize = DataAccess.MaxPageSize;
            var filter = SessionWrapper.Get<FilterType>(FilterName) ?? new FilterType();
            var orderBy = SessionWrapper.Get<string>(OrderByName) ?? string.Empty;
            if (filter.HasEntityValue)
            {
                var predicate = filter.CreateEntityPredicate();
                var accessModels = string.IsNullOrEmpty(orderBy) ? await DataAccess.QueryAsync(predicate, 0, pageSize) : await DataAccess.QueryAsync(predicate, orderBy, 0, pageSize);
                var viewModels = AfterQuery(accessModels).Select(e => ToViewModel(e, ActionMode.Index));
                modelCount = await DataAccess.CountAsync(predicate);
                result = View(BeforeView(viewModels, ActionMode.Index));
            }
            else
            {
                var accessModels = string.IsNullOrEmpty(orderBy) ? await DataAccess.GetPageListAsync(0, pageSize) : await DataAccess.GetPageListAsync(orderBy, 0, pageSize);
                var viewModels = AfterQuery(accessModels).Select(e => ToViewModel(e, ActionMode.Index));
                modelCount = await DataAccess.CountAsync();
                result = View(BeforeView(viewModels, ActionMode.Index));
            }
            ViewBag.Filter = filter;
            ViewBag.OrderBy = orderBy;
            ViewBag.PageSize = pageSize;
            ViewBag.ModelCount = modelCount;
            return result;
        }
        ///
        /// Generated by the generator
        ///
        public IActionResult Filter(FilterType filter)
        {
            SessionWrapper.Set<FilterType>(FilterName, filter);
            return RedirectToAction("Index");
        }
        ///
        /// Generated by the generator
        ///
        public IActionResult OrderBy(string orderBy)
        {
            SessionWrapper.Set<string>(OrderByName, orderBy);
            return RedirectToAction("Index");
        }
    }
}
