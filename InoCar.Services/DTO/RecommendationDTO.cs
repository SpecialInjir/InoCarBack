using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services.DTO
{
    public class RecommendationDTO
    {
        [Required(ErrorMessage = "Enter Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Enter Price")]
        public Decimal Price { get; set; }
    }
}
