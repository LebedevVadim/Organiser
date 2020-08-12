using Microsoft.AspNetCore.Mvc;
using Organiser.Models;
using Organiser.Models.DailyPlanner;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Organiser.Components
{
    public class WeekModeViewComponent : ViewComponent
    {
        private readonly IEventsRepository eventsRepository;

        private readonly Dictionary<Week, IEnumerable<IEvent>> listView;

        public WeekModeViewComponent(IEventsRepository repository)
        {
            eventsRepository = repository;

            listView = new Dictionary<Week, IEnumerable<IEvent>>();
        }

        public IViewComponentResult Invoke()
        {
            SetListView();
            return View(listView);
        }

        private void SetListView()
        {
            var uniqWeek = eventsRepository.Events.Select(x => new Week { BeginWeek = x.BeginDate, EndWeek = x.BeginDate.AddDays(7) }).Distinct().OrderBy(x => x.BeginWeek);

            var tmpList = new List<IEvent>();

            foreach (var uWeek in uniqWeek)
            {
                tmpList = eventsRepository.Events.Where(x => x.BeginDate.Date >= uWeek.BeginWeek.Date && x.BeginDate.Date <= uWeek.EndWeek.Date).ToList();
                listView[uWeek] = tmpList;
            }
        }
    }

    public struct Week
    {
        public DateTime BeginWeek { get; set; }

        public DateTime EndWeek { get; set; }
    }
}
