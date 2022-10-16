using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Entities
{
    public class TimeSlot
    {
        public int Id { get; set; }
        public int ServiceConsultantId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsDeleted { get; set;}
        public List<ServiceRequest> ServiceRequests { get; set; }

        public ServiceConsultant ServiceConsultant { get; set; }

    }
}
