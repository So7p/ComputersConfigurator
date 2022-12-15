using ComputerStore.Application.Common.Interfaces.Contexts;
using ComputerStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ComputerStore.Infastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Computer> Computers { get; set; } = null!;
        public DbSet<Model> Models { get; set; } = null!;
        public DbSet<Configuration> Configurations { get; set; } = null!;
        public DbSet<CPU> CPUs { get; set; } = null!;
        public DbSet<GPU> GPUs { get; set; } = null!;
        public DbSet<RAM> RAMs { get; set; } = null!;
        public DbSet<Drive> Drives { get; set; } = null!;
        public DbSet<CPUManufacturer> CPUManufacturers { get; set; } = null!;
        public DbSet<GPUManufacturer> GPUManufacturers { get; set; } = null!;
        public DbSet<DriveType> DriveTypes { get; set; } = null!;
        public DbSet<ComputerType> ComputerTypes { get; set; } = null!;
        public DbSet<ComputerBrand> ComputerBrands { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public async Task<int> SaveChangesAsync() => await base.SaveChangesAsync();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }

}
