using ComputerStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ComputerStore.Application.Common.Interfaces.Contexts
{
    public interface IApplicationDbContext //Пока не нужен, на git не кидать
    {
        DbSet<Laptop> Laptops { get; set; }
        DbSet<Model> Models { get; set; }
        DbSet<Configuration> Configurations { get; set; }
        DbSet<CPU> CPUs { get; set; }
        DbSet<GPU> GPUs { get; set; }
        DbSet<RAM> RAMs { get; set; }
        DbSet<Drive> Drives { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync();
    }
}
