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

            modelBuilder.Entity<Orders>().ToTable("Order_info");

            modelBuilder.Entity<OrderDetail>().ToTable("Order_Details");

            modelBuilder.Entity<Product>().ToTable("Product_info");

            modelBuilder.Entity<Customer>().Property(c => c.CustomerId)
                .IsRequired()
                .HasColumnType("INT");

            modelBuilder.Entity<Customer>()
                .HasMany(o => o.Orders)
                .WithOne(c => c.Customer);

            modelBuilder.Entity<Product>().Property(p => p.ProductPrice)
                .HasColumnType("decimal(8,2)").HasDefaultValue(0);

            modelBuilder.Entity<ProductOrderDetail>()
                .HasKey(po => new { po.ProductId, po.OrderDetailId });

            modelBuilder.Entity<ProductOrderDetail>()
                .HasOne(po => po.Product)
                .WithMany(p => p.ProductOrders)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProductOrderDetail>()
                .HasOne(po => po.OrderDetail)
                .WithMany(p => p.ProductOrders)
                .HasForeignKey(p => p.OrderDetailId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }

}
