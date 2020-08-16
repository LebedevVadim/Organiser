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

        Guid TypeGuid { get; }

        [Display(Name = "Тип")]
        string TypeEvent { get; }

        [Display(Name = "Тема")]
        [Required(ErrorMessage = "Введите тему")]
        string Subject { get; set; }

        [Display(Name = "Дата и время начала")]
        [Required(ErrorMessage = "Введите дату и время начала")]
        DateTime? BeginDate { get; set; }
    }
}
