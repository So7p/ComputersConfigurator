using ComputerStore.Domain.Common;

namespace ComputerStore.Domain.Entities
{
    public class CPU : BaseEntity
    {
        public string Model { get; set; } = null!;
        public int Cores { get; set; }

        public CPUManufacturer CPUManufacturer { get; set; } = null!;
        public int CPUManufacturerId { get; set; }

        public ICollection<Configuration> Configurations { get; set; } = null!;
    }
}
