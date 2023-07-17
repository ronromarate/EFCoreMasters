// See https://aka.ms/new-console-template for more information
using EFCoreAssignment;
using EFCoreAssignment.Entities;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

var connection = @"Server=.\SQLEXPRESS;Database=EFCoreMasters.Session01;Trusted_Connection=True"; // TODO : Add your connection string here
var optionsBuilder =
    new DbContextOptionsBuilder
           <AppDbContext>();
optionsBuilder.UseSqlServer(connection);

var options = optionsBuilder.Options;

Filtering(new AppDbContext(options));
SingleOrDefault(new AppDbContext(options));
LoadingRelatedData_Manual(new AppDbContext(options));
LoadingRelatedData_ExplicitLoading(new AppDbContext(options));
LoadingRelatedData_EagerLoading(new AppDbContext(options));

static void Filtering(AppDbContext dbContext)
{
    // TODO : Filter by Product Name
    using (dbContext)
    {
        var products = dbContext.Products.Where(p => p.Name == "Product 1").ToList();
    }
}

static void SingleOrDefault(AppDbContext dbContext)
{
    // TODO : Select using SingleOrDefault by Product Id    
    using (dbContext)
    {
        var products = dbContext.Products.SingleOrDefault(p => p.Id == 1);
    }
}

static void LoadingRelatedData_Manual(AppDbContext dbContext)
{
    // TODO : Load Product with related shop data manually
    using (dbContext)
    {
        var product = dbContext.Products.FirstOrDefault();

        if (product != null)
        {
            product.Shop = dbContext.Shops.Single(p => p.Id == product.ShopId);
        }
    }
}

static void LoadingRelatedData_ExplicitLoading(AppDbContext dbContext)
{
    // TODO : Load Product with related shop data explicitly

    using (dbContext)
    {
        var product = dbContext.Products.FirstOrDefault();

        if (product != null)
        {
            dbContext.Entry(product).Reference(p => p.Shop).Load();
            dbContext.Entry(product).Collection(p => p.Reviews).Load();
        }
    }
}

static void LoadingRelatedData_EagerLoading(AppDbContext dbContext)
{
    // TODO : Load Product with related Shop data eagerly    

    using (dbContext)
    {
        var product = dbContext.Products
            .Include(p => p.Shop)
            .Include(p => p.Reviews)
            .FirstOrDefault();
    }
}

Console.WriteLine("EF Core is the best");

// TODO: Assignment 2

InsertProduct(new AppDbContext(options));
InsertProductWithNewShop(new AppDbContext(options));
UpdateProduct(new AppDbContext(options));
DeleteProduct(new AppDbContext(options));
DeleteProductByKey(new AppDbContext(options));

static void InsertProduct(AppDbContext dbContext)
{
    // TODO: Insert a new Product
    using (dbContext)
    {
        var product = new Product()
        {
            Name = "Product 6",
            ShopId = 1
        };

        dbContext.Add(product);
        dbContext.SaveChanges();
    }
}

static void InsertProductWithNewShop(AppDbContext dbContext)
{
    // TODO: Insert a new Product with a new Shop
    var shop = new Shop()
    {
        Name = "Shop 4"
    };

    var product = new Product()
    {
        Name = "Product 7",
        Shop = shop
    };

    dbContext.Add(shop);
    dbContext.Add(product);
    dbContext.SaveChanges();
}

static void UpdateProduct(AppDbContext dbContext)
{
    // TODO: Update a Product
    var product = dbContext.Products.FirstOrDefault(p => p.Name == "Product 6");

    if (product != null) 
    {
        product.Name = "Product 6 modified";
        product.ShopId = 2;
        dbContext.SaveChanges();
    }
}

static void DeleteProduct(AppDbContext dbContext)
{
    // TODO: Delete a Product
    var productId = 12;
    var product = dbContext.Products.FirstOrDefault(p => p.Id == productId);

    if (product != null)
    {
        dbContext.Remove(product);
        dbContext.SaveChanges();
    }
}

static void DeleteProductByKey(AppDbContext dbContext)
{
    // TODO: Delete a Product with just having a key
    var productId = 13;
    var product = new Product { Id = productId };

    dbContext.Remove(product);
    dbContext.SaveChanges();
}
