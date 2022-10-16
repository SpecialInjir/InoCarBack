using InoCar.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services.DTO
{
    public class VisitReasonDTO
    {
       
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Visit Reason type is required")]
        public VisitReasonTypes Type { get; set; }
    }
}
