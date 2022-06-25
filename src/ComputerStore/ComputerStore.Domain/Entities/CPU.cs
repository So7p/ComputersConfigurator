using ComputerStore.Domain.Common;
using ComputerStore.Domain.Enums;

namespace ComputerStore.Domain.Entities
{
    public class CPU : BaseEntity
    {
        public CpuManufacturer Manufacturer { get; set; } 
        public string Model { get; set; } = null!;

        public ICollection<Configuration> Configurations { get; set; } = null!;
    }
}
