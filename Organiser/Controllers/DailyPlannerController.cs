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

        public ViewResult Edit(int eventId, string typeEvent)
        {
            ViewBag.Title = "Редактирование";
            return View(eventsRepository.Events.FirstOrDefault(x => x.EventID == eventId && x.TypeEvent == typeEvent));
        }

        public ViewResult Create(string typeEvent)
        {
            ViewBag.Title = "Создание";
            if (typeEvent == "Дело")
                return View(nameof(Edit), new Case());
            else if (typeEvent == "Встреча")
                return View(nameof(Edit), new Meet());
            else if (typeEvent == "Памятка")
                return View(nameof(Edit), new Reminder());
            else
                return View("Error", "Не найден тип!");
        }

        [HttpPost]
        public RedirectResult Delete(int eventId, string typeEvent, string returnUrl)
        {
            var deteleEntry = eventsRepository.DeleteEvent(eventId, typeEvent);

            if (deteleEntry != null)
            {
                TempData["Message"] = string.Format("{0}: {1} была удалена!", deteleEntry.TypeEvent, deteleEntry.Subject);
            }

            return Redirect(returnUrl);
        }

        [HttpPost]
        public IActionResult EditCase(Case @case)
        {
            return EditEvent(@case);
        }

        [HttpPost]
        public IActionResult EditMeet(Meet meet)
        {
            return EditEvent(meet);
        }

        [HttpPost]
        public IActionResult EditReminder(Reminder reminder)
        {
            return EditEvent(reminder);
        }

        private IActionResult EditEvent(IEvent ev)
        {
            if (ModelState.IsValid)
            {
                if (ev is Meet meet)
                    eventsRepository.SaveEvent(meet);
                if (ev is Case @case)
                    eventsRepository.SaveEvent(@case);
                if (ev is Reminder reminder)
                    eventsRepository.SaveEvent(reminder);

                TempData["message"] = string.Format("{0}: {1} была сохранена", ev.TypeEvent, ev.Subject);
                
                return RedirectToAction(nameof(List));
            }
            else
            {
                return View(nameof(Edit));
            }
        }
    }
}