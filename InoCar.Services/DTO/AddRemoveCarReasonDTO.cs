using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services.DTO
{
    public class AddRemoveCarReasonDTO
    {
        [Required(ErrorMessage = "Description required")]
        public string Description { get; set; }

        
    }

}
