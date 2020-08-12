using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organiser.Models.DailyPlanner
{
    public class Case : IEvent
    {
        public string TypeEvent => "Дело";
        public string Subject { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
