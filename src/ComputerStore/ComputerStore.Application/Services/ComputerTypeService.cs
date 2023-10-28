using AutoMapper;
using ComputerStore.Application.Common.Exceptions;
using ComputerStore.Application.Common.Interfaces.Services;
using ComputerStore.Application.Common.Interfaces.UOW;
using ComputerStore.Application.DTOs.ComputerType;
using ComputerStore.Application.Services.Common;

namespace ComputerStore.Application.Services
{
    public class ComputerTypeService : BaseService, IComputerTypeService
    {
        public ComputerTypeService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<IEnumerable<ComputerTypeDto>> GetAllAsync()
        {
            var computerTypes = await unitOfWork.ComputerTypeRepository.GetAllAsync();
            var computerTypeDtos = mapper.Map<IEnumerable<ComputerTypeDto>>(computerTypes);

            return computerTypeDtos;
        }

        public async Task<ComputerTypeDto> GetByIdAsync(int id)
        {
            var computerType = await unitOfWork.ComputerTypeRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Computer Type was not found");

            var computerTypeDto = mapper.Map<ComputerTypeDto>(computerType);

            return computerTypeDto;
        }
    }
}