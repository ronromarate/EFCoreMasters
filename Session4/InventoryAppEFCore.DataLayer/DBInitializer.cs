using InventoryAppEFCore.DataLayer.EfClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppEFCore.DataLayer
{
    public class DBInitializer
    {
        private readonly InventoryAppEfCoreContext context;

        public DBInitializer(InventoryAppEfCoreContext context)
        {
            this.context = context;
        }

        public async Task SeedAsync()
        {
            if (!this.context.PriceOffers.Any())
            {
                this.context.PriceOffers.Add(new PriceOffer()
                {
                    NewPrice = 150,
                    ProductId = 1,
                    PromotinalText = "Product 1"
                });

                this.context.PriceOffers.Add(new PriceOffer()
                {
                    NewPrice = 250,
                    ProductId = 2,
                    PromotinalText = "Product 2"
                });

                this.context.PriceOffers.Add(new PriceOffer()
                {
                    NewPrice = 350,
                    ProductId = 3,
                    PromotinalText = "Product 3"
                });

                this.context.PriceOffers.Add(new PriceOffer()
                {
                    NewPrice = 450,
                    ProductId = 4,
                    PromotinalText = "Product 4"
                });

                await this.context.SaveChangesAsync();
            }

            if (!this.context.Products.Any())
            {
                this.context.Products.Add(new Product()
                {
                    Name = "Product 1",
                    IsDeleted = false
                });

                this.context.Products.Add(new Product()
                {
                    Name = "Product 2",
                    IsDeleted = false
                });

                this.context.Products.Add(new Product()
                {
                    Name = "Product 3",
                    IsDeleted = true
                });

                this.context.Products.Add(new Product()
                {
                    Name = "Product 4",
                    IsDeleted = false
                });

                await this.context.SaveChangesAsync();
            }
        }
    }
}
