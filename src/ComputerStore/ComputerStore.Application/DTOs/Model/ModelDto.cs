using ComputerStore.Application.DTOs.Common;

namespace ComputerStore.Application.DTOs.Model
{
    public class ModelDto : BaseDto
    {
        public string Name { get; set; } = null!;
        public int ConfigurationId { get; set; } 
        public string ComputerBrandName { get; set; } = null!; 
    }
}
