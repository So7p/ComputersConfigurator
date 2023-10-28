using AutoMapper;
using ComputerStore.Application.Common.Exceptions;
using ComputerStore.Application.Common.Interfaces.Services;
using ComputerStore.Application.Common.Interfaces.UOW;
using ComputerStore.Application.DTOs.CPU;
using ComputerStore.Application.Services.Common;

namespace ComputerStore.Application.Services
{
    public class CPUService : BaseService, ICPUService
    {
        public CPUService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<IEnumerable<CPUDto>> GetAllAsync()
        {
            var cpus = await unitOfWork.CPURepository.GetAllAsync();
            var cpuDtos = mapper.Map<IEnumerable<CPUDto>>(cpus);

            return cpuDtos;
        }

        public async Task<CPUDto> GetByIdAsync(int id)
        {
            var cpu = await unitOfWork.CPURepository.GetByIdAsync(id)
                ?? throw new NotFoundException("CPU was not found");

            var cpuDto = mapper.Map<CPUDto>(cpu);

            return cpuDto;
        }
    }
}