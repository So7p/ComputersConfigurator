using ComputerStore.Application.Common.Interfaces.Contexts;
using ComputerStore.Application.Common.Interfaces.Repositories;
using ComputerStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ComputerStore.Infastructure.Persistence.Repositories
{
    public class ModelRepository : GenericRepository<Model>, IModelRepository
    {
        public ModelRepository(IApplicationDbContext appContext) : base(appContext)
        {
        }

        public override async Task<IEnumerable<Model>> GetAllAsync() =>
            await appContext.Set<Model>()
            .AsNoTracking()
            .Include(m => m.Configuration)
            .Include(m => m.ComputerBrand)
            .ToListAsync();

        public override async Task<Model?> GetByIdAsync(int id) =>
            await appContext.Set<Model>()
            .AsNoTracking()
            .Include(m => m.Configuration)
            .Include(m => m.ComputerBrand)
            .FirstOrDefaultAsync(e => e.Id == id);
    }
}
