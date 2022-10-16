using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Api.Model
{
    public class ApiPersonalOffer
    {
        public int Id { get; set; }

        public string Description { get; set; }
        public Decimal Discount  { get; set; }
    }
}
