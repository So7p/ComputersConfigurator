using ComputerStore.Application.Common.Interfaces.Contexts;
using ComputerStore.Application.Common.Interfaces.Repositories;
using ComputerStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ComputerStore.Infastructure.Persistence.Repositories
{
    public class GPURepository : GenericRepository<GPU>, IGPURepository
    {
        public GPURepository(IApplicationDbContext appContext) : base(appContext)
        {
        }

        public override async Task<IEnumerable<GPU>> GetAllAsync() =>
            await appContext.Set<GPU>()
            .AsNoTracking()
            .Include(g => g.GPUManufacturer)
            .ToListAsync();

        public override async Task<GPU?> GetByIdAsync(int id) =>
            await appContext.Set<GPU>()
            .AsNoTracking()
            .Include(g => g.GPUManufacturer)
            .FirstOrDefaultAsync(e => e.Id == id);
    }
}
