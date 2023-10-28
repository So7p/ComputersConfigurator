using ComputerStore.Application.DTOs.Configuration;
using AutoMapper;
using ComputerStore.Domain.Entities;

namespace ComputerStore.Application.Common.Mappings
{
    public class ConfigurationProfile : Profile
    {
        public ConfigurationProfile()
        {
            CreateMap<Configuration, ConfigurationDto>()
                .ForMember(dest => dest.CPU, opt => opt.MapFrom(src => $"{src.CPU.CPUManufacturer.Name} {src.CPU.Model} " +
                $"{src.CPU.Cores} cores"))
                .ForMember(dest => dest.GPU, opt => opt.MapFrom(src => $"{src.GPU.GPUManufacturer.Name} {src.GPU.Model} " +
                $"{src.GPU.Vram}GB"))
                .ForMember(dest => dest.RAM, opt => opt.MapFrom(src => $"{src.RAM.Value}GB {src.RAM.Type} " +
                $"{src.RAM.Frequency} MHz"))
                .ForMember(dest => dest.Drive, opt => opt.MapFrom(src => $"{src.Drive.DriveType.Type} {src.Drive.MemoryValue}GB"));

            CreateMap<ConfigurationForCreateDto, Configuration>();
            CreateMap<ConfigurationForUpdateDto, Configuration>();
            
        }
    }
}