using ComputerStore.Application.Common.Interfaces.Repositories;

namespace ComputerStore.Application.Common.Interfaces.UOW
{
    public interface IUnitOfWork
    {
        IComputerRepository ComputerRepository { get; }
        IConfigurationRepository ConfigurationRepository { get; }
        IModelRepository ModelRepository { get; }
        ICPURepository CPURepository { get; }
        IGPURepository GPURepository { get; }
        IDriveRepository DriveRepository { get; }
        IRAMRepository RAMRepository { get; }
        IComputerBrandRepository ComputerBrandRepository { get; }
        IComputerTypeRepository ComputerTypeRepository { get; }
    }
}