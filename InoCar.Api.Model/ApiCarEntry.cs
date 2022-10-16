using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Api.Model
{
    public class ApiCarEntry
    {

        public int Id { get; set; }
        public int CertificateId { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        //public string ImgUrl { get; set; }
        public bool? IsCompleted { get; set; }

        public string? ExplainationText { get; set; }
        public DateTime? EndWorkDate { get; set; }

    }
}
