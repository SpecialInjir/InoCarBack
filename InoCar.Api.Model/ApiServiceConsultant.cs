using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Api.Model
{
    public class ApiServiceConsultant
    {
        public int Id { get; set; }
        public int DealershipId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}
