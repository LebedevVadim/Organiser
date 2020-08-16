using Organiser.Models.DailyPlanner;
using System.Collections.Generic;
using Organiser.Models.Constants;
using System;

namespace Organiser.Models.ViewModels
{
    public class EventsListModeShow
    {
        public ModeShow ModesShow { get; } = new ModeShow();

        public IEnumerable<IEvent> Events { get; set; }

        public ModeShowEnum CurrentModeShow { get; set; } = ModeShowEnum.List;
    }
}
