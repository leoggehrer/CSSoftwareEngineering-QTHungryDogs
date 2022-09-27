namespace QTHungryDogs.Logic.Modules.Common
{
    [Flags]
    public enum OpenState
    {
        NoDefinition = 0,
        Open = 1,                       // 0b0001
        Closed = 2 * Open,              // 0b0010
        ClosedPermanent = 2 * Closed,   // 0b0100

        ClosedState = Closed + ClosedPermanent,     // 0b0110
        OpenState = Open,               // 0b0001
    }
}
