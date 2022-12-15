using ComputerStore.Application.DTOs.Model;

namespace ComputerStore.Application.Common.Interfaces.Services
{
    public interface IModelService
    {
        Task<IEnumerable<ModelDto>> GetAllAsync();
        Task<ModelDto> GetByIdAsync(int id);
        Task CreateAsync(ModelForCreateDto computerForCreateDto);
        Task UpdateAsync(ModelForUpdateDto computerForUpdateDto);
        Task DeleteAsync(int id);
    }
}
