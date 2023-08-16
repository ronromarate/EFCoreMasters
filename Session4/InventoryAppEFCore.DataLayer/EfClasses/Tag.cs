﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppEFCore.DataLayer.EfClasses
{
  
    public class Tag
    {
        public string TagFluentKey { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
