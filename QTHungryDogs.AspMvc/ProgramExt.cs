//@CodeCopy
//MdStart
namespace QTHungryDogs.AspMvc
{
    /// <summary>
    /// Extension Program
    /// </summary>
    public partial class Program
    {
        /// <summary>
        /// Services can be added using this method.
        /// </summary>
        /// <param name="builder">The builder</param>
        public static void BeforeBuild(WebApplicationBuilder builder)
        {
#if ACCOUNT_ON
            builder.Services.AddTransient<QTHungryDogs.Logic.Contracts.Account.IIdentitiesAccess<QTHungryDogs.Logic.Models.Account.Identity>, QTHungryDogs.Logic.Facades.Account.IdentitiesFacade>();
            builder.Services.AddTransient<QTHungryDogs.Logic.Contracts.Account.IRolesAccess<QTHungryDogs.Logic.Models.Account.Role>, QTHungryDogs.Logic.Facades.Account.RolesFacade>();
            builder.Services.AddTransient<QTHungryDogs.Logic.Contracts.Account.IUsersAccess<QTHungryDogs.Logic.Models.Account.User>, QTHungryDogs.Logic.Facades.Account.UsersFacade>();
#endif
            AddServices(builder);
        }
        /// <summary>
        /// Configures can be added using this method.
        /// </summary>
        /// <param name="app"></param>
        public static void AfterBuild(WebApplication app)
        {
            AddConfigures(app);
        }
        static partial void AddServices(WebApplicationBuilder builder);
        static partial void AddConfigures(WebApplication app);
    }
}
//MdEnd
