using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services.DTO
{
    public class DealershipDTO
    {

        [Required(ErrorMessage = "Enter Dealership Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Dealership Brand")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "Enter Address")]

        public string Address { get; set; }

        [Required(ErrorMessage = "Enter Operator Num")]
        [DataType(DataType.PhoneNumber)]
        public string OperatorNum { get; set; }
        [Required(ErrorMessage = "Enter Opening Time")]
      
        public DateTime OpenTime { get; set; }
        [Required(ErrorMessage = "Enter Closing Time")]
      
        public DateTime CloseTime { get; set; }
        public string? ImgUrl { get; set; }
    }
}
