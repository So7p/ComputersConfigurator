using ComputerStore.Application.DTOs.Computer;

namespace ComputerStore.Application.Common.Interfaces.Services
{
    public interface IComputerService
    {
        Task<IEnumerable<ComputerDto>> GetAllAsync();
        Task<ComputerDto> GetByIdAsync(int id);
        Task CreateAsync(ComputerForCreateDto computerForCreateDto);
        Task UpdateAsync(ComputerForUpdateDto computerForUpdateDto);
        Task DeleteAsync(int id);
    }
}
