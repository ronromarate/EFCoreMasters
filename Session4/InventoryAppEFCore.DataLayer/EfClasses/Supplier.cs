﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppEFCore.DataLayer.EfClasses
{
    public class Supplier
    {
        public int SupplierFluentKey { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string FullDescription { get; private  set; }

        public string ContactPersonFirstName { get; set; }
        public string ContactPersonLastName { get; set; }
        public string ContactPersonFullName { get; private set; }
        public DateTime CreatedOn { get; private set; }

        [NotMapped]
        public ExcludeClass ExcludedClass { get; set; }

        //Relationships
        public ICollection<Product> ProductsLink { get; set; }
    }
}
