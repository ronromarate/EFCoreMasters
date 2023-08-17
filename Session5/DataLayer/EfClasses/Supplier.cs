﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.EfClasses
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public ProductSupplier ProductLink { get; set; }
    }
}
