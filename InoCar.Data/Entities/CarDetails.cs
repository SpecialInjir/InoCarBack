using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Entities
{
    public class CarDetails
    {
        public int Id { get; set; }
        public int CertificateId { get; set; }

        public DateTime WarrantyEndDate { get; set; }
        public DateTime DaysBeforeTO { get; set; }
        public int KmBeforeTO { get; set; }
        public int MileageToTO { get; set; }
        public DateTime LastVisitTO { get; set; }

        public string ReminderOfMaintenance  { get; set; }

        public string? ReminderOfTO { get; set; }
        public string? Recommendations { get; set; }
        public string? IndividualOffers  { get; set; }

        public string? ServiceCampaigns { get; set; }

        public CarCertificate CarCertificate { get; set; }
    }
}
