using ComputerStore.Application.DTOs.GPU;

namespace ComputerStore.Application.Common.Interfaces.Services
{
    public interface IGPUService 
    {
        Task<IEnumerable<GPUDto>> GetAllAsync();
        Task<GPUDto> GetByIdAsync(int id);
    }
}