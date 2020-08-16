using Organiser.Models.DailyPlanner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organiser.Models
{
    public class FakeEventRepository
    {
        public IEnumerable<IEvent> Events { get; }

        public FakeEventRepository()
        {
            Events = new List<IEvent>
        {
            new Case {Subject = "Тестовое дело", BeginDate = new DateTime(2020, 08, 12, 20, 16, 00), EndDate = new DateTime(2020, 08, 12, 21, 16, 00) },
            new Case {Subject = "Тестовое дело 2", BeginDate = new DateTime(2020, 08, 13, 10, 00, 00), EndDate = new DateTime(2020, 08, 13, 12, 00, 00) },
            new Case {Subject = "Тестовое дело 3", BeginDate = new DateTime(2020, 09, 12, 20, 16, 00), EndDate = new DateTime(2020, 09, 12, 21, 16, 00) },
            new Meet {Subject = "Тестовая встреча", BeginDate = new DateTime(2020, 08, 12, 20, 16, 00), EndDate = new DateTime(2020, 08, 12, 21, 16, 00), Place = "Переговорка №1" },
            new Meet {Subject = "Тестовая встреча 2", BeginDate = new DateTime(2020, 08, 12, 20, 16, 00), EndDate = new DateTime(2020, 08, 12, 21, 16, 00), Place = "Переговорка №1" },
            new Meet {Subject = "Тестовая встреча 3", BeginDate = new DateTime(2020, 08, 12, 20, 16, 00), EndDate = new DateTime(2020, 08, 12, 21, 16, 00), Place = "Переговорка №1" },
            new Reminder {Subject = "Тестовая памятка", BeginDate = new DateTime(2020, 08, 12, 20, 16, 00)},
            new Reminder {Subject = "Тестовая памятка 2", BeginDate = new DateTime(2020, 08, 12, 20, 16, 00)}
        };
        }
    }
}
