using Microsoft.AspNetCore.Mvc;
using Organiser.Models;
using Organiser.Models.DailyPlanner;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Organiser.Components
{
    public class MonthModeViewComponent : ViewComponent
    {
        private readonly IEventsRepository eventsRepository;

        private readonly Dictionary<DateTime, IEnumerable<IEvent>> listView;

        public MonthModeViewComponent(IEventsRepository repository)
        {
            eventsRepository = repository;
            listView = new Dictionary<DateTime, IEnumerable<IEvent>>();
        }

        public IViewComponentResult Invoke()
        {
            SetListView();
            return View(listView);
        }

        private void SetListView()
        {
            var uniqMonth = eventsRepository.Events.Select(x => new { Month = x.BeginDate.Month, Year = x.BeginDate.Year }).Distinct().OrderBy(x => x.Month);
            var tmpList = new List<IEvent>();

            foreach (var uMonth in uniqMonth)
            {
                tmpList = eventsRepository.Events.Where(x => x.BeginDate.Month == uMonth.Month).ToList();
                listView[new DateTime(uMonth.Year, uMonth.Month, 01)] = tmpList;
            }
        }
    }
}
