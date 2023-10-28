using ComputerStore.Application.DTOs.RAM;

namespace ComputerStore.Application.Common.Interfaces.Services
{
    public interface IRAMService
    {
        Task<IEnumerable<RAMDto>> GetAllAsync();
        Task<RAMDto> GetByIdAsync(int id);
    }
}