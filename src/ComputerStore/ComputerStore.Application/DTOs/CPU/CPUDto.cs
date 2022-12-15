using ComputerStore.Application.DTOs.Common;

namespace ComputerStore.Application.DTOs.CPU
{
    public class CPUDto : BaseDto
    {
        public string Model { get; set; } = null!;
        public int Cores { get; set; }
        public string CPUManufacturerName { get; set; } = null!; // Mapping CPUManufacturerName to table on view (Manufacturer)
    }
}
