using QTHungryDogs.Logic.Models.OpeningState;

namespace QTHungryDogs.Logic.Contracts.Base
{
    partial interface IRestaurantsAccess<T>
    {
        Task<IEnumerable<FromToTime>> CreateDayOpeningStates(int id, DateTime date);
        Task<IEnumerable<FromToTime>> CreateFromToOpeningStates(int id, DateTime from, DateTime to);

        Task<bool> CloseNowAsync(int id);
        Task<bool> OpenNowAsync(int id);
        Task<bool> SetBusyAsync(int id);
    }
}
