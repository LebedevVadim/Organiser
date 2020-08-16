using Microsoft.AspNetCore.Mvc;
using Organiser.Models;
using Organiser.Models.DailyPlanner;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Organiser.Components
{
    public class DayModeViewComponent : ViewComponent
    {
        private readonly Dictionary<DateTime, IEnumerable<IEvent>> listView; 

        public DayModeViewComponent()
        {
            listView = new Dictionary<DateTime, IEnumerable<IEvent>>();
        }

        public IViewComponentResult Invoke(IEnumerable<IEvent> events)
        {
            SetListView(events);
            return View(listView);
        }

        private void SetListView(IEnumerable<IEvent> events)
        {
            var uniqDays = events.Select(x => x.BeginDate.Value.Date).Distinct().OrderBy(x => x);
            
            var tmpList = new List<IEvent>();

            foreach (var uDay in uniqDays)
            {
                tmpList = events.Where(x => x.BeginDate.Value.Date == uDay.Date).ToList();
                listView[uDay] = tmpList.OrderBy(x => x.BeginDate);
            }
        }
    }
}
