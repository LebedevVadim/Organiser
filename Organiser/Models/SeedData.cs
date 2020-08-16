using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Organiser.Models.DailyPlanner;
using System;
using System.Linq;

namespace Organiser.Models
{
    public class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            if (!context.Events.Any())
            {
                context.AddRange(
                    new Case
                    {
                        Subject = "Распечатать бумаги начальнику",
                        BeginDate = new DateTime(2020, 08, 17, 12, 00, 00),
                        EndDate = new DateTime(2020, 08, 17, 13, 00, 00)
                    },
                    new Case
                    {
                        Subject = "Исправить недочеты в коде",
                        BeginDate = new DateTime(2020, 08, 17, 14, 00, 00),
                        EndDate = new DateTime(2020, 08, 17, 17, 00, 00)
                    },
                    new Case
                    {
                        Subject = "Подговить документацию к встрече",
                        BeginDate = new DateTime(2020, 09, 17, 14, 00, 00),
                        EndDate = new DateTime(2020, 09, 17, 17, 00, 00)
                    },
                    new Case
                    {
                        Subject = "Поменять воду в кулере",
                        BeginDate = new DateTime(2020, 08, 17, 09, 00, 00),
                        EndDate = new DateTime(2020, 08, 17, 09, 30, 00)
                    },
                    new Meet
                    { 
                        Subject = "Летучка с командой",
                        BeginDate = new DateTime(2020, 08, 17, 13, 00, 00),
                        EndDate = new DateTime(2020, 08, 17, 14, 30, 00),
                        Place = "Переговорка № 100"
                    },
                     new Meet
                     {
                         Subject = "Встреча с заказчиком",
                         BeginDate = new DateTime(2020, 08, 25, 13, 00, 00),
                         EndDate = new DateTime(2020, 08, 25, 14, 30, 00),
                         Place = "Переговорка № 3"
                     },
                      new Meet
                      {
                          Subject = "Демо",
                          BeginDate = new DateTime(2020, 10, 01, 10, 00, 00),
                          EndDate = new DateTime(2020, 10, 01, 14, 30, 00),
                          Place = "Переговорка № 101"
                      },
                      new Reminder
                      { 
                        Subject = "Не забыть отправить почту",
                        BeginDate = new DateTime(2020, 10, 03, 16, 00, 00)
                      }
                    );
                context.SaveChanges();
            }
        }
    }
}
