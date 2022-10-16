using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services.DTO
{
    public class ServiceRequestDTO
    {
        
        [Required(ErrorMessage = "Enter CarId")]
        public int CarId { get; set; }
       
        [Required]
        public string City { get; set; }

        [Required]
        public int DealershipId { get; set; }

        [Required]
        public int VisitReasonId { get; set; }
        public int? Mileage { get; set; }
        public int? ServiceConsultantId { get; set; }
     
        public int?  TimeSlotId { get; set; }

        [StringLength(1000, ErrorMessage = "The maximum сomment is 1000 characters")]
        public string? Comment { get; set; }

    }
}
