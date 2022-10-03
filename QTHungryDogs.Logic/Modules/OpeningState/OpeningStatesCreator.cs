using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using QTHungryDogs.Logic.Entities.App;
using QTHungryDogs.Logic.Entities.Base;
using QTHungryDogs.Logic.Models.OpeningState;
using QTHungryDogs.Logic.Modules.Common;

namespace QTHungryDogs.Logic.Modules.OpeningState
{
    internal class OpeningStatesCreator
    {
        public static IEnumerable<FromToTime> FillupTimeTable(IEnumerable<FromToTime> timeTable, DateTime from, DateTime to)
        {
            var result = new List<FromToTime>(timeTable);
            var run = CreateDate(from, 0, 0, 0);
            var runTo = CreateDate(to, 23, 59, 59);

            while (run <= runTo)
            {
                var dayStamp = run.GetDayStamp();

                if (result.Any(e => e.From.GetDayStamp() == dayStamp) == false)
                {
                    result.Add(new FromToTime
                    {
                        From = CreateDate(run, 0, 0, 0),
                        To = CreateDate(run, 23, 59, 59),
                        State = OpenState.Closed,
                    });
                }
                run = run.AddDays(1);
            }
            return result.OrderBy(e => e.From);
        }
        public static IEnumerable<FromToTime> ExpandTimeTable(IEnumerable<FromToTime> timeTable)
        {
            var result = new List<FromToTime>();
            var orderedTimeTable = new List<FromToTime>(timeTable.OrderBy(e => e.From));
            var item = orderedTimeTable.FirstOrDefault();

            if (item != null && item.From.GetTimeSecondStamp() > 0)
            {
                result.Add(new FromToTime
                {
                    From = CreateDate(item.From, 0, 0, 0),
                    To = item.From.AddSeconds(-1),
                    State = OpenState.Closed,
                });
            }

            if (orderedTimeTable.Count < 2)
            {
                result.AddRange(orderedTimeTable);
            }
            else
            {
                var curItem = default(FromToTime);
                var nxtItem = default(FromToTime);

                for (int i = 0; i < orderedTimeTable.Count - 1; i++)
                {
                    curItem = orderedTimeTable[i];
                    nxtItem = orderedTimeTable[i + 1];

                    result.Add(curItem);

                    if (curItem.To.AddSeconds(1).GetDateSecondStamp() < nxtItem.From.GetDateSecondStamp())
                    {
                        result.Add(new FromToTime
                        {
                            From = curItem.To.AddSeconds(1),
                            To = nxtItem.From.AddSeconds(-1),
                            State = OpenState.Closed,
                        });
                    }
                }
                if (nxtItem != null && nxtItem.From.GetDateSecondStamp() < nxtItem.To.GetDateSecondStamp())
                {
                    result.Add(nxtItem);
                }
            }

            item = result.LastOrDefault();

            if (item != null)
            {
                if (item.To.GetDateSecondStamp() < CreateDate(item.To, 23, 59, 59).GetDateSecondStamp())
                {
                    result.Add(new FromToTime
                    {
                        From = item.To.AddSeconds(1),
                        To = CreateDate(item.To, 23, 59, 59),
                        State = OpenState.Closed,
                    });
                }
            }

            return result.Where(e => e.To.GetDateSecondStamp() > e.From.GetDateSecondStamp());
        }
        public static IEnumerable<FromToTime> SplitTimeTable(IEnumerable<FromToTime> timeTable)
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
                        run = new FromToTime
                        {
                            From = CreateDate(run.From.AddDays(1), 0, 0, 0),
                            To = item.To,
                            State = item.State
                        };

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
        public static IEnumerable<FromToTime> RemoveOverlaps(IEnumerable<FromToTime> timeTable)
        {
            var result = new List<FromToTime>();
            var orderedTimeTable = new List<FromToTime>(timeTable.OrderBy(e => e.From));

            if (orderedTimeTable.Count < 2)
            {
                result.AddRange(orderedTimeTable);
            }
            else
            {
                var curItem = default(FromToTime);
                var nxtItem = default(FromToTime);

                for (int i = 0; i < orderedTimeTable.Count - 1; i++)
                {
                    curItem = orderedTimeTable[i];
                    nxtItem = orderedTimeTable[i + 1];

                    if (curItem.State == nxtItem.State
                        && curItem.To.GetDateSecondStamp() >= nxtItem.From.GetDateSecondStamp())
                    {
                        result.Add(new FromToTime
                        {
                            From = curItem.From,
                            To = nxtItem.To,
                            State = curItem.State,
                        });
                        i++;
                    }
                    else if ((curItem.State & OpenState.SpecialState) > 0
                        && curItem.To.GetDateSecondStamp() >= nxtItem.From.GetDateSecondStamp())
                    {
                        result.Add(new FromToTime
                        {
                            From = curItem.From,
                            To = nxtItem.From.AddSeconds(-1),
                            State = curItem.State,
                        });
                    }
                    else if ((nxtItem.State & OpenState.SpecialState) > 0
                        && curItem.To.GetDateSecondStamp() >= nxtItem.From.GetDateSecondStamp())
                    {
                        result.Add(new FromToTime
                        {
                            From = curItem.From,
                            To = nxtItem.From.AddSeconds(-1),
                            State = curItem.State,
                        });
                    }
                    else if (curItem.From.GetDateSecondStamp() < curItem.To.GetDateSecondStamp())
                    {
                        result.Add(curItem);
                    }
                }
                if (nxtItem != null && nxtItem.From.GetDateSecondStamp() < nxtItem.To.GetDateSecondStamp())
                {
                    result.Add(nxtItem);
                }
            }
            return result;
        }
        public static IEnumerable<FromToTime> ClearTimeTable(IEnumerable<FromToTime> timeTable)
        {
            var result = new List<FromToTime>();
            var orderedTimeTable = new List<FromToTime>(timeTable.OrderBy(e => e.From));

            if (orderedTimeTable.Count < 2)
            {
                result.AddRange(orderedTimeTable);
            }
            else
            {
                var prvItem = orderedTimeTable.First();

                result.Add(prvItem);
                for (int i = 1; i < orderedTimeTable.Count; i++)
                {
                    var curItem = orderedTimeTable[i];

                    if (curItem.From.GetDateSecondStamp() > prvItem.To.GetDateSecondStamp())
                    {
                        result.Add(curItem);
                    }
                    else if (curItem.To.GetDateSecondStamp() > prvItem.To.GetDateSecondStamp())
                    {
                        result.Add(new FromToTime
                        {
                            From = prvItem.To.AddSeconds(1),
                            To = curItem.To,
                            State = curItem.State,
                        });
                    }
                    prvItem = result.Last(); ;
                }
            }
            return result;
        }

        public static DateTime CreateDate(DateTime date, int hour, int minute, int second)
                                            => new(date.Year, date.Month, date.Day, hour, minute, second);
        public static (DateTime from, DateTime to) CreateWeekRange(DateTime date)
                                            => (CreateDate(date.AddDays(DayOfWeek.Sunday - date.DayOfWeek), 0, 0, 0),
                                                CreateDate(date.AddDays(DayOfWeek.Saturday - date.DayOfWeek), 23, 59, 59));
        public static (DateTime from, DateTime to) CreateWeekRangeAt(DateTime date)
                                            => (CreateDate(date, 0, 0, 0),
                                                CreateDate(date.AddDays(7), 23, 59, 59));

        public static bool IsClosedPermanent(Restaurant restaurant, DateTime date)
        {
            var result = OpenState.NoDefinition;
            var dateStamp = date.GetDateSecondStamp();

            if (restaurant.State == RestaurantState.Closed)
            {
                result = OpenState.ClosedPermanent;
            }
            else if (restaurant.SpecialOpeningHours.FirstOrDefault(e => e.State == OpenState.ClosedPermanent && e.From.GetDateSecondStamp() <= dateStamp && (e.To.HasValue == false || dateStamp <= e.To.Value.GetDateSecondStamp())) != null)
            {
                result = OpenState.ClosedPermanent;
            }
            return result == OpenState.ClosedPermanent;
        }
        public static OpenState GetOpenState(Restaurant restaurant, DateTime date)
        {
            var result = IsClosedPermanent(restaurant, date) ? OpenState.ClosedPermanent : OpenState.NoDefinition;

            if (result != OpenState.ClosedPermanent)
            {
                var dateStamp = date.GetDateSecondStamp();
                var fromToOpenStates = OpeningStatesCreator.CreateDayOpeningStates(restaurant.OpeningHours, restaurant.SpecialOpeningHours, date);
                var fromToOpenState = fromToOpenStates.FirstOrDefault(e => e.IsBetween(date));

                if (fromToOpenState != null)
                {
                    result = fromToOpenState.State;
                }
            }
            return result;
        }
        public static FromToTime CreateClosedPermanentItem(DateTime dateTime)
        {
            return new FromToTime
            {
                From = CreateDate(dateTime, 0, 0, 0),
                To = CreateDate(dateTime, 23, 59, 59),
                State = OpenState.ClosedPermanent,
            };
        }
        public static IEnumerable<FromToTime> CreateDayOpeningStates(IEnumerable<OpeningHour> openingHours, IEnumerable<SpecialOpeningHour> specialOpeningHours, DateTime date)
        {
            var dayStamp = date.GetDayStamp();
            var result = CreateFromToOpeningStates(openingHours, specialOpeningHours, date.AddDays(-1), date.AddDays(1));

            return result.Where(e => e.From.GetDayStamp() <= dayStamp && dayStamp <= e.To.GetDayStamp());
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
            var openingHourStates = RemoveOverlaps(CreateOpeningStates(openingHours, from, to));
            var specialOpeningHourStates = RemoveOverlaps(CreateSpecialOpeningStates(specialOpeningHours, from, to));

            result.AddRange(MergeOpeningStates(openingHourStates, specialOpeningHourStates));
            result.AddRange(FillupTimeTable(result.Eject(), from, to));
            result.AddRange(ExpandTimeTable(result.Eject()));
            result.AddRange(RemoveOverlaps(result.Eject()));
            //result.AddRange(SplitTimeTable(result.Eject()));
            result.AddRange(ClearTimeTable(result.Eject()));

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
        private static IEnumerable<FromToTime> CreateSpecialOpeningStates(IEnumerable<SpecialOpeningHour> specialOpeningHours, DateTime from, DateTime to)
        {
            var result = new List<FromToTime>();
            var run = CreateDate(from, 0, 0, 0);
            var runTo = CreateDate(to, 23, 59, 59);
            var closedPermanent = false;

            while (run <= runTo)
            {
                var dayStamp = run.GetDayStamp();

                if (closedPermanent)
                {
                    result.Add(new FromToTime
                    {
                        From = run,
                        To = CreateDate(run, 23, 59, 59),
                        State = OpenState.ClosedPermanent,
                    });
                }

                foreach (var item in specialOpeningHours.Where(e => e.From.GetDayStamp() == dayStamp)
                                                        .OrderBy(e => e.From))
                {
                    if (closedPermanent == false)
                    {
                        result.Add(new FromToTime
                        {
                            From = item.From,
                            To = item.To ?? CreateDate(run, 23, 59, 59),
                            State = item.State
                        });
                    }

                    if (item.State == OpenState.ClosedPermanent && item.To.HasValue == false)
                    {
                        closedPermanent = true;
                    }
                }
                run = run.AddDays(1);
            }
            return result;
        }
        private static IEnumerable<FromToTime> MergeOpeningStates(IEnumerable<FromToTime> openingHourStates, IEnumerable<FromToTime> specialOpeningHourStates)
        {
            var result = new List<FromToTime>();
            var orderedTimeTable = new List<FromToTime>(openingHourStates.Union(specialOpeningHourStates).OrderBy(e => e.From));

            foreach (var item in orderedTimeTable)
            {
                var last = result.LastOrDefault();

                if (item.State == OpenState.IsBusy
                    && last != null
                    && last.To.GetDateSecondStamp() >= item.From.GetDateSecondStamp())
                {
                    result.Add(item);
                    result.Add(new FromToTime
                    {
                        From = item.To.AddSeconds(1),
                        To = last.To,
                        State = last.State,
                    });
                    last.To = item.From.AddSeconds(-1);
                }
                else
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}
