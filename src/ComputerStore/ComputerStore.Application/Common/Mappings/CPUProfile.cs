using ComputerStore.Application.DTOs.CPU;
using AutoMapper;
using ComputerStore.Domain.Entities;

namespace ComputerStore.Application.Common.Mappings
{
    public class CPUProfile : Profile
    {
        public CPUProfile() 
        {
            CreateMap<CPU, CPUDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.CPUManufacturer.Name} {src.Model} {src.Cores} cores"));
        }
    }
}