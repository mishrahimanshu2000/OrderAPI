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
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.ToTable("Customer");

                entity.HasIndex(e => e.CustomerName, "IndexCustomerName");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("Order");

                entity.HasIndex(e => e.CustomerId, "IndexOrderCustomerId");

                entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getDate())")
                .HasColumnType("datetime");

                entity.HasOne(e => e.Customer).WithMany(x => x.CustomerOrder)
                    .HasForeignKey(e => e.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.OrderDetailId);

                entity.ToTable("OrderDetail");

                entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");

                entity.HasOne(e => e.Order).WithMany(x => x.OrderDetails)
                    .HasForeignKey(e => e.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(e => e.Product).WithMany(x => x.OrderDetails)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("Product");

                entity.HasIndex(e => e.ProductCode, "IndexProductCode");

                entity.Property(e => e.ProductPrice)
                    .HasDefaultValueSql("((0))")
                    .HasColumnType("decimal(12,2)");
            });

            modelBuilder.Entity<ProductOrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.OrderDetailId});

                entity.ToTable("ProductOrderDetail");

                entity.HasOne(e => e.Product).WithMany(x => x.ProductOrderDetail)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(e => e.OrderDetail).WithMany(x => x.ProductOrderDetail)
                    .HasForeignKey(e => e.OrderDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}
