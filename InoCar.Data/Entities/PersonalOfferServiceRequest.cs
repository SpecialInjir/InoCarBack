using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Entities
{
    public  class PersonalOfferServiceRequest
    {
        public int Id { get; set; }
        public int PersonalOfferId { get; set; }
        public int ServiceRequestId { get; set; }

        public PersonalOffer PersonalOffer { get; set; }

        public ServiceRequest ServiceRequest { get; set; }
    }
}
