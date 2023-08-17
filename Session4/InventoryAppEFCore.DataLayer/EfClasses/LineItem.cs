using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppEFCore.DataLayer.EfClasses
{
    public class LineItem
    {
        private int _productId;

        [Key]
        public int LineItemKey { get; set; }
        public short NumOfProducts { get; set; }
        public decimal ProductPrice { get; set; }

        //relationships
        public int OrderId { get; set; }
        public int ProductId => _productId;
        public Product SelectedProduct { get; set; }

        public void SetPropertyValue(int productId)
        {
            _productId = productId;
        }
    }
}
