using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services.DTO
{
    public class ProductDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public Decimal Price { get; set; }

        [Required(ErrorMessage = "MaintenanceWorkId is required")]
        public int MaintenanceWorkId { get; set; }
        public int? PersonalOfferId { get; set; }
    }
}
