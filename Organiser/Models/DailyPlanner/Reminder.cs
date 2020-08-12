using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organiser.Models.DailyPlanner
{
    public class Reminder : IEvent
    {
        public string TypeEvent => "Памятка";
        public string Subject { get; set; }
        public DateTime BeginDate { get; set; }
    }
}
