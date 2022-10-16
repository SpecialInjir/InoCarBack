using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Api.Model
{
    public class ApiCarDetails
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

        //public string VIN { get; set; }

        //public string SeriaCTC { get; set; }
        //public string NumberCTC { get; set; }
        //public DateTime DateCTC { get; set; }


    }
}
