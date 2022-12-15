using ComputerStore.Domain.Common;

namespace ComputerStore.Domain.Entities
{
    public class CPUManufacturer : BaseEntity
    {
        public string Name { get; set; } = null!;

        public ICollection<CPU> CPUs { get; set; } = null!;
    }
}
