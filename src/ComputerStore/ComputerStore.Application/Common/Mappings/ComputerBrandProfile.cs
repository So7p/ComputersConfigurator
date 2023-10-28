using ComputerStore.Application.DTOs.ComputerBrand;
using AutoMapper;
using ComputerStore.Domain.Entities;

namespace ComputerStore.Application.Common.Mappings
{
    public class ComputerBrandProfile : Profile
    {
        public ComputerBrandProfile()
        {
            CreateMap<ComputerBrand, ComputerBrandDto>();
        }
    }
}