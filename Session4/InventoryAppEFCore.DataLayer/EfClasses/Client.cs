using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppEFCore.DataLayer.EfClasses
{
    public class Client
    {
        [Key]
        public int ClientKey { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

    }
}
