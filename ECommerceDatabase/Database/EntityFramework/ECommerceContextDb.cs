using Microsoft.EntityFrameworkCore;
using ECommerceDatabase.Database.Entities;

namespace ECommerceDatabase.Database.EntityFramework
{
    /// <summary>
    /// Entity Framework In-Memory database
    /// </summary>
    public class ECommerceContextDb : DbContext
    {
        public ECommerceContextDb(DbContextOptions<ECommerceContextDb> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Brand>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Category>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Order>()
                .HasMany<OrderedProduct>(p => p.OrderedProducts);

            modelBuilder.Entity<OrderStatus>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<PaymentDetails>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Product>()
                .HasMany<ProductImage>(p => p.Images);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Brand)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.BrandId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductType)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.ProductTypeId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<ProductImage>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<ProductType>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Role>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<ProductSize>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<ProductSize>()
                .HasOne(p => p.ProductType);

            modelBuilder.Entity<Transaction>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<User>()
                .HasKey(p => p.Id);
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderedProduct> OrderedProducts { get; set; }
        public DbSet<DeliveryInformation> BillingInformation { get; set; }
        public DbSet<DeliveryInformation> ShippingInformation { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<PaymentDetails> PaymentDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
    }
}