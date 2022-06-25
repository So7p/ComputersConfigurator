using ComputerStore.Domain.Common;
using ComputerStore.Domain.Enums;

namespace ComputerStore.Domain.Entities
{
    public class GPU : BaseEntity
    {
        public GpuManufacturer Manufacturer { get; set; }
        public string Model { get; set; } = null!;
        public int Vram { get; set; }

        public ICollection<Configuration> Configurations { get; set; } = null!;
    }
}
