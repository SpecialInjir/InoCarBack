using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public int CertificateId { get; set; }

        public string Mark { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string StateNumber { get; set; }
        public int? Transmission { get; set; }
        public string? EngineType { get; set; }
        public string? Drive { get; set; }
        public int Mileage { get; set; }
        public string? ImgUrl { get; set; }

        public bool IsDeleted { get; set; }
        public int? RemoveCarReasonId { get; set; }
        public RemoveCarReason? RemoveCarReason { get; set;}

        public List<ServiceRequest>? ServiceRequests { get; set; }

        public CarCertificate CarCertificate { get; set; }
    }
}
