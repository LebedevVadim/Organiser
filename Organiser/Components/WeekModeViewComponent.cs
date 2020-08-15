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
            var uniqWeek = new List<Week>();

            foreach (var e in eventsRepository.Events)
            {
                if (uniqWeek.Any())
                {
                    if (!uniqWeek.Any(x => x.BeginWeek.Date <= e.BeginDate.Date && x.EndWeek.Date >= e.BeginDate.Date))
                        uniqWeek.Add(new Week { BeginWeek = e.BeginDate.Date, EndWeek = e.BeginDate.AddDays(7).Date });
                }
                else
                {
                    uniqWeek.Add(new Week { BeginWeek = e.BeginDate.Date, EndWeek = e.BeginDate.AddDays(7).Date });
                }
            }

            var tmpList = new List<IEvent>();

            foreach (var uWeek in uniqWeek.OrderBy(x => x.BeginWeek))
            {
                tmpList = eventsRepository.Events.Where(x => x.BeginDate.Date >= uWeek.BeginWeek.Date && x.BeginDate.Date <= uWeek.EndWeek.Date).ToList();
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
