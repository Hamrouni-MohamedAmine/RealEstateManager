﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateManager.Database.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Value { get; set; }
        public string Family { get; set; }

        public ICollection<Payment> Payments { get; set; }
    }
}
