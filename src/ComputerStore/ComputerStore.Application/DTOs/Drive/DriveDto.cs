using ComputerStore.Application.DTOs.Common;

namespace ComputerStore.Application.DTOs.Drive
{
    public class DriveDto : BaseDto
    {
        public int MemoryValue { get; set; }
        public string Type { get; set; } = null!; // Mapping DriveType
    }
}
