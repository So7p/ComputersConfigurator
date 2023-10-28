using ComputerStore.Application.DTOs.GPU;
using AutoMapper;
using ComputerStore.Domain.Entities;

namespace ComputerStore.Application.Common.Mappings
{
    public class GPUProfile : Profile
    {
        public GPUProfile()
        {
            CreateMap<GPU, GPUDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.GPUManufacturer.Name} {src.Model} {src.Vram}GB"));
        }
    }
}