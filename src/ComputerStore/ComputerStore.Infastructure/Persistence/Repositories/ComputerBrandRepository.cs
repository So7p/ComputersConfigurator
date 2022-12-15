using ComputerStore.Application.Common.Interfaces.Contexts;
using ComputerStore.Application.Common.Interfaces.Repositories;
using ComputerStore.Domain.Entities;

namespace ComputerStore.Infastructure.Persistence.Repositories
{
    public class ComputerBrandRepository : GenericRepository<ComputerBrand>, IComputerBrandRepository
    {
        public ComputerBrandRepository(IApplicationDbContext appContext) : base(appContext)
        {

        }
    }
}
