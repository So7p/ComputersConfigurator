using ComputerStore.Application.DTOs.CPU;

namespace ComputerStore.Application.Common.Interfaces.Services
{
    public interface ICPUService
    {
        Task<IEnumerable<CPUDto>> GetAllAsync();
        Task<CPUDto> GetByIdAsync(int id);
    }
}