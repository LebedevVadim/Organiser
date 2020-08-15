using Organiser.Models.DailyPlanner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organiser.Models
{
    public class EFEventsRepository : IEventsRepository
    {

        private readonly ApplicationDbContext context;

        public EFEventsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<IEvent> Events => context.Events;

        public IEnumerable<Case> Cases => context.Cases;

        public IEnumerable<Meet> Meets => context.Meets;

        public IEnumerable<Reminder> Reminders => context.Reminders;

        public IEvent DeleteEvent(int eventId, string typeEvent)
        {
            var dbEntry = context.Events.FirstOrDefault(x => x.EventID == eventId && x.TypeEvent == typeEvent);

            if (dbEntry != null)
            {
                if (dbEntry is Case)
                    context.Cases.Remove(dbEntry as Case);
                if (dbEntry is Meet)
                    context.Meets.Remove(dbEntry as Meet);
                if (dbEntry is Reminder)
                    context.Reminders.Remove(dbEntry as Reminder);

                context.SaveChanges();
            }

            return dbEntry;
        }

        public void SaveEvent(Meet meet)
        {
            if (meet.EventID == 0)
            {
                context.Meets.Add(meet);
            }
            else
            {
                var dbEntry = context.Meets.FirstOrDefault(p => p.EventID == meet.EventID);
                if (dbEntry != null)
                {
                    dbEntry.Subject = meet.Subject;
                    dbEntry.Place = meet.Place;
                    dbEntry.EndDate = meet.EndDate;
                    dbEntry.BeginDate = meet.BeginDate;
                }
            }

            context.SaveChanges();
        }

        public void SaveEvent(Case @case)
        {
            if (@case.EventID == 0)
            {
                context.Cases.Add(@case);
            }
            else
            {
                var dbEntry = context.Cases.FirstOrDefault(p => p.EventID == @case.EventID);
                if (dbEntry != null)
                {
                    dbEntry.Subject = @case.Subject;
                    dbEntry.EndDate = @case.EndDate;
                    dbEntry.BeginDate = @case.BeginDate;
                }
            }

            context.SaveChanges();
        }

        public void SaveEvent(Reminder reminder)
        {
            if (reminder.EventID == 0)
            {
                context.Reminders.Add(reminder);
            }
            else
            {
                var dbEntry = context.Reminders.FirstOrDefault(p => p.EventID == reminder.EventID);
                if (dbEntry != null)
                {
                    dbEntry.Subject = reminder.Subject;
                    dbEntry.BeginDate = reminder.BeginDate;
                }
            }

            context.SaveChanges();
        }
    }
}
