using Organiser.Models.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organiser.Models.DailyPlanner
{
    [Table("Cases")]
    public class Case : IEvent
    {
        [Key]
        [Column("Id")]
        public int EventID { get; set; }

        public Guid TypeGuid => Types.Case.Guid;

        [Required]
        [MaxLength(10)]
        public string TypeEvent => Types.Case.TypeName;

        [Required(ErrorMessage = "Введите тему!")]
        [MaxLength(100)]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Введите дату начала")]
        public DateTime? BeginDate { get; set; }

        [Display(Name = "Дата и время окончания")]
        [Required(ErrorMessage = "Введите дату окончания")]
        public DateTime? EndDate { get; set; }
    }
}
