using ComputerStore.Application.Common.Interfaces.Contexts;
using ComputerStore.Application.Common.Interfaces.Repositories;
using ComputerStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ComputerStore.Infastructure.Persistence.Repositories
{
    public class ConfigurationRepository : GenericRepository<Configuration>, IConfigurationRepository
    {
        public ConfigurationRepository(IApplicationDbContext appContext) : base(appContext)
        {
        }

        public override async Task<IEnumerable<Configuration>> GetAllAsync() =>
            await appContext.Set<Configuration>()
            .AsNoTracking()
            .Include(c => c.CPU)                 
            .Include(c => c.CPU.CPUManufacturer) 
            .Include(c => c.GPU)                 
            .Include(c => c.GPU.GPUManufacturer)
            .Include(c => c.RAM)                 
            .Include(c => c.Drive)               
            .Include(c => c.Drive.DriveType)
            .ToListAsync();

        public override async Task<Configuration?> GetByIdAsync(int id) =>
            await appContext.Set<Configuration>()
            .AsNoTracking()
            .Include(c => c.CPU)
            .Include(c => c.CPU.CPUManufacturer)
            .Include(c => c.GPU)
            .Include(c => c.GPU.GPUManufacturer)
            .Include(c => c.RAM)
            .Include(c => c.Drive)
            .Include(c => c.Drive.DriveType)
            .SingleOrDefaultAsync(c => c.Id == id);

    }
}
