using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services.DTO
{
    public class MaintenanceWorkDTO
    {
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Exploitation Months is required")]
        public int ExploitationMonths { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public Decimal Price { get; set; }

    }
}
