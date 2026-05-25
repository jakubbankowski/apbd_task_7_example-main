using Microsoft.EntityFrameworkCore;
using APBD_TASK_7.Models;

namespace APBD_TASK_7.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<PC> Pcs { get; set; } = null!;
    public DbSet<Component> Components { get; set; } = null!;
    public DbSet<PCComponent> PcComponents { get; set; } = null!;
    public DbSet<ComponentType> ComponentTypes { get; set; } = null!;
    public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PCComponent>()
            .HasKey(pc => new { pc.PCId, pc.ComponentCode });
        
        var types = new[]
        {
            new ComponentType { Id = 1, Abbreviation = "GPU", Name = "Graphics Processing Unit" },
            new ComponentType { Id = 2, Abbreviation = "CPU", Name = "Central Processing Unit" },
            new ComponentType { Id = 3, Abbreviation = "RAM", Name = "Random Access Memory" }
        };

        var manufacturers = new[]
        {
            new ComponentManufacturer { Id = 1, Abbreviation = "NV", FullName = "NVIDIA Corporation", FoundationDate = new DateTime(1993, 4, 5) },
            new ComponentManufacturer { Id = 2, Abbreviation = "INTC", FullName = "Intel Corporation", FoundationDate = new DateTime(1968, 7, 18) },
            new ComponentManufacturer { Id = 3, Abbreviation = "AMD", FullName = "Advanced Micro Devices", FoundationDate = new DateTime(1969, 5, 1) }
        };

        var components = new[]
        {
            new Component { Code = "COMP000001", Name = "GeForce RTX 4090", Description = "Flagship GPU", ComponentManufacturerId = 1, ComponentTypesId = 1 },
            new Component { Code = "COMP000002", Name = "Core i9-14900K", Description = "High-end CPU", ComponentManufacturerId = 2, ComponentTypesId = 2 },
            new Component { Code = "COMP000003", Name = "Vengeance DDR5 32GB", Description = "Fast system memory", ComponentManufacturerId = 3, ComponentTypesId = 3 }
        };

        var pcs = new[]
        {
            new PC { Id = 1, Name = "Gaming Beast X", Weight = 12.5, Warranty = 36, CreatedAt = new DateTime(2026, 5, 8, 9, 0, 0), Stock = 5 },
            new PC { Id = 2, Name = "Office Mini Pro", Weight = 4.2, Warranty = 24, CreatedAt = new DateTime(2026, 4, 15, 13, 30, 0), Stock = 12 },
            new PC { Id = 3, Name = "Workstation Ultra", Weight = 15.0, Warranty = 48, CreatedAt = new DateTime(2026, 5, 20, 10, 0, 0), Stock = 2 }
        };

        var pcComponents = new[]
        {
            new PCComponent { PCId = 1, ComponentCode = "COMP000001", Amount = 1 },
            new PCComponent { PCId = 1, ComponentCode = "COMP000002", Amount = 1 },
            new PCComponent { PCId = 2, ComponentCode = "COMP000003", Amount = 2 }
        };
        
        modelBuilder.Entity<ComponentType>().HasData(types);
        modelBuilder.Entity<ComponentManufacturer>().HasData(manufacturers);
        modelBuilder.Entity<Component>().HasData(components);
        modelBuilder.Entity<PC>().HasData(pcs);
        modelBuilder.Entity<PCComponent>().HasData(pcComponents);
        
    }
}