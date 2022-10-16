using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services.DTO
{
    public class ServiceConsultantDTO
    {

        [Required(ErrorMessage = "Enter Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter  First Name")]
        public string FirstName { get; set; }

    }
}
