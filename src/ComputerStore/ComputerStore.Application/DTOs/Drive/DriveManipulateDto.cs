namespace ComputerStore.Application.DTOs.Drive
{
    public abstract class DriveManipulateDto
    {
        public int MemoryValue { get; set; }
        public string Type { get; set; } = null!; // Mapping DriveType
    }
}
