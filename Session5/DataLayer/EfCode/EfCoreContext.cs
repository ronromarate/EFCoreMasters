using DataLayer.EfClasses;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.EfCode
{
    public class EfCoreContext : DbContext
    {
        public EfCoreContext(DbContextOptions<EfCoreContext> options)
           : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<LineItem> LineItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PriceOffer> PriceOffers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSupplier> ProductSuppliers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One-to-one
            modelBuilder.Entity<LineItem>()
                 .HasOne(x => x.Product)
                 .WithOne()
                 .HasForeignKey<LineItem>(x => x.ProductId);

           //One-to-many
           modelBuilder.Entity<Product>()
                .HasMany(x => x.Reviews)
                .WithOne()
                .HasForeignKey(x => x.ProductId);

            //Many-to-many
            modelBuilder.Entity<ProductSupplier>()
                .HasKey(x => new { x.ProductId, x.SupplierId });
        }

    }
}
