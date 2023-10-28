using ComputerStore.Application.DTOs.RAM;
using AutoMapper;
using ComputerStore.Domain.Entities;

namespace ComputerStore.Application.Common.Mappings
{
    public class RAMProfile : Profile
    {
        public RAMProfile() 
        {
            CreateMap<RAM, RAMDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Value}GB {src.Type} {src.Frequency}MHz"));
        }
    }
}