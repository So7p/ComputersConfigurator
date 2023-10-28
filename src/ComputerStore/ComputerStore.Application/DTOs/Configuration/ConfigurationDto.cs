using ComputerStore.Application.DTOs.Common;

namespace ComputerStore.Application.DTOs.Configuration
{
    public class ConfigurationDto : BaseDto
    {
        public string CPU { get; set; } = null!; 
        public string GPU { get; set; } = null!; 
        public string RAM { get; set; } = null!; 
        public string Drive { get; set; } = null!; 
    }
}
