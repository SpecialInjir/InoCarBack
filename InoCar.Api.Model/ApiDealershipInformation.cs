using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Api.Model
{
    public class ApiDealershipInformation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }

        public string Address { get; set; }

        public string OperatorNum { get; set; }

        public TimeSpan OpeningTime { get; set; }

        public TimeSpan ClosingTime { get; set; }
        public string? ImgUrl { get; set; }
    }
}
