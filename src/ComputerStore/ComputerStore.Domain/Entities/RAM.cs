using ComputerStore.Domain.Common;

namespace ComputerStore.Domain.Entities
{
    public class RAM : BaseEntity
    {
        public int Value { get; set; }

        public ICollection<Configuration> Configurations { get; set; } = null!;
    }
}
