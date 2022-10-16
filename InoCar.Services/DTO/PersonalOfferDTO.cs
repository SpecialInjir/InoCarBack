using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services.DTO
{
    public class PersonalOfferDTO
    {

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Discount is required")]
        public Decimal Discount { get; set; }

        [Required(ErrorMessage = "ActivatedPrice is required")]
        public Decimal ActivatedPrice { get; set; }

        [Required(ErrorMessage = "Brand is required")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "EndDate is required")]
        public DateTime EndDate {get ; set; }
    }
}
