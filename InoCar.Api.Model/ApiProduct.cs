using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Api.Model
{
    public class ApiProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Decimal Price { get; set; }
        public int? MaintenanceWorkId { get; set; }
        public int? PersonalOfferId { get; set; }
    }
}
