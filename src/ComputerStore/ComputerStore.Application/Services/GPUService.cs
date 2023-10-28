using AutoMapper;
using ComputerStore.Application.Common.Exceptions;
using ComputerStore.Application.Common.Interfaces.Services;
using ComputerStore.Application.Common.Interfaces.UOW;
using ComputerStore.Application.DTOs.GPU;
using ComputerStore.Application.Services.Common;

namespace ComputerStore.Application.Services
{
    public class GPUService : BaseService, IGPUService
    {
        public GPUService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<IEnumerable<GPUDto>> GetAllAsync()
        {
            var gpus = await unitOfWork.GPURepository.GetAllAsync();
            var gpuDtos = mapper.Map<IEnumerable<GPUDto>>(gpus);

            return gpuDtos;
        }

        public async Task<GPUDto> GetByIdAsync(int id)
        {
            var gpu = await unitOfWork.GPURepository.GetByIdAsync(id)
                ?? throw new NotFoundException("GPU was not found");

            var gpuDto = mapper.Map<GPUDto>(gpu);

            return gpuDto;
        }
    }
}