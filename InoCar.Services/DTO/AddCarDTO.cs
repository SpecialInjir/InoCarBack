using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace InoCar.Services.DTO
{
    public class AddCarDTO
    {
        [Required(ErrorMessage = "Enter CarCertificateId")]
        public int CarCertificateId { get; set; }
        

        [Required(ErrorMessage = "Enter your mark")]
        public string Mark { get; set; }

        [Required(ErrorMessage = "Enter your model")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Enter  year")]
        [Range(1925, 2025, ErrorMessage = "Invalid year")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Enter state number")]
        [RegularExpression(@"^[АВЕКМНОРСТУХ]\d{3}[АВЕКМНОРСТУХ]{2}\d{2,3}", ErrorMessage = "Invalid State Number Format.")]
                                                            
        public string StateNumber { get; set; }
        public int? Transmission { get; set; }
        public string? EngineType { get; set; }
        public string? Drive { get; set; }

        [Required(ErrorMessage = "Enter mileage")]
        public int Mileage { get; set; }
    }
}
