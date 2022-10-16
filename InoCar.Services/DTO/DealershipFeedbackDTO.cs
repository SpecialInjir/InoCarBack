using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services.DTO
{
    public class DealershipFeedbackDTO
    {

        [StringLength(50, ErrorMessage = "The maximum length of the first name is 50 characters")]
        [Required(ErrorMessage = "Enter your first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter point number")]
        [Range(1, 10, ErrorMessage = "Invalid point number")]
        public int PointNumber { get; set; }

        [StringLength(2000, ErrorMessage = "The maximum length of the comment is 2000 characters")]
        public string? Comment { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Incorrect date format")]
        [Required(ErrorMessage = "Specify the date of publication")]
        public DateTime PublicDate { get; set; }
    
    }
}
