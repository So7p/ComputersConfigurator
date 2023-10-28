using ComputerStore.Application.Common.Interfaces.Contexts;
using ComputerStore.Application.Common.Interfaces.Repositories;
using ComputerStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ComputerStore.Infastructure.Persistence.Repositories
{
    public class CPURepository : GenericRepository<CPU>, ICPURepository
    {
        public CPURepository(IApplicationDbContext appContext) : base(appContext)
        {
        }

        public override async Task<IEnumerable<CPU>> GetAllAsync() =>
            await appContext.Set<CPU>()
            .AsNoTracking()
            .Include(c => c.CPUManufacturer)
            .ToListAsync();

        public override async Task<CPU?> GetByIdAsync(int id) =>
            await appContext.Set<CPU>()
            .AsNoTracking()
            .Include(c => c.CPUManufacturer)
            .FirstOrDefaultAsync(e => e.Id == id);
    }
}