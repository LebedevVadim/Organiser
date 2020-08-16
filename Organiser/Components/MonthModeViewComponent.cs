using Microsoft.AspNetCore.Mvc;
using Organiser.Models.DailyPlanner;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Organiser.Components
{
    public class MonthModeViewComponent : ViewComponent
    {
        private readonly Dictionary<DateTime, IEnumerable<IEvent>> listView;

        public MonthModeViewComponent()
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
            var uniqMonth = events.Select(x => new { Month = x.BeginDate.Value.Month, Year = x.BeginDate.Value.Year }).Distinct().OrderBy(x => x.Month);
            var tmpList = new List<IEvent>();

            foreach (var uMonth in uniqMonth)
            {
                tmpList = events.Where(x => x.BeginDate.Value.Month == uMonth.Month).ToList();
                listView[new DateTime(uMonth.Year, uMonth.Month, 01)] = tmpList.OrderBy(x => x.BeginDate);
            }
        }
    }
}
