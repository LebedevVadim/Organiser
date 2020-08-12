using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Organiser.Models;
using Organiser.Models.DailyPlanner;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Organiser.Components
{
    public class DayModeViewComponent : ViewComponent
    {
        private readonly IEventsRepository eventsRepository;

        private Dictionary<DateTime, IEnumerable<IEvent>> listView; 

        public DayModeViewComponent(IEventsRepository repository)
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
            var uniqDays = eventsRepository.Events.Select(x => x.BeginDate).Distinct().OrderBy(x => x);
            
            var tmpList = new List<IEvent>();

            foreach (var uDay in uniqDays)
            {
                tmpList = eventsRepository.Events.Where(x => x.BeginDate.Date == uDay.Date).ToList();
                listView[uDay] = tmpList;
            }
        }
    }
}
