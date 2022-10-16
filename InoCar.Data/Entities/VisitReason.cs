using InoCar.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Entities
{
    public class VisitReason
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; }
        public List<ServiceRequest> ServiceRequests { get; set; }
        public List<MaintenanceWork> MaintenanceWorks { get; set; }
        public VisitReasonTypes Type { get; set; }
     
    }
}
