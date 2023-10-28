using AutoMapper;
using ComputerStore.Application.Common.Exceptions;
using ComputerStore.Application.Common.Interfaces.Services;
using ComputerStore.Application.Common.Interfaces.UOW;
using ComputerStore.Application.DTOs.RAM;
using ComputerStore.Application.Services.Common;

namespace ComputerStore.Application.Services
{
    public class RAMService : BaseService, IRAMService
    {
        public RAMService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<IEnumerable<RAMDto>> GetAllAsync()
        {
            var rams = await unitOfWork.RAMRepository.GetAllAsync();
            var ramDtos = mapper.Map<IEnumerable<RAMDto>>(rams);

            return ramDtos;
        }

        public async Task<RAMDto> GetByIdAsync(int id)
        {
            var ram = await unitOfWork.RAMRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("RAM was not found");

            var ramDto = mapper.Map<RAMDto>(ram);

            return ramDto;
        }
    }
}