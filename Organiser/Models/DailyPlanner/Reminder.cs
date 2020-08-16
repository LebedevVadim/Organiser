using Organiser.Models.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organiser.Models.DailyPlanner
{
    [Table("Reminders")]
    public class Reminder : IEvent
    {
        [Key]
        [Column("Id")]
        public int EventID { get; set; }

        public Guid TypeGuid => Types.Reminder.Guid;

        [Required]
        [MaxLength(10)]
        public string TypeEvent => Types.Reminder.TypeName;

        [Required(ErrorMessage = "Введите тему!")]
        [MaxLength(100)]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Введите дату начала")]
        public DateTime? BeginDate { get; set; }
    }
}
