using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Organiser.Models
{
    public enum ModeShowEnum
    {
        [Display(Name = "День")]
        Day,

        [Display(Name = "Неделя")]
        Week,

        [Display(Name = "Месяц")]
        Month,

        [Display(Name = "Список")]
        List
    }

    public class ModeShow
    {
        public IEnumerable<ModeShowEnum> ModesShow => new List<ModeShowEnum> { ModeShowEnum.Day, ModeShowEnum.Week, ModeShowEnum.Month, ModeShowEnum.List };
    }
}
