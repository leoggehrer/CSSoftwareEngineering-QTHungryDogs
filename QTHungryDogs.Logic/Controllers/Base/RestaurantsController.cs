//@GeneratedCode
namespace QTHungryDogs.Logic.Controllers.Base
{
    ///
    /// Generated by the generator
    ///
    [Modules.Security.Authorize("SysAdmin", "AppAdmin")]
    public sealed partial class RestaurantsController : Controllers.GenericController<Entities.Base.Restaurant>, Contracts.Base.IRestaurantsAccess<Entities.Base.Restaurant>
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
        ///
        /// Generated by the generator
        ///
        public RestaurantsController()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        ///
        /// Generated by the generator
        ///
        public RestaurantsController(ControllerObject other)
        : base(other)
        {
            Constructing();
            Constructed();
        }
    }
}
