using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services.DTO
{
    public class AddPasswordDTO
    {
        [EmailAddress(ErrorMessage = "The email address is incorrect")]
        [Required(ErrorMessage = "Enter your email address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])\S{8,15}$",
         ErrorMessage = "Must be between 8 and 15 long. " +
            "Contain at least one number, one uppercase letter, one lowercase letter.")]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password), ErrorMessage = "Passwords don't match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
