using ComputerStore.Application.DTOs.Drive;

namespace ComputerStore.Application.Common.Interfaces.Services
{
    public interface IDriveService
    {
        Task<IEnumerable<DriveDto>> GetAllAsync();
        Task<DriveDto> GetByIdAsync(int id);
    }
}