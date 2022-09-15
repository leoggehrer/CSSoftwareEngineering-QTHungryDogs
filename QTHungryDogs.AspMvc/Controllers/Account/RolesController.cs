//@CodeCopy
//MdStart
#if ACCOUNT_ON
using Microsoft.AspNetCore.Mvc;
using QTHungryDogs.Logic.Contracts;
using QTHungryDogs.Logic.Entities.Account;
using FilterType = QTHungryDogs.AspMvc.Models.Account.RoleFilter;

namespace QTHungryDogs.AspMvc.Controllers.Account
{
    public partial class RolesController : GenericController<Logic.Entities.Account.Role, Models.Account.Role>
    {
        private static string FilterName => typeof(FilterType).Name;
        public RolesController(IDataAccess<Logic.Entities.Account.Role> dataAccess) : base(dataAccess)
        {
        }
        public override Task<IActionResult> Index()
        {
            ViewBag.Filter = SessionWrapper.Get<FilterType>(FilterName) ?? new FilterType();

            return base.Index();
        }
        public async Task<IActionResult> Filter(FilterType filter)
        {
            var accessModels = await DataAccess.GetAllAsync();

            ViewBag.Filter = filter;
            SessionWrapper.Set<FilterType>(FilterName, filter);
            return View("Index", AfterQuery(accessModels).Select(e => ToViewModel(e, ActionMode.Index)));
        }
    }
}
#endif
//MdEnd
