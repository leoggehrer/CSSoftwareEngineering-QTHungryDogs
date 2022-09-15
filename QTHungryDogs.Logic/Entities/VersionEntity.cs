//@CodeCopy
//MdStart

using QTHungryDogs.Logic.Contracts;

namespace QTHungryDogs.Logic.Entities
{
    public abstract partial class VersionEntity : IdentityEntity, IVersionable
    {
        /// <summary>
        /// Row version of the entity.
        /// </summary>
        [Timestamp]
        public byte[]? RowVersion { get; internal set; }
    }
}
//MdEnd
