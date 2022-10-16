using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services.DTO
{
    public class AddCarCertificateDTO
    {
        
       

        [Required(ErrorMessage = "Enter your VIN")]
        [RegularExpression("[A-HJ-NPR-Z0-9]{13}[0-9]{4}", ErrorMessage = "Invalid VIN Format.")]
        public string VIN { get; set; }

        [Required(ErrorMessage = "Enter your Seria CTC")]

        [RegularExpression("^([0-9]{2}[[A-Z0-9]{2})?$", ErrorMessage = "Invalid Seria CTC Format.")]
        public string SeriaCTC { get; set; }

        [Required(ErrorMessage = "Enter your Number CTC")]
        [RegularExpression("^([0-9]{6})?$", ErrorMessage = "Invalid Number CTC Format.")]
        public string NumberCTC { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Incorrect date of birth format")]
        [Required(ErrorMessage = "Specify the date of CTC")]
        public DateTime DateCTC { get; set; }
    }
}
