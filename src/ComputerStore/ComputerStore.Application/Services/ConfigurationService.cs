using AutoMapper;
using ComputerStore.Application.Common.Exceptions;
using ComputerStore.Application.Common.Interfaces.Services;
using ComputerStore.Application.Common.Interfaces.UOW;
using ComputerStore.Application.DTOs.Configuration;
using ComputerStore.Application.Services.Common;
using ComputerStore.Domain.Entities;

namespace ComputerStore.Application.Services
{
    public class ConfigurationService : BaseService, IConfigurationService
    {
        public ConfigurationService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {

        }

        public async Task<IEnumerable<ConfigurationDto>> GetAllAsync()
        {
            var configurations = await unitOfWork.ConfigurationRepository.GetAllAsync();
            var configurationsDtos = mapper.Map<IEnumerable<ConfigurationDto>>(configurations);

            return configurationsDtos;
        }

        public async Task<ConfigurationDto> GetByIdAsync(int id)
        {
            var configuration = await unitOfWork.ConfigurationRepository.GetByIdAsync(id);
            var configurationDto = mapper.Map<ConfigurationDto>(configuration);

            return configurationDto;
        }

        public async Task CreateAsync(ConfigurationForCreateDto configurationForCreateDto)
        {
            if (configurationForCreateDto == null)
                throw new ArgumentNullException(nameof(configurationForCreateDto));

            var configuration = mapper.Map<Configuration>(configurationForCreateDto);

            await unitOfWork.ConfigurationRepository.CreateAsync(configuration);
        }

        public async Task UpdateAsync(ConfigurationForUpdateDto configurationForUpdateDto)
        {
            if (configurationForUpdateDto == null)
                throw new ArgumentNullException(nameof(configurationForUpdateDto));

            var configuration = mapper.Map<Configuration>(configurationForUpdateDto);

            await unitOfWork.ConfigurationRepository.UpdateAsync(configuration);
        }

        public async Task DeleteAsync(int id)
        {
            var checkConfiguration = await unitOfWork.ConfigurationRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Id was not found");

            await unitOfWork.ConfigurationRepository.DeleteAsync(id);
        }
    }
}
