using InoCar.Data.Entities;
using InoCar.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Entities
{
    public class MaintenanceWork
    {
        public int Id { get; set; }
        public int VisitReasonId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public int ExploitationMonths { get; set; }
        public Decimal Price { get; set; }

        public VisitReason VisitReason { get; set; }
    
        public List<Product> Products { get; set; }

        
    }
}
