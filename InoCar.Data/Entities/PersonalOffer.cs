using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Entities
{
    public class PersonalOffer
    {
       
        public int Id { get; set; }
        public string Description { get; set; }
        public Decimal Discount { get; set; }
        public Decimal ActivatedPrice { get; set; }
        public string Brand { get; set; }
        public bool IsDeleted { get; set; }
        public List<Product> Products { get; set; }
        public DateTime EndDate { get; set; }
        public List<PersonalOfferServiceRequest> PersonalOfferServiceRequests { get; set; }
    }
}
