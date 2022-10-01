namespace QTHungryDogs.Logic.Controllers.Base
{
    partial class RestaurantXIdentitiesController
    {
        internal override IEnumerable<string> Includes => new[] { nameof(Entities.Base.RestaurantXIdentity.Restaurant), nameof(Entities.Base.RestaurantXIdentity.Identity) };
    }
}
