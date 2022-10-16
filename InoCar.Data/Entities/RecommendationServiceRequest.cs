using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Entities
{
    public class RecommendationServiceRequest
    {
        public int Id { get; set; }
        public int RecommendationId { get; set; }
        public int ServiceRequestId { get; set; }

        public Recommendation Recommendation { get; set; }
    
        public ServiceRequest ServiceRequest { get; set; }

    }
}
