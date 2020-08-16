using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organiser.Models.Constants
{
    public static class Types
    {
        public static TypeEvent Case => new TypeEvent { Guid = new Guid("37103ce2-e316-4973-b7fa-0f714c221f57"), TypeName = "Дело"};

        public static TypeEvent Meet => new TypeEvent { Guid = new Guid("6c9ba035-0c14-46a9-adc9-7f5e9a718025"), TypeName = "Встреча" };

        public static TypeEvent Reminder => new TypeEvent { Guid = new Guid("398cd1eb-da43-419c-98ab-c38149f80290"), TypeName = "Памятка" };
    }

    public struct TypeEvent
    {
        public Guid Guid { get; set; }

        public string TypeName { get; set; }
    }
}
