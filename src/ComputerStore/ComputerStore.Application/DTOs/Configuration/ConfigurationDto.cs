using ComputerStore.Application.DTOs.Common;

namespace ComputerStore.Application.DTOs.Configuration
{
    public class ConfigurationDto : BaseDto
    {
        public string CPU { get; set; } = null!; // Mapping Manufacturer and Model to presentation table on view (CPU)
        public string GPU { get; set; } = null!; // Mapping Manufacturer and Model to presentation table on view (GPU)
        public string RAM { get; set; } = null!; // Mapping Value, Type and Frequenncy to presentation table on view (RAM)
        public string Drive { get; set; } = null!; // Mapping DriveType and MemoryValue to presentation table on view (Drive)
    }
}
