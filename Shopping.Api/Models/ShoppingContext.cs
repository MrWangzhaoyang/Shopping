using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Api.Models
{
    public class ShoppingContext : DbContext
    {
        public ShoppingContext(DbContextOptions<ShoppingContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .ToTable("Products")
                .HasKey(u => u.Id);

            modelBuilder.Entity<ShoppingCart>()
                .ToTable("ShoppingCarts")
                .HasKey(u => u.Id);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

    }
}
