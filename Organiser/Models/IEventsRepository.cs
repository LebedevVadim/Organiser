using Organiser.Models.DailyPlanner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organiser.Models
{
    public interface IEventsRepository
    {
       IEnumerable<IEvent> Events { get; }
    }
}
