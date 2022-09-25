﻿//@CodeCopy
//MdStart
#if ACCOUNT_ON

namespace QTHungryDogs.AspMvc.Controllers.Account
{
    using TAccessModel = QTHungryDogs.Logic.Models.Account.Identity;
    using TViewModel = QTHungryDogs.AspMvc.Models.Account.Identity;
    using TFilterModel = QTHungryDogs.AspMvc.Models.Account.IdentityFilter;
    using TAccessContract = QTHungryDogs.Logic.Contracts.Account.IIdentitiesAccess<QTHungryDogs.Logic.Models.Account.Identity>;
    using Microsoft.AspNetCore.Mvc;

    public partial class IdentitiesController : Controllers.FilterGenericController<TAccessModel, TViewModel, TFilterModel, TAccessContract>
    {
        ///
        /// Generated by the generator
        ///
        static IdentitiesController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        protected override string ControllerName => "Identities";
        ///
        /// Generated by the generator
        ///
        public IdentitiesController(TAccessContract other)
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

        // Extensions
        private Models.Account.AccessRole[]? accessRoleList;
        public Models.Account.AccessRole[] AccessRoleList
        {
            get
            {
                if (accessRoleList == null)
                {
                    var services = HttpContext.RequestServices;
                    using var ctrl = (Logic.Contracts.Account.IRolesAccess<Logic.Models.Account.Role>)services.GetService(typeof(Logic.Contracts.Account.IRolesAccess<Logic.Models.Account.Role>))!;

                    ctrl.SessionToken = SessionWrapper.SessionToken;

                    accessRoleList = Task.Run(async () => await ctrl.GetAllAsync("Designation asc")).Result.Select(e => Models.Account.AccessRole.Create(e)).ToArray();
                }
                return accessRoleList;
            }
        }

        partial void AfterToViewModel(Models.Account.Identity viewModel, ActionMode actionMode)
        {
            if ((actionMode & ActionMode.EditAction) > 0)
            {
                viewModel.AccessRoleList = AccessRoleList;

            }
        }

        public async Task<IActionResult> AddAccessRole(int id, int accessRoleId)
        {
            try
            {
                var instanceAccess = DataAccess as Logic.Contracts.Account.IIdentitiesAccess<Logic.Models.Account.Identity>;

                await instanceAccess!.AddRoleAsync(id, accessRoleId);
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
        public async Task<IActionResult> RemoveAccessRole(int id, int accessRoleId)
        {
            try
            {
                var instanceAccess = DataAccess as Logic.Contracts.Account.IIdentitiesAccess<Logic.Models.Account.Identity>;

                await instanceAccess!.RemoveRoleAsync(id, accessRoleId);
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

        // Extensions
    }
}
#endif
//MdEnd
