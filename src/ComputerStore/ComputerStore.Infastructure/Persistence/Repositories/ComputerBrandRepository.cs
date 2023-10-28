using ComputerStore.Application.Common.Interfaces.Contexts;
using ComputerStore.Application.Common.Interfaces.Repositories;
using ComputerStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ComputerStore.Infastructure.Persistence.Repositories
{
    public class ComputerBrandRepository : GenericRepository<ComputerBrand>, IComputerBrandRepository
    {
        public ComputerBrandRepository(IApplicationDbContext appContext) : base(appContext)
        {
        }

        public override async Task<IEnumerable<ComputerBrand>> GetAllAsync() =>
            await appContext.Set<ComputerBrand>()
            .AsNoTracking()
            .ToListAsync();

        public override async Task<ComputerBrand?> GetByIdAsync(int id) =>
            await appContext.Set<ComputerBrand>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
    }
}