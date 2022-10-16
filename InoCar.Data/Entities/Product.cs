using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Decimal Price { get; set; }
        public int MaintenanceWorkId { get; set; }
        public int? PersonalOfferId { get; set; }
        public bool IsDeleted { get; set; }
        public PersonalOffer PersonalOffer { get; set; }
        public MaintenanceWork MaintenanceWork { get; set; }
        public List<MileageLevel> MileageLevels { get; set; }
    }
}
