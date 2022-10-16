using InoCar.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Entities
{
    public class ServiceRequest
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string UserId { get; set; }
        public string City { get; set; }
        public int? Mileage { get; set; }
        public int DealershipId { get; set; }

        public int VisitReasonId { get; set; }
        public int? ServiceConsultantId { get; set; }

        public int? TimeSlotId { get; set; }

        public string? Comment { get; set; }

        public bool IsRequestConfirm { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreateRequestDate {get;set;}
        public Decimal RequestPrice { get; set; }
        public Decimal VisitReasonPrice { get; set; }
        public Decimal? RecommendationsPrice { get; set; }
        public Decimal? PersonalOffersPrice { get; set; }
        public Decimal? Discount { get; set; }
        public int? RecommendationServiceRequestId { get; set; }
        public int? PersonalOfferServiceRequestId { get; set; }
        public RequestTypes RequestType { get; set; }
        public Dealership Dealership { get; set; }
      
        public VisitReason VisitReason { get; set; }
        public  ServiceConsultant ServiceConsultant { get; set;  }
      
        public  TimeSlot TimeSlot { get; set; }
       
        public Car Car { get; set; }
        public User User { get; set; }

        public List<PersonalOfferServiceRequest> PersonalOfferServiceRequests { get; set; }
        public List<RecommendationServiceRequest> RecommendationServiceRequests { get; set; }
       
    }
}

