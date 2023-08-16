using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.EfClasses
{
    public class PriceOffer
    {
        public int PriceOfferId { get; set; }
        public decimal NewPrice { get; set; }
        [MaxLength(150)]
        public string PromotionalText { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
