using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organiser.Models.DailyPlanner
{
    public class Meet : IEvent
    {
        public string TypeEvent => "Встреча";
        public string Subject { get; set; }
        public string Place { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
