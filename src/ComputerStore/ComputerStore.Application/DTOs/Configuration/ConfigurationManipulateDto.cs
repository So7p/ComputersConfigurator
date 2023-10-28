namespace ComputerStore.Application.DTOs.Configuration
{
    public abstract class ConfigurationManipulateDto
    {
        /*public string CPU { get; set; } = null!; 
        public string GPU { get; set; } = null!; 
        public string RAM { get; set; } = null!; 
        public string Drive { get; set; } = null!;*/
        public int CPUId { get; set; }
        public int GPUId { get; set; }
        public int RAMId { get; set; }
        public int DriveId { get; set; }
    }
}
