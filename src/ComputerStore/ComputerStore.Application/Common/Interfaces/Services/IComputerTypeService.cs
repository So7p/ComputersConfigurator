using ComputerStore.Application.DTOs.ComputerType;

namespace ComputerStore.Application.Common.Interfaces.Services
{
    public interface IComputerTypeService
    {
        Task<IEnumerable<ComputerTypeDto>> GetAllAsync();
        Task<ComputerTypeDto> GetByIdAsync(int id);
    }
}