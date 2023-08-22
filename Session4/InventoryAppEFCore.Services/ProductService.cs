using AutoMapper;
using AutoMapper.QueryableExtensions;
using InventoryAppEFCore.DataLayer;
using InventoryAppEFCore.DataLayer.EfClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppEFCore.Services
{
    public class ProductService : IProductService
    {
        private readonly InventoryAppEfCoreContext _dbContext;
        public ProductService(InventoryAppEfCoreContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateProjection<Product, ProductDto>()
                    .ForMember(p => p.ProductName, m => m.MapFrom(s => s.Name)));

            return await _dbContext.Products.ProjectTo<ProductDto>(config).ToListAsync();
        }
    }

    public interface IProductService
    {
        Task<List<ProductDto>> GetProducts();
    }

    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
