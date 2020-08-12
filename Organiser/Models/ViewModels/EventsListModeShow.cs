using Organiser.Models.DailyPlanner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organiser.Models.ViewModels
{
    public class EventsListModeShow
    {
        public ModeShow ModesShow { get; } = new ModeShow();

        public IEnumerable<IEvent> Events { get; set; }

        public ModeShowEnum CurrentModeShow { get; set; } = ModeShowEnum.List;
    }
}
