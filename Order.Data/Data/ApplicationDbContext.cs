using Microsoft.EntityFrameworkCore;
using Order.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer_info");

            modelBuilder.Entity<Orders>().ToTable("Oredr_info");

            modelBuilder.Entity<OrderDetail>().ToTable("Order_Details");

            modelBuilder.Entity<Product>().ToTable("Product_info");

            modelBuilder.Entity<Customer>().Property(c => c.CustomerId)
                .IsRequired()
                .HasColumnType("INT");

            modelBuilder.Entity<Product>().Property(p => p.ProductPrice)
                .HasColumnType("decimal(8,2)").HasDefaultValue(0);
        }
    }

}
