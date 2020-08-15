using Organiser.Models.DailyPlanner;
using System.Collections.Generic;

namespace Organiser.Models
{
    public interface IEventsRepository
    {
        IEnumerable<IEvent> Events { get; }

        IEvent DeleteEvent(int eventId, string typeEvent);

        void SaveEvent(Meet meet);
        void SaveEvent(Case @case);
        void SaveEvent(Reminder reminder);

    }
}
