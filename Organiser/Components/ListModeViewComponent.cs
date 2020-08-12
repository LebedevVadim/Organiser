using Microsoft.AspNetCore.Mvc;
using Organiser.Models;
using System.Linq;

namespace Organiser.Components
{
    public class ListModeViewComponent : ViewComponent
    {
        IEventsRepository eventsRepository;

        public ListModeViewComponent(IEventsRepository repository)
        {
            eventsRepository = repository;
        }

        public IViewComponentResult Invoke()
        {
            return View(eventsRepository.Events.OrderBy(x => x.BeginDate));
        }
    }
}
