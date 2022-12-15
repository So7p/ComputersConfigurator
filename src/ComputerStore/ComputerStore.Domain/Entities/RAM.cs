using ComputerStore.Domain.Common;

namespace ComputerStore.Domain.Entities
{
    public class RAM : BaseEntity
    {
        public int Value { get; set; }
        public string Type { get; set; } = null!;
        public int Frequency { get; set; }

        public ICollection<Configuration> Configurations { get; set; } = null!;
    }
}
