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

            modelBuilder.Entity<PaymentDetail>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Product>()
                .HasMany<ProductImage>(p => p.Images);

            modelBuilder.Entity<Product>()
                .HasMany<ProductSize>(p => p.Sizes);

            modelBuilder.Entity<ProductImage>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<ProductType>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Role>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<ProductSize>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Transaction>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<User>()
                .HasKey(p => p.Id);
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
    }
}