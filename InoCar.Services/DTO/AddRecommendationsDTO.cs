using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services.DTO
{
    public class AddRecommendationsDTO
    {
        [Required]
        public int ServiceRequestId { get; set; }
        public List<int>? RecommedationIds { get; set; }
    }
}
