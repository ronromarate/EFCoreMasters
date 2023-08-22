using InventoryAppEFCore.DataLayer.EfClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Security.Cryptography.X509Certificates;

namespace InventoryAppEFCore.DataLayer
{
    public class InventoryAppEfCoreContext : DbContext
    {
      
        public InventoryAppEfCoreContext(DbContextOptions<InventoryAppEfCoreContext> options)
          : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<PriceOffer> PriceOffers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TO DO Fluent API

            //Primary key
            modelBuilder.Entity<Review>()
                .HasKey(x => x.ReviewFluentKey);

            modelBuilder.Entity<Supplier>()
                .HasKey(x => x.SupplierFluentKey);

            modelBuilder.Entity<Tag>()
                .HasKey(x => x.TagFluentKey);

            //Required and MaxLength
            modelBuilder.Entity<Supplier>()
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            //Exclude property
            modelBuilder.Entity<Product>()
                .Ignore(x => x.Promotion);

            //Shadow property
            modelBuilder.Entity<Supplier>()
                .Property<DateTime>("LastModified");

            //Backing field
            modelBuilder.Entity<LineItem>()
                .Property(x => x.ProductId)
                .HasField("_productId");

            //Value conversion
            var utcConverter = new ValueConverter<DateTime, DateTime>(
                toDb => toDb,
                fromDb =>
                DateTime.SpecifyKind(fromDb, DateTimeKind.Utc));

            modelBuilder.Entity<Order>()
                .Property(x => x.DateOrderedUtc)
                .HasConversion(utcConverter);

            //Soft Delete
            modelBuilder.Entity<Product>()
                .HasQueryFilter(p => !p.IsDeleted);

            //Seed Client
            modelBuilder.Entity<Client>().HasData(
                new { ClientKey = 1, Name = "Client 1", IsDeleted = false },
                new { ClientKey = 2, Name = "Client 2", IsDeleted = false },
                new { ClientKey = 3, Name = "Client 3", IsDeleted = true });

            //Add Product View
            modelBuilder.Entity<PriceOffer>().ToTable("PriceOffer");
            modelBuilder.Entity<PriceOffer>().ToView("PriceOfferView").HasNoKey();
            
        }
    }
}