using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Organiser.Models;
using Organiser.Models.DailyPlanner;
using Organiser.Models.ViewModels;

namespace Organiser.Controllers
{
    public class DailyPlannerController : Controller
    {
        private readonly IEventsRepository eventsRepository;
        public DailyPlannerController(IEventsRepository repository)
        {
            eventsRepository = repository;
        }

        public ViewResult List() => View(new EventsListModeShow() { Events = eventsRepository.Events });

        public ViewResult ModeShow(string value)
        {
            ModeShowEnum mode;
            if (Enum.TryParse(value, out mode))
                return View("List", new EventsListModeShow() { CurrentModeShow = mode, Events = eventsRepository.Events });
            else
                return View("Error", "Не удалось найти режим вывода!");
        }
    }
}