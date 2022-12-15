using ComputerStore.Domain.Common;

namespace ComputerStore.Domain.Entities
{
    public class GPU : BaseEntity
    {
        public string Model { get; set; } = null!;
        public int Vram { get; set; }

        public GPUManufacturer GPUManufacturer { get; set; } = null!;
        public int GPUManufacturerId { get; set; }

        public ICollection<Configuration> Configurations { get; set; } = null!;
    }
}
