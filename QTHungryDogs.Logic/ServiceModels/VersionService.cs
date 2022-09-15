//@CodeCopy
//MdStart

using QTHungryDogs.Logic.Contracts;

namespace QTHungryDogs.Logic.ServiceModels
{
    public abstract partial class VersionService : IdentityService, IVersionable
    {
        /// <summary>
        /// Row version of the entity.
        /// </summary>
        public byte[]? RowVersion { get; set; }
    }
}
//MdEnd
