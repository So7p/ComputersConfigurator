using AutoMapper;
using ComputerStore.Application.Common.Exceptions;
using ComputerStore.Application.Common.Interfaces.Services;
using ComputerStore.Application.Common.Interfaces.UOW;
using ComputerStore.Application.DTOs.ComputerBrand;
using ComputerStore.Application.Services.Common;

namespace ComputerStore.Application.Services
{
    public class ComputerBrandService : BaseService, IComputerBrandService
    {
        public ComputerBrandService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<IEnumerable<ComputerBrandDto>> GetAllAsync()
        {
            var computerBrands = await unitOfWork.ComputerBrandRepository.GetAllAsync();
            var computerBrandDtos = mapper.Map<IEnumerable<ComputerBrandDto>>(computerBrands);

            return computerBrandDtos;
        }

        public async Task<ComputerBrandDto> GetByIdAsync(int id)
        {
            var computerBrand = await unitOfWork.ComputerBrandRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Computer Brand was not found");

            var computerBrandDto = mapper.Map<ComputerBrandDto>(computerBrand);

            return computerBrandDto;
        }
    }
}