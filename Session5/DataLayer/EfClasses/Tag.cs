using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.EfClasses
{
    public class Tag
    {
        public int TagId { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
