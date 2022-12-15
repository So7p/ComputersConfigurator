using ComputerStore.Application.DTOs.Configuration;

namespace ComputerStore.Application.Common.Interfaces.Services
{
    public interface IConfigurationService
    {
        Task<IEnumerable<ConfigurationDto>> GetAllAsync();
        Task<ConfigurationDto> GetByIdAsync(int id);
        Task CreateAsync(ConfigurationForCreateDto computerForCreateDto);
        Task UpdateAsync(ConfigurationForUpdateDto computerForUpdateDto);
        Task DeleteAsync(int id);
    }
}
