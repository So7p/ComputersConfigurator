using ComputerStore.Application.DTOs.Model;
using AutoMapper;
using ComputerStore.Domain.Entities;

namespace ComputerStore.Application.Common.Mappings
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            CreateMap<Model, ModelDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Name}"))
                .ForMember(dest => dest.ConfigurationId, opt => opt.MapFrom(src => $"{src.Configuration.Id}"))
                .ForMember(dest => dest.ComputerBrandName, opt => opt.MapFrom(src => $"{src.ComputerBrand.Name}"));

            CreateMap<ModelForCreateDto, Model>();
            CreateMap<ModelForUpdateDto, Model>();

        }
    }
}
