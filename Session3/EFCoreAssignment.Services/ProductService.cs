using EFCoreAssignment.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment.Data.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _dbContext;
        public ProductService(AppDbContext dbContext) 
        {
            this._dbContext = dbContext;
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            // TODO get products
            return await _dbContext.Products.Select(p => 
                new ProductDto(
                    p.Id, 
                    p.Name, 
                    p.ShopId
                )).ToListAsync();
        }

        public async Task<ProductDto> GetProduct(int id)
        {
            // TODO get product
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product != null)
            {
                return new ProductDto(product.Id, product.Name, product.ShopId);
            }

            return null;
        }

        public async Task<int> CreateProduct(CreateProductDto productForCreation)
        {
            // TODO create a product
            if (productForCreation != null)
            {
                _dbContext.Products.Add(new Product()
                {
                    Name = productForCreation.Name,
                    ShopId = productForCreation.ShopId
                });

                return await _dbContext.SaveChangesAsync();
            }

            return 0;
        }

        public async Task UpdateProduct(UpdateProductDto productForUpdate)
        {
            //TODO update a product
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == productForUpdate.Id);

            if (product != null)
            {
                product.Name = productForUpdate.Name;
                product.ShopId = productForUpdate.ShopId;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteProduct(int id)
        {
            //TODO delete a product
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product != null)
            {
                _dbContext.Remove(product);
                await _dbContext.SaveChangesAsync();
            }
        }
    }

    public interface IProductService
    {
        Task<List<ProductDto>> GetProducts();
        Task<ProductDto> GetProduct(int id);
        Task<int> CreateProduct(CreateProductDto productForCreation);
        Task UpdateProduct(UpdateProductDto productForUpdate);
        Task DeleteProduct(int id);
    }

    public record ProductDto(int Id, string Name, int ShopId);
    public record CreateProductDto(string Name, int ShopId);
    public record UpdateProductDto(int Id, string Name, int ShopId);
}