namespace ComputerStore.Application.DTOs.GPU
{
    public abstract class GPUManipulateDto
    {
        public string Model { get; set; } = null!;
        public int Vram { get; set; }
        public string GPUManufacturerName { get; set; } = null!; // Mapping GPUManufacturerName
    }
}
