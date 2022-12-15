using ComputerStore.Domain.Common;

namespace ComputerStore.Domain.Entities
{
    public class ComputerType : BaseEntity
    {
        public string Type { get; set; } = null!;

        public ICollection<Computer> Computers { get; set; } = null!;
    }
}
