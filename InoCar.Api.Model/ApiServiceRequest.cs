using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Api.Model
{
    public class ApiServiceRequest
    {

        public int Id { get; set; }
        public ApiCar Car { get; set; }
        public string City { get; set; }
        public int? Mileage { get; set; }
        public ApiDealership Dealership { get; set; }

        public ApiVisitReason VisitReason { get; set; }
        public ApiServiceConsultant ServiceConsultant { get; set; }

        public ApiTimeSlot TimeSlot { get; set; }

        public string? Comment { get; set; }

        public bool IsRequestConfirm { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreateRequestDate { get; set; }
        public Decimal RequestPrice { get; set; }

        public Decimal VisitReasonPrice { get; set; }
        public Decimal RecommendationsPrice { get; set; }
        public Decimal PersonalOffersPrice { get; set; }
        public Decimal Discount { get; set; }
    }
}
