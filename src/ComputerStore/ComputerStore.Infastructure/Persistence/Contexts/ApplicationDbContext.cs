using ComputerStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ComputerStore.Infastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Laptop> Laptops { get; set; } = null!;
        public DbSet<Model> Models { get; set; } = null!;
        public DbSet<Configuration> Configurations { get; set; } = null!;
        public DbSet<CPU> CPUs { get; set; } = null!;
        public DbSet<GPU> GPUs { get; set; } = null!;
        public DbSet<RAM> RAMs { get; set; } = null!;
        public DbSet<Drive> Drives { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }

}
