using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Organiser.Models;
using Organiser.Models.Constants;
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
            if (eventId <= 0 || string.IsNullOrEmpty(typeEvent))
                return View("Error", "Что-то пошло не так");

            ViewBag.Title = "Редактирование";
            return View(eventsRepository.Events.FirstOrDefault(x => x.EventID == eventId && x.TypeGuid.ToString() == typeEvent));
        }

        public ViewResult Create(string typeEvent)
        {
            ViewBag.Title = "Создание";
            if (typeEvent == Types.Case.Guid.ToString())
                return View(nameof(Edit), new Case());
            else if (typeEvent == Types.Meet.Guid.ToString())
                return View(nameof(Edit), new Meet());
            else if (typeEvent == Types.Reminder.Guid.ToString())
                return View(nameof(Edit), new Reminder());
            else
                return View("Error", "Не найден тип!");
        }

        [HttpPost]
        public IActionResult Delete(int eventId, string typeEvent, string returnUrl)
        {
            if (eventId <= 0 || string.IsNullOrEmpty(typeEvent) || string.IsNullOrEmpty(returnUrl))
                return View("Error", "Что-то пошло не так");

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

        public ViewResult Filter([FromQuery(Name = "typeGuids")]List<string> typeGuids, string beginDate, string subject, string mode)
        {
            var events = eventsRepository.Events;

            if (typeGuids != null && typeGuids.Any())
            {
                events = events.Where(x => typeGuids.Any(t => t == x.TypeGuid.ToString()));
            }

            if (!string.IsNullOrEmpty(beginDate) && DateTime.TryParse(beginDate, out DateTime date) && !string.IsNullOrEmpty(mode))
            {
                if (mode == Modes.Equally)
                    events = events.Where(x => x.BeginDate == date);
                if (mode == Modes.Less)
                    events = events.Where(x => x.BeginDate <= date);
                if (mode == Modes.More)
                    events = events.Where(x => x.BeginDate >= date);
            }

            if (!string.IsNullOrEmpty(subject))
            {
                events = events.Where(x => x.Subject.Contains(subject));
            }
            return View(nameof(List), new EventsListModeShow { Events = events });
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