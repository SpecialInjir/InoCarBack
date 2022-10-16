using InoCar.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services.DTO
{
    public class AddUserCodeDTO
    {

        [EmailAddress(ErrorMessage = "The email address is incorrect")]
        [Required(ErrorMessage = "Enter your email address")]
        public string Email { get; set; }

        [StringLength(4, ErrorMessage = "Length must be 4", MinimumLength = 4)]
        [Required(ErrorMessage = "Enter the code)")]
        public string Code { get; set; }
     
      

    }
}
