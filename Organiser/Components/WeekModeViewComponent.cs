using Microsoft.AspNetCore.Mvc;
using Organiser.Models;
using System;
using System.Linq;

namespace Organiser.Components
{
    public class WeekModeViewComponent : ViewComponent
    {
        private readonly IEventsRepository eventsRepository;

        public WeekModeViewComponent(IEventsRepository repository)
        {
            eventsRepository = repository;
        }

        public IViewComponentResult Invoke()
        {
            return View(eventsRepository.Events.Where(x => x.BeginDate.Date >= DateTime.Now.Date && x.BeginDate.Date <= DateTime.Now.Date.AddDays(7)).OrderBy(x => x.BeginDate));
        }
    }
}
