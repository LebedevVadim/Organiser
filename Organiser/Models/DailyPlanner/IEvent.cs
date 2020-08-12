using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organiser.Models.DailyPlanner
{
    public interface IEvent
    {
        string TypeEvent { get; }
        string Subject { get; set; }
        DateTime BeginDate { get; set; }
    }
}
