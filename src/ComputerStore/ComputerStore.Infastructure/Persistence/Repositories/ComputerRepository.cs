using ComputerStore.Application.Common.Interfaces.Contexts;
using ComputerStore.Application.Common.Interfaces.Repositories;
using ComputerStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ComputerStore.Infastructure.Persistence.Repositories
{
    public class ComputerRepository : GenericRepository<Computer>, IComputerRepository
    {
        public ComputerRepository(IApplicationDbContext appContext) : base(appContext)
        {
        }

        public override async Task<IEnumerable<Computer>> GetAllAsync() =>
            await appContext.Set<Computer>()
            .AsNoTracking()
            .Include(c => c.Model)
            .Include(c => c.ComputerType)
            .ToListAsync();

        public override async Task<Computer?> GetByIdAsync(int id) =>
            await appContext.Set<Computer>()
            .AsNoTracking()
            .Include(c => c.Model)
            .Include(c => c.ComputerType)
            .SingleOrDefaultAsync(e => e.Id == id);

    }
}
