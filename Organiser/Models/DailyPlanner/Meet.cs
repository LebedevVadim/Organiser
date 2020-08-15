using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organiser.Models.DailyPlanner
{
    [Table("Meets")]
    public class Meet : IEvent
    {
        [Key]
        [Column("Id")]
        public int EventID { get; set; }

        [Required]
        [MaxLength(10)]
        public string TypeEvent => "Встреча";

        [Required(ErrorMessage = "Введите тему!")]
        [MaxLength(100)]
        public string Subject { get; set; }

        [Display(Name = "Место")]
        [Required(ErrorMessage = "Введите место")]
        [MaxLength(50)]
        public string Place { get; set; }

        [Required(ErrorMessage = "Введите дату начала")]
        public DateTime BeginDate { get; set; }

        [Display(Name = "Дата и время окончания")]
        [Required(ErrorMessage = "Введите дату окончания")]
        public DateTime EndDate { get; set; }
        
    }
}
