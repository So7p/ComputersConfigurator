using ComputerStore.Application.Common.Interfaces.Repositories;

namespace ComputerStore.Application.Common.Interfaces.UOW
{
    public interface IUnitOfWork
    {
        IComputerRepository ComputerRepository { get; }
        IConfigurationRepository ConfigurationRepository { get; }
        IModelRepository ModelRepository { get; }
    }
}
