using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Api.Model
{
    public class ApiTimeSlot
    {
        public int Id { get; set; }
        public int ServiceConsultantId { get; set; }

        public string TimeSlot { get; set; }
    }
}
