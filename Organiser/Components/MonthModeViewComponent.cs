using Microsoft.AspNetCore.Mvc;
using Organiser.Models;
using System;
using System.Linq;

namespace Organiser.Components
{
    public class MonthModeViewComponent : ViewComponent
    {
        private IEventsRepository eventsRepository;

        public MonthModeViewComponent(IEventsRepository repository)
        {
            eventsRepository = repository;
        }

        public IViewComponentResult Invoke()
        {
            return View(eventsRepository.Events.Where(x => x.BeginDate.Date >= DateTime.Now.Date && x.BeginDate.Date <= DateTime.Now.Date.AddMonths(1)).OrderBy(x => x.BeginDate));
        }
    }
}
