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
        private ICPURepository _cpuRepository;
        private IGPURepository _gpuRepository;
        private IDriveRepository _driveRepository;
        private IRAMRepository _ramRepository;
        private IComputerBrandRepository _computerBrandRepository;
        private IComputerTypeRepository _computerTypeRepository;

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

        public ICPURepository CPURepository 
        { 
            get { return _cpuRepository ??= new CPURepository(_context); }
        }

        public IGPURepository GPURepository
        {
            get { return _gpuRepository ??= new GPURepository(_context); }
        }

        public IDriveRepository DriveRepository
        {
            get { return _driveRepository ??= new DriveRepository(_context); }
        }

        public IRAMRepository RAMRepository
        {
            get { return _ramRepository ??= new RAMRepository(_context); }
        }

        public IComputerBrandRepository ComputerBrandRepository
        {
            get { return _computerBrandRepository ??= new ComputerBrandRepository(_context); }
        }

        public IComputerTypeRepository ComputerTypeRepository
        {
            get { return _computerTypeRepository ??= new ComputerTypeRepository(_context); }
        }
    }
}