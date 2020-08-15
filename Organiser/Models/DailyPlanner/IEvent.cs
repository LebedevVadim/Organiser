using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Organiser.Models.DailyPlanner
{
    public interface IEvent
    {
        int EventID { get; set; }

        [Display(Name = "Тип")]
        string TypeEvent { get; }

        [Display(Name = "Тема")]
        string Subject { get; set; }

        [Display(Name = "Дата и время начала")]
        DateTime BeginDate { get; set; }
    }
}
