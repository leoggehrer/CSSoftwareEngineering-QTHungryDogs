namespace QTHungryDogs.Logic.Modules.Common
{
    [Flags]
    public enum OpenState
    {
        NoDefinition = 0,
        Open = 1,                       // 0b0001
        OpenNow = 2 * Open,             // 0b0010
        Closed = 2 * OpenNow,           // 0b0100
        ClosedPermanent = 2 * Closed,   // 0b1000

        ClosedState = Closed + ClosedPermanent,     // 0b1100
        OpenState = Open + OpenNow,     // 0b0011
    }
}
