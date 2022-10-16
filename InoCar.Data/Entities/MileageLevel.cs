using InoCar.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Entities
{
    public class MileageLevel
    {
        public int Id { get; set; }
        public int Mileage { get; set; }
        public int ProductId { get; set; }
        public WorkTypes WorkTypes { get; set; }

        public Product Product { get; set; }    
    }
}
