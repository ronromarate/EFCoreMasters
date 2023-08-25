using InventoryAppEFCore.DataLayer.EfClasses;
using Microsoft.EntityFrameworkCore;
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

        public void ComputedColumnSql()
        {
            Supplier supplier = new Supplier()
            {
                Name = "Supplier 4",
                Description = "Description 4",
                ContactPersonFirstName = "Bob",
                ContactPersonLastName = "Smith"
            };

            this.context.Suppliers.Add(supplier);
            this.context.SaveChanges();
        }

        //UDF - Scalar
        public void CreateScalarUdfForProductsCountByStatus()
        {
            this.context.Database.ExecuteSqlRaw(
                $"CREATE FUNCTION ProductsCountByStatus (@isDeleted BIT)" +
                    @"  RETURNS INT
                      AS
                      BEGIN
                          DECLARE @result as INT
                          SELECT 
                                @result = COUNT(*)
                          FROM [dbo].[Products] AS p
                          WHERE p.IsDeleted = @isDeleted
                      RETURN @result
                      END");

            var productsCount = this.context.ProductsCountByStatus(false);
        }

        //UDF - Table-Valued
        public void CreateTableValuedUdf()
        {
            this.context.Database.ExecuteSqlRaw(
                $"CREATE FUNCTION GetPriceOfferFiltered (@amount INT)" +
                    @" RETURNS TABLE 
                       AS
                       RETURN 
                       (
	                        SELECT *
	                        FROM [dbo].[PriceOffers] p
	                        WHERE p.NewPrice < @amount
                       )");

            var products = this.context.GetPriceOfferFiltered(450);
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

            if (!this.context.Suppliers.Any())
            {
                this.context.Suppliers.Add(new Supplier()
                {
                    Name = "Supplier 1",
                    Description = "Description 1",
                    ContactPersonFirstName = "Mark",
                    ContactPersonLastName = "Perez"
                });

                this.context.Suppliers.Add(new Supplier()
                {
                    Name = "Supplier 2",
                    Description = "Description 2",
                    ContactPersonFirstName = "Dan",
                    ContactPersonLastName = "Bautista"
                });

                this.context.Suppliers.Add(new Supplier()
                {
                    Name = "Supplier 3",
                    Description = "Description 3",
                    ContactPersonFirstName = "April",
                    ContactPersonLastName = "Cruz"
                });

                await this.context.SaveChangesAsync();
            }
        }
    }
}
