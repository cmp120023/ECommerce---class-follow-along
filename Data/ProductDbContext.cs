using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>()
                .HasIndex(m => m.Username)
                .IsUnique();

            modelBuilder.Entity<Member>()
                 .HasIndex(m => m.Email)
                 .IsUnique();
        }
        //tracked entities
        public DbSet<Product> Products { get; set; }

        public DbSet<Member> Members { get; set; }
    }
}
