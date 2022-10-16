using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services.DTO
{
    public class TimeSlotDTO
    {
        [Required(ErrorMessage = "Start Time is required")]
        public DateTime StartTime { get; set; }
        [Required(ErrorMessage = "End Time is required")]
        public DateTime EndTime { get; set; }
    }
}
