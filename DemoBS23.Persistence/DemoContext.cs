using Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Persistence;

public class DemoContext : DbContext
{
    public DemoContext(DbContextOptions<DemoContext> options) : base(options) { }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Detail> Details { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasData(new Employee { Id = 1, Name = "Iqram" });
        modelBuilder.Entity<Employee>().HasData(new Employee { Id = 2, Name = "Raju" });
        modelBuilder.Entity<Project>().HasData(new Project { Id = 1, Name = "Project1" });
        modelBuilder.Entity<Project>().HasData(new Project { Id = 2, Name = "Project2" });

        base.OnModelCreating(modelBuilder);
    }
}
