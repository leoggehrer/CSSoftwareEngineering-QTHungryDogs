using QTHungryDogs.Logic.Models.OpeningState;

namespace QTHungryDogs.Logic.Contracts.Base
{
    partial interface IRestaurantsAccess<T>// : Contracts.IDataAccess<T>
    {
        Task<IEnumerable<FromToTime>> LoadDayTimeTable(int id, DateTime date);
    }
}
