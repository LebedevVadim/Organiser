using Microsoft.AspNetCore.Mvc;
using Organiser.Models;
using Organiser.Models.DailyPlanner;
using System.Collections.Generic;
using System.Linq;

namespace Organiser.Components
{
    public class ListModeViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IEnumerable<IEvent> events)
        {
            return View(events.OrderBy(x => x.BeginDate));
        }
    }
}
