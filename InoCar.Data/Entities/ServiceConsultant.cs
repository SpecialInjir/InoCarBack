using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Entities
{
    public class ServiceConsultant
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public bool IsDeleted { get; set; }
        public int DealershipId { get; set; }
        public Dealership Dealership { get; set; }
        public List<TimeSlot> TimeSlots { get; set; }
        public List<ServiceRequest> ServiceRequests { get; set; }


    }
}
