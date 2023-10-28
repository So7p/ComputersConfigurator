using AutoMapper;
using ComputerStore.Application.Common.Exceptions;
using ComputerStore.Application.Common.Interfaces.Services;
using ComputerStore.Application.Common.Interfaces.UOW;
using ComputerStore.Application.DTOs.Drive;
using ComputerStore.Application.Services.Common;

namespace ComputerStore.Application.Services
{
    public class DriveService : BaseService, IDriveService
    {
        public DriveService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<IEnumerable<DriveDto>> GetAllAsync()
        {
            var drives = await unitOfWork.DriveRepository.GetAllAsync();
            var driveDtos = mapper.Map<IEnumerable<DriveDto>>(drives);

            return driveDtos;
        }

        public async Task<DriveDto> GetByIdAsync(int id)
        {
            var drive = await unitOfWork.DriveRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Drive was not found");

            var driveDto = mapper.Map<DriveDto>(drive);

            return driveDto;
        }
    }
}
