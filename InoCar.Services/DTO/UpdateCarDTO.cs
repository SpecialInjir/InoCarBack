using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services.DTO
{
    public class UpdateCarDTO
    {
        public string? Mark { get; set; }
        public string? Model { get; set; }
        public int? Year { get; set; }
        public string? StateNumber { get; set; }
        public int? Transmission { get; set; }
        public string? EngineType { get; set; }
        public string? Drive { get; set; }
        public int? Mileage { get; set; }
    }
}
