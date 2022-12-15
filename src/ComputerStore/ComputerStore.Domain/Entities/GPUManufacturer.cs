using ComputerStore.Domain.Common;

namespace ComputerStore.Domain.Entities
{
    public class GPUManufacturer : BaseEntity
    {
        public string Name { get; set; } = null!;

        public ICollection<GPU> GPUs { get; set; } = null!;
    }
}
