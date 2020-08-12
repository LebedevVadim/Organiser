using Microsoft.AspNetCore.Mvc;
using Organiser.Models;
using System;
using System.Linq;

namespace Organiser.Components
{
    public class DayModeViewComponent : ViewComponent
    {
        IEventsRepository eventsRepository;

        public DayModeViewComponent(IEventsRepository repository)
        {
            eventsRepository = repository;
        }

        public IViewComponentResult Invoke()
        {
            return View(eventsRepository.Events.Where(x => x.BeginDate.Date == DateTime.Now.Date).OrderBy(x => x.BeginDate));
        }
    }
}
