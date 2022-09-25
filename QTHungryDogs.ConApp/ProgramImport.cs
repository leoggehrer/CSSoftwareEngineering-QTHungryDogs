using QTHungryDogs.Logic.Entities.Base;
using QTHungryDogs.Logic.Models.Account;

namespace QTHungryDogs.ConApp
{
    partial class Program
    {
        static partial void AfterRun()
        {
            var login = Task.Run(async () => await Logic.AccountAccess.LogonAsync(SaEmail, SaPwd, "Import")).Result;

            Task.Run(async () => await ImportRestaurants(login)).Wait();
        }

        static string RestaurantFile = "Restaurants.csv";
        static string OpeningHourFile = "RestaurantOpenings.csv";
        static async Task<Logic.Entities.Base.Restaurant[]> ImportRestaurants(LoginSession loginSession)
        {
            using var restaurantCtrl = new Logic.Controllers.Base.RestaurantsController()
            {
                SessionToken = loginSession.SessionToken,
            };
            var restaurants = File.ReadLines(RestaurantFile, System.Text.Encoding.Default)
                                  .Skip(1)
                                  .Select(l => l.Split(";"))
                                  .Select(d => new
                                  {
                                      Id = d[0],
                                      Restaurant = new Restaurant
                                      {
                                          Email = $"restaurant-{d[0]}@gmx.at",
                                          DisplayName = d[1],
                                          UniqueName = d[2],
                                          OwnerName = d[3],
                                          AddressStreet = d[4],
                                          AddressHousenumber = d[5],
                                          AddressZipcode = d[6],
                                          AddressCity = d[7],
                                          State = (Logic.Modules.Common.RestaurantState)Int32.Parse(d[8])
                                      }
                                  });
            var openings = File.ReadLines(OpeningHourFile, System.Text.Encoding.Default)
                                .Skip(1)
                                .Select(l => l.Split(";"))
                                .Select(d => new
                                {
                                    Id = d[0],
                                    RestaurantId = d[1],
                                    OpeningHour = new OpeningHour
                                    {
                                        Weekday = (Logic.Modules.Common.Weekday)Int32.Parse(d[2]),
                                        OpenFrom = TimeSpan.Parse(d[3]),
                                        OpenTo = TimeSpan.Parse(d[4]),
                                        Notes = d[5],
                                        IsActive = d[6] == "1" ? true : false,
                                    }
                                });

            var entities = new List<Restaurant>();

            foreach (var item in restaurants)
            {
                var entity = item.Restaurant;

                entity.OpeningHours.AddRange(openings.Where(e => e.RestaurantId == item.Id).Select(e => e.OpeningHour));
                entities.Add(entity);
            }

            await restaurantCtrl.InsertAsync(entities);
            await restaurantCtrl.SaveChangesAsync();

            return entities.ToArray();
        }
    }
}
