using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services.DTO
{
    public class UpdateProfileDTO
    {
        [StringLength(15, ErrorMessage = "The maximum length of the City is 15 characters")]
        public string? City { get; set; }

        [StringLength(50, ErrorMessage = "The maximum length of the last name is 50 characters")]
        
        public string? LastName { get; set; }

        [StringLength(50, ErrorMessage = "The maximum length of the first name is 50 characters")]
       
        public string? FirstName { get; set; }

        [StringLength(50, ErrorMessage = "The maximum length of the patronymic  is 50 characters")]
        public string? Patronymic { get; set; }
    }
}
