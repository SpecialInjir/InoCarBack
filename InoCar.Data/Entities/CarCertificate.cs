﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Entities
{
    public class CarCertificate
    {

        public int Id { get; set; }
        public string UserId { get; set; }
        public string VIN { get; set; }

        public string SeriaCTC { get; set; }
        public string NumberCTC { get; set; }
        public DateTime DateCTC { get; set; }
        public User User { get; set; }
        public Car Car { get; set; }
        public  CarDetails CarDetails { get; set; }
    }
}
