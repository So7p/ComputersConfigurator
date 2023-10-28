using ComputerStore.Application.DTOs.Drive;
using AutoMapper;
using ComputerStore.Domain.Entities;

namespace ComputerStore.Application.Common.Mappings
{
    public class DriveProfile : Profile
    {
        public DriveProfile() 
        {
            CreateMap<Drive, DriveDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.DriveType.Type} {src.MemoryValue}GB"));
        }
    }
}