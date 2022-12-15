using ComputerStore.Application.DTOs.Common;

namespace ComputerStore.Application.DTOs.Model
{
    public class ModelDto : BaseDto
    {
        public string Name { get; set; } = null!;
        public int ConfigurationId { get; set; } // Mapping Configurations.Id from Configurations
        public string ComputerBrandName { get; set; } = null!; // Mapping ComputerBrands.Name from ComputerBrands
    }
}
