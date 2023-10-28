using ComputerStore.Application.Common.Interfaces.Contexts;
using ComputerStore.Application.Common.Interfaces.Repositories;
using ComputerStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ComputerStore.Infastructure.Persistence.Repositories
{
    public class ComputerTypeRepository : GenericRepository<ComputerType>, IComputerTypeRepository
    {
        public ComputerTypeRepository(IApplicationDbContext appContext) : base(appContext)
        {        
        }

        public override async Task<IEnumerable<ComputerType>> GetAllAsync() =>
            await appContext.Set<ComputerType>()
            .AsNoTracking()
            .ToListAsync();

        public override async Task<ComputerType?> GetByIdAsync(int id) =>
            await appContext.Set<ComputerType>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
    }
}