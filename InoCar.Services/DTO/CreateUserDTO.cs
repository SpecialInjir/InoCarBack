using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services.DTO
{
    public class CreateUserDTO
    {
       
        [StringLength(50, ErrorMessage = "The maximum length of the last name is 50 characters")]
        [Required(ErrorMessage = "Enter your last name")]
        public string LastName { get; set; } 

        [StringLength(50, ErrorMessage = "The maximum length of the first name is 50 characters")]
        [Required(ErrorMessage = "Enter your first name")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "The maximum length of the patronymic is 50 characters")]
        public string? Patronymic { get; set; }

        [EmailAddress(ErrorMessage = "The email address is incorrect")]
        [Required(ErrorMessage = "Enter your email address")]
        public string Email { get; set; }

        
        [DataType(DataType.Date, ErrorMessage = "Incorrect date of birth format")]
        [Required(ErrorMessage = "Specify the date of birth")]
      
        public DateTime DateBirth { get; set; }

        
        [Required(ErrorMessage = "Specify the city")]
        public string City { get; set; }
      
      
    }
}
