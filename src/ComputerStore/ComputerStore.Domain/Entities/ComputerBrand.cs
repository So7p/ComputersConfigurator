using ComputerStore.Domain.Common;

namespace ComputerStore.Domain.Entities
{
    public class ComputerBrand : BaseEntity
    {
        public string Name { get; set; } = null!;

        public ICollection<Model> Models { get; set; } = null!;
    }
}
