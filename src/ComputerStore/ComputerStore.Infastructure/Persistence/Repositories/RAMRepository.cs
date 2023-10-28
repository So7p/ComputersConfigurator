using ComputerStore.Application.Common.Interfaces.Contexts;
using ComputerStore.Application.Common.Interfaces.Repositories;
using ComputerStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ComputerStore.Infastructure.Persistence.Repositories
{
    public class RAMRepository : GenericRepository<RAM>, IRAMRepository
    {
        public RAMRepository(IApplicationDbContext appContext) : base(appContext)
        {
        }

        public override async Task<IEnumerable<RAM>> GetAllAsync() =>
            await appContext.Set<RAM>()
            .AsNoTracking()
            .ToListAsync();

        public override async Task<RAM?> GetByIdAsync(int id) =>
            await appContext.Set<RAM>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
    }
}