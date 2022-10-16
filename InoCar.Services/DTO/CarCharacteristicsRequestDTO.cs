using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services.DTO
{
    public class CarCharacteristicsRequestDTO
    {
        [Required]
        public int CarId { get; set; }
       
        public string? Email { get; set; }
    }
}
