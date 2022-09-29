using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using QTHungryDogs.Logic.Entities.App;
using QTHungryDogs.Logic.Entities.Base;
using QTHungryDogs.Logic.Models.OpeningState;
using QTHungryDogs.Logic.Modules.Common;

namespace QTHungryDogs.Logic.Modules.OpeningState
{
    internal class OpeningStatesCreator
    {
        public static IEnumerable<FromToTime> Split(IEnumerable<FromToTime> timeTable)
        {
            var result = new List<FromToTime>();

            foreach (var item in timeTable)
            {
                if (item.From.GetDayStamp() == item.To.GetDayStamp())
                {
                    result.Add(item);
                }
                else
                {
                    var run = new FromToTime { From = item.From, To = CreateDate(item.From, 23, 59, 59), State = item.State };

                    while (run.From.GetDayStamp() < item.To.GetDayStamp())
                    {
                        result.Add(run);
                        run = new FromToTime { From = CreateDate(run.From.AddDays(1), 0, 0, 0), To = item.To, State = item.State };

                        if (run.From.GetDayStamp() < item.To.GetDayStamp())
                        {
                            run.To = CreateDate(run.From, 23, 59, 59);
                        }
                        result.Add(run);
                    }
                }
            }
            return result;
        }
        public static IEnumerable<FromToTime> Expand(IEnumerable<FromToTime> timeTable)
        {
            var expandTable = new List<FromToTime>();
            var orderdTimeTable = new List<FromToTime>(timeTable.OrderBy(e => e.FromDateSecondStamp));
            var firstItem = orderdTimeTable.FirstOrDefault();

            if (firstItem != null && firstItem.From.GetTimeSecondStamp() > 0)
            {
                expandTable.Add(new FromToTime
                {
                    From = CreateDate(firstItem.From, 0, 0, 0),
                    To = firstItem.From.AddSeconds(-1),
                    State = OpenState.Closed,
                });
            }

            for (int i = 0; i < orderdTimeTable.Count - 1; i++)
            {
                var curItem = orderdTimeTable[i];
                var nxtItem = orderdTimeTable[i + 1];

                if ((curItem.State & OpenState.OpenState) > 0
                    && curItem.ToDateSecondStamp > nxtItem.ToDateSecondStamp)
                {
                    expandTable.Add(new FromToTime
                    {
                        From = nxtItem.To.AddSeconds(1),
                        To = curItem.To,
                        State = curItem.State,
                    });
                }
                else if ((curItem.State & OpenState.OpenState) > 0
                         && (nxtItem.State & OpenState.OpenState) > 0
                         && curItem.ToDateSecondStamp < nxtItem.FromDateSecondStamp)
                {
                    expandTable.Add(new FromToTime
                    {
                        From = curItem.To.AddSeconds(1),
                        To = nxtItem.From.AddSeconds(-1),
                        State = OpenState.Closed,
                    });
                    expandTable.Add(curItem);
                }
                else
                {
                    expandTable.Add(curItem);
                }
            }
            MoveFromTimeToBottom(expandTable, OpenState.ClosedState, OpenState.OpenState);
            MoveToTimeToTop(expandTable, OpenState.ClosedState, OpenState.OpenState);
            MoveFromTimeToBottom(expandTable, OpenState.OpenState, OpenState.OpenState);
            MoveToTimeToTop(expandTable, OpenState.OpenState, OpenState.OpenState);

            return Split(expandTable.Where(e => e.ToDateSecondStamp > e.FromDateSecondStamp));
        }
        public static IEnumerable<FromToTime> Fillup(IEnumerable<FromToTime> timeTable)
        {
            var result = new List<FromToTime>();
            var source = new List<FromToTime>(timeTable.OrderBy(e => e.FromDateSecondStamp));
            var checkItem = source.FirstOrDefault();

            if (checkItem != null && CreateDate(checkItem.From, 0, 0, 0).GetDateSecondStamp() < checkItem.FromDateSecondStamp)
            {
                var item = new FromToTime
                {
                    From = CreateDate(checkItem.From, 0, 0, 0),
                    To = checkItem.From.AddSeconds(-1),
                    State = OpenState.NoDefinition,
                };
                result.Add(item);
            }

            foreach (var curItem in source)
            {
                var lastItem = result.LastOrDefault();

                if (lastItem != null && (lastItem.To.AddSeconds(1)).GetDateSecondStamp() < curItem.From.GetDateSecondStamp())
                {
                    var item = new FromToTime
                    {
                        From = lastItem.To.AddSeconds(1),
                        To = curItem.From.AddSeconds(-1),
                        State = (lastItem.State & OpenState.OpenState) > 0 ? OpenState.Closed : OpenState.Open,
                    };
                    result.Add(item);
                }
                result.Add(curItem);
            }

            checkItem = result.LastOrDefault();

            if (checkItem != null)
            {
                if (checkItem.ToDateSecondStamp < CreateDate(checkItem.To, 23, 59, 59).GetDateSecondStamp())
                {
                    var item = new FromToTime
                    {
                        From = checkItem.To.AddSeconds(1),
                        To = CreateDate(checkItem.To, 23, 59, 59),
                        State = (checkItem.State & OpenState.OpenState) > 0 ? OpenState.Closed : OpenState.Open,
                    };
                    result.Add(item);
                }
            }
            return result.Where(e => e.ToDateSecondStamp - e.FromDateSecondStamp > 0).OrderBy(e => e.FromDateSecondStamp);
        }

        public static void MoveFromTimeToBottom(IEnumerable<FromToTime> timeTable, OpenState curState, OpenState prvState)
        {
            var count = timeTable.Count();

            for (int i = count - 1; i > 0; i--)
            {
                var curItem = timeTable.ElementAt(i);

                if ((curItem.State & curState) > 0)
                {
                    for (int j = i - 1; j >= 0; j--)
                    {
                        var prvItem = timeTable.ElementAt(j);

                        if ((prvItem.State & prvState) > 0
                            && curItem.FromDateSecondStamp <= prvItem.ToDateSecondStamp)
                        {
                            prvItem.To = curItem.From.AddSeconds(-1);
                        }
                    }
                }
            }
        }
        public static void MoveToTimeToTop(IEnumerable<FromToTime> timeTable, OpenState curState, OpenState nxtState)
        {
            var count = timeTable.Count();

            for (int i = 0; i < count - 1; i++)
            {
                var cur = timeTable.ElementAt(i);

                if ((cur.State & curState) > 0)
                {
                    for (int j = i + 1; j < count; j++)
                    {
                        var nxtItem = timeTable.ElementAt(j);

                        if ((nxtItem.State & nxtState) > 0
                            && cur.ToDateSecondStamp >= nxtItem.FromDateSecondStamp)
                        {
                            nxtItem.From = IsLastDayTime(cur.To) ? cur.To : cur.To.AddSeconds(1);
                        }
                    }
                }
            }
        }
        public static IEnumerable<FromToTime> Merge(IEnumerable<FromToTime> timeTable, OpenState state)
        {
            var result = new List<FromToTime>();

            foreach (var curItem in timeTable)
            {
                var lastItem = result.LastOrDefault();

                if (lastItem != null
                    && ((lastItem.State & state) > 0 && (curItem.State & state) > 0)
                    && (lastItem.To.AddSeconds(1).GetDateSecondStamp() == curItem.From.GetDateSecondStamp()))
                {
                    lastItem.To = curItem.To;
                }
                else
                {
                    var item = new FromToTime
                    {
                        From = curItem.From,
                        To = curItem.To,
                        State = curItem.State,
                    };
                    result.Add(item);
                }
            }
            return result;
        }

        public static bool IsLastDayTime(DateTime date)
        {
            return date.Hour == 23 && date.Minute == 59 && date.Second == 59;
        }

        public static DateTime CreateDate(DateTime date, int hour, int minute, int second)
                                            => new(date.Year, date.Month, date.Day, hour, minute, second);
        public static (DateTime from, DateTime to) CreateWeekRange(DateTime date)
                                            => (CreateDate(date.AddDays(DayOfWeek.Sunday - date.DayOfWeek), 0, 0, 0),
                                                CreateDate(date.AddDays(DayOfWeek.Saturday - date.DayOfWeek), 23, 59, 59));
        public static (DateTime from, DateTime to) CreateWeekRangeAt(DateTime date)
                                            => (CreateDate(date, 0, 0, 0),
                                                CreateDate(date.AddDays(7), 23, 59, 59));

        public static OpenState GetOpenState(Restaurant restaurant, DateTime date)
        {
            var result = OpenState.NoDefinition;
            var dateStamp = date.GetDateSecondStamp();

            if (restaurant.State == RestaurantState.InActive)
            {
                result = OpenState.Closed;
            }
            else if (restaurant.State == RestaurantState.Closed)
            {
                result = OpenState.Closed;
            }
            else if (restaurant.SpecialOpeningHours.FirstOrDefault(e => e.State == OpenState.IsBusy && e.To.HasValue && e.From.GetDateSecondStamp() <= dateStamp && dateStamp <= e.To.Value.GetDateSecondStamp()) != null)
            {
                //var specialOpening = restaurant.SpecialOpeningHours.FirstOrDefault(e => e.From.GetDateSecondStamp() <= date.GetDateSecondStamp() && e.To.HasValue == false && e.State == OpenState.ClosedPermanent);

                result = OpenState.ClosedPermanent;
            }
            else if (restaurant.SpecialOpeningHours.FirstOrDefault(e => e.State == OpenState.ClosedPermanent && e.From.GetDateSecondStamp() <= dateStamp && (e.To.HasValue == false || dateStamp <= e.To.Value.GetDateSecondStamp())) != null)
            {
                //var specialOpening = restaurant.SpecialOpeningHours.FirstOrDefault(e => e.From.GetDateSecondStamp() <= date.GetDateSecondStamp() && e.To.HasValue == false && e.State == OpenState.ClosedPermanent);

                result = OpenState.ClosedPermanent;
            }
            else
            {
                var fromToOpenStates = OpeningStatesCreator.CreateDayOpeningStates(restaurant.OpeningHours, restaurant.SpecialOpeningHours, date);
                var fromToOpenState = fromToOpenStates.FirstOrDefault(e => e.IsBetween(date));

                if (fromToOpenState != null)
                {
                    result = fromToOpenState.State;
                }
            }
            return result;
        }
        public static IEnumerable<FromToTime> CreateDayOpeningStates(IEnumerable<OpeningHour> openingHours, IEnumerable<SpecialOpeningHour> specialOpeningHours, DateTime date)
        {
            var dayStamp = date.GetDayStamp();
            var result = CreateFromToOpeningStates(openingHours, specialOpeningHours, date.AddDays(-1), date.AddDays(1));

            return result.Where(e => e.From.GetDayStamp() >= dayStamp && dayStamp <= e.To.GetDayStamp());
        }
        public static IEnumerable<FromToTime> CreateWeekOpeningStates(IEnumerable<OpeningHour> openingHours, IEnumerable<SpecialOpeningHour> specialOpeningHours, DateTime date)
        {
            var (from, to) = OpeningStatesCreator.CreateWeekRangeAt(date);
            var result = CreateFromToOpeningStates(openingHours, specialOpeningHours, from.AddDays(-1), to.AddDays(1));

            return result.Where(e => e.IsBetween(from) || e.IsBetween(to));
        }
        public static IEnumerable<FromToTime> CreateFromToOpeningStates(IEnumerable<OpeningHour> openingHours, IEnumerable<SpecialOpeningHour> specialOpeningHours, DateTime from, DateTime to)
        {
            var result = new List<FromToTime>();

            result.AddRange(CreateOpeningStates(openingHours, from, to));
            result.AddRange(CreateOpeningStates(specialOpeningHours, from, to));
            result.AddRange(OpeningStatesCreator.Expand(result.Eject()));
            result.AddRange(OpeningStatesCreator.Fillup(result.Eject()));

            if (result.Any() == false)
            {
                if (result.Count == 0)
                {
                    result.Add(new FromToTime
                    {
                        From = OpeningStatesCreator.CreateDate(from, 0, 0, 0),
                        To = OpeningStatesCreator.CreateDate(from, 23, 59, 59),
                        State = OpenState.NoDefinition,
                    });
                }
            }
            return result;
        }
        private static IEnumerable<FromToTime> CreateOpeningStates(IEnumerable<OpeningHour> openingHours, DateTime from, DateTime to)
        {
            var result = new List<FromToTime>();
            var runFrom = OpeningStatesCreator.CreateDate(from, 0, 0, 0);
            var runTo = OpeningStatesCreator.CreateDate(to, 23, 59, 59);
            var run = runFrom;

            while (run <= runTo)
            {
                foreach (var item in openingHours.Where(e => (int)e.Weekday == (int)run.DayOfWeek && e.IsActive == true)
                                                 .OrderBy(e => e.OpenFrom))
                {
                    var fromToTime = default(FromToTime);

                    if (item.OpenFrom.GetTimeSecondStamp() < item.OpenTo.GetTimeSecondStamp())
                    {
                        fromToTime = new FromToTime
                        {
                            From = OpeningStatesCreator.CreateDate(run, item.OpenFrom.Hours, item.OpenFrom.Minutes, item.OpenFrom.Seconds),
                            To = OpeningStatesCreator.CreateDate(run, item.OpenTo.Hours, item.OpenTo.Minutes, item.OpenTo.Seconds),
                            State = OpenState.Open,
                        };
                    }
                    else
                    {
                        var nextDay = run.AddDays(1);

                        fromToTime = new FromToTime
                        {
                            From = OpeningStatesCreator.CreateDate(run, item.OpenFrom.Hours, item.OpenFrom.Minutes, item.OpenFrom.Seconds),
                            To = OpeningStatesCreator.CreateDate(nextDay, item.OpenTo.Hours, item.OpenTo.Minutes, item.OpenTo.Seconds),
                            State = OpenState.Open,
                        };
                    }
                    if (result.Any(e => e.IsEquals(fromToTime)) == false)
                    {
                        result.Add(fromToTime);
                    }
                }
                run = run.AddDays(1);
            }
            return result;
        }
        private static IEnumerable<FromToTime> CreateOpeningStates(IEnumerable<SpecialOpeningHour> specialOpeningHours, DateTime from, DateTime to)
        {
            var result = new List<FromToTime>();
            var run = CreateDate(from, 0, 0, 0);
            var runTo = CreateDate(to, 23, 59, 59);
            var openState = OpenState.NoDefinition;

            while (run <= runTo)
            {
                var dayStamp = run.GetDayStamp();

                if (openState == OpenState.ClosedPermanent)
                {
                    result.Add(new FromToTime
                    {
                        From = run,
                        To = CreateDate(run, 23, 59, 59),
                        State = openState,
                    });
                }

                foreach (var item in specialOpeningHours.Where(e => e.From.GetDayStamp() == dayStamp)
                                                        .OrderBy(e => e.From))
                {
                    if (openState != OpenState.ClosedPermanent)
                    {
                        result.Add(new FromToTime
                        {
                            From = item.From,
                            To = item.To ?? CreateDate(run, 23, 59, 59),
                            State = item.State
                        });
                    }

                    if (item.State == OpenState.ClosedPermanent && item.To.HasValue== false)
                    {
                        openState = OpenState.ClosedPermanent;
                    }
                }
                run = run.AddDays(1);
            }
            return result;
        }
    }
}
