using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Entities
{
    public class Recommendation
    {
        public int Id { get; set; } 
        public string Description { get; set; }

        public bool IsDeleted { get; set; } 
        public Decimal Price { get; set; }
        public List<RecommendationServiceRequest> RecommendationServiceRequests { get; set; }
    }
}
