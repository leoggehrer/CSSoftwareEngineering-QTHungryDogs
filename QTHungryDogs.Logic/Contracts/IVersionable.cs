//@CodeCopy
//MdStart

namespace QTHungryDogs.Logic.Contracts
{
    public partial interface IVersionable : IIdentifyable
    {
        byte[]? RowVersion { get; }
    }
}
//MdEnd
