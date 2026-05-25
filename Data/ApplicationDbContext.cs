using APBD_TASK_7.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_TASK_7.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    /*
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Product
        modelBuilder.Entity<Product>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<Product>()
            .Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(200);

        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasPrecision(10, 2);

        // Configure Order
        modelBuilder.Entity<Order>()
            .HasKey(o => o.Id);

        modelBuilder.Entity<Order>()
            .Property(o => o.CustomerName)
            .IsRequired()
            .HasMaxLength(200);

        modelBuilder.Entity<Order>()
            .Property(o => o.TotalAmount)
            .HasPrecision(10, 2);

        modelBuilder.Entity<Order>()
            .HasMany(o => o.Items)
            .WithOne(oi => oi.Order)
            .HasForeignKey(oi => oi.OrderId);

        // Configure OrderItem
        modelBuilder.Entity<OrderItem>()
            .HasKey(oi => oi.Id);

        modelBuilder.Entity<OrderItem>()
            .Property(oi => oi.UnitPrice)
            .HasPrecision(10, 2);

        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Product)
            .WithMany()
            .HasForeignKey(oi => oi.ProductId);
    }
    */
}
