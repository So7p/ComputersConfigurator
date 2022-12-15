using ComputerStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ComputerStore.Application.Common.Interfaces.Contexts
{
    public interface IApplicationDbContext
    {
        DbSet<Computer> Computers { get; set; }
        DbSet<Model> Models { get; set; }
        DbSet<Configuration> Configurations { get; set; }
        DbSet<CPU> CPUs { get; set; }
        DbSet<GPU> GPUs { get; set; }
        DbSet<RAM> RAMs { get; set; }
        DbSet<Drive> Drives { get; set; }
        DbSet<CPUManufacturer> CPUManufacturers { get; set; }
        DbSet<GPUManufacturer> GPUManufacturers { get; set; }
        DbSet<DriveType> DriveTypes { get; set; }
        DbSet<ComputerType> ComputerTypes { get; set; }
        DbSet<ComputerBrand> ComputerBrands { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync();
    }
}
