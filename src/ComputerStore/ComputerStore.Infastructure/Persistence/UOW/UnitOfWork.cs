using ComputerStore.Application.Common.Interfaces.Contexts;
using ComputerStore.Application.Common.Interfaces.Repositories;
using ComputerStore.Application.Common.Interfaces.UOW;
using ComputerStore.Infastructure.Persistence.Repositories;

namespace ComputerStore.Infastructure.Persistence.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IApplicationDbContext _context;

        private IComputerRepository _computerRepository;

        private IConfigurationRepository _configurationRepository;

        private IModelRepository _modelRepository;

        public UnitOfWork(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IComputerRepository ComputerRepository
        {
            get { return _computerRepository ??= new ComputerRepository(_context); }
        }

        public IConfigurationRepository ConfigurationRepository
        {
            get { return _configurationRepository ??= new ConfigurationRepository(_context); }
        }

        public IModelRepository ModelRepository
        {
            get { return _modelRepository ??= new ModelRepository(_context); }
        }
    }
}
