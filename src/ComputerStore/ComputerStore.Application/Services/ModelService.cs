using AutoMapper;
using ComputerStore.Application.Common.Exceptions;
using ComputerStore.Application.Common.Interfaces.Services;
using ComputerStore.Application.Common.Interfaces.UOW;
using ComputerStore.Application.DTOs.Model;
using ComputerStore.Application.Services.Common;
using ComputerStore.Domain.Entities;

namespace ComputerStore.Application.Services
{
    public class ModelService : BaseService, IModelService
    {
        public ModelService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {

        }

        public async Task<IEnumerable<ModelDto>> GetAllAsync()
        {
            var models = await unitOfWork.ModelRepository.GetAllAsync();
            var modelsDtos = mapper.Map<IEnumerable<ModelDto>>(models);

            return modelsDtos;
        }

        public async Task<ModelDto> GetByIdAsync(int id)
        {
            var model = await unitOfWork.ModelRepository.GetByIdAsync(id);
            var modelDto = mapper.Map<ModelDto>(model);

            return modelDto;
        }

        public async Task CreateAsync(ModelForCreateDto modelForCreateDto)
        {
            if (modelForCreateDto == null)
                throw new ArgumentNullException(nameof(modelForCreateDto));

            var model = mapper.Map<Model>(modelForCreateDto);

            await unitOfWork.ModelRepository.CreateAsync(model);
        }

        public async Task UpdateAsync(ModelForUpdateDto modelForUpdateDto)
        {
            if (modelForUpdateDto == null)
                throw new ArgumentNullException(nameof(modelForUpdateDto));

            var model = mapper.Map<Model>(modelForUpdateDto);

            await unitOfWork.ModelRepository.UpdateAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            var checkModel = await unitOfWork.ModelRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Id was not found");

            await unitOfWork.ModelRepository.DeleteAsync(id);
        }
    }
}
