using ComputerStore.Application.DTOs.Computer;
using AutoMapper;
using ComputerStore.Domain.Entities;

namespace ComputerStore.Application.Common.Mappings
{
    public class ComputerProfile : Profile
    {
        public ComputerProfile()
        {
            CreateMap<Computer, ComputerDto>()
                .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => $"{src.Model.Name}"))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => $"{src.ComputerType.Type}"));

            CreateMap<ComputerForCreateDto, Computer>();
            CreateMap<ComputerForUpdateDto, Computer>();
        }
    }
}
