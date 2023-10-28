using ComputerStore.Application.DTOs.ComputerBrand;

namespace ComputerStore.Application.Common.Interfaces.Services
{
    public interface IComputerBrandService
    {
        Task<IEnumerable<ComputerBrandDto>> GetAllAsync();
        Task<ComputerBrandDto> GetByIdAsync(int id);
    }
}