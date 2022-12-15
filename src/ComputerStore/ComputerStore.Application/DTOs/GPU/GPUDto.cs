using ComputerStore.Application.DTOs.Common;
using ComputerStore.Domain.Entities;

namespace ComputerStore.Application.DTOs.GPU
{
    public class GPUDto : BaseDto
    {
        public string Model { get; set; } = null!;
        public int Vram { get; set; }
        public string GPUManufacturerName { get; set; } = null!; // Mapping GPUManufacturerName
    }
}
