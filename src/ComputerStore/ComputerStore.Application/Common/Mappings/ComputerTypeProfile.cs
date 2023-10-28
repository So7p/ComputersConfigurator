using ComputerStore.Application.DTOs.ComputerType;
using AutoMapper;
using ComputerStore.Domain.Entities;

namespace ComputerStore.Application.Common.Mappings
{
    public class ComputerTypeProfile : Profile
    {
        public ComputerTypeProfile() 
        {
            CreateMap<ComputerType, ComputerTypeDto>();
        }
    }
}