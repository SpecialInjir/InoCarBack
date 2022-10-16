using InoCar.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Entities
{
    public class RemoveCarReason
    {
        public int Id { get; set; }
        public string Description { get;set;}

        public bool IsDeleted { get; set; }
        public List<Car>? Cars { get; set; }

        public RemoveCarReasonTypes Type { get; set; }
    }
}
