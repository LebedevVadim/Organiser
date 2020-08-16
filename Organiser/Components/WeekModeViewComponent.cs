using Microsoft.AspNetCore.Mvc;
using Organiser.Models.DailyPlanner;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Organiser.Components
{
    public class WeekModeViewComponent : ViewComponent
    {
        private readonly Dictionary<Week, IEnumerable<IEvent>> listView;

        public WeekModeViewComponent()
        {
            listView = new Dictionary<Week, IEnumerable<IEvent>>();
        }

        public IViewComponentResult Invoke(IEnumerable<IEvent> events)
        {
            SetListView(events);
            return View(listView);
        }

        private void SetListView(IEnumerable<IEvent> events)
        {
            var uniqWeek = new List<Week>();

            foreach (var e in events)
            {
                if (uniqWeek.Any())
                {
                    if (!uniqWeek.Any(x => x.BeginWeek.Date <= e.BeginDate.Value.Date && x.EndWeek.Date >= e.BeginDate.Value.Date))
                        uniqWeek.Add(new Week { BeginWeek = e.BeginDate.Value.Date, EndWeek = e.BeginDate.Value.AddDays(7).Date });
                }
                else
                {
                    uniqWeek.Add(new Week { BeginWeek = e.BeginDate.Value.Date, EndWeek = e.BeginDate.Value.AddDays(7).Date });
                }
            }

            var tmpList = new List<IEvent>();

            foreach (var uWeek in uniqWeek.OrderBy(x => x.BeginWeek))
            {
                tmpList = events.Where(x => x.BeginDate.Value.Date >= uWeek.BeginWeek.Date && x.BeginDate.Value.Date <= uWeek.EndWeek.Date).ToList();
                listView[uWeek] = tmpList.OrderBy(x => x.BeginDate);
            }
        }
    }

    public struct Week
    {
        public DateTime BeginWeek { get; set; }

        public DateTime EndWeek { get; set; }
    }
}
