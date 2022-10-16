using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Entities
{
    public class Dealership
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Brand { get; set; }

        public string Address { get; set; }

        public string OperatorNum { get; set; }

        public TimeSpan OpeningTime { get; set; }

        public TimeSpan ClosingTime { get; set; }
        public string? ImgUrl { get; set; }
        public bool IsDeleted { get; set; }
        public List<ServiceRequest> ServiceRequests { get; set; }

        public List<ServiceConsultant> ServiceConsultants { get; set; }
       
        public List<DealershipFeedback> DealershipFeedbacks { get; set; }
    }
}
