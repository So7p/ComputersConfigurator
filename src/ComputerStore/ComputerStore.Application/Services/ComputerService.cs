﻿using AutoMapper;
using ComputerStore.Application.Common.Exceptions;
using ComputerStore.Application.Common.Interfaces.Services;
using ComputerStore.Application.Common.Interfaces.UOW;
using ComputerStore.Application.DTOs.Computer;
using ComputerStore.Application.Services.Common;
using ComputerStore.Domain.Entities;
using System.Text.Json;

namespace ComputerStore.Application.Services
{
    public class ComputerService : BaseService, IComputerService
    {
        public ComputerService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task <IEnumerable<ComputerDto>> GetAllAsync()
        {
            var computers = await unitOfWork.ComputerRepository.GetAllAsync();
            var computersDtos = mapper.Map<IEnumerable<ComputerDto>>(computers);

            string fileName = "ComputersRepost.json";
            using FileStream createStream = File.Create(fileName);
            string jsonString = JsonSerializer.Serialize(JsonSerializer.Serialize(computersDtos));
            File.WriteAllText(fileName, jsonString);

            return computersDtos;
        }

        public async Task<ComputerDto> GetByIdAsync(int id)
        {
            var computer = await unitOfWork.ComputerRepository.GetByIdAsync(id);
            var computerDto = mapper.Map<ComputerDto>(computer);

            return computerDto;
        }

        public async Task CreateAsync(ComputerForCreateDto computerForCreateDto)
        {
            if (computerForCreateDto == null)
                throw new ArgumentNullException(nameof(computerForCreateDto));

            var computer = mapper.Map<Computer>(computerForCreateDto);

            await unitOfWork.ComputerRepository.CreateAsync(computer);
        }

        public async Task UpdateAsync(ComputerForUpdateDto computerForUpdateDto)
        {
            if(computerForUpdateDto == null)
                throw new ArgumentNullException(nameof(computerForUpdateDto));

            var computer = mapper.Map<Computer>(computerForUpdateDto);

            await unitOfWork.ComputerRepository.UpdateAsync(computer);
        }

        public async Task DeleteAsync(int id)
        {
            var checkComputer = await unitOfWork.ComputerRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Id was not found");

            await unitOfWork.ComputerRepository.DeleteAsync(id);
        }

    }
}
