﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateManager.Database.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateOverdue { get; set; }
        public bool Paid { get; set; }

        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
