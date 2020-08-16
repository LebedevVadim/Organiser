using Microsoft.EntityFrameworkCore;
using Organiser.Models.DailyPlanner;
using System.Collections.Generic;
using System.Linq;

namespace Organiser.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Case> Cases { get; set; }

        public DbSet<Meet> Meets { get; set; }

        public DbSet<Reminder> Reminders { get; set; }

        public IEnumerable<IEvent> Events
        {
            get
            {
                var list = new List<IEvent>();
                list.AddRange(Cases);
                list.AddRange(Meets);
                list.AddRange(Reminders);
                return list;
            }
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
