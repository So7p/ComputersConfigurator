using ComputerStore.Application.Common.Interfaces.Contexts;
using ComputerStore.Application.Common.Interfaces.Repositories;
using ComputerStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ComputerStore.Infastructure.Persistence.Repositories
{
    public class DriveRepository : GenericRepository<Drive>, IDriveRepository
    {
        public DriveRepository(IApplicationDbContext appContext) : base(appContext) 
        { 
        }

        public override async Task<IEnumerable<Drive>> GetAllAsync() =>
            await appContext.Set<Drive>()
            .AsNoTracking()
            .Include(d => d.DriveType)
            .ToListAsync();

        public override async Task<Drive?> GetByIdAsync(int id) =>
            await appContext.Set<Drive>()
            .AsNoTracking()
            .Include(d => d.DriveType)
            .FirstOrDefaultAsync(e => e.Id == id);
    }
}
